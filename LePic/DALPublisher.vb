Imports System.Data
Imports System.Data.SqlClient

Public Class DALPublisher

    Private Shared Property cmd As SqlCommand

    Public Shared Sub InsertOrUpdate(ByRef refPublisher As Publisher)

        Dim command As New SqlCommand("INSERT INTO PUBLISHER SELECT @PublisherName,@PublishingYear,@Book Set @ID=SCOPE_IDENTITY()", conn)

        Try
            If refPublisher.ID > 0 Then

            End If
            cmd = New SqlCommand("UPDATE Publisher set PublisherName=@PublisherName,PublishingYear=@PublishingYear,Book=@Book  ,WHERE ID=@ID")
            conn.Open()
            cmd.Parameters.AddWithValue("@ID", refPublisher.ID)

            cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput
            cmd.Parameters.AddWithValue("@PublisherName", refPublisher.ID)
            cmd.Parameters.AddWithValue("@PublishingYear", refPublisher.ID)
            cmd.Parameters.AddWithValue("@Book", refPublisher.ID)

            cmd.ExecuteNonQuery()

            refPublisher.ID = cmd.Parameters("@ID").Value

        Catch ex As Exception
            Throw
        Finally
            conn.Close()
            cmd.Dispose()
        End Try


    End Sub

    Public Shared Sub FetchById(ByRef refBook As Publisher)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("SELECT * FROM Publisher WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refPublisher.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refPublisher()
                    .ID = dr.Item("ID")
                    .PublisherName = dr.Item("PublisherName")
                    .PublishingYear = dr.Item("PublishingYear")
                    .Book = dr.Item("Book")

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
    Public Shared Function FetchList() As List(Of Publisher)


    End Function
    Public Shared Sub Delete(ByRef Delete As Publisher)
        Dim conn As New SqlConnection("Server=Localhost;Initial Catalog=SchoolLibrarySystem;integrated security=SSPI")
        Dim cmd As New SqlCommand("DELETE  FROM    WHERE ID=@ID", conn)
        Try

            conn.Open()

            cmd.Parameters.AddWithValue("@ID", refPublisher.ID)

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then

                dr.Read()

                With refPublisher()
                    .ID = dr.Item("ID")
                    .PublisherName = dr.Item("PublisherName")
                    .PublishingYear = dr.Item("PublishingYear")
                    .Book = dr.Item("Book")
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

    Private Shared Function refPublisher() As Object
        Throw New NotImplementedException
    End Function

    Private Shared Function refPublisherName() As Object
        Throw New NotImplementedException
    End Function

    Private Shared Function refPublishingYear() As Object
        Throw New NotImplementedException
    End Function

  

End Class