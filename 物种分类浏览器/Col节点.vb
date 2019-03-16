Public MustInherit Class Col节点
    Inherits TreeViewItem
    Protected HTTP客户端 As New Net.Http.HttpClient
    Private iItemsSource As ObservableCollection(Of TreeViewItem)
    Public Overrides ReadOnly Property ItemsSource As ObservableCollection(Of TreeViewItem)
        Get
            If iItemsSource Is Nothing Then
                iItemsSource = New ObservableCollection(Of TreeViewItem) From {New Col简单属性("加载中", "")}
                填充()
                Return iItemsSource
            Else
                Return iItemsSource
            End If
        End Get
    End Property
    Private iHasUnrealizedChildren = True
    Private Property RwHasUnrealizedChildren As Boolean
        Get
            Return iHasUnrealizedChildren
        End Get
        Set(value As Boolean)
            iHasUnrealizedChildren = value
            OnPropertyChanged("HasUnrealizedChildren")
        End Set
    End Property
    Public Overrides ReadOnly Property HasUnrealizedChildren As Boolean
        Get
            Return RwHasUnrealizedChildren
        End Get
    End Property

    Public Overrides ReadOnly Property Visibility As Visibility
        Get
            Return If(ShowPaused, Visibility.Collapsed, Visibility.Visible)
        End Get
    End Property
    Private iShowPaused As Boolean = True
    Private Property RwShowPaused As Boolean
        Get
            Return iShowPaused
        End Get
        Set(value As Boolean)
            iShowPaused = value
            OnPropertyChanged("ShowPaused")
            OnPropertyChanged("Visibility")
        End Set
    End Property
    Public Overrides ReadOnly Property ShowPaused As Boolean
        Get
            Return RwShowPaused
        End Get
    End Property
    Protected MustOverride Function 取子节点() As IEnumerable(Of TreeViewItem)
    Public Overrides Async Sub 填充()
        RwHasUnrealizedChildren = False
        RwShowPaused = False
        iItemsSource = If(iItemsSource, New ObservableCollection(Of TreeViewItem))
        Col集合属性.分层装填(iItemsSource, Await Task.Run(Function() 取子节点()))
        RwShowPaused = True
    End Sub
    Sub New(Optional name As String = Nothing)
        MyBase.New(name)
    End Sub
End Class