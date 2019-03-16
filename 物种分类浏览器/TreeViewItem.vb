''' <summary>
''' 界面的功能需求
''' </summary>
Public MustInherit Class TreeViewItem
    Implements INotifyPropertyChanged
    MustOverride ReadOnly Property Text As String
    MustOverride ReadOnly Property ItemsSource As ObservableCollection(Of TreeViewItem)
    MustOverride ReadOnly Property HasUnrealizedChildren As Boolean
    MustOverride ReadOnly Property Visibility As Visibility
    MustOverride ReadOnly Property ShowPaused As Boolean
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    MustOverride Sub 填充()
    Friend ReadOnly name As String
    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Sub New(Optional name As String = Nothing)
        Me.name = name
    End Sub
End Class
