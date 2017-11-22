'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/18/2016
' * Time: 1:26 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DataModel
    Public Class Node
        Implements IEnumerable(Of Node)
        Public Property Title() As String
            Get
                Return m_Title
            End Get
            Set
                m_Title = Value
            End Set
        End Property
        Private m_Title As String
        Public Property Childs() As List(Of Node)
            Get
                Return m_Childs
            End Get
            Private Set
                m_Childs = Value
            End Set
        End Property
        Private m_Childs As List(Of Node)
        Public Property Parent() As Node
            Get
                Return m_Parent
            End Get
            Set
                m_Parent = Value
            End Set
        End Property
        Private m_Parent As Node
        Public Property FileName() As String
            Get
                Return m_FileName
            End Get
            Set
                m_FileName = Value
            End Set
        End Property
        Private m_FileName As String
        Public Property Type() As Integer
            Get
                Return m_Type
            End Get
            Set
                m_Type = Value
            End Set
        End Property
        Private m_Type As Integer
        Public Sub New(_type As Integer, title__1 As String, _filename As String)
            Title = title__1
            Type = _type
            FileName = _filename
            Childs = New List(Of Node)()
        End Sub

        Public Function GetEnumerator() As IEnumerator(Of Node) Implements IEnumerable(Of Node).GetEnumerator
            Return Childs.GetEnumerator()
        End Function

        Private Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Childs.GetEnumerator()
        End Function

        Public Overrides Function ToString() As String
            Return Title
        End Function

        Public Function IsChildOf(parent__1 As Node) As Boolean
            Return parent__1 Is Parent OrElse (Parent IsNot Nothing AndAlso Parent.IsChildOf(parent__1))
        End Function

        Public Sub AddChild(child As Node)
            Childs.Add(child)
            child.Parent = Me
        End Sub

        Public Sub InsertChild(child As Node, index As Integer)
            Childs.Insert(index, child)
            child.Parent = Me
        End Sub

        Public Sub RemoveChild(child As Node)
            Childs.Remove(child)
            child.Parent = Nothing
        End Sub
    End Class
End Namespace

