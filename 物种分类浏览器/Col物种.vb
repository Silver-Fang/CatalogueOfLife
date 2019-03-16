Imports Newtonsoft.Json.Linq

Class Col物种
    Inherits Col节点
    ReadOnly HexId As String
    Sub New(name As String, url As String)
        MyBase.New(name)
        HexId = url.Split("/")(5)
    End Sub

    Public Overrides ReadOnly Property Text As String
        Get
            Return name & "种"
        End Get
    End Property

    Protected Overrides Function 取子节点() As IEnumerable(Of TreeViewItem)
        Dim a As JObject = JObject.Parse(HTTP客户端.GetStringAsync("http://webservice.catalogueoflife.org/col/webservice?response=full&format=json&id=" & HexId).Result)("results")(0), d As New Collection(Of TreeViewItem) From {New Col简单属性("接受名", a("name"))}
        Dim c As New ObservableCollection(Of TreeViewItem)
        For Each b As JObject In a("classification")
            c.Add(New Col简单属性(b("rank"), b("name")))
        Next
        d.Add(New Col集合属性("分类", c))
        c = New ObservableCollection(Of TreeViewItem)
        For Each b As JObject In a("common_names")
            c.Add(New Col简单属性(b("language"), b("name")))
        Next
        d.Add(New Col集合属性("俗名", c))
        Return d
    End Function
End Class
