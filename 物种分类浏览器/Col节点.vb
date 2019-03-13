Public MustInherit Class Col节点
    Implements INotifyPropertyChanged
    MustOverride ReadOnly Property Text As String
    MustOverride ReadOnly Property ItemsSource As IEnumerable(Of Col节点)
    Private iShowPaused As Boolean = True
    Property HasUnrealizedChildren As Boolean = True
    Property ShowPaused As Boolean
        Get
            Return iShowPaused
        End Get
        Set(value As Boolean)
            iShowPaused = value
            OnPropertyChanged("ShowPaused")
            OnPropertyChanged("Visibility")
        End Set
    End Property
    ReadOnly Property Visibility As Visibility
        Get
            Return If(ShowPaused, Visibility.Collapsed, Visibility.Visible)
        End Get
    End Property
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Shared ReadOnly HTTP客户端 As New Net.Http.HttpClient
    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
