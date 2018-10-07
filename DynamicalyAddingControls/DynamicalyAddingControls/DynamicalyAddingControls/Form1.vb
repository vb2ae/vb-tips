Public Class Form1
    'VB10 sp1 style code for older add byval
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To 5
            Dim bt As New Button
            bt.Location = New Drawing.Point(8, 8 + i * 24)
            bt.TabIndex = i
            bt.Text = i.ToString
            bt.Tag = i.ToString
            AddHandler bt.Click, AddressOf ClickButton
            Controls.Add(bt)
        Next
    End Sub
    Private Sub ClickButton(sender As Object, e As EventArgs)
        Dim buttonUsed = DirectCast(sender, Button)
        buttonUsed.BackColor = Color.Black
        MessageBox.Show("Clicked was " & buttonUsed.Tag.ToString)
    End Sub
End Class
