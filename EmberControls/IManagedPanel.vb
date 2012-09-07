Public Interface IManagedPanel
    Event ControlValueChanged(ByVal e As ManagedPanel.ControlValueChangedArgs)
    Sub SaveSettings()
    Sub LoadResources()
    Sub LoadSettings()
    Sub Setup()
End Interface
