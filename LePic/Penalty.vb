Public Class Penalty
    Public Sub New()

    End Sub
    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DALPenalty.FetchbyID(Me)
    End Sub

    Property ID As Integer
    Property StudentID As Integer
    Property BorrowingID As Integer


    ReadOnly Property Student As Student
        Get
            Dim st As New Student(Me.StudentID)
            Return st
        End Get
    End Property

    ReadOnly Property Borrowing As Borrowing
        Get
            Dim br As New Borrowing(Me.BorrowingID)
            Return br

        End Get
    End Property

  
   
End Class
