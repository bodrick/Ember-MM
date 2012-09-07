Imports System.ComponentModel
Imports System.ComponentModel.Design

<Designer(GetType(ManagedPanelDesigner), GetType(IRootDesigner))>
<ToolboxItem(False)> _
Public Class ManagedPanel
    Inherits UserControl
    Implements IManagedPanel

    Public Event ControlValueChanged(ByVal e As ControlValueChangedArgs) Implements IManagedPanel.ControlValueChanged

    Public Class ControlValueChangedArgs
        Inherits EventArgs
        Public Sub New(val As Boolean)
            _NeedsUpdate = val
        End Sub
        Public Property NeedsUpdate As Boolean = False
    End Class

    Public Sub New()
        InitializeComponent()
        If TypeOf Me.Parent Is PanelManager Then
            MyBase.Dock = DockStyle.Fill
        End If
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    'DefaultSize
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(617, 400)
        End Get
    End Property

    Protected Overridable Sub OnControlValueChanged(sender As Object, ByVal e As EventArgs)
        If Loaded Then
            If sender IsNot Nothing Then
                If sender.Tag IsNot Nothing Then
                    Dim tags As String() = sender.Tag.ToString().ToLower().Split(","c)
                    If tags.Contains("forceupdate") Then
                        RaiseEvent ControlValueChanged(New ControlValueChangedArgs(True))
                    End If
                Else
                    RaiseEvent ControlValueChanged(New ControlValueChangedArgs(False))
                End If
            Else
                RaiseEvent ControlValueChanged(e)
            End If
        End If
    End Sub

    Protected Overridable Sub LoadResources() Implements IManagedPanel.LoadResources
        Throw New NotImplementedException()
    End Sub

    Public Overridable Sub SaveSettings() Implements IManagedPanel.SaveSettings
        Throw New NotImplementedException()
    End Sub

    Protected Overridable Sub LoadSettings() Implements IManagedPanel.LoadSettings
        Throw New NotImplementedException()
    End Sub

    Public Overridable Sub Setup() Implements IManagedPanel.Setup
        Dim allControls = Functions.GetAllControls(Of Control)(Me).OfType(Of Control)().ToList()
        For Each ctrl In allControls
            Dim tags As String()
            Dim ignoreControl As Boolean = False
            If ctrl.Tag IsNot Nothing Then
                tags = ctrl.Tag.ToString().ToLower().Split(","c)
                If tags.Contains("ignorechanges") Then
                    ignoreControl = True
                End If
            End If
            If Not ignoreControl Then
                Select Case ctrl.GetType()
                    Case GetType(CheckBox)
                        AddHandler DirectCast(ctrl, CheckBox).CheckedChanged, AddressOf OnControlValueChanged
                    Case GetType(Button)
                        AddHandler DirectCast(ctrl, Button).Click, AddressOf OnControlValueChanged
                    Case GetType(DataGridView)
                        AddHandler DirectCast(ctrl, DataGridView).CurrentCellDirtyStateChanged, AddressOf OnControlValueChanged
                    Case GetType(ComboBox)
                        AddHandler DirectCast(ctrl, ComboBox).SelectedIndexChanged, AddressOf OnControlValueChanged
                    Case GetType(TrackBar)
                        AddHandler DirectCast(ctrl, TrackBar).ValueChanged, AddressOf OnControlValueChanged
                End Select
            End If
        Next
        LoadResources()
        LoadSettings()
        _loaded = True
    End Sub

    <Browsable(False)>
    Private _loaded As Boolean
    Public ReadOnly Property Loaded As Boolean
        Get
            Return _loaded
        End Get
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), _
    DefaultValue(GetType(DockStyle), "Fill")> _
    Public Overrides Property Dock() As System.Windows.Forms.DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set(ByVal value As System.Windows.Forms.DockStyle)
            MyBase.Dock = DockStyle.Fill
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), _
    DefaultValue(GetType(AnchorStyles), "None")> _
    Public Overrides Property Anchor() As AnchorStyles
        Get
            Return AnchorStyles.None
        End Get
        Set(ByVal value As AnchorStyles)
            MyBase.Anchor = AnchorStyles.None
        End Set
    End Property

    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        MyBase.OnLocationChanged(e)
        MyBase.Location = Point.Empty
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        If TypeOf Me.Parent Is PanelManager Then
            Me.Size = Me.Parent.ClientSize
        End If
    End Sub

    Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)
        'MessageBox.Show((Me.Parent).ToString())
        'If Not (TypeOf Me.Parent Is PanelManager) AndAlso Not (Me.Parent Is Nothing) Then
        'Throw New ArgumentException("Managed Panels may only be added to a Panel Manager.")
        'End If
        MyBase.OnParentChanged(e)
    End Sub

    Public Property PanelType As String
    Public Property ImageIndex As Integer
    Public Property PanelText As String
    Public Property PanelOrder As Integer
    Public Property ParentName As String
    Public Property PanelImage As Image
End Class

