Imports LePic

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Amono As New Student(1)


        MessageBox.Show("Student name is " & Amono.Name)
    End Sub
End Class
