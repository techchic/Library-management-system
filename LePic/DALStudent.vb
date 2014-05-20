Imports System.Data
Imports System.Data.SqlClient
Namespace DAL

    Public Class DALStudent

        Public Shared Sub InsertOrUpdate(ByRef refStudent As Student)

            Dim cmd As New SqlCommand("INSERT INTO Student SELECT @Name,@RegistrationNumber,@Coarse,@Year,@Cellphone@EmailAddress;Set @ID=SCOPE_IDENTITY()", conn)
            Try


                If refStudent.ID > 0 Then
                    cmd = New SqlCommand("UPDATE Student Set Name= @Name,RegistrationNumber=@RegistrationNumber,Coarse=@Coarse,Year=@Year,Cellphone=@Cellphone,EmailAddress=@EmailAddress WHERE ID=@ID", conn)
                End If


                conn.Open()
                cmd.Parameters.AddWithValue("@ID", refStudent.ID)

                cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

                cmd.Parameters.AddWithValue("@Name", refStudent.Name)
                cmd.Parameters.AddWithValue("@RegistrationNumber", refStudent.RegistrationNumber)
                cmd.Parameters.AddWithValue("@Coarse", refStudent.Coarse)
                cmd.Parameters.AddWithValue("@Year", refStudent.Year)
                cmd.Parameters.AddWithValue("@Cellphone", refStudent.Cellphone)
                cmd.Parameters.AddWithValue("@EmailAddress", refStudent.Email)
                cmd.ExecuteNonQuery()

                refStudent.ID = cmd.Parameters("@ID").Value

            Catch ex As Exception
                Throw
            Finally
                conn.Close()
                cmd.Dispose()
            End Try


        End Sub

        Public Shared Sub FetchById(ByRef refStudent As Student)
            Dim cmd As New SqlCommand("SELECT * FROM Student WHERE ID=@ID", conn)
            Try

                conn.Open()

                cmd.Parameters.AddWithValue("@ID", refStudent.ID)

                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.HasRows Then

                    dr.Read()

                    With refStudent
                        .ID = dr.Item("ID")
                        .Name = dr.Item("Name")
                        .RegistrationNumber = dr.Item("RegistrationNumber")
                        .Coarse = dr.Item("Coarse")
                        .Year = dr.Item("Year")
                        .Cellphone = dr.Item("Cellphone")
                        .Email = dr.Item("EmailAddress")
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
        Public Shared Function FetchList() As List(Of Student)


        End Function
        Public Shared Sub Delete(ByRef Delete As Student)
            Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
            Dim cmd As New SqlCommand("DELETE  FROM  Student WHERE ID=@ID", conn)
            Try

                conn.Open()

                cmd.Parameters.AddWithValue("@ID", refStudent.ID)

                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.HasRows Then

                    dr.Read()

                    With refStudent()
                        .ID = dr.Item("ID")
                        .Name = dr.Item("Name")
                        .RegistrationNumber = dr.Item("RegistrationNumber")
                        .Coarse = dr.Item("Coarse")
                        .Year = dr.Item("Year")
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

        Private Shared Function refStudent() As Object
            Throw New NotImplementedException
        End Function

    End Class
End Namespace