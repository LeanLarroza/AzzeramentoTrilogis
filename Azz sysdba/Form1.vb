Imports FirebirdSql.Data.FirebirdClient

Public Class Form1

    Public Shared DateTimePickerA As Date
    Public Shared DateTimePickerB As Date

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = True
        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            Dim provisorio As Date
            provisorio = DateTimePicker1.Value
            DateTimePicker1.Value = DateTimePicker2.Value
            DateTimePicker2.Value = provisorio
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            Dim provisorio As Date
            provisorio = DateTimePicker1.Value
            DateTimePicker2.Value = DateTimePicker1.Value
            DateTimePicker1.Value = provisorio
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DateTimePickerA = DateTimePicker1.Value
        DateTimePickerB = DateTimePicker2.Value
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub
End Class
