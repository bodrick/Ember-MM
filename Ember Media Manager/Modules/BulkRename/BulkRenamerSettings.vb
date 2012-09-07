Imports EmberMediaManger.API

Namespace Modules.BulkRename
    Public Class BulkRenamerSettings        
        Protected Overrides Sub LoadSettings()
            txtFolderPattern.Text = AdvancedSettings.GetSetting("FoldersPattern", "$T {($Y)}")
            txtFilePattern.Text = AdvancedSettings.GetSetting("FilesPattern", "$T{.$S}")
            chkRenameMulti.Checked = AdvancedSettings.GetBooleanSetting("AutoRenameMulti", False)
            chkRenameSingle.Checked = AdvancedSettings.GetBooleanSetting("AutoRenameSingle", False)
            chkGenericModule.Checked = AdvancedSettings.GetBooleanSetting("GenericModule", True)
            chkBulkRenamer.Checked = AdvancedSettings.GetBooleanSetting("BulkRenamer", True)
        End Sub

        Public Overrides Sub SaveSettings()
            AdvancedSettings.SetSetting("FoldersPattern", txtFolderPattern.Text)
            AdvancedSettings.SetSetting("FilesPattern", txtFilePattern.Text)
            AdvancedSettings.SetBooleanSetting("AutoRenameMulti", chkRenameMulti.Checked)
            AdvancedSettings.SetBooleanSetting("AutoRenameSingle", chkRenameSingle.Checked)
            AdvancedSettings.SetBooleanSetting("BulkRenamer", chkGenericModule.Checked)
            AdvancedSettings.SetBooleanSetting("GenericModule", chkBulkRenamer.Checked)
        End Sub

        Protected Overrides Sub LoadResources()
            chkRenameMulti.Text = Languages.Automatically_Rename_Files_During_Multi_Scraper
            chkRenameSingle.Text = Languages.Automatically_Rename_Files_During_Single_Scraper
            gbRenamerPatterns.Text = Languages.Default_Renaming_Patterns
            lblFilePattern.Text = Languages.Files_Pattern
            lblFolderPattern.Text = Languages.Folders_Pattern
            chkGenericModule.Text = Languages.Enable_Generic_Rename_Module
            chkBulkRenamer.Text = Languages.Enable_Bulk_Renamer_Tool
            lblBulkRenameHelp.Text = String.Format(Languages.BulkRenameHelp, vbNewLine)
        End Sub
    End Class
End Namespace