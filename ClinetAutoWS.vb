Imports System
Imports System.IO
Imports System.Net
Imports System.Collections
Imports System.String
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices '   DllImport
Imports System.Security.Principal '  WindowsImpersonationContext
Imports System.Security.Permissions
Imports System.Text
Imports System.Diagnostics
Module ClientAutoFunctions
    Public dsms As New ClientAuto.DSMWebServiceAPIService
    Public SessionID As New Object 'web service session ID
    Public TotalComputerCount As Long
    Public ComputerNames(50000, 3) As String
    Public TotalPackageCount As Long
    Public Packageinfo(5000, 3) As String
    Public Credentials(50, 4) As String
    Public CredentialCount As Integer
    Public SelectedComputerName As String
    Public SelectedPackageUUID As String
    Public SelectedCommputerUUID As String
    Public SelectedDomain As String
    Public SelectedProcedureID As String
    Public ProcedureNames(50, 4) As String
    Public TotalProcedureCount As Long
    Public JobType As String
    Public parameters As String
    Public ContainerUUID As String
    Public jobID As String
    Function WSLogin(HostName As String, fqdn As String, user As String, password As String) As String 'called by startup.validate to see if credentials are valid

        ' UpdateLog(1, "common.WSlogin", "Attemping to get sessionID from " + HostName, 0)
        SessionID = ""



        Try
            dsms.Url = "http://" + HostName + "/DSM_Webservice/mod_gsoap.dll"
            Dim PasswordENC As String = Convert.ToBase64String(New System.Text.ASCIIEncoding().GetBytes(password))
            Dim userenc As String = Convert.ToBase64String(New System.Text.ASCIIEncoding().GetBytes("winnt://" + fqdn + "/" + user))

            SessionID = dsms.Login2(userenc, PasswordENC, HostName)
        Catch ex As Exception
            MessageBox.Show("Trying To login To WebServices On Server " + HostName + vbCrLf + "as user " + "winnt://" + fqdn + "/" + user + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)

            Return "NOTOK"

        End Try
        'UpdateLog(1, "common.WSlogin", "Obtained sessionid " + SessionID.ToString, 0)

        Return SessionID.ToString
    End Function

    Function wslogout() As String
        Try
            dsms.Logout(SessionID)
        Catch ex As Exception
            Return "NotOK"
        End Try
        Return "OK"
    End Function
    Function WSGetAllComputerUUID() As String
        Dim SysGroupName As ClientAuto.SystemGroup = ClientAuto.SystemGroup.COALLCOMPUTERS
        Try
            Return dsms.GetSystemGroupUUID(SessionID.ToString, SysGroupName)
        Catch ex As Exception
            MessageBox.Show("Trying to GetSystemGroupUUID in WSGetSystemGroupUUID " + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
            Exit Function
        End Try

    End Function
    Function WSGetAllComputers() As String 'called by startup.validate after wsgetallsoftware completes

        Dim ret As String = WSGetAllComputerUUID()
        Dim Allcomputers() As ClientAuto.ComputerProperties2

        Dim TotalMachineCount As Long = 0
        Dim ss As String = "*"
        Dim ComputerProperty2 As New ClientAuto.ComputerProperty2
        ComputerProperty2 = ClientAuto.ComputerProperty2.COMPUTERHOSTNAME


        Dim ComputerPropertyFilter2(0) As ClientAuto.ComputerPropertyFilter2
        ComputerPropertyFilter2(0) = New ClientAuto.ComputerPropertyFilter2() With {
        .searchString = "*",
        .computerProperty = ClientAuto.ComputerProperty2.COMPUTERHOSTNAME,
        .filterCondition = ClientAuto.ComputerFilterCondition.COMPUTERFILTERWILDCARDEQ}


        Dim handle As Long
        Dim ComputerPropertiesRequired2 As New ClientAuto.ComputerPropertiesRequired2 With {
        .computerHostNameRequired = True,
        .computerUUIDRequired = True,
        .computerDomainLabelRequired = True}
        Dim TotalSpecified As Boolean = True
        Try
            dsms.OpenUnitGroupComputerMembersList2(SessionID.ToString, ret, ComputerPropertyFilter2, True, ComputerProperty2, handle, ComputerPropertiesRequired2, handle, True, TotalMachineCount, TotalSpecified)
        Catch ex As Exception

            MessageBox.Show("Trying to Get Total number of computers" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
            Exit Function
        End Try


        Try
            Allcomputers = dsms.GetUnitGroupComputerMembers2(SessionID.ToString, handle, TotalMachineCount)
            dsms.CloseUnitGroupComputerMembersList(SessionID.ToString, handle)
        Catch ex As Exception

            MessageBox.Show("Trying to Get list of computers" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
            Exit Function
        End Try
        TotalMachineCount = TotalMachineCount - 1
        For j = 0 To TotalMachineCount
            ComputerNames(j, 0) = Allcomputers(j).computerHostName
            ComputerNames(j, 1) = Allcomputers(j).computerUUID
            ComputerNames(j, 2) = Allcomputers(j).computerDomainLabel
        Next
        TotalComputerCount = TotalMachineCount
        'Return "OK"

        Return "OK"

    End Function

    Function WSGetAllSoftware() As String  'called by startup.validate once credentials have been validated 

        Dim StrArray() As String
        Dim WSoutSoftwarePackageList() As ClientAuto.SoftwarePackageProperties2
        Dim ReturnText As String = Nothing
        Dim Failed As Boolean = False
        Dim index As Long = 0
        Dim numrequired As Long
        Dim TotalCount As Long = Nothing
        Dim j As Integer
        Dim packpropreq As New ClientAuto.SoftwarePackagePropertiesRequired With {
        .softwarePackageNameRequired = True,
        .softwarePackageVersionRequired = True,
        .softwarePackageIdRequired = True}

        Dim sortprop As ClientAuto.SoftwarePackageProperty = ClientAuto.SoftwarePackageProperty.SDPKGNAME

        Dim packfilter(0) As ClientAuto.SoftwarePackageFilter
        packfilter(0) = New ClientAuto.SoftwarePackageFilter() With {
        .swPkgProperty = ClientAuto.SoftwarePackageProperty.SDPKGNAME,
        .condition = ClientAuto.FILTERCONDITION.FILTERWILDCARDEQ,
        .searchString = "*"}

        Dim ArrayOfSoftwarePackageFilter As ClientAuto.ArrayOfSoftwarePackageFilter = New ClientAuto.ArrayOfSoftwarePackageFilter With {
        .filter = packfilter,
        .matchAll = True}

        Try

            WSoutSoftwarePackageList = dsms.GetSoftwarePackageList(SessionID.ToString, Nothing, packpropreq, ArrayOfSoftwarePackageFilter, ClientAuto.SoftwarePackageProperty.SDPKGBASEDONPKGNAME, True, index, numrequired, True, TotalCount)
        Catch ex As Exception
            MessageBox.Show("Trying to Get Total number of software packages" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)

            Return "NOTOK"
            Exit Function
        End Try
        If TotalCount = 0 Then


            Return "NoPackages"
            Exit Function
        End If
        numrequired = TotalCount

        Try
            WSoutSoftwarePackageList = dsms.GetSoftwarePackageList(SessionID.ToString, Nothing, packpropreq, ArrayOfSoftwarePackageFilter, ClientAuto.SoftwarePackageProperty.SDPKGBASEDONPKGNAME, True, index, numrequired, True, TotalCount)

        Catch ex As Exception

            MessageBox.Show("Trying to Get Total number of software packages" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)

            Return "NOTOK"
            Exit Function
        End Try



        TotalPackageCount = TotalCount
            For j = 0 To TotalPackageCount - 1
                Packageinfo(j, 0) = WSoutSoftwarePackageList(j).softwarePackageName
                Packageinfo(j, 1) = WSoutSoftwarePackageList(j).softwarePackageVersion
                Packageinfo(j, 2) = Packageinfo(j, 0) + "'" + Packageinfo(j, 1)
                Packageinfo(j, 3) = WSoutSoftwarePackageList(j).softwarePackageId
            Next



        Return "OK"



    End Function

    Function WSGetPackageProceures(type As String) As String 'called once one has selected a pacakge from the softwareselect pull down 
        Dim index As Long
        Dim NumReq As Long
        Dim tpc As Long
        Dim SoftwarePackageProcedureProperties4() As ClientAuto.SoftwarePackageProcedureProperties4

        Dim SoftwarePackageProceduretypeMask As New ClientAuto.SoftwarePackageProcedureTypeMask
        If type = "Install" Then

            SoftwarePackageProceduretypeMask.install = True
        ElseIf type = "Activate" Then

            SoftwarePackageProceduretypeMask.activate = True
        ElseIf type = "Configure" Then

            SoftwarePackageProceduretypeMask.configure = True
        ElseIf type = "Uninstall" Then

            SoftwarePackageProceduretypeMask.uninstall = True
        End If


        Dim SoftwarePackageProceduresRequred2 As New ClientAuto.SoftwarePackageProcedurePropertiesRequired2 With {
        .softwarePackageProcedureIdRequired = True,
        .softwarePackageProcedureNameRequired = True,
        .parametersRequired = True}

        Try
            SoftwarePackageProcedureProperties4 = dsms.GetSoftwarePackageProcedureList(SessionID.ToString, SelectedPackageUUID, SoftwarePackageProceduretypeMask, SoftwarePackageProceduresRequred2, index, NumReq, tpc)

        Catch ex As Exception

            MessageBox.Show("Trying to Get list of " + type + " procedures" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
            Exit Function
        End Try


        NumReq = tpc
        Try
                SoftwarePackageProcedureProperties4 = dsms.GetSoftwarePackageProcedureList(SessionID.ToString, SelectedPackageUUID, SoftwarePackageProceduretypeMask, SoftwarePackageProceduresRequred2, index, NumReq, tpc)

            Catch ex As Exception
                MessageBox.Show("Trying to Get list of install procedures" + vbCrLf + "Process returned the following error" + vbCrLf + ex.Message)
                Return "NOTOK"
                Exit Function
            End Try


        If SoftwarePackageProcedureProperties4.Length > 0 Then

            For j = 0 To SoftwarePackageProcedureProperties4.Length - 1


                ProcedureNames(TotalProcedureCount, 0) = SoftwarePackageProcedureProperties4(j).softwarePackageProcedureName
                ProcedureNames(TotalProcedureCount, 1) = SoftwarePackageProcedureProperties4(j).softwarePackageProcedureId
                ProcedureNames(TotalProcedureCount, 2) = type
                ProcedureNames(TotalProcedureCount, 3) = SoftwarePackageProcedureProperties4(j).parameters
                ProcedureNames(TotalProcedureCount, 4) = ProcedureNames(TotalProcedureCount, 0) + " | " + ProcedureNames(TotalProcedureCount, 2)

                TotalProcedureCount = TotalProcedureCount + 1









            Next

        End If

        Return "OK"


    End Function


    Function WSCreateContainer(ContainerName As String) As String 'called by button create container once a procedure and targets are selected 

        Dim SoftwareJobContainerProperties As ClientAuto.CreateSoftwareJobContainerProperties = New ClientAuto.CreateSoftwareJobContainerProperties With {
       .name = ContainerName,
       .nameSupplied = True}

        Try
            ContainerUUID = dsms.CreateSoftwareJobContainer(SessionID.ToString, SoftwareJobContainerProperties)
        Catch ex As Exception


            MessageBox.Show("process WSCreateContainer Creating software job container generated the following error" + vbCrLf + ex.Message)
            Return "NOTOK"


        End Try

        Return "OK"
    End Function

    Function WSCreateInstallSoftwareJob(SDJobName As String, userparm As String) As String  'called by create container button assuming WScreate container completes
        Dim CreateSoftwareJobOrderProperties As ClientAuto.CreateSoftwareJobOrderProperties = New ClientAuto.CreateSoftwareJobOrderProperties With {
        .jobName = SDJobName,
        .jobNameSupplied = True}

        If userparm <> Nothing Then
            CreateSoftwareJobOrderProperties.userParameters = userparm
            CreateSoftwareJobOrderProperties.userParametersSupplied = True
        End If
        Dim grouparray() As String
        ReDim grouparray(-1)

        Dim machinearray() As String


        ReDim machinearray(0)
        machinearray(0) = SelectedCommputerUUID

        Dim ret As String = WSCheckPackageinstallStatus(True)
        If ret = "PackageInstalled" Then
            MessageBox.Show("Package Already Installed, aborting application")
            Application.Exit()
        End If

        Try
            jobID = dsms.CreateInstallSoftwareJob(SessionID.ToString, SelectedProcedureID, CreateSoftwareJobOrderProperties, ContainerUUID, grouparray, machinearray)
        Catch ex As Exception

            MessageBox.Show("process WSCreateSoftware Creating Install software job generated the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
        End Try

        Return "OK"
    End Function



    Function WSCheckPackageinstallStatus(iSinstall As Boolean) As String
        Dim installed As Boolean = False
        Dim AllComputerUUID As String = WSGetAllComputerUUID()
        Dim unitsoftwarejobpropertiesrequired As ClientAuto.UnitSoftwareJobPropertiesRequired = New ClientAuto.UnitSoftwareJobPropertiesRequired With {
        .softwareJobIdRequired = True,
    .unitHostUUIDRequired = True,
    .softwarePackageProcedureIdRequired = True,
    .unitInstallationSoftwareJobIdRequired = True,
      .softwarePackageIdRequired = True}
        Dim handle As Long
        Dim totalpackagecount As Long
        Dim unitsoftwareproperties() As ClientAuto.UnitSoftwareJobProperties
        Dim installjobid(100) As String
        Dim j As Integer
        Try
            dsms.OpenSoftwarePackageInstallationList(SessionID.ToString, SelectedPackageUUID, AllComputerUUID, unitsoftwarejobpropertiesrequired, handle, True, totalpackagecount, True)
            If totalpackagecount > 0 Then
                unitsoftwareproperties = dsms.GetSoftwarePackageInstallations(SessionID.ToString, handle, totalpackagecount)
            End If
            dsms.CloseSoftwarePackageInstallationList(SessionID.ToString, handle)

        Catch ex As Exception

            MessageBox.Show("CheckPackageInstallation status generated the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
            Exit Function
        End Try
        If totalpackagecount > 0 Then

            For j = 0 To totalpackagecount
                If unitsoftwareproperties(j).unitHostUUID = SelectedCommputerUUID AndAlso unitsoftwareproperties(j).softwarePackageId = SelectedPackageUUID Then
                    If iSinstall = False Then
                        If SelectedProcedureID = unitsoftwareproperties(j).softwarePackageProcedureId Then

                            Return "ProceureInstalled"
                            Exit Function
                        Else
                            Return unitsoftwareproperties(j).unitInstallationSoftwareJobId
                            Exit Function
                        End If


                    Else
                        Return "PackageInstalled"
                        Exit Function
                    End If

                End If
            Next
        End If

    End Function

    Function WSSealAndActivate() As String  'called by create container once wscreatedsoftware job completes 



        Try
            dsms.SealAndActivateSoftwareJobContainer(SessionID.ToString, ContainerUUID)
        Catch ex As Exception

            MessageBox.Show("process SealAndActivateContainer process generated the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
        End Try


        Return "OK"


    End Function

    Function WSGetJobStatus() As String
        Dim SoftwareJobPropertiesRequired As ClientAuto.SoftwareJobPropertiesRequired = New ClientAuto.SoftwareJobPropertiesRequired With {
            .softwareJobStateRequired = True}
        Dim softwarejobproperties As ClientAuto.SoftwareJobProperties

        Try
            softwarejobproperties = dsms.GetSoftwareJob(SessionID.ToString, jobID, SoftwareJobPropertiesRequired)

            Return softwarejobproperties.softwareJobState.ToString
        Catch ex As Exception

            MessageBox.Show("process getsoftwarestatus returned the following error" + vbCrLf + ex.Message)
            Return "NOTOK"
        End Try






    End Function


End Module