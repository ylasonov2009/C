

Public Class Form1
    Dim key10 As Char
    Dim key20 As Char
    Dim key30 As Char
    Dim key4 As Char
    Dim key5 As Char
    Dim key6 As Char
    Dim key7 As Char
    Dim key8 As Char
    Dim key9 As Char
    Dim counter As Integer
    Dim Speed As Integer = 1000


    Dim outBuffer(1) As Char

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'outBuffer(0) = "~"
        'outBuffer(1) = ChrW(e.KeyData)
        'SerialPort1.Write(outBuffer, 0, 2)
    End Sub


    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        'outBuffer(0) = "`"
        outBuffer(0) = ChrW(e.KeyData)
        SerialPort1.Write(outBuffer, 0, 1)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SerialPort1.Open()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TrackBar2.Enabled = True
        Else
            TrackBar2.Enabled = False

        End If
        Button1.Focus()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)

    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        outBuffer(0) = ChrW(1)
        outBuffer(1) = ChrW(TrackBar2.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Volume.Click

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub TrackBar7_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar7.Scroll
        outBuffer(0) = ChrW(4)
        outBuffer(1) = ChrW(TrackBar7.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
        outBuffer(0) = ChrW(2)
        outBuffer(1) = ChrW(TrackBar4.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub TrackBar6_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar6.Scroll
        outBuffer(0) = ChrW(3)
        outBuffer(1) = ChrW(TrackBar6.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub TrackBar16_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar16.Scroll
        outBuffer(0) = ChrW(5)
        outBuffer(1) = ChrW(TrackBar16.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrackBar17_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub TrackBar14_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar14.Scroll
        outBuffer(0) = ChrW(6)
        outBuffer(1) = ChrW(TrackBar14.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub TrackBar15_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar15.Scroll
        outBuffer(0) = ChrW(9)
        outBuffer(1) = ChrW(TrackBar15.Value / 2)
        SerialPort1.Write(outBuffer, 0, 2)
        Button1.Focus()
    End Sub

    Private Sub TrackBar8_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub Button1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        outBuffer(0) = ChrW(e.KeyData)
        SerialPort1.Write(outBuffer, 0, 2)
        If e.KeyData = Keys.Q Then
            PictureBox1.Image = My.Resources.key1
        End If
        If e.KeyData = Keys.W Then
            PictureBox1.Image = My.Resources.key2
        End If
        If e.KeyData = Keys.E Then
            PictureBox1.Image = My.Resources.key3
        End If
        If e.KeyData = Keys.R Then
            PictureBox1.Image = My.Resources._4
        End If
        If e.KeyData = Keys.T Then
            PictureBox1.Image = My.Resources._5
        End If
        If e.KeyData = Keys.Y Then
            PictureBox1.Image = My.Resources._6
        End If
        If e.KeyData = Keys.U Then
            PictureBox1.Image = My.Resources._7
        End If
        If e.KeyData = Keys.I Then
            PictureBox1.Image = My.Resources._8
        End If
        If e.KeyData = Keys.O Then
            PictureBox1.Image = My.Resources._9
        End If
    End Sub


    Private Sub Button1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyUp
        outBuffer(0) = ChrW(10)
        SerialPort1.Write(outBuffer, 0, 2)
        PictureBox1.Image = My.Resources.blank_keyboard
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
    Private Sub Label24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label24.Click

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 0 Then
            outBuffer(0) = ChrW(100)
            SerialPort1.Write(outBuffer, 0, 2)
        End If
        If NumericUpDown1.Value = 1 Then
            outBuffer(0) = ChrW(101)
            SerialPort1.Write(outBuffer, 0, 2)
        End If
        If NumericUpDown1.Value = 2 Then
            outBuffer(0) = ChrW(102)
            SerialPort1.Write(outBuffer, 0, 2)
        End If
        Button1.Focus()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            TrackBar4.Enabled = True
        Else
            TrackBar4.Enabled = False

        End If
        Button1.Focus()
    End Sub

    Private Sub CheckBox3_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            TrackBar6.Enabled = True
        Else
            TrackBar6.Enabled = False

        End If
        Button1.Focus()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            TrackBar15.Enabled = True
            TrackBar14.Enabled = True
        Else
            TrackBar15.Enabled = False
            TrackBar14.Enabled = False

        End If

        Button1.Focus()
    End Sub
    Private Sub InitializeTimer()
        ' Run this procedure in an appropriate event.
        ' Set to 1 second.
        Timer1.Interval = 1000
        Timer1.Enabled = False


    End Sub
    Private Sub InitializeTimer2()
        ' Run this procedure in an appropriate event.
        ' Set to 1 second.


        Timer2.Enabled = True
        Timer2.Interval = 1000

    End Sub

    Private Sub Timer_Tick(ByVal Sender As Object, ByVal e As EventArgs)


    End Sub
    Private Sub Timer2_Tick(ByVal Sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        counter += 1
        If counter = 1 Then

            outBuffer(0) = key20
            PictureBox8.Image = My.Resources._0800808001355198716_tmpred_bl__2_
            PictureBox2.Image = My.Resources._0800808001355198716_tmpred_bl
        End If
        If counter = 2 Then
            outBuffer(0) = key30
            PictureBox3.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox2.Image = My.Resources._0800808001355198716_tmpred_bl__2_
        End If
        If counter = 3 Then
            outBuffer(0) = key4
            PictureBox4.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox3.Image = My.Resources._0800808001355198716_tmpred_bl__2_
        End If
        If counter = 4 Then
            outBuffer(0) = key5
            PictureBox5.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox4.Image = My.Resources._0800808001355198716_tmpred_bl__2_

        End If
        If counter = 5 Then
            outBuffer(0) = key6
            PictureBox6.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox5.Image = My.Resources._0800808001355198716_tmpred_bl__2_
        End If
        If counter = 6 Then
            outBuffer(0) = key7
            PictureBox7.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox6.Image = My.Resources._0800808001355198716_tmpred_bl__2_
        End If
        If counter = 7 Then
            outBuffer(0) = key8
            PictureBox8.Image = My.Resources._0800808001355198716_tmpred_bl
            PictureBox7.Image = My.Resources._0800808001355198716_tmpred_bl__2_
        End If
        If counter = 8 Then
            outBuffer(0) = key9
            PictureBox8.Image = My.Resources._0800808001355198716_tmpred_bl__2_
            PictureBox9.Image = My.Resources._0800808001355198716_tmpred_bl
            counter = 0
        End If


        SerialPort1.Write(outBuffer, 0, 2)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Timer2.Enabled = True
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value = 0 Then
            key10 = Chr(10)
        End If
        If NumericUpDown2.Value = 1 Then
            key10 = Chr(81)
        End If
        If NumericUpDown2.Value = 2 Then
            key10 = Chr(87)
        End If
        If NumericUpDown2.Value = 3 Then
            key10 = Chr(69)
        End If
        If NumericUpDown2.Value = 4 Then
            key10 = Chr(82)
        End If
        If NumericUpDown2.Value = 5 Then
            key10 = Chr(84)
        End If
        If NumericUpDown2.Value = 6 Then
            key10 = Chr(89)
        End If
        If NumericUpDown2.Value = 7 Then
            key10 = Chr(85)
        End If
        If NumericUpDown2.Value = 8 Then
            key10 = Chr(73)
        End If
        If NumericUpDown2.Value = 9 Then
            key10 = Chr(79)
        End If
        If NumericUpDown2.Value = 10 Then
            key10 = Chr(80)
        End If
        If NumericUpDown2.Value = 11 Then
            key10 = Chr(75)
        End If
        If NumericUpDown2.Value = 12 Then
            key10 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        If NumericUpDown3.Value = 0 Then
            key20 = Chr(10)
        End If
        If NumericUpDown3.Value = 1 Then
            key20 = Chr(81)
        End If
        If NumericUpDown3.Value = 2 Then
            key20 = Chr(87)
        End If
        If NumericUpDown3.Value = 3 Then
            key20 = Chr(69)
        End If
        If NumericUpDown3.Value = 4 Then
            key20 = Chr(82)
        End If
        If NumericUpDown3.Value = 5 Then
            key20 = Chr(84)
        End If
        If NumericUpDown3.Value = 6 Then
            key20 = Chr(89)
        End If
        If NumericUpDown3.Value = 7 Then
            key20 = Chr(85)
        End If
        If NumericUpDown3.Value = 8 Then
            key20 = Chr(73)
        End If
        If NumericUpDown3.Value = 9 Then
            key20 = Chr(79)
        End If
        If NumericUpDown3.Value = 10 Then
            key20 = Chr(80)
        End If
        If NumericUpDown3.Value = 11 Then
            key20 = Chr(75)
        End If
        If NumericUpDown3.Value = 12 Then
            key20 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown4.ValueChanged
        If NumericUpDown4.Value = 0 Then
            key30 = Chr(10)
        End If
        If NumericUpDown4.Value = 1 Then
            key30 = Chr(81)
        End If
        If NumericUpDown4.Value = 2 Then
            key30 = Chr(87)
        End If
        If NumericUpDown4.Value = 3 Then
            key30 = Chr(69)
        End If
        If NumericUpDown4.Value = 4 Then
            key30 = Chr(82)
        End If
        If NumericUpDown4.Value = 5 Then
            key30 = Chr(84)
        End If
        If NumericUpDown4.Value = 6 Then
            key30 = Chr(89)
        End If
        If NumericUpDown4.Value = 7 Then
            key30 = Chr(85)
        End If
        If NumericUpDown4.Value = 8 Then
            key30 = Chr(73)
        End If
        If NumericUpDown4.Value = 9 Then
            key30 = Chr(79)
        End If
        If NumericUpDown4.Value = 10 Then
            key30 = Chr(80)
        End If
        If NumericUpDown4.Value = 11 Then
            key30 = Chr(75)
        End If
        If NumericUpDown4.Value = 12 Then
            key30 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        If NumericUpDown5.Value = 0 Then
            key4 = Chr(10)
        End If
        If NumericUpDown5.Value = 1 Then
            key4 = Chr(81)
        End If
        If NumericUpDown5.Value = 2 Then
            key4 = Chr(87)
        End If
        If NumericUpDown5.Value = 3 Then
            key4 = Chr(69)
        End If
        If NumericUpDown5.Value = 4 Then
            key4 = Chr(82)
        End If
        If NumericUpDown5.Value = 5 Then
            key4 = Chr(84)
        End If
        If NumericUpDown5.Value = 6 Then
            key4 = Chr(89)
        End If
        If NumericUpDown5.Value = 7 Then
            key4 = Chr(85)
        End If
        If NumericUpDown5.Value = 8 Then
            key4 = Chr(73)
        End If
        If NumericUpDown5.Value = 9 Then
            key4 = Chr(79)
        End If
        If NumericUpDown5.Value = 10 Then
            key4 = Chr(80)
        End If
        If NumericUpDown5.Value = 11 Then
            key4 = Chr(75)
        End If
        If NumericUpDown5.Value = 12 Then
            key4 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown6.ValueChanged
        If NumericUpDown6.Value = 0 Then
            key5 = Chr(10)
        End If
        If NumericUpDown6.Value = 1 Then
            key5 = Chr(81)
        End If
        If NumericUpDown6.Value = 2 Then
            key5 = Chr(87)
        End If
        If NumericUpDown6.Value = 3 Then
            key5 = Chr(69)
        End If
        If NumericUpDown6.Value = 4 Then
            key5 = Chr(82)
        End If
        If NumericUpDown6.Value = 5 Then
            key5 = Chr(84)
        End If
        If NumericUpDown6.Value = 6 Then
            key5 = Chr(89)
        End If
        If NumericUpDown6.Value = 7 Then
            key5 = Chr(85)
        End If
        If NumericUpDown6.Value = 8 Then
            key5 = Chr(73)
        End If
        If NumericUpDown6.Value = 9 Then
            key5 = Chr(79)
        End If
        If NumericUpDown6.Value = 10 Then
            key5 = Chr(80)
        End If
        If NumericUpDown6.Value = 11 Then
            key5 = Chr(75)
        End If
        If NumericUpDown6.Value = 12 Then
            key5 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown7_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown7.ValueChanged
        If NumericUpDown7.Value = 0 Then
            key6 = Chr(10)
        End If
        If NumericUpDown7.Value = 1 Then
            key6 = Chr(81)
        End If
        If NumericUpDown7.Value = 2 Then
            key6 = Chr(87)
        End If
        If NumericUpDown7.Value = 3 Then
            key6 = Chr(69)
        End If
        If NumericUpDown7.Value = 4 Then
            key6 = Chr(82)
        End If
        If NumericUpDown7.Value = 5 Then
            key6 = Chr(84)
        End If
        If NumericUpDown7.Value = 6 Then
            key6 = Chr(89)
        End If
        If NumericUpDown7.Value = 7 Then
            key6 = Chr(85)
        End If
        If NumericUpDown7.Value = 8 Then
            key6 = Chr(73)
        End If
        If NumericUpDown7.Value = 9 Then
            key6 = Chr(79)
        End If
        If NumericUpDown7.Value = 10 Then
            key6 = Chr(80)
        End If
        If NumericUpDown7.Value = 11 Then
            key6 = Chr(75)
        End If
        If NumericUpDown7.Value = 12 Then
            key6 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown8_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown8.ValueChanged
        If NumericUpDown8.Value = 0 Then
            key7 = Chr(10)
        End If
        If NumericUpDown8.Value = 1 Then
            key7 = Chr(81)
        End If
        If NumericUpDown8.Value = 2 Then
            key7 = Chr(87)
        End If
        If NumericUpDown8.Value = 3 Then
            key7 = Chr(69)
        End If
        If NumericUpDown8.Value = 4 Then
            key7 = Chr(82)
        End If
        If NumericUpDown8.Value = 5 Then
            key7 = Chr(84)
        End If
        If NumericUpDown8.Value = 6 Then
            key7 = Chr(89)
        End If
        If NumericUpDown8.Value = 7 Then
            key7 = Chr(85)
        End If
        If NumericUpDown8.Value = 8 Then
            key7 = Chr(73)
        End If
        If NumericUpDown8.Value = 9 Then
            key7 = Chr(79)
        End If
        If NumericUpDown8.Value = 10 Then
            key7 = Chr(80)
        End If
        If NumericUpDown8.Value = 11 Then
            key7 = Chr(75)
        End If
        If NumericUpDown8.Value = 12 Then
            key7 = Chr(76)
        End If
    End Sub

    Private Sub NumericUpDown9_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown9.ValueChanged
        If NumericUpDown9.Value = 0 Then
            key8 = Chr(10)
        End If
        If NumericUpDown9.Value = 1 Then
            key8 = Chr(81)
        End If
        If NumericUpDown9.Value = 2 Then
            key8 = Chr(87)
        End If
        If NumericUpDown9.Value = 3 Then
            key8 = Chr(69)
        End If
        If NumericUpDown9.Value = 4 Then
            key8 = Chr(82)
        End If
        If NumericUpDown9.Value = 5 Then
            key8 = Chr(84)
        End If
        If NumericUpDown9.Value = 6 Then
            key8 = Chr(89)
        End If
        If NumericUpDown9.Value = 7 Then
            key8 = Chr(85)
        End If
        If NumericUpDown9.Value = 8 Then
            key8 = Chr(73)
        End If
        If NumericUpDown9.Value = 9 Then
            key8 = Chr(79)
        End If
        If NumericUpDown9.Value = 10 Then
            key8 = Chr(80)
        End If
        If NumericUpDown9.Value = 11 Then
            key8 = Chr(75)
        End If
        If NumericUpDown9.Value = 12 Then
            key8 = Chr(76)
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        outBuffer(0) = ChrW(10)
        SerialPort1.Write(outBuffer, 0, 2)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        NumericUpDown2.Value = (Int((13 * Rnd())))
        NumericUpDown3.Value = (Int((13 * Rnd())))
        NumericUpDown4.Value = (Int((13 * Rnd())))
        NumericUpDown5.Value = (Int((13 * Rnd())))
        NumericUpDown6.Value = (Int((13 * Rnd())))
        NumericUpDown7.Value = (Int((13 * Rnd())))
        NumericUpDown8.Value = (Int((13 * Rnd())))
        NumericUpDown9.Value = (Int((13 * Rnd())))
    End Sub

  
    Private Sub NumericUpDown10_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PictureBox1.Image = My.Resources.blank_keyboard
        Button1.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False

        NumericUpDown2.Visible = False
        NumericUpDown3.Visible = False
        NumericUpDown4.Visible = False
        NumericUpDown5.Visible = False
        NumericUpDown6.Visible = False
        NumericUpDown7.Visible = False
        NumericUpDown8.Visible = False
        NumericUpDown9.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        Timer1.Enabled = False
        Timer2.Enabled = False
        outBuffer(0) = ChrW(10)
        SerialPort1.Write(outBuffer, 0, 2)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        PictureBox1.Image = My.Resources.Untitled
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True

        NumericUpDown2.Visible = True
        NumericUpDown3.Visible = True
        NumericUpDown4.Visible = True
        NumericUpDown5.Visible = True
        NumericUpDown6.Visible = True
        NumericUpDown7.Visible = True
        NumericUpDown8.Visible = True
        NumericUpDown9.Visible = True

        PictureBox2.Visible = True
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
    End Sub
End Class
