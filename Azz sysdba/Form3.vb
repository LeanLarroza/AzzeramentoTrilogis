Imports System.IO
Imports FirebirdSql.Data.FirebirdClient

Public Class Form3
    Dim percorsob As String
    Dim esecu As String
    Dim userdb As String
    Dim passdb As String
    Public Shared dbconn As FbConnection

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Form1.DateTimePickerA.ToShortDateString
        Label2.Text = Form1.DateTimePickerB.ToShortDateString
        Me.Visible = True
        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)

        Inizini()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        dbconn = New FbConnection("User=" & userdb & ";Password=" & passdb & ";Database=C:\trilogis\trilogis.fb20;DataSource=localhost;")
        dbconn.Open()

        Dim sql As String = "SELECT RESOCONTOEMESSOID, OPERATOREID, RESOCONTOEMESSONUMERO, RESOCONTOPRINT FROM RESOCONTIEMESSI"
        Dim cmd As New FbCommand(sql, dbconn)
        Dim fbdatareader As FbDataReader = cmd.ExecuteReader
        Dim s(9) As String
        If fbdatareader.Read Then
            fbdatareader.Close()
            Dim sql1 As String = "SELECT RESOCONTOEMESSOID, OPERATOREID, RESOCONTOEMESSONUMERO, RESOCONTOPRINT FROM RESOCONTIEMESSI"
            Dim cmd1 As New FbCommand(sql, dbconn)
            Dim fbdatareader1 As FbDataReader = cmd.ExecuteReader
            While fbdatareader1.Read()
                s(0) = fbdatareader1.GetString(0) + 1
                s(1) = fbdatareader1.GetString(1)
                s(2) = fbdatareader1.GetString(2) + 1
                If Form1.DateTimePickerA.ToShortDateString <> Form1.DateTimePickerB.ToShortDateString Then
                    s(3) = 2
                Else
                    s(3) = 1
                End If
                s(4) = Form1.DateTimePickerA.ToString("MM/dd/yyyy")
                s(5) = Form1.DateTimePickerB.ToString("MM/dd/yyyy")
                s(6) = "00:00:00"
                s(7) = fbdatareader1.GetString(3)
                s(8) = False
            End While
        Else
            s(0) = 1
            s(1) = 6
            s(2) = 1
            If Form1.DateTimePickerA.ToShortDateString <> Form1.DateTimePickerB.ToShortDateString Then
                s(3) = 2
            Else
                s(3) = 1
            End If
            s(4) = Form1.DateTimePickerA.ToString("MM/dd/yyyy")
            s(5) = Form1.DateTimePickerB.ToString("MM/dd/yyyy")
            s(6) = "00:00:00"
            s(7) = "Null"
            s(8) = False
        End If

        Dim addDetailsTransaction As FbTransaction = dbconn.BeginTransaction()
        Dim query As New FbCommand("INSERT INTO RESOCONTIEMESSI (RESOCONTOEMESSOID,OPERATOREID,RESOCONTOEMESSONUMERO,RESOCONTOEMESSODATA,RESOCONTOEMESSOORA,RESOCONTOEMESSOTIPOID,RESOCONTOEMESSODATAINIZIO,RESOCONTOEMESSOORAINIZIO,RESOCONTOEMESSODATAFINE,RESOCONTOEMESSOORAFINE,RESOCONTOPRINT,NONAZZERAMENTO) VALUES ('" & s(0) & "','" & s(1) & "','" & s(2) & "','" & DateTime.Now.ToString("MM/dd/yyyy") & "','" & DateTime.Now.ToString("HH:mm:ss") & "','" & s(3) & "','" & s(4) & "','" & s(6) & "','" & s(5) & "','" & s(6) & "','" & s(7) & "','" & s(8) & "')", dbconn, addDetailsTransaction)
        query.UpdatedRowSource = System.Data.UpdateRowSource.Both
        Dim ENQ = query.ExecuteNonQuery()
        If ENQ = 1 Then
            addDetailsTransaction.Commit()
        Else
            addDetailsTransaction.Rollback()
        End If
        addDetailsTransaction.Dispose()
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Sub Inizini()
        Dim iniexist As String = "C:\trilogis\PentaStart.ini"
        Dim ini As New IniFile
        If System.IO.File.Exists(iniexist) Then
            ini.Load("C:\trilogis\pentastart.ini")
            percorsob = ini.GetKeyValue("BACKUP", "Unita")
            esecu = ini.GetKeyValue("AVVIO", "Esecuzione")
            userdb = ini.GetKeyValue("DB", "User")
            passdb = ini.GetKeyValue("DB", "Password")
        Else
            MessageBox.Show("Errore PentaStart", "PentaStart")
            Environment.Exit(0)
        End If


    End Sub

End Class