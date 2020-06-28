<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Detect
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Detect))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NomeDoPC = New System.Windows.Forms.Label()
        Me.EndereçoIPv6 = New System.Windows.Forms.Label()
        Me.ObtemEnderecoIP = New System.Windows.Forms.Label()
        Me.MacAddress = New System.Windows.Forms.Label()
        Me.lbResultado7 = New System.Windows.Forms.ListBox()
        Me.lbResultado5 = New System.Windows.Forms.ListBox()
        Me.lbResultado6 = New System.Windows.Forms.ListBox()
        Me.lbResultado4 = New System.Windows.Forms.ListBox()
        Me.lbResultado3 = New System.Windows.Forms.ListBox()
        Me.lbResultado2 = New System.Windows.Forms.ListBox()
        Me.lbResultado1 = New System.Windows.Forms.ListBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.LabelMAC = New System.Windows.Forms.Label()
        Me.EndFisico = New System.Windows.Forms.Label()
        Me.LabelMAC2 = New System.Windows.Forms.Label()
        Me.LabelMAC3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(41, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Algo irregular foi detectado !"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(90, 402)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(193, 17)
        Me.ListBox1.TabIndex = 3
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(88, 55)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(34, 23)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(18, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(322, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Relatório de detecção enviado com sucesso."
        '
        'Timer1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, -3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(165, 20)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 23)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(165, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(12, 49)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(165, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(12, 75)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(165, 20)
        Me.TextBox4.TabIndex = 9
        Me.TextBox4.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(12, 101)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(165, 20)
        Me.TextBox5.TabIndex = 10
        Me.TextBox5.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(272, 140)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'NomeDoPC
        '
        Me.NomeDoPC.AutoSize = True
        Me.NomeDoPC.Location = New System.Drawing.Point(278, 55)
        Me.NomeDoPC.Name = "NomeDoPC"
        Me.NomeDoPC.Size = New System.Drawing.Size(39, 13)
        Me.NomeDoPC.TabIndex = 12
        Me.NomeDoPC.Text = "Label4"
        Me.NomeDoPC.Visible = False
        '
        'EndereçoIPv6
        '
        Me.EndereçoIPv6.AutoSize = True
        Me.EndereçoIPv6.Location = New System.Drawing.Point(278, 72)
        Me.EndereçoIPv6.Name = "EndereçoIPv6"
        Me.EndereçoIPv6.Size = New System.Drawing.Size(39, 13)
        Me.EndereçoIPv6.TabIndex = 13
        Me.EndereçoIPv6.Text = "Label5"
        Me.EndereçoIPv6.Visible = False
        '
        'ObtemEnderecoIP
        '
        Me.ObtemEnderecoIP.AutoSize = True
        Me.ObtemEnderecoIP.Location = New System.Drawing.Point(278, 91)
        Me.ObtemEnderecoIP.Name = "ObtemEnderecoIP"
        Me.ObtemEnderecoIP.Size = New System.Drawing.Size(39, 13)
        Me.ObtemEnderecoIP.TabIndex = 14
        Me.ObtemEnderecoIP.Text = "Label6"
        Me.ObtemEnderecoIP.Visible = False
        '
        'MacAddress
        '
        Me.MacAddress.AutoSize = True
        Me.MacAddress.Location = New System.Drawing.Point(278, 117)
        Me.MacAddress.Name = "MacAddress"
        Me.MacAddress.Size = New System.Drawing.Size(39, 13)
        Me.MacAddress.TabIndex = 15
        Me.MacAddress.Text = "Label4"
        Me.MacAddress.Visible = False
        '
        'lbResultado7
        '
        Me.lbResultado7.FormattingEnabled = True
        Me.lbResultado7.Location = New System.Drawing.Point(103, 150)
        Me.lbResultado7.Name = "lbResultado7"
        Me.lbResultado7.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado7.TabIndex = 22
        Me.lbResultado7.Visible = False
        '
        'lbResultado5
        '
        Me.lbResultado5.FormattingEnabled = True
        Me.lbResultado5.Location = New System.Drawing.Point(103, 104)
        Me.lbResultado5.Name = "lbResultado5"
        Me.lbResultado5.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado5.TabIndex = 21
        Me.lbResultado5.Visible = False
        '
        'lbResultado6
        '
        Me.lbResultado6.FormattingEnabled = True
        Me.lbResultado6.Location = New System.Drawing.Point(103, 127)
        Me.lbResultado6.Name = "lbResultado6"
        Me.lbResultado6.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado6.TabIndex = 20
        Me.lbResultado6.Visible = False
        '
        'lbResultado4
        '
        Me.lbResultado4.FormattingEnabled = True
        Me.lbResultado4.Location = New System.Drawing.Point(103, 81)
        Me.lbResultado4.Name = "lbResultado4"
        Me.lbResultado4.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado4.TabIndex = 19
        Me.lbResultado4.Visible = False
        '
        'lbResultado3
        '
        Me.lbResultado3.FormattingEnabled = True
        Me.lbResultado3.Location = New System.Drawing.Point(103, 58)
        Me.lbResultado3.Name = "lbResultado3"
        Me.lbResultado3.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado3.TabIndex = 18
        Me.lbResultado3.Visible = False
        '
        'lbResultado2
        '
        Me.lbResultado2.FormattingEnabled = True
        Me.lbResultado2.Location = New System.Drawing.Point(103, 35)
        Me.lbResultado2.Name = "lbResultado2"
        Me.lbResultado2.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado2.TabIndex = 17
        Me.lbResultado2.Visible = False
        '
        'lbResultado1
        '
        Me.lbResultado1.FormattingEnabled = True
        Me.lbResultado1.Location = New System.Drawing.Point(103, 12)
        Me.lbResultado1.Name = "lbResultado1"
        Me.lbResultado1.Size = New System.Drawing.Size(134, 17)
        Me.lbResultado1.TabIndex = 16
        Me.lbResultado1.Visible = False
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(12, 173)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(165, 20)
        Me.TextBox6.TabIndex = 23
        Me.TextBox6.Visible = False
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(11, 199)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(165, 20)
        Me.TextBox7.TabIndex = 24
        Me.TextBox7.Visible = False
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(11, 225)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(165, 20)
        Me.TextBox8.TabIndex = 25
        Me.TextBox8.Visible = False
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(11, 251)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(165, 20)
        Me.TextBox9.TabIndex = 26
        Me.TextBox9.Visible = False
        '
        'LabelMAC
        '
        Me.LabelMAC.AutoSize = True
        Me.LabelMAC.Location = New System.Drawing.Point(278, 180)
        Me.LabelMAC.Name = "LabelMAC"
        Me.LabelMAC.Size = New System.Drawing.Size(56, 13)
        Me.LabelMAC.TabIndex = 27
        Me.LabelMAC.Text = "LabelMAC"
        Me.LabelMAC.Visible = False
        '
        'EndFisico
        '
        Me.EndFisico.AutoSize = True
        Me.EndFisico.Location = New System.Drawing.Point(278, 206)
        Me.EndFisico.Name = "EndFisico"
        Me.EndFisico.Size = New System.Drawing.Size(53, 13)
        Me.EndFisico.TabIndex = 28
        Me.EndFisico.Text = "EndFisico"
        Me.EndFisico.Visible = False
        '
        'LabelMAC2
        '
        Me.LabelMAC2.AutoSize = True
        Me.LabelMAC2.Location = New System.Drawing.Point(277, 232)
        Me.LabelMAC2.Name = "LabelMAC2"
        Me.LabelMAC2.Size = New System.Drawing.Size(62, 13)
        Me.LabelMAC2.TabIndex = 29
        Me.LabelMAC2.Text = "LabelMAC2"
        Me.LabelMAC2.Visible = False
        '
        'LabelMAC3
        '
        Me.LabelMAC3.AutoSize = True
        Me.LabelMAC3.Location = New System.Drawing.Point(278, 254)
        Me.LabelMAC3.Name = "LabelMAC3"
        Me.LabelMAC3.Size = New System.Drawing.Size(62, 13)
        Me.LabelMAC3.TabIndex = 30
        Me.LabelMAC3.Text = "LabelMAC3"
        Me.LabelMAC3.Visible = False
        '
        'Detect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.PB_Shield.My.Resources.Resources.istockphoto_900751194_612x612
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(359, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelMAC3)
        Me.Controls.Add(Me.LabelMAC2)
        Me.Controls.Add(Me.EndFisico)
        Me.Controls.Add(Me.LabelMAC)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.lbResultado7)
        Me.Controls.Add(Me.lbResultado5)
        Me.Controls.Add(Me.lbResultado6)
        Me.Controls.Add(Me.lbResultado4)
        Me.Controls.Add(Me.lbResultado3)
        Me.Controls.Add(Me.lbResultado2)
        Me.Controls.Add(Me.lbResultado1)
        Me.Controls.Add(Me.MacAddress)
        Me.Controls.Add(Me.ObtemEnderecoIP)
        Me.Controls.Add(Me.EndereçoIPv6)
        Me.Controls.Add(Me.NomeDoPC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Detect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents NomeDoPC As Label
    Friend WithEvents EndereçoIPv6 As Label
    Friend WithEvents ObtemEnderecoIP As Label
    Friend WithEvents MacAddress As Label
    Friend WithEvents lbResultado7 As ListBox
    Friend WithEvents lbResultado5 As ListBox
    Friend WithEvents lbResultado6 As ListBox
    Friend WithEvents lbResultado4 As ListBox
    Friend WithEvents lbResultado3 As ListBox
    Friend WithEvents lbResultado2 As ListBox
    Friend WithEvents lbResultado1 As ListBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents LabelMAC As Label
    Friend WithEvents EndFisico As Label
    Friend WithEvents LabelMAC2 As Label
    Friend WithEvents LabelMAC3 As Label
End Class
