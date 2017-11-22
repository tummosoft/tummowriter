Imports System.Drawing
Imports System.IO
Public Class frmPhotoView
    Private _filepath As String
    Private _location As Point
    Sub New(filepath As String, location As Point)

        ' This call is required by the designer.
        InitializeComponent()

        _filepath = filepath
        _location = location

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmPhotoView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = _location

        If File.Exists(_filepath) Then
            PictureBox1.Image = Image.FromFile(_filepath)
        End If

    End Sub

End Class