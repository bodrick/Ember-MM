Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class ManagedPanelDesigner
    Inherits DocumentDesigner

    Private m_verbs As DesignerVerbCollection = New DesignerVerbCollection
    Private m_SelectionService As ISelectionService

    Private ReadOnly Property HostControl() As ManagedPanel
        Get
            Return DirectCast(Me.Control, ManagedPanel)
        End Get
    End Property

    Public ReadOnly Property SelectionService() As ISelectionService
        Get
            If m_SelectionService Is Nothing Then
                m_SelectionService = DirectCast(GetService(GetType(ISelectionService)), ISelectionService)
            End If
            Return m_SelectionService
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        Dim verb1 As New DesignerVerb("Select PanelManager", AddressOf OnSelectManager)
        m_verbs.Add(verb1)

    End Sub

    Private Sub OnSelectManager(ByVal sender As Object, ByVal e As EventArgs)
        If Not Me.HostControl.Parent Is Nothing Then
            Me.SelectionService.SetSelectedComponents(New Component() {Me.HostControl.Parent})
        End If
    End Sub

    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Return System.Windows.Forms.Design.SelectionRules.Visible
        End Get
    End Property

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintAdornments(pe)
        Dim penColor As Color
        If Me.Control.BackColor.GetBrightness >= 0.5 Then
            penColor = ControlPaint.Dark(Me.Control.BackColor)
        Else
            penColor = Color.White
        End If
        Dim dashedPen As New Pen(penColor)
        Dim borderRectangle As Rectangle = Me.Control.ClientRectangle
        borderRectangle.Width -= 1
        borderRectangle.Height -= 1
        dashedPen.DashStyle = Drawing2D.DashStyle.Dash
        pe.Graphics.DrawRectangle(dashedPen, borderRectangle)
        dashedPen.Dispose()
    End Sub

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Return m_verbs
        End Get
    End Property

    Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
        properties.Remove("Anchor")
        properties.Remove("TabStop")
        properties.Remove("TabIndex")
        MyBase.PostFilterProperties(properties)
    End Sub

    Public Overrides Sub OnSetComponentDefaults()
        MyBase.InitializeNewComponent(Nothing)
        Me.Control.Visible = True
    End Sub
End Class