Imports System
Imports System.Collections.Generic
Imports System.Management
Imports System.Diagnostics
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Windows.Forms
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.InteropServices


Public Class Netstat_Shield
    Private Sub Todos_IPs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()

        Logger.RegistraEvento("[NETSTAT] Conectado com sucesso")

        listBox1.Items.Clear()
        Dim processo As Process = New Process()
        processo.StartInfo.FileName = (Environment.GetFolderPath(Environment.SpecialFolder.System) & "\NETSTAT.exe")
        processo.StartInfo.Arguments = String.Format(" -no")
        processo.StartInfo.RedirectStandardOutput = True
        processo.StartInfo.UseShellExecute = False
        processo.StartInfo.CreateNoWindow = True
        processo.Start()
        '  Await Task.Delay(200)
        Dim saida As String = processo.StandardOutput.ReadToEnd()
        Logger.RegistraEvento("[NETSTAT] Iniciando pattern...")
        Dim pattern As String = "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"
        Logger.RegistraEvento("[NETSTAT] Pattern iniciada")

        'listBox1.Items.AddRange = TextBox2.Text

        'If listBox1.Items.Equals("52.177.165.30") Then

        '    Dim BRC As BRC_NETSTAT_DETECT = New BRC_NETSTAT_DETECT()
        '    BRC_NETSTAT_DETECT.Show()

        'Else


        'End If

        Dim matches As MatchCollection
        Dim r As Regex = New Regex(pattern)
        matches = r.Matches(saida)

        For Each match As Match In matches
            listBox1.Items.Add(match)
            '    Await Task.Delay(10)
        Next
        Logger.RegistraEvento("[NETSTAT] Conexões obtidas com sucesso")

        'button2.Enabled = True





        label1.Visible = False
        ' button2.Enabled = False
        Logger.RegistraEvento("[NETSTAT-SAVER] Salvando...")
        If File.Exists(Application.StartupPath & "\GameSec\Conexões.xp") Then File.Delete(Application.StartupPath & "\GameSec\Conexões.xp")

        Dim caminhoArquivo As String = Application.StartupPath & "\GameSec\Conexões.xp"

        Using arquivo As StreamWriter = New StreamWriter(caminhoArquivo, True)
            Dim a As String
            Dim b As String
            Dim c As String

            Try
                a = EnderecoMAC1()
            Catch
                a = "Não Disponível."
            End Try

            Try
                b = EnderecoMAC2().ToString()
            Catch
                b = "Não Disponível."
            End Try

            Try
                c = EnderecoMAC3().ToString()
            Catch
                c = "Não Disponível."
            End Try

            arquivo.Write("Identificador 1: " & a)
            arquivo.Write(Environment.NewLine)
            arquivo.Write("Identificador 2: " & b)
            arquivo.Write(Environment.NewLine)
            arquivo.Write("Identificador 3: " & c)
            arquivo.Write(Environment.NewLine)

            For i As Integer = 0 To listBox1.Items.Count - 1
                arquivo.Write(listBox1.Items(i).ToString())
                arquivo.Write(Environment.NewLine)
            Next

            label1.Visible = False
        End Using
        Logger.RegistraEvento("[NETSTAT-SAVER] Arquivo salvo com sucesso")

        'Dim sabba As String = Environment.ExpandEnvironmentVariables _
        ' ("C:\Users\zepit\source\repos\PB Anti Cheat\PB Anti Cheat\bin\Release\GameSec\Conexões.xp")

        Thread.Sleep(3000)

        Dim sabba As String = (Application.StartupPath & "\GameSec\Conexões.xp")

        ' Dim sabba As String = File.Exists(Application.StartupPath & "\GameSec\Conexões.xp")
        Dim Arq As New System.IO.StreamReader(sabba)
        TextBox2.Clear()
        TextBox2.Text = Arq.ReadToEnd
        Arq.Close()

        Dim currentPath As String = (Application.StartupPath & "\GameSec\Conexões.xp")
        ' Dim strPath = "C:\Users\Administrador\Desktop\PB Anti Cheat\PB Anti Cheat\bin\Release\GameSec\Conexões.xp"

        '  Dim strPath = currentPath
        Dim fs As New FileStream(currentPath, FileMode.Open)
        Dim sr As New StreamReader(fs)
        Dim strFile As String

        strFile = sr.ReadToEnd()
        sr.Close()

        Dim fstwo As New FileStream(currentPath, FileMode.Create)

        strFile = strFile.Replace("172.67.150.165", "BRCheats detectado!")
        strFile = strFile.Replace("104.27.179.102", "BRCheats detectado!")
        strFile = strFile.Replace("50.63.202.42", "BRCheats detectado!")

        Dim sw As New StreamWriter(fstwo)

        sw.Write(strFile)

        sw.Flush()
        sw.Close()

        '  Logger.RegistraEvento("Salvo em: " & Application.StartupPath & "\GameSec\Conexões.xp")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub






    Public Shared Function EnderecoMAC1() As String
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

    Public Shared Function EnderecoMAC2() As PhysicalAddress
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

    Public Shared Function EnderecoMAC3() As PhysicalAddress
        For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

            If nic.OperationalStatus = OperationalStatus.Up AndAlso (Not nic.Description.Contains("Virtual") AndAlso Not nic.Description.Contains("Pseudo")) Then
                If nic.GetPhysicalAddress().ToString() <> "" Then Return nic.GetPhysicalAddress()
            End If
        Next

        Return Nothing
    End Function







    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'label1.Visible = False
        'button2.Enabled = False
        'If File.Exists(Application.StartupPath & "\ConnectionLogs.log") Then File.Delete(Application.StartupPath & "\ConnectionLogs.log")
        'Dim caminhoArquivo As String = Application.StartupPath & "\ConnectionLogs.log"

        'Using arquivo As StreamWriter = New StreamWriter(caminhoArquivo, True)
        '    Dim a As String
        '    Dim b As String
        '    Dim c As String

        '    Try
        '        a = EnderecoMAC1()
        '    Catch
        '        a = "Não Disponível."
        '    End Try

        '    Try
        '        b = EnderecoMAC2().ToString()
        '    Catch
        '        b = "Não Disponível."
        '    End Try

        '    Try
        '        c = EnderecoMAC3().ToString()
        '    Catch
        '        c = "Não Disponível."
        '    End Try

        '    arquivo.Write("ID: " & a)
        '    arquivo.Write(Environment.NewLine)
        '    arquivo.Write("ID: " & b)
        '    arquivo.Write(Environment.NewLine)
        '    arquivo.Write("ID: " & c)
        '    arquivo.Write(Environment.NewLine)

        '    For i As Integer = 0 To listBox1.Items.Count - 1
        '        arquivo.Write(listBox1.Items(i).ToString())
        '        arquivo.Write(Environment.NewLine)
        '    Next

        '    label1.Visible = True
        'End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        Close()
    End Sub
End Class