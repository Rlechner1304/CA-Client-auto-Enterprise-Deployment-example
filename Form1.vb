Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Public Class form1


    Dim inifilename As String


    Public Sub New()
        Dim package() As String
        ' This call is required by the designer.
        InitializeComponent()
        Dim k As Integer
        ' Add any initialization after the InitializeComponent() call.
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog <> DialogResult.Cancel Then
            inifilename = OpenFileDialog1.FileName
            Dim ret As String = GetCredentials(inifilename)
            For k = 0 To CredentialCount
                If Credentials(k, 4) = "YES" Then
                    TextBoxEnterprise.Text = Credentials(k, 0)
                    TextBoxHost.Text = Credentials(k, 1)
                    TextBoxUser.Text = Credentials(k, 2)
                    TextBoxPassword.Text = Credentials(k, 3)
                    Exit For
                End If
            Next
            If TextBoxEnterprise.Text <> Nothing AndAlso TextBoxHost.Text <> Nothing AndAlso TextBoxUser.Text <> Nothing AndAlso TextBoxPassword.Text <> Nothing Then
                ret = WSLogin(TextBoxHost.Text, TextBoxEnterprise.Text, TextBoxUser.Text, TextBoxPassword.Text)
                If ret = "NOTOK" Then
                    MessageBox.Show("Unable To login To the enterprise check credentials and ensure CAF tomcat is running")
                    Application.Exit()
                End If
            Else
                MessageBox.Show("Could not find enterprise login credentials check your credentials.ini file" + vbCrLf + "ensure you have specified enterprise name, FQDN of enterprise server, user, password and Enterprise=YES")
                Application.Exit()
            End If
            GBoxAllComputer.Visible = True

            ret = WSGetAllComputers()
            wslogout()
            If ret = "OK" Then

                For m = 0 To TotalComputerCount - 1
                    ListBoxAllComputers.Items.Add(ComputerNames(m, 0))
                Next


            Else
                Application.Exit()

            End If

        End If
    End Sub
    Function GetCredentials(INIFileName As String) As String



        Dim inisplit(2) As String


        For Each Line As String In File.ReadLines(INIFileName)
            ' Read a line.


            ' See what it is.

            If Line.Contains("[") Then
                ' Section heading.
                Credentials(CredentialCount, 0) = Line.Substring(1, Line.Length - 2)
                CredentialCount = CredentialCount + 1
            ElseIf Line.Contains("=") Then

                inisplit = Line.Split("=")

                If inisplit(0).Trim = "dmhostname" Then
                    Credentials(CredentialCount - 1, 1) = inisplit(1).Trim
                ElseIf inisplit(0).Trim = "user" Then
                    Credentials(CredentialCount - 1, 2) = inisplit(1).Trim
                ElseIf inisplit(0).Trim = "password" Then
                    Credentials(CredentialCount - 1, 3) = inisplit(1).Trim
                ElseIf inisplit(0).Trim.ToUpper = "ENTERPRISE" Then
                    If inisplit(1).Trim.ToUpper = "YES" Then
                        Credentials(CredentialCount - 1, 4) = "YES"

                    End If

                End If
            End If

        Next


        Dim k As Integer
        For k = 0 To CredentialCount - 1
            'MessageBox.Show(Credentials(k, 0) + " " + Credentials(k, 1) + " " + Credentials(k, 2) + " " + Credentials(k, 3))
        Next
        Return "OK"
    End Function

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click

    End Sub

    Private Sub ListBoxAllComputers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAllComputers.SelectedIndexChanged
        ButtonComputer.Visible = True

    End Sub




    Private Sub ButtonComputer_Click(sender As Object, e As EventArgs) Handles ButtonComputer.Click
        Dim ret As String
        SelectedComputerName = ListBoxAllComputers.SelectedItem.ToString
        Dim j As Long

        For j = 0 To TotalComputerCount - 1
            If SelectedComputerName = ComputerNames(j, 0) Then
                SelectedCommputerUUID = ComputerNames(j, 1)
                SelectedDomain = ComputerNames(j, 2)
                Exit For
            End If
        Next
        For j = 0 To CredentialCount
            If SelectedDomain = Credentials(j, 0) Then
                TextBoxEnterprise.Text = Credentials(j, 0)
                TextBoxHost.Text = Credentials(j, 1)
                TextBoxUser.Text = Credentials(j, 2)
                TextBoxPassword.Text = Credentials(j, 3)

                Exit For
            End If
        Next
        If TextBoxEnterprise.Text <> Nothing AndAlso TextBoxHost.Text <> Nothing AndAlso TextBoxUser.Text <> Nothing AndAlso TextBoxPassword.Text <> Nothing Then
            ret = WSLogin(TextBoxHost.Text, TextBoxEnterprise.Text, TextBoxUser.Text, TextBoxPassword.Text)
            If ret = "NOTOK" Then
                MessageBox.Show("Unable To login to the domain " + TextBoxEnterprise.Text + "  check credentials and ensure CAF tomcat is running")
                Application.Exit()
            End If
        Else
            MessageBox.Show("unable to get credentials for the domain " + SelectedDomain + ", check the credential file and retry")
            Application.Exit()
        End If

        GBoxAllComputer.Visible = False
        GBAllSoftware.Visible = True
        ret = WSGetAllSoftware()
        If ret = "OK" Then
            For j = 0 To TotalPackageCount - 1
                ListBoxAllSoftware.Items.Add(Packageinfo(j, 2))
            Next
        Else
            messagebox.Show("unable to get list of software packages from the domain " + SelectedDomain + ", aborting")
            Application.Exit()
        End If


    End Sub

    Private Sub ListBoxAllSoftware_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAllSoftware.SelectedIndexChanged
        ButtonPackage.Visible = True
    End Sub

    Private Sub ButtonPackage_Click(sender As Object, e As EventArgs) Handles ButtonPackage.Click
        Dim m As Integer
        GBAllSoftware.Visible = False
        GBProcedure.Visible = True
        For m = 0 To TotalPackageCount - 1
            If ListBoxAllSoftware.SelectedItem = Packageinfo(m, 2) Then
                SelectedPackageUUID = Packageinfo(m, 3)
                Exit For
            End If

        Next

        Dim ret = WSGetPackageProceures("Install")
        If ret <> "OK" Then
            MessageBox.Show("Could not get list of procedures, aborting")
            Application.Exit()
        End If

        ret = WSGetPackageProceures("Activate")
        If ret <> "OK" Then
            MessageBox.Show("Could not get list of procedures, aborting")
            Application.Exit()
        End If


        ret = WSGetPackageProceures("Configure")
        If ret <> "OK" Then
            MessageBox.Show("Could not get list of procedures, aborting")
            Application.Exit()
        End If

        ret = WSGetPackageProceures("Uninstall")
        If ret <> "OK" Then
            MessageBox.Show("Could not get list of procedures, aborting")
            Application.Exit()
        End If


        For m = 0 To TotalProcedureCount - 1

            ListBoxProcedure.Items.Add(ProcedureNames(m, 4))
        Next

    End Sub

    Private Sub ListBoxProcedure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxProcedure.SelectedIndexChanged
        ButtonProcedure.Visible = True

    End Sub

    Private Sub ButtonProcedure_Click(sender As Object, e As EventArgs) Handles ButtonProcedure.Click

        Dim j As Integer
        GBProcedure.Visible = False
        For j = 0 To TotalProcedureCount - 1

            If ListBoxProcedure.SelectedItem = ProcedureNames(j, 4) Then

                SelectedProcedureID = ProcedureNames(j, 1)

                JobType = ProcedureNames(j, 2)
                If ProcedureNames(j, 3).Length > 0 Then

                    Dim up As String = ProcedureNames(j, 3)
                    If up.Contains("$up") Then

                        GBParameters.Visible = True
                    Else
                        GBDeploy.Visible = True
                        ButtonDeploy.Visible = True
                    End If

                Else
                    GBDeploy.Visible = True
                    ButtonDeploy.Visible = True
                End If
                Exit For
            End If
        Next
    End Sub



    Private Sub ButtonDeploy_Click(sender As Object, e As EventArgs) Handles ButtonDeploy.Click
        GBDeploy.Visible = False
        Dim ret As String = WSCreateContainer(TBdeploy.Text)
        If ret = "NOTOK" Then
            MessageBox.Show("unable to Create Software Container Aborting")
            Application.Exit()

        End If
        If JobType = "Install" Then
            ret = WSCreateInstallSoftwareJob(SelectedComputerName, parameters)
        ElseIf JobType = "Activate" Then
            'not coded
        ElseIf JobType = "Configure" Then
            'not coded
        Else
            'not coded
        End If

        If ret = "OK" Then
            ret = WSSealAndActivate()
        End If
        If ret = "OK" Then
            GBStatus.Visible = True
        End If
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonParameters_Click(sender As Object, e As EventArgs) Handles ButtonParameters.Click
        GBParameters.Visible = False
        GBDeploy.Visible = True
        parameters = TextBoxParameters.Text
    End Sub

    Private Sub TextBoxParameters_TextChanged(sender As Object, e As EventArgs) Handles TextBoxParameters.TextChanged
        If TextBoxParameters.Text <> Nothing Then
            ButtonParameters.Visible = True
        Else
            ButtonParameters.Visible = False
        End If
    End Sub

    Private Sub TBdeploy_TextChanged(sender As Object, e As EventArgs) Handles TBdeploy.TextChanged
        If TBdeploy.Text <> Nothing Then
            ButtonDeploy.Visible = True
        End If
    End Sub

    Private Sub ButtonStatus_Click(sender As Object, e As EventArgs) Handles ButtonStatus.Click
        Dim ret As String = WSGetJobStatus()
        TBStatus.Text = ret
        LabelStatus.Visible = True
        TBStatus.Visible = True

    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        wslogout()
        Application.Exit()
    End Sub
End Class
