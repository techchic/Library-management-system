Imports System.Data
Imports System.Data.SqlClient
Namespace DAL
    Public Class DALBook

        Public Shared Sub InsertOrUpdate(ByRef refBook As Book)

            Dim cmd As New SqlCommand("INSERT INTO BOOKS SELECT @BookCode,@BookName,@Reservation,@Author;Set @ID=SCOPE_IDENTITY()", conn)
            Try


                If refBook.ID > 0 Then
                    cmd = New SqlCommand("UPDATE BOOKS Set BookCode= @BookCode,Author=@Author,Reservation=@Reservation,BookName=@BookName WHERE ID=@ID", conn)
                End If


                conn.Open()
                cmd.Parameters.AddWithValue("@ID", refBook.ID)

                cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

                cmd.Parameters.AddWithValue("@BookCode", refBook.BookCode)
                cmd.Parameters.AddWithValue("@Author", refBook.Author)
                cmd.Parameters.AddWithValue("@BookName", refBook.BookName)
                cmd.Parameters.AddWithValue("@Reservation", refBook.Reservation)
                cmd.ExecuteNonQuery()

                refBook.ID = cmd.Parameters("@ID").Value

            Catch ex As Exception
                Throw
            Finally
                conn.Close()
                cmd.Dispose()
            End Try


        End Sub

        Public Shared Sub FetchById(ByRef refBook As Book)
            Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
            Dim cmd As New SqlCommand("SELECT * FROM BOOKS WHERE ID=@ID", conn)
            Try

                conn.Open()

                cmd.Parameters.AddWithValue("@ID", refBook.ID)

                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.HasRows Then

                    dr.Read()

                    With refBook
                        .ID = dr.Item("ID")
                        .BookCode = dr.Item("BookCode")
                        .Author = dr.Item("Author")
                        .BookName = dr.Item("Name")
                        '   .Reservation = dr.Item("Reservtion")
                    End With
                End If

                dr.Close()
                dr = Nothing
            Catch ex As Exception
                Throw
            Finally
                conn.Close()
                cmd.Dispose()
            End Try


        End Sub
        Public Shared Function FetchList() As List(Of Book)


        End Function
        Public Shared Sub Delete(ByRef Delete As Book)
            Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
            Dim cmd As New SqlCommand("DELETE  FROM  BOOKS WHERE ID=@ID", conn)
            Try

                conn.Open()

                cmd.Parameters.AddWithValue("@ID", refBook.ID)

                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.HasRows Then

                    dr.Read()

                    With refBook()
                        .ID = dr.Item("ID")
                        .BOokCode = dr.Item("BookCode")
                        .Author = dr.Item("Author")
                        .Name = dr.Item("Name")
                    End With
                End If

                dr.Close()
                dr = Nothing
            Catch ex As Exception
                Throw
            Finally
                conn.Close()
                cmd.Dispose()
            End Try

        End Sub

        Private Shared Function refBook() As Object
            Throw New NotImplementedException
        End Function

    End Class

End Namespace

