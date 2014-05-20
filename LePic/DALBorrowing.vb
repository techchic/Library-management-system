
Imports System.Data
Imports System.Data.SqlClient
Public Class DALBorrowing
    Public Shared Sub InsertOrUpdate(ByRef refBorrowing As Borrowing)

        Dim cmd As New SqlCommand("INSERT INTO Borrowing SELECT @Student,@Book,@Type,@Period,@LendingDate,@ReturnDate,@Fine,@Reservation;Set @ID=SCOPE_IDENTITY()", conn)
        Try


            If refBorrowing.ID > 0 Then
                cmd = New SqlCommand("UPDATE Borrowing Set Student=@Student,Book=@Book,Type=@Type,Period=@Period,LendingDate=@LendingDate,ReturnDate=@ReturnDate,Fine=@Fine,Reservation=@Reservation WHERE ID=@ID", conn)
            End If


            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refBorrowing.ID)

            cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

            cmd.Parameters.AddWithValue("@Student", refBorrowing.Student)
            cmd.Parameters.AddWithValue("@Book", refBorrowing.Book)
            cmd.Parameters.AddWithValue("@Type", refBorrowing.Type)
            cmd.Parameters.AddWithValue("@Period", refBorrowing.Period)
            cmd.Parameters.AddWithValue("@LendingDate", refBorrowing.LendingDate)
            cmd.Parameters.AddWithValue("@ReturnDate", refBorrowing.ReturnDate)
            'cmd.Parameters.AddWithValue("@Fine", refBorrowing.Fine)
            cmd.Parameters.AddWithValue("@Reservation", refBorrowing.Reservation)
            cmd.ExecuteNonQuery()

            refBorrowing.ID = cmd.Parameters("@ID").Value

        Catch ex As Exception
            Throw
        Finally
            conn.Close()
            cmd.Dispose()
        End Try


    End Sub

    Public Shared Sub FetchById(ByRef refBorrowing As Borrowing)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("SELECT * FROM Borrowing WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refBorrowing.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refBorrowing
                    .ID = dr.Item("ID")
                    ' .Book = dr.Item("Book")
                    .Type = dr.Item("Type")
                    .Period = dr.Item("Period")
                    .LendingDate = dr.Item("Student")
                    .ReturnDate = dr.Item("ReturnDate")
                    ' .Fine = dr.Item("Fine")
                    ' .Reservation = dr.Item("Reservation")
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
    Public Shared Function FetchList() As List(Of Borrowing)


    End Function
    Public Shared Sub Delete(ByRef Delete As Borrowing)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("DELETE  FROM  Borrowing WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refBorrowing.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refBorrowing()
                    .ID = dr.Item("ID")
                    .Student = dr.Item("Student")
                    .Book = dr.Item("Book")
                    .Type = dr.Item("Type")
                    .Period = dr.Item("Period")
                    .LendingDate = dr.Item("Student")
                    .ReturnDate = dr.Item("ReturnDate")
                    .Fine = dr.Item("Fine")
                    .Reservation = dr.Item("Reservation")
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

    Private Shared Function refBorrowing() As Object
        Throw New NotImplementedException
    End Function
End Class
