Imports System.Data
Imports System.Data.SqlClient
Public Class DALPenalty
    Public Shared Sub InsertOrUpdate(ByRef refPenalty As Penalty)
        Dim cmd As New SqlCommand("INSERT INTO Penalty SELECT @Student,@Borrowing;Set @ID=SCOPE_IDENTITY()", conn)
        Try


            If refPenalty.ID > 0 Then
                cmd = New SqlCommand("UPDATE Penalty Set Student= @Student,Borrowing=@Borrowing, WHERE ID=@ID", conn)
            End If


            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refPenalty.ID)

            cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

            cmd.Parameters.AddWithValue("@Student", refPenalty.Student)
            cmd.Parameters.AddWithValue("@Borrowing", refPenalty.Borrowing)
            
            cmd.ExecuteNonQuery()

            refPenalty.ID = cmd.Parameters("@ID").Value



        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function FetchList() As List(Of Penalty)
        Dim conn As New SqlConnection("Sever=localhost;intial catalog=lepic=intergreted security SSPI")
        Dim cmd As New SqlCommand("DELETE FROM Penalty WHERE @ID=ID", conn)
        Try
            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refPenalty.ID)
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then


                With refPenalty()
                    .ID = dr.Item("ID")
                    .Student = dr.Item("Student")
                    .Borrowing = dr.Item("Borrowing")

                End With
            End If
            dr.Close()
            dr = Nothing

        Catch ex As Exception
            Throw
            conn.Close()
            cmd.Dispose()
        End Try
    End Function

    Private Shared Function refPenalty() As Object
        Throw New NotImplementedException
    End Function

    Shared Sub FetchbyID()
        Throw New NotImplementedException
    End Sub

    Shared Sub FetchbyID(ByVal penalty As Penalty)
        Throw New NotImplementedException
    End Sub

 



End Class
