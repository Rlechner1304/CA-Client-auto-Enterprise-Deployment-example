<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBoxEnterprise = New System.Windows.Forms.TextBox()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.GBConnection = New System.Windows.Forms.GroupBox()
        Me.LabelInvalid = New System.Windows.Forms.Label()
        Me.LabelHostName = New System.Windows.Forms.Label()
        Me.TextBoxHost = New System.Windows.Forms.TextBox()
        Me.ButtonLogin = New System.Windows.Forms.Button()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.LabelUser = New System.Windows.Forms.Label()
        Me.LabelEnterpriseName = New System.Windows.Forms.Label()
        Me.ListBoxAllComputers = New System.Windows.Forms.ListBox()
        Me.GBoxAllComputer = New System.Windows.Forms.GroupBox()
        Me.ButtonComputer = New System.Windows.Forms.Button()
        Me.GBAllSoftware = New System.Windows.Forms.GroupBox()
        Me.ButtonPackage = New System.Windows.Forms.Button()
        Me.ListBoxAllSoftware = New System.Windows.Forms.ListBox()
        Me.GBProcedure = New System.Windows.Forms.GroupBox()
        Me.ButtonProcedure = New System.Windows.Forms.Button()
        Me.ListBoxProcedure = New System.Windows.Forms.ListBox()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GBParameters = New System.Windows.Forms.GroupBox()
        Me.ButtonParameters = New System.Windows.Forms.Button()
        Me.TextBoxParameters = New System.Windows.Forms.TextBox()
        Me.LabelParameters = New System.Windows.Forms.Label()
        Me.GBDeploy = New System.Windows.Forms.GroupBox()
        Me.ButtonDeploy = New System.Windows.Forms.Button()
        Me.TBdeploy = New System.Windows.Forms.TextBox()
        Me.LabelDeploy = New System.Windows.Forms.Label()
        Me.GBStatus = New System.Windows.Forms.GroupBox()
        Me.ButtonStatus = New System.Windows.Forms.Button()
        Me.TBStatus = New System.Windows.Forms.TextBox()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.GBConnection.SuspendLayout()
        Me.GBoxAllComputer.SuspendLayout()
        Me.GBAllSoftware.SuspendLayout()
        Me.GBProcedure.SuspendLayout()
        Me.GBParameters.SuspendLayout()
        Me.GBDeploy.SuspendLayout()
        Me.GBStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxEnterprise
        '
        Me.TextBoxEnterprise.Location = New System.Drawing.Point(162, 46)
        Me.TextBoxEnterprise.Name = "TextBoxEnterprise"
        Me.TextBoxEnterprise.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxEnterprise.TabIndex = 0
        Me.TextBoxEnterprise.Text = "Lecri01-142dm"
        '
        'TextBoxUser
        '
        Me.TextBoxUser.Location = New System.Drawing.Point(163, 71)
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxUser.TabIndex = 1
        Me.TextBoxUser.Text = "Administrator"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(164, 97)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(220, 20)
        Me.TextBoxPassword.TabIndex = 2
        Me.TextBoxPassword.Text = "CAdemo123"
        '
        'GBConnection
        '
        Me.GBConnection.Controls.Add(Me.LabelInvalid)
        Me.GBConnection.Controls.Add(Me.LabelHostName)
        Me.GBConnection.Controls.Add(Me.TextBoxHost)
        Me.GBConnection.Controls.Add(Me.ButtonLogin)
        Me.GBConnection.Controls.Add(Me.LabelPassword)
        Me.GBConnection.Controls.Add(Me.LabelUser)
        Me.GBConnection.Controls.Add(Me.LabelEnterpriseName)
        Me.GBConnection.Controls.Add(Me.TextBoxPassword)
        Me.GBConnection.Controls.Add(Me.TextBoxEnterprise)
        Me.GBConnection.Controls.Add(Me.TextBoxUser)
        Me.GBConnection.Location = New System.Drawing.Point(21, 0)
        Me.GBConnection.Name = "GBConnection"
        Me.GBConnection.Size = New System.Drawing.Size(428, 166)
        Me.GBConnection.TabIndex = 3
        Me.GBConnection.TabStop = False
        Me.GBConnection.Text = "Connection Information"
        Me.GBConnection.Visible = False
        '
        'LabelInvalid
        '
        Me.LabelInvalid.AutoSize = True
        Me.LabelInvalid.ForeColor = System.Drawing.Color.Red
        Me.LabelInvalid.Location = New System.Drawing.Point(26, 137)
        Me.LabelInvalid.Name = "LabelInvalid"
        Me.LabelInvalid.Size = New System.Drawing.Size(218, 13)
        Me.LabelInvalid.TabIndex = 8
        Me.LabelInvalid.Text = "Unable to connect to Enterprise TRY AGAIN"
        Me.LabelInvalid.Visible = False
        '
        'LabelHostName
        '
        Me.LabelHostName.AutoSize = True
        Me.LabelHostName.Location = New System.Drawing.Point(26, 21)
        Me.LabelHostName.Name = "LabelHostName"
        Me.LabelHostName.Size = New System.Drawing.Size(110, 13)
        Me.LabelHostName.TabIndex = 7
        Me.LabelHostName.Text = "Enterprise Host Name"
        '
        'TextBoxHost
        '
        Me.TextBoxHost.Location = New System.Drawing.Point(162, 16)
        Me.TextBoxHost.Name = "TextBoxHost"
        Me.TextBoxHost.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxHost.TabIndex = 6
        Me.TextBoxHost.Text = "Lecri01-142dm.lvn.Broadcom.net"
        '
        'ButtonLogin
        '
        Me.ButtonLogin.Location = New System.Drawing.Point(312, 123)
        Me.ButtonLogin.Name = "ButtonLogin"
        Me.ButtonLogin.Size = New System.Drawing.Size(75, 41)
        Me.ButtonLogin.TabIndex = 5
        Me.ButtonLogin.Text = "Validate Connection"
        Me.ButtonLogin.UseVisualStyleBackColor = True
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(26, 105)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(53, 13)
        Me.LabelPassword.TabIndex = 4
        Me.LabelPassword.Text = "Password"
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(26, 78)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(60, 13)
        Me.LabelUser.TabIndex = 4
        Me.LabelUser.Text = "User Name"
        '
        'LabelEnterpriseName
        '
        Me.LabelEnterpriseName.AutoSize = True
        Me.LabelEnterpriseName.Location = New System.Drawing.Point(26, 50)
        Me.LabelEnterpriseName.Name = "LabelEnterpriseName"
        Me.LabelEnterpriseName.Size = New System.Drawing.Size(85, 13)
        Me.LabelEnterpriseName.TabIndex = 3
        Me.LabelEnterpriseName.Text = "Enterprise Name"
        '
        'ListBoxAllComputers
        '
        Me.ListBoxAllComputers.FormattingEnabled = True
        Me.ListBoxAllComputers.HorizontalScrollbar = True
        Me.ListBoxAllComputers.Location = New System.Drawing.Point(15, 19)
        Me.ListBoxAllComputers.Name = "ListBoxAllComputers"
        Me.ListBoxAllComputers.Size = New System.Drawing.Size(395, 641)
        Me.ListBoxAllComputers.Sorted = True
        Me.ListBoxAllComputers.TabIndex = 4
        '
        'GBoxAllComputer
        '
        Me.GBoxAllComputer.Controls.Add(Me.ButtonComputer)
        Me.GBoxAllComputer.Controls.Add(Me.ListBoxAllComputers)
        Me.GBoxAllComputer.Location = New System.Drawing.Point(24, 172)
        Me.GBoxAllComputer.Name = "GBoxAllComputer"
        Me.GBoxAllComputer.Size = New System.Drawing.Size(425, 734)
        Me.GBoxAllComputer.TabIndex = 5
        Me.GBoxAllComputer.TabStop = False
        Me.GBoxAllComputer.Text = "All Computers"
        Me.GBoxAllComputer.Visible = False
        '
        'ButtonComputer
        '
        Me.ButtonComputer.Location = New System.Drawing.Point(325, 680)
        Me.ButtonComputer.Name = "ButtonComputer"
        Me.ButtonComputer.Size = New System.Drawing.Size(75, 37)
        Me.ButtonComputer.TabIndex = 6
        Me.ButtonComputer.Text = "Select Computer"
        Me.ButtonComputer.UseVisualStyleBackColor = True
        Me.ButtonComputer.Visible = False
        '
        'GBAllSoftware
        '
        Me.GBAllSoftware.Controls.Add(Me.ButtonPackage)
        Me.GBAllSoftware.Controls.Add(Me.ListBoxAllSoftware)
        Me.GBAllSoftware.Location = New System.Drawing.Point(455, 25)
        Me.GBAllSoftware.Name = "GBAllSoftware"
        Me.GBAllSoftware.Size = New System.Drawing.Size(384, 655)
        Me.GBAllSoftware.TabIndex = 6
        Me.GBAllSoftware.TabStop = False
        Me.GBAllSoftware.Text = "All Software"
        Me.GBAllSoftware.Visible = False
        '
        'ButtonPackage
        '
        Me.ButtonPackage.AutoEllipsis = True
        Me.ButtonPackage.Location = New System.Drawing.Point(297, 596)
        Me.ButtonPackage.Name = "ButtonPackage"
        Me.ButtonPackage.Size = New System.Drawing.Size(75, 43)
        Me.ButtonPackage.TabIndex = 7
        Me.ButtonPackage.Text = "Select Package"
        Me.ButtonPackage.UseVisualStyleBackColor = True
        Me.ButtonPackage.Visible = False
        '
        'ListBoxAllSoftware
        '
        Me.ListBoxAllSoftware.FormattingEnabled = True
        Me.ListBoxAllSoftware.HorizontalScrollbar = True
        Me.ListBoxAllSoftware.Location = New System.Drawing.Point(13, 14)
        Me.ListBoxAllSoftware.Name = "ListBoxAllSoftware"
        Me.ListBoxAllSoftware.Size = New System.Drawing.Size(359, 576)
        Me.ListBoxAllSoftware.Sorted = True
        Me.ListBoxAllSoftware.TabIndex = 5
        '
        'GBProcedure
        '
        Me.GBProcedure.Controls.Add(Me.ButtonProcedure)
        Me.GBProcedure.Controls.Add(Me.ListBoxProcedure)
        Me.GBProcedure.Location = New System.Drawing.Point(468, 689)
        Me.GBProcedure.Name = "GBProcedure"
        Me.GBProcedure.Size = New System.Drawing.Size(259, 200)
        Me.GBProcedure.TabIndex = 7
        Me.GBProcedure.TabStop = False
        Me.GBProcedure.Text = "Procedure List"
        Me.GBProcedure.Visible = False
        '
        'ButtonProcedure
        '
        Me.ButtonProcedure.Location = New System.Drawing.Point(172, 154)
        Me.ButtonProcedure.Name = "ButtonProcedure"
        Me.ButtonProcedure.Size = New System.Drawing.Size(75, 36)
        Me.ButtonProcedure.TabIndex = 8
        Me.ButtonProcedure.Text = "Select Procedure"
        Me.ButtonProcedure.UseVisualStyleBackColor = True
        Me.ButtonProcedure.Visible = False
        '
        'ListBoxProcedure
        '
        Me.ListBoxProcedure.FormattingEnabled = True
        Me.ListBoxProcedure.HorizontalScrollbar = True
        Me.ListBoxProcedure.Location = New System.Drawing.Point(11, 21)
        Me.ListBoxProcedure.Name = "ListBoxProcedure"
        Me.ListBoxProcedure.Size = New System.Drawing.Size(236, 121)
        Me.ListBoxProcedure.Sorted = True
        Me.ListBoxProcedure.TabIndex = 6
        '
        'ButtonReset
        '
        Me.ButtonReset.Location = New System.Drawing.Point(668, 938)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(75, 36)
        Me.ButtonReset.TabIndex = 9
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(764, 941)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 36)
        Me.ButtonExit.TabIndex = 10
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GBParameters
        '
        Me.GBParameters.Controls.Add(Me.ButtonParameters)
        Me.GBParameters.Controls.Add(Me.TextBoxParameters)
        Me.GBParameters.Controls.Add(Me.LabelParameters)
        Me.GBParameters.Location = New System.Drawing.Point(885, 50)
        Me.GBParameters.Name = "GBParameters"
        Me.GBParameters.Size = New System.Drawing.Size(200, 142)
        Me.GBParameters.TabIndex = 11
        Me.GBParameters.TabStop = False
        Me.GBParameters.Text = "Parameters"
        Me.GBParameters.Visible = False
        '
        'ButtonParameters
        '
        Me.ButtonParameters.Location = New System.Drawing.Point(103, 87)
        Me.ButtonParameters.Name = "ButtonParameters"
        Me.ButtonParameters.Size = New System.Drawing.Size(75, 41)
        Me.ButtonParameters.TabIndex = 6
        Me.ButtonParameters.Text = "Submit Parameters"
        Me.ButtonParameters.UseVisualStyleBackColor = True
        Me.ButtonParameters.Visible = False
        '
        'TextBoxParameters
        '
        Me.TextBoxParameters.Location = New System.Drawing.Point(20, 48)
        Me.TextBoxParameters.Name = "TextBoxParameters"
        Me.TextBoxParameters.Size = New System.Drawing.Size(158, 20)
        Me.TextBoxParameters.TabIndex = 1
        '
        'LabelParameters
        '
        Me.LabelParameters.AutoSize = True
        Me.LabelParameters.Location = New System.Drawing.Point(18, 27)
        Me.LabelParameters.Name = "LabelParameters"
        Me.LabelParameters.Size = New System.Drawing.Size(113, 13)
        Me.LabelParameters.TabIndex = 0
        Me.LabelParameters.Text = "Enter User Parameters"
        '
        'GBDeploy
        '
        Me.GBDeploy.Controls.Add(Me.ButtonDeploy)
        Me.GBDeploy.Controls.Add(Me.TBdeploy)
        Me.GBDeploy.Controls.Add(Me.LabelDeploy)
        Me.GBDeploy.Location = New System.Drawing.Point(888, 200)
        Me.GBDeploy.Name = "GBDeploy"
        Me.GBDeploy.Size = New System.Drawing.Size(200, 143)
        Me.GBDeploy.TabIndex = 12
        Me.GBDeploy.TabStop = False
        Me.GBDeploy.Text = "Deploy"
        Me.GBDeploy.Visible = False
        '
        'ButtonDeploy
        '
        Me.ButtonDeploy.Location = New System.Drawing.Point(103, 87)
        Me.ButtonDeploy.Name = "ButtonDeploy"
        Me.ButtonDeploy.Size = New System.Drawing.Size(75, 41)
        Me.ButtonDeploy.TabIndex = 6
        Me.ButtonDeploy.Text = "Deploy Package"
        Me.ButtonDeploy.UseVisualStyleBackColor = True
        Me.ButtonDeploy.Visible = False
        '
        'TBdeploy
        '
        Me.TBdeploy.Location = New System.Drawing.Point(20, 48)
        Me.TBdeploy.Name = "TBdeploy"
        Me.TBdeploy.Size = New System.Drawing.Size(158, 20)
        Me.TBdeploy.TabIndex = 1
        '
        'LabelDeploy
        '
        Me.LabelDeploy.AutoSize = True
        Me.LabelDeploy.Location = New System.Drawing.Point(18, 27)
        Me.LabelDeploy.Name = "LabelDeploy"
        Me.LabelDeploy.Size = New System.Drawing.Size(149, 13)
        Me.LabelDeploy.TabIndex = 0
        Me.LabelDeploy.Text = "Enter SD Job Container Name"
        '
        'GBStatus
        '
        Me.GBStatus.Controls.Add(Me.ButtonStatus)
        Me.GBStatus.Controls.Add(Me.TBStatus)
        Me.GBStatus.Controls.Add(Me.LabelStatus)
        Me.GBStatus.Location = New System.Drawing.Point(888, 359)
        Me.GBStatus.Name = "GBStatus"
        Me.GBStatus.Size = New System.Drawing.Size(200, 143)
        Me.GBStatus.TabIndex = 13
        Me.GBStatus.TabStop = False
        Me.GBStatus.Text = "Status"
        Me.GBStatus.Visible = False
        '
        'ButtonStatus
        '
        Me.ButtonStatus.Location = New System.Drawing.Point(103, 87)
        Me.ButtonStatus.Name = "ButtonStatus"
        Me.ButtonStatus.Size = New System.Drawing.Size(75, 41)
        Me.ButtonStatus.TabIndex = 6
        Me.ButtonStatus.Text = "Get Job Status"
        Me.ButtonStatus.UseVisualStyleBackColor = True
        '
        'TBStatus
        '
        Me.TBStatus.Location = New System.Drawing.Point(20, 48)
        Me.TBStatus.Name = "TBStatus"
        Me.TBStatus.ReadOnly = True
        Me.TBStatus.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TBStatus.Size = New System.Drawing.Size(158, 20)
        Me.TBStatus.TabIndex = 1
        Me.TBStatus.Visible = False
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(18, 27)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(57, 13)
        Me.LabelStatus.TabIndex = 0
        Me.LabelStatus.Text = "Job Status"
        Me.LabelStatus.Visible = False
        '
        'form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1278, 1015)
        Me.Controls.Add(Me.GBStatus)
        Me.Controls.Add(Me.GBDeploy)
        Me.Controls.Add(Me.GBParameters)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.GBProcedure)
        Me.Controls.Add(Me.GBAllSoftware)
        Me.Controls.Add(Me.GBoxAllComputer)
        Me.Controls.Add(Me.GBConnection)
        Me.Name = "form1"
        Me.Text = "Form1"
        Me.GBConnection.ResumeLayout(False)
        Me.GBConnection.PerformLayout()
        Me.GBoxAllComputer.ResumeLayout(False)
        Me.GBAllSoftware.ResumeLayout(False)
        Me.GBProcedure.ResumeLayout(False)
        Me.GBParameters.ResumeLayout(False)
        Me.GBParameters.PerformLayout()
        Me.GBDeploy.ResumeLayout(False)
        Me.GBDeploy.PerformLayout()
        Me.GBStatus.ResumeLayout(False)
        Me.GBStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxEnterprise As TextBox
    Friend WithEvents TextBoxUser As TextBox
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents GBConnection As GroupBox
    Friend WithEvents ButtonLogin As Button
    Friend WithEvents LabelPassword As Label
    Friend WithEvents LabelUser As Label
    Friend WithEvents LabelEnterpriseName As Label
    Friend WithEvents ListBoxAllComputers As ListBox
    Friend WithEvents GBoxAllComputer As GroupBox
    Friend WithEvents ButtonComputer As Button
    Friend WithEvents GBAllSoftware As GroupBox
    Friend WithEvents ButtonPackage As Button
    Friend WithEvents ListBoxAllSoftware As ListBox
    Friend WithEvents GBProcedure As GroupBox
    Friend WithEvents ButtonProcedure As Button
    Friend WithEvents ListBoxProcedure As ListBox
    Friend WithEvents ButtonReset As Button
    Friend WithEvents ButtonExit As Button
    Friend WithEvents LabelHostName As Label
    Friend WithEvents TextBoxHost As TextBox
    Friend WithEvents LabelInvalid As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GBParameters As GroupBox
    Friend WithEvents ButtonParameters As Button
    Friend WithEvents TextBoxParameters As TextBox
    Friend WithEvents LabelParameters As Label
    Friend WithEvents GBDeploy As GroupBox
    Friend WithEvents ButtonDeploy As Button
    Friend WithEvents TBdeploy As TextBox
    Friend WithEvents LabelDeploy As Label
    Friend WithEvents GBStatus As GroupBox
    Friend WithEvents ButtonStatus As Button
    Friend WithEvents TBStatus As TextBox
    Friend WithEvents LabelStatus As Label
End Class
