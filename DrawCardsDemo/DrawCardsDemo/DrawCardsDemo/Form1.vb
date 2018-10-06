Public Class Form1
    Private WithEvents Timer1 As New System.Windows.Forms.Timer With {.Interval = 50, .Enabled = True}
    Private TheStep As Single = 0
    Private Cards As New List(Of Bitmap)
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.BackColor = Color.Teal
        Me.Width = 500
        Me.Height = 500
        'make "Cards" list of 52+ single card images from full deck image
        Dim wc As New System.Net.WebClient
        Dim ImageInBytes() As Byte = wc.DownloadData("http://math.hws.edu/javanotes/c13/cards.png")
        Dim ImageStream As New IO.MemoryStream(ImageInBytes)
        Using bmpCards = New System.Drawing.Bitmap(ImageStream)
            Dim w As Integer = bmpCards.Width \ 13
            Dim h As Integer = bmpCards.Height \ 5
            Dim srcRect As Rectangle
            Dim destRect As Rectangle = New Rectangle(0, 0, w, h)
            Using bmpCard As Bitmap = New Bitmap(w, h)
                Using g As Graphics = Graphics.FromImage(bmpCard)
                    'read the cards into a list
                    For y = 0 To 4
                        For x = 0 To 12
                            srcRect = New Rectangle(x * w, y * h, w, h)
                            With g
                                .DrawImage(bmpCards, destRect, srcRect, GraphicsUnit.Pixel)
                                Cards.Add(CType(bmpCard.Clone, Bitmap))
                                If y = 4 And x = 3 Then Exit For
                            End With
                        Next
                    Next
                End Using
            End Using
        End Using
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TheStep = CSng(TheStep + 0.25)
        If TheStep > 17 Then TheStep = 0
        PictureBox1.Refresh()
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim x, y As Integer
        Dim x2 = (Me.ClientSize.Width / 2) - 30
        Dim y2 = (Me.ClientSize.Height / 2) - 50
        For i = 0 To 51
            x = CInt(x2 + (0.7 * x2 * Math.Cos(i * TheStep / 57.8)))
            y = CInt(y2 + (0.7 * x2 * Math.Sin(i * TheStep / 57.8)))
            e.Graphics.DrawImage(Cards(i), x, y)
        Next
    End Sub
End Class
