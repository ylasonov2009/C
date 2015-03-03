<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TrackBar2 = New System.Windows.Forms.TrackBar
        Me.Volume = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TrackBar4 = New System.Windows.Forms.TrackBar
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TrackBar6 = New System.Windows.Forms.TrackBar
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.TrackBar7 = New System.Windows.Forms.TrackBar
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TrackBar14 = New System.Windows.Forms.TrackBar
        Me.TrackBar15 = New System.Windows.Forms.TrackBar
        Me.Label24 = New System.Windows.Forms.Label
        Me.CheckBox7 = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.TrackBar16 = New System.Windows.Forms.TrackBar
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown7 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown8 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown9 = New System.Windows.Forms.NumericUpDown
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.WriteBufferSize = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(274, 109)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'TrackBar2
        '
        Me.TrackBar2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar2.CausesValidation = False
        Me.TrackBar2.Enabled = False
        Me.TrackBar2.Location = New System.Drawing.Point(281, 172)
        Me.TrackBar2.Maximum = 20
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(107, 45)
        Me.TrackBar2.TabIndex = 7
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Volume
        '
        Me.Volume.AutoSize = True
        Me.Volume.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Volume.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Volume.Location = New System.Drawing.Point(312, 193)
        Me.Volume.Name = "Volume"
        Me.Volume.Size = New System.Drawing.Size(42, 13)
        Me.Volume.TabIndex = 16
        Me.Volume.Text = "Volume"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(289, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Osc 1 - Sine Wave"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(201, 317)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Volume"
        '
        'TrackBar4
        '
        Me.TrackBar4.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar4.CausesValidation = False
        Me.TrackBar4.Enabled = False
        Me.TrackBar4.Location = New System.Drawing.Point(170, 296)
        Me.TrackBar4.Maximum = 20
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(107, 45)
        Me.TrackBar4.TabIndex = 22
        Me.TrackBar4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(164, 233)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label11.Location = New System.Drawing.Point(311, 448)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Volume"
        '
        'TrackBar6
        '
        Me.TrackBar6.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar6.CausesValidation = False
        Me.TrackBar6.Enabled = False
        Me.TrackBar6.Location = New System.Drawing.Point(280, 427)
        Me.TrackBar6.Maximum = 20
        Me.TrackBar6.Name = "TrackBar6"
        Me.TrackBar6.Size = New System.Drawing.Size(107, 45)
        Me.TrackBar6.TabIndex = 30
        Me.TrackBar6.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Location = New System.Drawing.Point(274, 364)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 29
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'TrackBar7
        '
        Me.TrackBar7.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar7.CausesValidation = False
        Me.TrackBar7.Location = New System.Drawing.Point(825, 250)
        Me.TrackBar7.Maximum = 20
        Me.TrackBar7.Minimum = 1
        Me.TrackBar7.Name = "TrackBar7"
        Me.TrackBar7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar7.Size = New System.Drawing.Size(45, 107)
        Me.TrackBar7.TabIndex = 37
        Me.TrackBar7.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar7.Value = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label12.Location = New System.Drawing.Point(813, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Master Volume"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label22.Location = New System.Drawing.Point(617, 334)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 13)
        Me.Label22.TabIndex = 62
        Me.Label22.Text = "Dry/Wet"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label23.Location = New System.Drawing.Point(617, 294)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = "Feedback"
        '
        'TrackBar14
        '
        Me.TrackBar14.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar14.CausesValidation = False
        Me.TrackBar14.Location = New System.Drawing.Point(602, 313)
        Me.TrackBar14.Maximum = 12
        Me.TrackBar14.Name = "TrackBar14"
        Me.TrackBar14.Size = New System.Drawing.Size(135, 45)
        Me.TrackBar14.TabIndex = 60
        Me.TrackBar14.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBar15
        '
        Me.TrackBar15.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar15.CausesValidation = False
        Me.TrackBar15.Location = New System.Drawing.Point(602, 271)
        Me.TrackBar15.Maximum = 12
        Me.TrackBar15.Name = "TrackBar15"
        Me.TrackBar15.Size = New System.Drawing.Size(135, 45)
        Me.TrackBar15.TabIndex = 59
        Me.TrackBar15.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label24.Location = New System.Drawing.Point(617, 251)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 13)
        Me.Label24.TabIndex = 58
        Me.Label24.Text = "Delay"
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox7.Location = New System.Drawing.Point(602, 251)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox7.TabIndex = 57
        Me.CheckBox7.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(469, 491)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(204, 31)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Press here to start playing"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label25.Location = New System.Drawing.Point(647, 164)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 65
        Me.Label25.Text = "Audio In"
        '
        'TrackBar16
        '
        Me.TrackBar16.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.TrackBar16.CausesValidation = False
        Me.TrackBar16.Location = New System.Drawing.Point(602, 143)
        Me.TrackBar16.Maximum = 20
        Me.TrackBar16.Name = "TrackBar16"
        Me.TrackBar16.Size = New System.Drawing.Size(135, 45)
        Me.TrackBar16.TabIndex = 64
        Me.TrackBar16.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar16.Value = 1
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(413, 292)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 66
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label8.Location = New System.Drawing.Point(289, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Osc 3 - Triangular Wave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(179, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Osc 2 - Square Wave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(410, 271)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Octave"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Key2Rs232vb.My.Resources.Resources.blank_keyboard
        Me.PictureBox1.InitialImage = Global.Key2Rs232vb.My.Resources.Resources.blank_keyboard
        Me.PictureBox1.Location = New System.Drawing.Point(237, 538)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(654, 75)
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(448, 449)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 69
        Me.Button2.Text = "Play"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 220
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(407, 548)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown2.TabIndex = 70
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Visible = False
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(448, 548)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown3.TabIndex = 71
        Me.NumericUpDown3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown3.Visible = False
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(489, 548)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown4.TabIndex = 72
        Me.NumericUpDown4.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown4.Visible = False
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(530, 548)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown5.TabIndex = 73
        Me.NumericUpDown5.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown5.Visible = False
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.Location = New System.Drawing.Point(572, 548)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown6.TabIndex = 74
        Me.NumericUpDown6.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown6.Visible = False
        '
        'NumericUpDown7
        '
        Me.NumericUpDown7.Location = New System.Drawing.Point(613, 548)
        Me.NumericUpDown7.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown7.Name = "NumericUpDown7"
        Me.NumericUpDown7.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown7.TabIndex = 75
        Me.NumericUpDown7.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown7.Visible = False
        '
        'NumericUpDown8
        '
        Me.NumericUpDown8.Location = New System.Drawing.Point(654, 548)
        Me.NumericUpDown8.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown8.Name = "NumericUpDown8"
        Me.NumericUpDown8.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown8.TabIndex = 76
        Me.NumericUpDown8.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown8.Visible = False
        '
        'NumericUpDown9
        '
        Me.NumericUpDown9.Location = New System.Drawing.Point(695, 548)
        Me.NumericUpDown9.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown9.Name = "NumericUpDown9"
        Me.NumericUpDown9.Size = New System.Drawing.Size(35, 20)
        Me.NumericUpDown9.TabIndex = 77
        Me.NumericUpDown9.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown9.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(532, 449)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 78
        Me.Button3.Text = "Stop"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(613, 449)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 79
        Me.Button4.Text = "Randomize"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SaddleBrown
        Me.Button5.Location = New System.Drawing.Point(397, 109)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(95, 23)
        Me.Button5.TabIndex = 81
        Me.Button5.Text = "Synthesizer"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.SaddleBrown
        Me.Button6.Location = New System.Drawing.Point(498, 109)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(103, 23)
        Me.Button6.TabIndex = 82
        Me.Button6.Text = "Sequencer"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox2.Location = New System.Drawing.Point(407, 501)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox2.TabIndex = 83
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox3.Location = New System.Drawing.Point(448, 501)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox3.TabIndex = 84
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox4.Location = New System.Drawing.Point(489, 501)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox4.TabIndex = 85
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox5.Location = New System.Drawing.Point(535, 501)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox5.TabIndex = 86
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox6.Location = New System.Drawing.Point(577, 501)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox6.TabIndex = 87
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox7.Location = New System.Drawing.Point(618, 501)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox7.TabIndex = 88
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox8.Location = New System.Drawing.Point(658, 501)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox8.TabIndex = 89
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Image = Global.Key2Rs232vb.My.Resources.Resources._0800808001355198716_tmpred_bl__2_
        Me.PictureBox9.Location = New System.Drawing.Point(695, 501)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox9.TabIndex = 90
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(902, 624)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.NumericUpDown9)
        Me.Controls.Add(Me.NumericUpDown8)
        Me.Controls.Add(Me.NumericUpDown7)
        Me.Controls.Add(Me.NumericUpDown6)
        Me.Controls.Add(Me.NumericUpDown5)
        Me.Controls.Add(Me.NumericUpDown4)
        Me.Controls.Add(Me.NumericUpDown3)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TrackBar16)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TrackBar14)
        Me.Controls.Add(Me.TrackBar15)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.CheckBox7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TrackBar7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TrackBar6)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrackBar4)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Volume)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TopMost = True
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Volume As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrackBar4 As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TrackBar6 As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents TrackBar7 As System.Windows.Forms.TrackBar
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TrackBar14 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar15 As System.Windows.Forms.TrackBar
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TrackBar16 As System.Windows.Forms.TrackBar
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown8 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown9 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
