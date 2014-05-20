Public Class Reservation

    Private _p1 As Integer
    Property ID As Integer
    Property BookID As Integer
    ReadOnly Property Book As Book
        Get
            Return New Book(Me.BookID)
        End Get
    End Property
    Property Student As Student
    Property Publisher As Publisher
End Class
