Imports System.IO
Imports System.Text
Public NotInheritable Class Logger
    Private Sub New()
    End Sub

    ' Calcula o nome do arquivo de log
    Private Shared LogArquivo As String = (Application.StartupPath) + "\GameSec\Logs.xp"
    Private Shared PastaArquivo As String = (Application.StartupPath) + "\GameSec"
    ' Escreve a data e hora atual mais a linha de texto no arquivo de log
    Public Shared Sub RegistraEvento(texto As String)
        If Not Directory.Exists(Application.StartupPath & "\GameSec") Then
            Dim _url As String = Application.StartupPath & "\GameSec"
            MkDir(_url)
            SetAttr(_url, vbHidden)
            RegistraEvento("[HUB] Pasta GameSec criada")
        End If
        File.AppendAllText(LogArquivo, (Convert.ToString(DateTime.Now.ToString() + ": ") & texto) + vbCrLf)
    End Sub


    Public Shared Sub CriarPrint()
        If Not Directory.Exists(Application.StartupPath & "\GameSec\Screen") Then
            Dim _url As String = Application.StartupPath & "\GameSec\Screen"
            MkDir(_url)
            SetAttr(_url, vbHidden)
            RegistraEvento("[HUB] Pasta Scren criada")
        End If
        Try
            Dim TamanhoJanela As Size = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Dim PrintScreen As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            Dim Desenhar As Graphics = Graphics.FromImage(PrintScreen)
            Desenhar.CopyFromScreen(New Point(0, 0), New Point(0, 0), TamanhoJanela)
            PrintScreen.Save((Application.StartupPath) + "\GameSec\Screen\log.jpeg", Imaging.ImageFormat.Jpeg)
            RegistraEvento("[PrintScreen] Captura obtida com sucesso")
        Catch ex As Exception
            RegistraEvento("[PrintScreen] Erro ao obter captura")
        End Try

    End Sub
    Public Shared Sub DeletaLog()
        If Directory.Exists(Application.StartupPath & "\GameSec") Then
            Directory.Delete(PastaArquivo, True)
            End
        End If
    End Sub

End Class