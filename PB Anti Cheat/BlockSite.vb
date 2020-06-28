Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Namespace Sample1
    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)

            Dim path As [String] = "C:\Windows\System32\drivers\etc\hosts"
            Dim sw As New StreamWriter(path, True)
            Dim sitetoblock As [String] = vbLf & " 127.0.0.1 xyz.com"
            sw.Write(sitetoblock)
            sw.Close()

        End Sub
    End Class
End Namespace