Imports System.Data
Imports System.Data.SqlClient
Public Class DALReservation
    Public Shared Sub InsertOrUpdate(ByRef refReservation As Reservation)

        Dim cmd As New SqlCommand("INSERT INTO Reservation SELECT @Book,@Student,@Publisher;Set @ID=SCOPE_IDENTITY()", conn)
        Try


            If refReservation.ID > 0 Then
                cmd = New SqlCommand("UPDATE BOOKS Set Reservation= @Book,Student=@Student,Publisher=@Publisher,WHERE ID=@ID", conn)
            End If


            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refReservation.ID)

            cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

            cmd.Parameters.AddWithValue("@Book", refReservation.Book)
            cmd.Parameters.AddWithValue("@Student", refReservation.student)
            cmd.Parameters.AddWithValue("@Publisher", refReservation.publisher)

            cmd.ExecuteNonQuery()

            refReservation.ID = cmd.Parameters("@ID").Value

        Catch ex As Exception
            Throw
        Finally
            conn.Close()
            cmd.Dispose()
        End Try


    End Sub

    Public Shared Sub FetchById(ByRef refReservation As Reservation)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("SELECT * FROM Reservation WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refReservation.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refReservation
                    .ID = dr.Item("ID")
                    .Book = dr.Item(" Book")
                    .Student = dr.Item("Student")
                    .Publisher = dr.Item("Publisher")
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
    Public Shared Function FetchList() As List(Of Reservation)


    End Function
    Public Shared Sub Delete(ByRef Delete As Reservation)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("DELETE  FROM  RESERVATION WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refReservation.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refReservation()
                    .ID = dr.Item("ID")
                    .Book = dr.Item(" Book")
                    .Student = dr.Item("Student")
                    .Publisher = dr.Item("Publisher")
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

    Private Shared Function refReservation() As Object
        Throw New NotImplementedException
    End Function
End Class
