Public Class Student
    Public Sub New()

    End Sub
    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DALStudent.FetchById(Me)
    End Sub
    Public Sub New(ByVal Name As String, ByVal RegistrationNumber As String, ByVal coarse As String, ByVal year As Integer, ByVal cell As String, ByVal email As String)
        Me.Name = Name
        Me.RegistrationNumber = RegistrationNumber
        Me.Coarse = coarse
        Me.Year = year
        Me.Cellphone = Cellphone
        Me.Email = email
        DALStudent.FetchList()

    End Sub
    Property ID As Integer
    Property Name As String
    Property RegistrationNumber As String
    Property Coarse As String
    Property Year As Integer
    Property Cellphone As Integer
    Property Email As String

    
End Class
