Public Class Col简单属性
    Inherits TreeViewItem
    ReadOnly 值 As String
    Public Overrides ReadOnly Property Text As String
        Get
            Return name & "：" & 值
        End Get
    End Property

    Public Overrides ReadOnly Property ItemsSource As ObservableCollection(Of TreeViewItem)

    Public Overrides ReadOnly Property HasUnrealizedChildren As Boolean = False

    Public Overrides ReadOnly Property Visibility As Visibility = Visibility.Collapsed

    Public Overrides ReadOnly Property ShowPaused As Boolean = True
    Sub New(name As String, 值 As String)
        MyBase.New(name)
        Me.值 = 值
    End Sub

    Public Overrides Sub 填充()
    End Sub
End Class
