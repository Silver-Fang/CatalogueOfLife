Imports Newtonsoft.Json.Linq

Public Class Col分类阶元
    Inherits Col节点
    ReadOnly total As UInteger, id As UInteger
    ReadOnly Property Type As String

    Public Overrides ReadOnly Property Text As String
        Get
            Return name & Type & "，共" & total & "物种"
        End Get
    End Property

    Private Sub New(id As UInteger, name As String, total As UInteger, type As String)
        MyBase.New(name)
        Me.id = id
        Static 翻译 As New Dictionary(Of String, String) From {{"", "界"}, {"phylum", "门"}, {"class", "纲"}, {"order", "目"}, {"superfamily", "超科"}, {"family", "科"}, {"genus", "属"}}
        Me.total = total
        Me.Type = 翻译(type)
    End Sub

    Sub New()
        Call 填充()
    End Sub

    Protected Overrides Function 取子节点() As IEnumerable(Of TreeViewItem)
        Dim a As JArray = JObject.Parse(HTTP客户端.GetStringAsync("http://www.catalogueoflife.org/col/browse/tree/fetch/taxa?id=" & id).Result)("items"), d As New Collection(Of TreeViewItem)
        For Each b As JObject In a
            If b("type") = "species" Then
                d.Add(New Col物种(b("name"), b("url")))
            Else
                d.Add(New Col分类阶元(b("id"), b("name"), UInteger.Parse(b("total").ToString.Replace(",", "")), b("type")))
            End If
        Next
        Return d
    End Function
End Class
