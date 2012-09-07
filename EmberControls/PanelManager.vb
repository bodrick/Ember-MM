Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.ComponentModel.Design


<DefaultProperty("SelectedPanel"), _
DefaultEvent("SelectedIndexChanged"), _
Designer(GetType(PanelManagerDesigner))> _
Public Class PanelManager
    Inherits System.Windows.Forms.Control

    Private m_SelectedPanel As ManagedPanel

    Public Event SelectedIndexChanged As EventHandler

    'ManagedPanels
    <Editor(GetType(ManagedPanelCollectionEditor), GetType(UITypeEditor))> _
    Public ReadOnly Property ManagedPanels() As ControlCollection
        Get
            Return MyBase.Controls
        End Get
    End Property

    'SelectedPanel
    <TypeConverter(GetType(SelectedPanelConverter))> _
    Public Property SelectedPanel() As ManagedPanel
        Get
            Return m_SelectedPanel
        End Get
        Set(ByVal Value As ManagedPanel)
            If m_SelectedPanel Is Value Then Return
            m_SelectedPanel = Value
            OnSelectedPanelChanged(EventArgs.Empty)
        End Set
    End Property

    'SelectedIndex
    <Browsable(False)> _
    Public Property SelectedIndex() As Int32
        Get
            Return Me.ManagedPanels.IndexOf(CType(Me.SelectedPanel, ManagedPanel))
        End Get
        Set(ByVal Value As Int32)
            If Value = -1 Then
                Me.SelectedPanel = Nothing
            Else
                Me.SelectedPanel = DirectCast(Me.ManagedPanels(Value), ManagedPanel)
            End If
        End Set
    End Property

    'DefaultSize
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(617, 400)
        End Get
    End Property

    Protected Overridable Sub OnSelectedPanelChanged(ByVal e As EventArgs)
        Static oldSelection As ManagedPanel = Nothing
        If Not (oldSelection Is Nothing) Then
            oldSelection.Visible = False
        End If
        If Not (m_SelectedPanel Is Nothing) Then
            CType(m_SelectedPanel, ManagedPanel).Visible = True
        End If
        Dim tabChanged As Boolean
        If m_SelectedPanel Is Nothing Then
            tabChanged = Not (oldSelection Is Nothing)
        Else
            tabChanged = Not (m_SelectedPanel.Equals(oldSelection))
        End If
        If tabChanged And Me.Created Then
            RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
        End If
        oldSelection = CType(m_SelectedPanel, ManagedPanel)
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        If Not (TypeOf e.Control Is ManagedPanel) Then            
            Throw New ArgumentException("Only Controls.ManagedPanels can be added to a Controls.PanelManger.")
        End If
        If Not (Me.SelectedPanel Is Nothing) Then
            CType(Me.SelectedPanel, ManagedPanel).Visible = False
        End If
        Me.SelectedPanel = DirectCast(e.Control, ManagedPanel)
        e.Control.Visible = True
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        If Not (TypeOf e.Control Is ManagedPanel) Then Return
        If Me.ManagedPanels.Count > 0 Then
            Me.SelectedIndex = 0
        Else
            Me.SelectedPanel = Nothing
        End If
        MyBase.OnControlRemoved(e)
    End Sub

End Class

