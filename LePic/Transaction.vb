Public Class Transaction
    Property ID As Integer
    Property BorrowingID As Integer
    Property ReservationID As Integer
    Property PenaltyID As Penalty
    Property LostBook As String


    ReadOnly Property Borrowing As Borrowing
        Get
            Dim br As New Borrowing(Me.BorrowingID)
            Return br

        End Get
    End Property

    ReadOnly Property Reservation As Reservation
        Get
            Dim r As New Reservation
            Return r
        End Get
    End Property

    Public Sub New()

    End Sub
    
    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DAlTransaction.FetchById(Me)
    End Sub

    Public Sub New(ByVal LostBook As String)
        Me.LostBook = LostBook
        DAlTransaction.FetchList(Me)

    End Sub
End Class