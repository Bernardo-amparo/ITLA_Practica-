Public Class Form1
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim userInput As String = ToolStripTextBox1.Text.Trim()

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

        If WebView21.CoreWebView2 IsNot Nothing Then
            WebView21.CoreWebView2.Navigate(finalUrl)
        End If
    End Sub
End Class
