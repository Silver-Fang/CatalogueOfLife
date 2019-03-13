Imports Newtonsoft.Json.Linq
Structure 分类层次
    Property 层次 As String
    Property 名称 As String
End Structure
Structure 俗名语言
    Property 俗名 As String
    Property 语言 As String
End Structure
Class Col物种
    Inherits Col节点
    ReadOnly HexId As String
    ReadOnly Property Text As String
    Sub New(id As UInteger, name As String, total As UShort, type As String, url As String)
        MyBase.New(id, name, total, type)
        HexId = url.Split("/")(5)
    End Sub
    Private 接受名 As String, 俗名 As IEnumerable(Of 俗名语言), 分类 As IEnumerable(Of 分类层次)
    Private Sub 获取明细()
        Dim a As JObject = JObject.Parse(HTTP客户端.GetStringAsync("http://webservice.catalogueoflife.org/col/webservice?response=full&format=json&id=" & HexId).Result)("results")(0)
        接受名 = a("name")
        Dim c As New Collection(Of 分类层次)
        For Each b As JObject In a("classification")
            c.Add(New 分类层次 With {.名称 = b("name"), .层次 = b("rank")})
        Next
        分类 = c
        Dim d As New Collection(Of 俗名语言)
        For Each b As JObject In a("common_names")
            d.Add(New 俗名语言 With {.俗名 = b("name"), .语言 = b("language")})
        Next
        俗名 = d
    End Sub
    ReadOnly Property AcceptedScientificName As String
        Get
            If 接受名 Is Nothing Then 获取明细()
            Return 接受名
        End Get
    End Property
    ReadOnly Property CommonNames As IEnumerable(Of 俗名语言)
        Get
            If 俗名 Is Nothing Then 获取明细()
            Return 俗名
        End Get
    End Property
    ReadOnly Property Classification As IEnumerable(Of 分类层次)
        Get
            If 分类 Is Nothing Then 获取明细()
            Return 分类
        End Get
    End Property
End Class