Public Class PanelManagerDesigner
    Inherits System.Windows.Forms.Design.ParentControlDesigner

    Private m_verbs As DesignerVerbCollection = New DesignerVerbCollection
    Private m_DesignerHost As IDesignerHost
    Private m_SelectionService As ISelectionService

    Private ReadOnly Property HostControl() As PanelManager
        Get
            Return DirectCast(Me.Control, PanelManager)
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        Dim verb1 As New DesignerVerb("Add MangedPanel", AddressOf OnAddPanel)
        Dim verb2 As New DesignerVerb("Remove ManagedPanel", AddressOf OnRemovePanel)
        m_verbs.AddRange(New DesignerVerb() {verb1, verb2})

    End Sub

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        'Don't want DrawGrid Dots.
    End Sub

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            If m_verbs.Count = 2 Then
                If HostControl.ManagedPanels.Count > 0 Then
                    m_verbs(1).Enabled = True
                Else
                    m_verbs(1).Enabled = False
                End If
            End If
            Return m_verbs
        End Get
    End Property

    Public ReadOnly Property DesignerHost() As IDesignerHost
        Get
            If m_DesignerHost Is Nothing Then
                m_DesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)
            End If
            Return m_DesignerHost
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

    Private Sub OnAddPanel(ByVal sender As Object, ByVal e As EventArgs)

        Dim oldManagedPanels As Control.ControlCollection = HostControl.Controls

        RaiseComponentChanging(TypeDescriptor.GetProperties(HostControl)("ManagedPanels"))

        Dim P As ManagedPanel = DirectCast(DesignerHost.CreateComponent(GetType(ManagedPanel)), ManagedPanel)
        P.Text = P.Name
        HostControl.ManagedPanels.Add(P)

        RaiseComponentChanged(TypeDescriptor.GetProperties(HostControl)("ManagedPanels"), oldManagedPanels, HostControl.ManagedPanels)
        HostControl.SelectedPanel = P

        SetVerbs()

    End Sub

    Private Sub OnRemovePanel(ByVal sender As Object, ByVal e As EventArgs)

        Dim oldManagedPanels As Control.ControlCollection = HostControl.Controls

        If HostControl.SelectedIndex < 0 Then Return

        RaiseComponentChanging(TypeDescriptor.GetProperties(HostControl)("TabPages"))

        DesignerHost.DestroyComponent(CType(HostControl.ManagedPanels(HostControl.SelectedIndex), ManagedPanel))

        RaiseComponentChanged(TypeDescriptor.GetProperties(HostControl)("ManagedPanels"), oldManagedPanels, HostControl.ManagedPanels)

        SelectionService.SetSelectedComponents(New IComponent() {HostControl}, SelectionTypes.Auto)

        SetVerbs()
    End Sub

    Private Sub SetVerbs()

        Select Case HostControl.ManagedPanels.Count
            Case 0
                Verbs(1).Enabled = False
            Case 1
                Verbs(1).Enabled = True
        End Select

    End Sub

    Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
        properties.Remove("AutoScroll")
        properties.Remove("AutoScrollMargin")
        properties.Remove("AutoScrollMinSize")
        properties.Remove("Text")
        MyBase.PostFilterProperties(properties)
    End Sub

    Public Overrides Sub OnSetComponentDefaults()
        HostControl.ManagedPanels.Add(DirectCast(DesignerHost.CreateComponent(GetType(ManagedPanel)), ManagedPanel))
        HostControl.ManagedPanels.Add(DirectCast(DesignerHost.CreateComponent(GetType(ManagedPanel)), ManagedPanel))
        Dim pm As PanelManager = DirectCast(Me.Control, PanelManager)
        pm.ManagedPanels(0).Text = pm.ManagedPanels(0).Name
        pm.ManagedPanels(1).Text = pm.ManagedPanels(1).Name
        HostControl.SelectedIndex = 0
    End Sub

End Class

Public Class ManagedPanelCollectionEditor
    Inherits System.ComponentModel.Design.CollectionEditor

    Public Sub New(ByVal type As Type)
        MyBase.New(type)
    End Sub

    Protected Overrides Function CreateCollectionItemType() As System.Type
        Return GetType(ManagedPanel)
    End Function

End Class



Public Class SelectedPanelConverter
    Inherits ReferenceConverter

    Public Sub New()
        MyBase.New(GetType(ManagedPanel))
    End Sub

    Protected Overrides Function IsValueAllowed(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object) As Boolean
        If Not (context Is Nothing) Then
            Dim pm As PanelManager = DirectCast(context.Instance, PanelManager)
            Return pm.ManagedPanels.Contains(CType(value, ManagedPanel))
        End If
        Return False
    End Function

End Class

