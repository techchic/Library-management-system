Imports System.Data
Imports System.Data.SqlClient
Public Class DAlTransaction
    Public Shared Sub InsertOrUpdate(ByRef refTransaction As Transaction)

        Dim cmd As New SqlCommand("INSERT INTO FINE SELECT @Borrowing,@Reservation,@Fine,@Book;Set @ID=SCOPE_IDENTITY()", conn)
        Try
            If refTransaction.ID > 0 Then
                cmd = New SqlCommand("UPDATE FINE set @Reservation=Reservation,@Borrowing=Borrowing,@Book=Book where @ID=ID", conn)
            End If
            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refTransaction.ID)

            cmd.Parameters("ID").Direction = ParameterDirection.InputOutput
            cmd.Parameters.AddWithValue("@Reservation", refTransaction.ID)
            cmd.Parameters.AddWithValue("@Student", refTransaction.ID)
            cmd.Parameters.AddWithValue("@Borrowing", refTransaction.ID)


            refFine.ID = cmd.Parameters("@ID").Value



        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function FetchList() As List(Of Penalty)
        Dim conn As New SqlConnection("Sever=localhost;intial catalog=lepic=intergreted security SSPI")
        Dim cmd As New SqlCommand("DELETE FROM FINE WHERE @ID=ID", conn)
        Try
            conn.Open()
            ' cmd.Parameters.AddWithValue("@ID", refTransaction.ID)
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then
                'dr.HasRows()

                With refFine()
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

    Private Shared Function refBook() As Object
        Throw New NotImplementedException
    End Function

    Private Shared Function refFine() As Object
        Throw New NotImplementedException
    End Function

    Shared Sub FetchById()
        Throw New NotImplementedException
    End Sub

    Shared Sub FetchById(ByVal transaction As Transaction)
        Throw New NotImplementedException
    End Sub

    Shared Sub FetchList(ByVal transaction As Transaction)
        Throw New NotImplementedException
    End Sub


End Class