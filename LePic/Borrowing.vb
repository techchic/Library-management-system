Public Class Borrowing
    Property ID As Integer
    Property StudentID As Integer
    Property BookID As Integer
    Property Type As String
    Property Period As Integer
    Property LendingDate As Date
    Property ReturnDate As Date
    Property PenaltyID As Integer
    Property ReservationID As Integer
    ReadOnly Property student As Student
        Get
            Dim s As New Student(Me.StudentID)
            Return s
        End Get
    End Property
    ReadOnly Property Penalty As Penalty
        Get
            Dim p As New Penalty(Me.PenaltyID)
            Return p

        End Get
    End Property
    ReadOnly Property Book As Book
        Get
            Dim b As New Book(Me.BookID)
            Return b
        End Get
    End Property
    ReadOnly Property Reservation As Reservation
        Get
            Dim r As New Reservation(Me.ReservationID)
            Return r
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DALBorrowing.FetchById(Me)
    End Sub
   
    Public Sub New(ByVal Type As String, ByVal Period As Integer, ByVal Lendingdate As Date, ByVal ReturnDate As Date)
        DALBorrowing.FetchList()
        Me.Type = Type
        Me.Period = Period
        Me.LendingDate = Lendingdate
        Me.ReturnDate = ReturnDate
    End Sub

End Class