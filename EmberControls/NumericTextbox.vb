Public Class IntegerTextbox
    Inherits TextBox
    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If [Char].IsNumber(e.KeyChar) OrElse [Char].IsControl(e.KeyChar) Then
        Else
            ' Consume this invalid key and beep.
            e.Handled = True
        End If
    End Sub

    Public ReadOnly Property IntValue() As Integer
        Get
            Dim returnValue As Int32
            Int32.TryParse(Me.Text, returnValue)
            Return returnValue
        End Get
    End Property
End Class
