'Serial Port Interfacing with VB.net 2010 Express Edition
'Copyright (C) 2010  Richard Myrick T. Arellaga
'
'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.
'
'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.


Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Public Class frmMain
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data
    Dim byteData(65535) As Byte
    'Dim FullbyteData(4096) As Byte
    Dim count As Integer
    Dim ci As Integer
    Dim cj As Integer
    Dim bmpR As New Bitmap(128, 128)
    Dim bmpG As New Bitmap(128, 128)
    Dim bmpB As New Bitmap(128, 128)
    Dim bmpNA As New Bitmap(128, 128)
    Dim bmpWA As New Bitmap(128, 128)
    Dim drawer As System.Drawing.Image

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SerialPort1.Close()

    End Sub



    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer = 0

        For i As Integer = 0 To byteData.Length - 1 Step 4
            byteData(i) = 0

            '  byteData(i) = Math.Abs(cnt)
            '
            '           byteData(i + 1) = Math.Abs(cnt)
            '          byteData(i + 2) = Math.Abs(cnt)
            '         byteData(i + 3) = 255
            'If (i <= 4095) Then
            'rtb8.Text &= byteData(i) & byteData(i + 1) & byteData(i + 2) & byteData(i + 3) & Chr(13)
            ' End If

            '        cnt += 1
            '       If (cnt = 256) Then
            'cnt = -254
            ' End If

        Next

        'When our form loads, auto detect all serial ports in the system and populate the cmbPort Combo box.
        myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
        cmbBaud.Items.Add(115200)
        cmbBaud.Items.Add(9600)     'Populate the cmbBaud Combo box to common baud rates used   
        cmbBaud.Items.Add(19200)
        cmbBaud.Items.Add(38400)
        cmbBaud.Items.Add(57600)

        For i = 0 To UBound(myPort)
            cmbPort.Items.Add(myPort(i))
        Next
        cmbPort.Text = cmbPort.Items.Item(0)    'Set cmbPort text to the first COM port detected
        cmbBaud.Text = cmbBaud.Items.Item(0)    'Set cmbBaud text to the first Baud rate on the list

        btnDisconnect.Enabled = False           'Initially Disconnect Button is Disabled        

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        SerialPort1.PortName = cmbPort.Text         'Set SerialPort1 to the selected COM port at startup
        SerialPort1.BaudRate = cmbBaud.Text         'Set Baud rate to the selected value on 

        'Other Serial Port Property
        SerialPort1.Parity = IO.Ports.Parity.None
        SerialPort1.StopBits = IO.Ports.StopBits.One
        SerialPort1.DataBits = 8            'Open our serial port
        SerialPort1.Open()

        btnConnect.Enabled = False          'Disable Connect button
        btnDisconnect.Enabled = True        'and Enable Disconnect button
        count = 0
        ci = 0
        cj = 0
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        SerialPort1.Close()             'Close our Serial Port

        btnConnect.Enabled = True
        btnDisconnect.Enabled = False
        tbExc.Text = "DONE"
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        SerialPort1.Write(txtTransmit.Text & vbCr) 'The text contained in the txtText will be sent to the serial port as ascii
        'plus the carriage return (Enter Key) the carriage return can be ommitted if the other end does not need it
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim loc As Integer

        If (loc <= 64512) Then
            SerialPort1.Encoding = System.Text.Encoding.GetEncoding("windows-1252")
            For i As Integer = 0 To 1023 Step 1
                loc = count + i
                byteData(loc) = SerialPort1.ReadByte()
            Next
            count += 1024
        End If
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.PortName = cmbPort.Text         'pop a message box to user if he is changing ports
        Else                                            'without disconnecting first.
            MsgBox("Valid only if port is Closed", vbCritical)
        End If
    End Sub

    Private Sub cmbBaud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaud.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.BaudRate = cmbBaud.Text         'pop a message box to user if he is changing baud rate
        Else                                            'without disconnecting first.
            MsgBox("Valid only if port is Closed", vbCritical)
        End If
    End Sub


    Private Sub btnConvert_Click(sender As System.Object, e As System.EventArgs) Handles btnConvert.Click
        tbNum.Text = byteData.Length

        count = 0
        ci = 0
        cj = 0

        ' set to x/2 -1 same below for y; this is the start point as it cycles

        Dim x As Integer = 63
        Dim y As Integer = 63

        pixelCR(x, y)

        For a As Integer = 0 To 62
            'move down
            For b As Integer = 0 To (2 * a + 1) - 1 Step 1
                y += 1
                pixelCR(x, y)
            Next
            'move right
            For c As Integer = 0 To (2 * a + 1) - 1 Step 1
                x += 1
                pixelCR(x, y)
            Next
            'move up
            For d As Integer = 0 To (2 * (a + 1)) - 1 Step 1
                y -= 1
                pixelCR(x, y)
            Next
            'move left
            For f As Integer = 0 To (2 * (a + 1)) - 1 Step 1
                x -= 1
                pixelCR(x, y)
            Next
        Next


        ' red
        drawer = bmpR
        PictureBox1.Image = drawer
        ' green
        drawer = bmpG
        PictureBox2.Image = drawer
        ' blue
        drawer = bmpB
        PictureBox3.Image = drawer
        ' no alpha
        drawer = bmpNA
        PictureBox4.Image = drawer
        ' with alpha
        drawer = bmpWA
        PictureBox5.Image = drawer

    End Sub

    Private Sub pixelCR(x As Integer, y As Integer)
        Dim red1 As Integer
        Dim green2 As Integer
        Dim blue3 As Integer
        Dim alphaA As Integer
        Dim pixel1 As Color
        red1 = Convert.ToInt32(byteData(cj + ci))
        green2 = Convert.ToInt32(byteData(cj + 256 + ci))
        blue3 = Convert.ToInt32(byteData(cj + 512 + ci))
        alphaA = Convert.ToInt32(byteData(cj + 768 + ci))

        If ((cj + ci) <= 4096) Then
            rtb8.Text &= red1.ToString()
        End If





        ' red
        pixel1 = Color.FromArgb(red1, 0, 0)
        bmpR.SetPixel(x, y, pixel1)
        ' green
        pixel1 = Color.FromArgb(0, green2, 0)
        bmpG.SetPixel(x, y, pixel1)
        ' blue
        pixel1 = Color.FromArgb(0, 0, blue3)
        bmpB.SetPixel(x, y, pixel1)
        ' no alpha
        pixel1 = Color.FromArgb(red1, green2, blue3)
        bmpNA.SetPixel(x, y, pixel1)
        ' with alpha
        pixel1 = Color.FromArgb(alphaA, red1, green2, blue3)
        bmpWA.SetPixel(x, y, pixel1)


        cj += 1
        If (cj = 256) Then
            cj = 0
            ci += 1024
        End If
    End Sub



    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        rtb8.Text = ""
        tbExc.Text = ""
        tbNum.Text = ""
    End Sub

End Class
