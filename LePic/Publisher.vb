Public Class Publisher
    Property ID As Integer
    Property PublisherName As String
    Property PublishingYear As Date
    Property BookID As Integer
    ReadOnly Property Book As Book
        Get
            Dim b As New Book(Me.BookID)
            Return b

        End Get
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal ID As Integer)
        Me.ID = ID
        DALPublisher.FetchById(Me)
    End Sub
    Public Sub New(ByVal PublisherName As String, ByVal PublishingYear As Date)
        Me.PublisherName = PublisherName
        Me.PublishingYear = PublisherName
        DALPublisher.FetchList()

    End Sub
End Class


