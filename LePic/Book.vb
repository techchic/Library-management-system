Public Class Book
    Property ID As Integer
    Property BookCode As String
    Property Author As String
    Property BookName As String
    Property PublisherID As Integer
    Property ReservationID As Integer
    Property Comment As String
    ReadOnly Property Publisher As Publisher
        Get
            Dim pub As New Publisher(Me.PublisherID)
            Return pub
        End Get
    End Property
    ReadOnly Property Reservation As Reservation
        Get
            Dim reserve As New Reservation(Me.ReservationID)
            Return reserve
        End Get
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DALBook.FetchById(Me)
    End Sub
    Public Sub New(ByVal Bookcode As String, ByVal Author As String, ByVal BookName As String, ByVal Comment As String)
        Me.BookCode = Bookcode
        Me.Author = Author
        Me.BookName = BookName
        Me.Comment = Comment
        ' DALBook.FetchList(Me)

    End Sub
End Class

