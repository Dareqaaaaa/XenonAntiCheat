Imports System.Net.Dns
Imports System.Threading
Public Class Detectado

    Public Class ObtemIP

        Shared Function ObtemEnderecoIP() As String

            Dim oEndereco As System.Net.IPAddress

            Dim sEndereco As String


            With GetHostByName(GetHostName)

                oEndereco = New System.Net.IPAddress(.AddressList(0).Address)

                sEndereco = oEndereco.ToString

            End With

            ObtemEnderecoIP = sEndereco

        End Function

    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        '  Logger.RegistraEvento("O Anti Cheat foi finalizado pelo usuário após uma detectação!")

        Application.Exit()
    End Sub

    Private Sub Detectado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()

        Logger.RegistraEvento("[ERRO-FATAL] Anti Cheat desabilitado")

    End Sub

    Private Sub Detectado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '   Logger.RegistraEvento("O Anti Cheat foi finalizado pelo usuário após uma detectação!")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Thread.Sleep(5000)

        Dim bio() As Process = System.Diagnostics.Process.GetProcessesByName("PointBlank")
        For Each jogo As Process In bio
            jogo.Kill()
        Next

        Logger.RegistraEvento("[ERRO-FATAL] Anti Cheat desabilitado")
    End Sub
End Class