Public Class Col分类阶元
    Private id As UInteger, name As String

    Public ReadOnly Property Content As String
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property ItemsSource As String
        Get
            Throw New NotImplementedException()
        End Get
    End Property
    Sub New(id As UInteger, name As String)
        Me.id = id
        Me.name = name
    End Sub
End Class
