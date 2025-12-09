Imports System.Web

Public Class Form1

    Private Sub WebView21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await WebView22.EnsureCoreWebView2Async()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If WebView22.CanGoBack Then
            WebView22.GoBack()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If WebView22.CanGoForward Then
            WebView22.GoForward()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        WebView22.Reload()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        WebView22.CoreWebView2.Navigate("https://www.google.com")
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        Dim userInput As String = ToolStripComboBox1.Text.Trim()

        If String.IsNullOrWhiteSpace(userInput) Then Exit Sub

        Dim finalUrl As String

        If userInput.ToLower().StartsWith("http") OrElse (userInput.Contains(".") AndAlso Not userInput.Contains(" ")) Then

            If Not userInput.ToLower().StartsWith("http") Then
                finalUrl = "https://" & userInput
            Else
                finalUrl = userInput
            End If

        Else
            Dim busquedaCodificada As String = userInput.Replace(" ", "+")
            finalUrl = "https://www.google.com/search?q=" & busquedaCodificada
        End If

        If WebView22.CoreWebView2 IsNot Nothing Then
            WebView22.CoreWebView2.Navigate(finalUrl)
        End If
    End Sub

End Class