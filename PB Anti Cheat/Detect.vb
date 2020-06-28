Imports System.Net.Dns
Imports System.Net.NetworkInformation
Imports System.Net.Mail
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Management
Imports System.Text
Public Class Detect
    Public Class ObtemIP

        Shared Function ObtemEnderecoIP() As String

            Dim oEndereco As System.Net.IPAddress

            Dim sEndereco As String


            With GetHostByName(GetHostName)

                oEndereco = New System.Net.IPAddress(.AddressList(0).Address)
                '  Label4.Text = GetHostName()
                sEndereco = oEndereco.ToString

            End With

            ObtemEnderecoIP = sEndereco

        End Function



    End Class

    Public Shared Function GetEnderecoMAC1() As String
        Try
            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim enderecoMAC As String = String.Empty

            For Each adapter As NetworkInterface In nics

                If enderecoMAC = String.Empty Then
                    Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
                    enderecoMAC = adapter.GetPhysicalAddress().ToString()
                End If
            Next

            Return enderecoMAC
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetEnderecoMAC2() As PhysicalAddress
        Try

            For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

                If nic.NetworkInterfaceType = NetworkInterfaceType.Ethernet AndAlso nic.OperationalStatus = OperationalStatus.Up Then
                    Return nic.GetPhysicalAddress()
                End If
            Next

            Return Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetEnderecoMAC3() As String
        Try
            Dim objMOS As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMOS.[Get]()
            Dim enderecoMAC As String = String.Empty

            For Each objMO As ManagementObject In objMOC

                If enderecoMAC = String.Empty Then
                    If objMO("MacAddress") IsNot Nothing Then enderecoMAC = objMO("MacAddress").ToString()
                End If

                objMO.Dispose()
            Next

            enderecoMAC = enderecoMAC.Replace(":", "")
            Return enderecoMAC
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetEnderecoMAC4() As String
        Dim enderecoMac As String = ""

        Try

            For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                If nic.NetworkInterfaceType <> NetworkInterfaceType.Ethernet Then Continue For

                If nic.OperationalStatus = OperationalStatus.Up Then
                    enderecoMac += nic.GetPhysicalAddress().ToString()
                    Exit For
                End If
            Next

            Return enderecoMac
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetEnderecoMAC5() As String
        Try
            Dim mgmt As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objCol As ManagementObjectCollection = mgmt.GetInstances()
            Dim address As String = String.Empty

            For Each obj As ManagementObject In objCol

                If address = String.Empty Then
                    If CBool(obj("IPEnabled")) = True Then address = obj("MacAddress").ToString()
                End If

                obj.Dispose()
            Next

            address = address.Replace(":", "")
            Return address
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetEnderecoMAC6() As List(Of String)
        Dim query As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
        Dim adapters As List(Of String) = New List(Of String)()

        For Each mo As ManagementObject In query.[Get]()

            If CBool(mo("IPEnabled")) AndAlso mo("MacAddress") IsNot Nothing Then
                adapters.Add(CStr(mo("Description")) & " " & CStr(mo("MacAddress")))
            End If
        Next

        Return adapters
    End Function

    Public Shared Function GetEnderecosFisicos() As String()
        Dim resultado = New List(Of String)()

        Try
            Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

            For Each adapter As NetworkInterface In interfaces
                Dim address As PhysicalAddress = adapter.GetPhysicalAddress()
                Dim bytes As Byte() = address.GetAddressBytes()
                If bytes.Length = 0 Then Continue For
                Dim mac = New StringBuilder()

                For i As Integer = 0 To bytes.Length - 1
                    mac.Append(bytes(i).ToString("X2"))
                    If i <> bytes.Length - 1 Then mac.Append("-")
                Next

                resultado.Add(mac.ToString())
            Next

            Return resultado.ToArray()
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Private Sub Detect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            lbResultado1.Items.Add(GetEnderecoMAC1())
            TextBox6.Text = GetEnderecoMAC1()
            LabelMAC2.Text = GetEnderecoMAC1()
            Logger.RegistraEvento("Endereço MAC do usuário [Mod]: " = GetEnderecoMAC1())
        Catch ex As Exception
            MessageBox.Show("Erro : " & ex.Message)
        End Try

        'Try
        '    Dim resultado As String = ""
        '    Dim address As PhysicalAddress = GetEnderecoMAC2()
        '    Dim bytes As Byte() = address.GetAddressBytes()

        '    For i As Integer = 0 To bytes.Length - 1
        '        resultado = resultado & bytes(i).ToString("X2")

        '        If i <> bytes.Length - 1 Then
        '            resultado += "-"
        '        End If
        '    Next

        '    lbResultado2.Items.Add(resultado)
        'Catch ex As Exception
        '    MessageBox.Show("Erro : " & ex.Message)
        'End Try


        Try
            lbResultado3.Items.Add(GetEnderecoMAC3())
            LabelMAC3.Text = GetEnderecoMAC3()
            '  GetEnderecoMAC3 = LabelMAC.Text
            ' Logger.RegistraEvento("Endereço MAC do usuário [Mod]: " = LabelMAC.Text)
        Catch ex As Exception
            '   MessageBox.Show("Erro : " & ex.Message)
        End Try


        'Try
        '    lbResultado4.Items.Add(GetEnderecoMAC4())
        '    TextBox8.Text = GetEnderecoMAC4()
        '    '   Logger.RegistraEvento("Endereço MAC do usuário [Mod]: " = GetEnderecoMAC4())
        'Catch ex As Exception
        '    MessageBox.Show("Erro : " & ex.Message)
        'End Try


        'Try
        '    lbResultado5.Items.Add(GetEnderecoMAC5())
        '    TextBox9.Text = GetEnderecoMAC5()
        '    '  Logger.RegistraEvento("Endereço MAC do usuário [Mod]: " = GetEnderecoMAC5())
        'Catch ex As Exception
        '    MessageBox.Show("Erro : " & ex.Message)
        'End Try







        '  ListBox1.Enabled = True


        Logger.RegistraEvento("O Anti Cheat foi finalizado automaticamente após uma detecção!")

        Logger.RegistraEvento("----------------------------------------------------")

        Logger.CriarPrint()

        Logger.RegistraEvento("Detectado: " + Label1.Text)

        Logger.RegistraEvento("Nome do PC suspeito: " + GetHostName())

        NomeDoPC.Text = GetHostName()

        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Logger.RegistraEvento("Endereço IPv6 de link local: " + h.AddressList.GetValue(0).ToString)

        EndereçoIPv6.Text = h.AddressList.GetValue(0).ToString

        Logger.RegistraEvento("Endereço IPv4 do usuário: " + ObtemIP.ObtemEnderecoIP)

        ObtemEnderecoIP.Text = ObtemIP.ObtemEnderecoIP

        Dim mc As ManagementClass
        Dim mo As ManagementBaseObject
        mc = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances

        For Each mo In moc
            If mo.Item("IPenabled") = True Then
                ListBox1.Items.Add("Endereço MAC " & mo.Item("MacAddress"))
                TextBox5.Text = mo.Item("MacAddress")
                Logger.RegistraEvento("Endereço MAC do usuário: " & LabelMAC2.Text)
            End If
        Next

        MacAddress.Text = TextBox5.Text

        Logger.RegistraEvento("----------------------------------------------------")
        Dim MyMailMessage As New MailMessage()
        Dim SMTPServer As New SmtpClient("smtp.gmail.com")
        MyMailMessage.From = New MailAddress("EMAIL QUE ENVIARÁ O RELATORIO")
        MyMailMessage.To.Add("EMAIL QUE RECEBERÁ")
        MyMailMessage.Subject = ("[GameSec] Relatório de detecção")
        Dim d As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        MyMailMessage.Body = ("Detectado: " & Label1.Text & " ||| " & "Nome do PC: " & NomeDoPC.Text & " ||| " & "Endereço IPv6: " & EndereçoIPv6.Text & " ||| " & "Endereço IPv4: " & ObtemEnderecoIP.Text & " ||| " & "Endereço MAC : " & LabelMAC2.Text & " ||| " & "Endereço MAC 3: " & LabelMAC3.Text)
        MyMailMessage.Attachments.Add(New Attachment((Application.StartupPath) + "\GameSec\Logs.xp"))
        MyMailMessage.Attachments.Add(New Attachment((Application.StartupPath) + "\GameSec\Screen\log.jpeg"))
        SMTPServer.Port = ("587")
        SMTPServer.Credentials = New System.Net.NetworkCredential("EMAIL QUE ENVIARÁ O RELATORIO", "SENHA DO EMAIL")
        SMTPServer.EnableSsl = True
        Try
            SMTPServer.Send(MyMailMessage)
        Catch ex As Exception
            Logger.RegistraEvento("[Exception] Erro ao enviar relatorio")
        End Try

        Dim bio() As Process = Process.GetProcessesByName("PointBlank")
        For Each jogo As Process In bio
            jogo.Kill()
        Next
        End
    End Sub

End Class