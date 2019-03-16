Public Class Col集合属性
    Inherits TreeViewItem
    Shared Sub 分层装填(ItemsSource As ObservableCollection(Of TreeViewItem), value As IEnumerable(Of TreeViewItem))
        ItemsSource.Clear()
        Dim e As Single = 1 / Math.Ceiling(Math.Log(value.Count, 28)), a As UShort = value.Count ^ (1 - If(e = 1, 0, e)), b As TreeViewItem, c As New ObservableCollection(Of TreeViewItem)
        For Each b In value
            If c.Count = a Then
                ItemsSource.Add(New Col集合属性(DirectCast(c(0), Col节点).name & "~" & b.name & "，共" & c.Count & "项", c))
                c = New ObservableCollection(Of TreeViewItem)
            End If
            c.Add(b)
        Next
        If ItemsSource.Any Then
            ItemsSource.Add(New Col集合属性(DirectCast(c(0), Col节点).name & "~" & b.name & "，共" & c.Count & "项", c))
        Else
            For Each f As TreeViewItem In c
                ItemsSource.Add(f)
            Next
        End If
    End Sub
    Sub New(name As String, value As ObservableCollection(Of TreeViewItem))
        MyBase.New(name)
        Text = name
        分层装填(ItemsSource, value)
    End Sub

    Public Overrides ReadOnly Property Text As String

    Public Overrides ReadOnly Property ItemsSource As New ObservableCollection(Of TreeViewItem)

    Public Overrides ReadOnly Property HasUnrealizedChildren As Boolean = False

    Public Overrides ReadOnly Property Visibility As Visibility = Visibility.Collapsed

    Public Overrides ReadOnly Property ShowPaused As Boolean = False

    Public Overrides Sub 填充()
    End Sub
End Class
