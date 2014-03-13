Public Class ActiveSheet

    Private _SourcePage As String
    Public Property SourcePage() As String
        Get
            Return _SourcePage
        End Get
        Set(ByVal value As String)
            _SourcePage = value
        End Set
    End Property

    Private _FileURL As String
    Public Property FileURL() As String
        Get
            Return _FileURL
        End Get
        Set(ByVal value As String)
            _FileURL = value
        End Set
    End Property

    Private _NodeID As String
    Public Property NodeID() As String
        Get
            Return _NodeID
        End Get
        Set(ByVal value As String)
            _NodeID = value
        End Set
    End Property

    Private _LocalFilePath As String
    Public Property LocalFilePath() As String
        Get
            Return _LocalFilePath
        End Get
        Set(ByVal value As String)
            _LocalFilePath = value
        End Set
    End Property

    Private _FileSize As String
    Public Property FileSize() As String
        Get
            Return _FileSize
        End Get
        Set(ByVal value As String)
            _FileSize = value
        End Set
    End Property

    Private _DateDownloaded As String
    Public Property DateDownloaded() As String
        Get
            Return _DateDownloaded
        End Get
        Set(ByVal value As String)
            _DateDownloaded = value
        End Set
    End Property

    Private _DateCreated As String
    Public Property DateCreated() As String
        Get
            Return _DateCreated
        End Get
        Set(ByVal value As String)
            _DateCreated = value
        End Set
    End Property

    Private _Title As String
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Private _Subject As String
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property



End Class
