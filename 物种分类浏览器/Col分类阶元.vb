Imports Newtonsoft.Json.Linq
Public Class Col分类阶元
    Inherits Col节点
    ReadOnly id As UInteger, name As String, total As UInteger
    ReadOnly Property Type As String
    Private iItemsSource As Collection(Of Col节点)
    Public Overrides ReadOnly Property ItemsSource As IEnumerable(Of Col节点)
        Get
            If iItemsSource Is Nothing Then
                ShowPaused = False
                Task.Run(Sub()
                             iItemsSource = New Collection(Of Col节点)
                             For Each b As JObject In DirectCast(JObject.Parse(HTTP客户端.GetStringAsync("http://www.catalogueoflife.org/col/browse/tree/fetch/taxa?id=" & id).Result)("items"), JArray)
                                 If b("type") = "species" Then
                                     iItemsSource.Add(New Col物种(b("id"), b("name"), b("total"), b("type"), b("url")))
                                 Else
                                     iItemsSource.Add(New Col分类阶元(b("id"), b("name"), UInteger.Parse(b("total").ToString.Replace(",", "")), b("type")))
                                 End If
                             Next
                             OnPropertyChanged("ItemsSource")
                         End Sub)
                Return {}
            Else
                Return iItemsSource
            End If
        End Get
    End Property
    Private Sub New(id As UInteger, name As String, total As UInteger, type As String)
        Static 翻译 As New Dictionary(Of String, String) From {{"", "界"}, {"phylum", "门"}, {"class", "纲"}, {"order", "目"}, {"superfamily", "超科"}, {"family", "科"}, {"genus", "属"}}
        Me.id = id
        Me.name = name
        Me.total = total
        Me.Type = 翻译(type)
    End Sub
    Sub New()
        id = 0
    End Sub
End Class
