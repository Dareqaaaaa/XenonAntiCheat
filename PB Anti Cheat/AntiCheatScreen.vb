Imports System.Threading
Imports System.Net
Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.IO
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Management
Imports HtmlAgilityPack
Imports System.Drawing.Bitmap
Public Class GameSec

    Dim path As String
    Dim sw As StreamWriter


    Private Function getFileMd5(ByVal filePath As String) As String
        Dim File() As Byte = IO.File.ReadAllBytes(filePath)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim byteHash() As Byte = Md5.ComputeHash(File)
        Return Convert.ToBase64String(byteHash)
    End Function

    Dim lista_PeT As New ListBox
    Dim i As Integer = -1
    Dim TH1 As Thread
    Private Sub ListarDados()
        Dim pList() As Process = Process.GetProcesses
        For Each proc As Process In pList
            If proc.MainWindowTitle <> Nothing Then
                If Me.InvokeRequired Then
                    Dim args() As String = {proc.MainWindowTitle.ToUpper}
                    Me.Invoke(New Action(Of String)(AddressOf ListarDados), args)
                    Return
                End If
                lista_PeT.Items.Add(proc.MainWindowTitle.ToUpper)
            Else
                If Me.InvokeRequired Then
                    Dim args() As String = {proc.ProcessName.ToUpper}
                    Me.Invoke(New Action(Of String)(AddressOf ListarDados), args)
                    Return
                End If
                lista_PeT.Items.Add(proc.ProcessName.ToUpper)
            End If
        Next
        Do
            Try
                i = i + 1
                lista_PeT.SelectedIndex = i
                Dim pesquisar As String
                For Each item As String In elemento_chave
                    pesquisar = InStr(lista_PeT.SelectedItem, item)
                    If pesquisar > 0 Then
                        Detect.Label1.Text = lista_PeT.SelectedItem
                        Detect.ShowDialog()
                    End If
                Next
            Catch
                i = -1
                lista_PeT.Items.Clear()
                Exit Do
            End Try
        Loop
        TH1 = New Thread(AddressOf ListarDados)
        'TH1.IsBackground = False
        TH1.Start()
        'Button1.Enabled = False
    End Sub

    'Verifica alterações na data/hora do sistema
    Sub TimeChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Logger.RegistraEvento("A data/hora do sistema foi alterada" & e.ToString())
    End Sub

    ' Este método é chamado quando uma preferência do usuário é alterada.d
    Private Sub SystemEvents_UserPreferenceChanging(ByVal sender As Object, ByVal e As UserPreferenceChangingEventArgs)
        Logger.RegistraEvento("Alteração de preferencias do usuário : " & e.Category.ToString())
    End Sub

    ' Este método é chamado quando a paleta é alterada.
    Private Sub SystemEvents_PaletteChanged(ByVal sender As Object, ByVal e As EventArgs)
        Logger.RegistraEvento("Ocorreu uma alteração na Paleta")
    End Sub

    ' Este método é chamado quando as exibição das configurações muda
    Private Sub SystemEvents_DisplaySettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
        Logger.RegistraEvento("Exibição das configurações foi alterada.")
    End Sub

    ' Verifica as alterações das preferências do usuário
    Sub UserPreferenceChangedEvent(ByVal sender As Object, ByVal e As Microsoft.Win32.UserPreferenceChangedEventArgs)
        ' Verifica a categoria alterada
        Select Case e.Category
            Case Microsoft.Win32.UserPreferenceCategory.Color
                Logger.RegistraEvento("Foram alteradas as cores do sistema")
            Case Microsoft.Win32.UserPreferenceCategory.Screensaver
                Logger.RegistraEvento("Foi alterado o screensaver do sistema")
            Case Microsoft.Win32.UserPreferenceCategory.Window
                Logger.RegistraEvento("Foram alteradas dimensões ou características do sistema")
        End Select
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        '  Logger.RegistraEvento("Form SizeChanged")
    End Sub






    Private tempo As New Timers.Timer(5000)
    Public Sub DispararTimer(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        Dim TargetProcess As Process() = Process.GetProcessesByName("PointBlank")
        If TargetProcess.Length > 1 Then
            For Each Taskmgr As Process In TargetProcess
                Taskmgr.Kill()
                Logger.RegistraEvento("[Anti Multi-client] Foi fechado mais de um processo do Point blank.")
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Logger.DeletaLog()
        'Adicione um handler para capturar o evento tick do timer: 
        tempo.Enabled = True
        AddHandler tempo.Elapsed, AddressOf DispararTimer
        Dim md5code As String
        Dim TextBoxC As New OpenFileDialog
        Dim currentPath As String = IO.Path.Combine(Directory.GetCurrentDirectory(), "PointBlank.exe")
        Dim num = 0
        If File.Exists(currentPath) Then
            Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            Dim cu As FileStream = New FileStream(currentPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            cu = New FileStream(currentPath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            md5.ComputeHash(cu)
            Dim hash As Byte() = md5.Hash
            Dim buff As StringBuilder = New StringBuilder
            Dim hashByte As Byte
            For Each hashByte In hash
                buff.Append(String.Format("{0:X2}", hashByte))
            Next
            md5code = buff.ToString()
            Logger.RegistraEvento("© GameSec by XENON Protect. 2020 - Inicio dos logs")
            Logger.RegistraEvento("Versão: 3.0.0.0")
            Logger.RegistraEvento("[Step 1] Verificação de autenticação do jogo")
            If md5code = "1EED81C74492489015C35E562247917A" Then
                'TextBox1.Text = currentPath
                Dim Taskmgr3() As Process = Process.GetProcessesByName("PointBlank")
                If Taskmgr3.Length > 1 Then
                    MsgBox("Existe mais de um point blank aberto!", MsgBoxStyle.Critical, "GameSec - Erro")
                    Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
                    For Each jogo As Process In Taskmgr0
                        jogo.Kill()
                    Next
                    Logger.RegistraEvento("[Anti Multi-client] Point Blank não iniciado pois há mais de um processo do mesmo aberto.")
                    End
                Else
                    Logger.RegistraEvento("[Step 2] Verificação de autenticação do jogo completa.")
                End If
            Else
                Logger.DeletaLog()
                Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
                For Each jogo As Process In Taskmgr0
                    jogo.Kill()
                Next
                End
            End If
        Else
            End
        End If


        'Reescrever arquivo host -- teste --
        'Dim PastaArquivo = "C:\Windows\System32\drivers\etc\hosts"
        ' Dim text = "127.0.0.1 www.google.com"
        '  Try
        ' Logger.RegistraEvento("[Step 3] Tentativa de reescrever arquivo hosts")
        ' Logger.RegistraEvento("----------------------------------------------------")
        ' Dim fw = New StreamWriter(PastaArquivo, True)
        ' fw.WriteLine(text)
        ' fw.Close()
        ' Logger.RegistraEvento("[Success] Arquivo host atualizado com sucesso ")
        ' Logger.RegistraEvento("----------------------------------------------------")
        ' Catch
        ' Logger.RegistraEvento("[Error] Não foi possivel reescrever o arquivo ")
        ' Logger.RegistraEvento("----------------------------------------------------")
        ' End Try


        EsconderAC.Enabled = True

        Dim Taskmgr1() As Process = Process.GetProcessesByName("Taskmgr")
        For Each Taskmgr As Process In Taskmgr1
            Logger.RegistraEvento("[ALERT] O Usuario tentou abrir o Taskmgr")
            Taskmgr.Kill()
        Next




        Dim web As New WebClient
        Dim Dados As String = web.DownloadString("https://projectcruize.com/salt/status-ac.txt")

        If Dados = "Manutencao" Then

            MsgBox("Estamos realizando uma manutenção, tente novamente mais tarde.", MsgBoxStyle.Critical, "GameSec - Estamos em manutenção")
            Logger.DeletaLog()
            Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
            For Each jogo As Process In Taskmgr0
                jogo.Kill()
            Next
            End

        ElseIf Dados = "Problema" Then

            MsgBox("Nossos servidores estão com problemas, aguarde até que tudo se normalize.", MsgBoxStyle.Critical, "GameSec - Erro do servidor")
            Logger.DeletaLog()
            Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
            For Each jogo As Process In Taskmgr0
                jogo.Kill()
            Next
            End

        ElseIf Dados = "Finalizado" Then
            'Detectado.Show()
            Logger.RegistraEvento("[GameSec-NotEnabled] O contrato foi finalizado, portanto o GameSec by XENON Inc. encerrou a proteção do jogo.")
            Logger.DeletaLog()
            Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
            For Each jogo As Process In Taskmgr0
                jogo.Kill()
            Next
            End
        ElseIf Dados = "Liberado" Then
            Logger.RegistraEvento("[GameSec-Enabled] Acesso liberado ao Anti Cheat")
        End If

        Dim f As Netstat_Shield = New Netstat_Shield()
        f.Show()

        Try
            AddHandler SystemEvents.UserPreferenceChanging, AddressOf SystemEvents_UserPreferenceChanging
            AddHandler SystemEvents.PaletteChanged, AddressOf SystemEvents_PaletteChanged
            AddHandler SystemEvents.DisplaySettingsChanged, AddressOf SystemEvents_DisplaySettingsChanged
            AddHandler SystemEvents.TimeChanged, AddressOf TimeChangedEvent
            Logger.RegistraEvento("[START_SYSTEM] Sistema de defesa iniciado")
        Catch
            Logger.RegistraEvento("[START_SYSTEM] Sistema de defesa não iniciado.")
        End Try





        Dim TargetProcess As Process() = Process.GetProcessesByName("PointBlank")

        If TargetProcess.Length = 0 Then
            Logger.DeletaLog()
            End
        ElseIf TargetProcess.Length = 1 Then
            Logger.RegistraEvento("[GAME_VERIFIED] O processo foi encontrado")
        ElseIf TargetProcess.Length > 1 Then
            For Each Taskmgr As Process In TargetProcess
                Logger.DeletaLog()
                Taskmgr.Kill()
                End
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TH1 = New Thread(AddressOf ListarDados)
        TH1.IsBackground = True
        TH1.Start()
        Button1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TH1 = New Thread(AddressOf ListarDados)
        TH1.IsBackground = True
        TH1.Start()
        Button1.Enabled = False

        Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles MD5.Tick


        Dim ProcessoCE2() As Process = Process.GetProcessesByName("Cheat Engine")

        For Each x As Process In ProcessoCE2
            x.Kill()
        Next

        Dim ProcessoCE3() As Process = Process.GetProcessesByName("Trainer")

        For Each x As Process In ProcessoCE3
            x.Kill()
        Next

        Dim processos As Process() = Process.GetProcesses

        Try

            For Each processo In processos
                If getFileMd5(processo.MainModule.FileName) = "CFF55136C6F7251E51D99B3B2FE17F4F" Then
                    processo.Kill()
                End If

                If getFileMd5(processo.MainModule.FileName) = "E82FE182C26D88C8B44974F46968CA4B" Then

                    processo.Kill()

                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
        For Each jogo As Process In Taskmgr0
            jogo.Kill()
        Next
    End Sub

    Private Sub AutoCloseGame_Tick(sender As Object, e As EventArgs) Handles AutoCloseGame.Tick
        Dim ProcessoCE2() As Process = Process.GetProcessesByName("PointBlank")
        Logger.RegistraEvento("[Anti-cheat] Jogo finalizado")
        Logger.RegistraEvento("----------------------------------------------------")
        For Each x As Process In ProcessoCE2
            x.Kill()
        Next

    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim Taskmgr0() As Process = Process.GetProcessesByName("PointBlank")
        For Each jogo As Process In Taskmgr0
            jogo.Kill()
        Next
        Logger.RegistraEvento("© GameSec 2020 - Fim dos logs")
        Logger.RegistraEvento("----------------------------------------------------")
    End Sub


    Private Sub Gerenciador_Tick(sender As Object, e As EventArgs) Handles Gerenciador.Tick
        Dim Taskmgr1() As Process = Process.GetProcessesByName("Taskmgr")
        For Each Taskmgr As Process In Taskmgr1
            Logger.RegistraEvento("O Usuario tentou abrir o Taskmgr")
            Taskmgr.Kill()
        Next
    End Sub

    Private Sub EsconderAC_Tick(sender As Object, e As EventArgs) Handles EsconderAC.Tick
        Me.Hide()
    End Sub

    Private Sub DnSpyBlock_Tick(sender As Object, e As EventArgs) Handles dnSpyBlock.Tick
        Dim bio() As Process = Process.GetProcessesByName("dnSpy")
        For Each dnSpy As Process In bio
            Logger.RegistraEvento("O Usuario tentou abrir o dnSpy")
            dnSpy.Kill()
        Next
    End Sub

    Private Sub GameDetect_Tick(sender As Object, e As EventArgs) Handles GameDetect.Tick
        Dim teste() As Process
        teste = Process.GetProcessesByName("PointBlank")
        If teste.Length > 0 Then
        Else
            Logger.RegistraEvento("[GAME_CLOSED] O jogo foi finalizado normalmente")
            Logger.RegistraEvento("© GameSec 2020 - Fim dos logs")
            Logger.RegistraEvento("----------------------------------------------------")
            Logger.DeletaLog()
            End
        End If
    End Sub
End Class
