' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports System.IO
Imports EmberAPI

Public Class frmTMDBInfoSettingsHolder

#Region "Events"

	Public Event ModuleSettingsChanged()

	Public Event SetupScraperChanged(ByVal state As Boolean, ByVal difforder As Integer)

#End Region	'Events

#Region "Methods"

	Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
		Dim order As Integer = ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.AssemblyName = EmberTMDBScraperModule._AssemblyName).ScraperOrder
		If order < ModulesManager.Instance.externalScrapersModules.Where(Function(y) y.ProcessorModule.IsScraper).Count - 1 Then
			ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.ScraperOrder = order + 1).ScraperOrder = order
			ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.AssemblyName = EmberTMDBScraperModule._AssemblyName).ScraperOrder = order + 1
			RaiseEvent SetupScraperChanged(cbEnabled.Checked, 1)
			orderChanged()
		End If
	End Sub

	Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
		Dim order As Integer = ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.AssemblyName = EmberTMDBScraperModule._AssemblyName).ScraperOrder
		If order > 0 Then
			ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.ScraperOrder = order - 1).ScraperOrder = order
			ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.AssemblyName = EmberTMDBScraperModule._AssemblyName).ScraperOrder = order - 1
			RaiseEvent SetupScraperChanged(cbEnabled.Checked, -1)
			orderChanged()
		End If
	End Sub

	Private Sub cbEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEnabled.CheckedChanged
		RaiseEvent SetupScraperChanged(cbEnabled.Checked, 0)
	End Sub

	Private Sub chkCrew_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCrew.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkCast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCast.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkGenre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGenre.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkMPAA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMPAA.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkOutline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOutline.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkRating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRating.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkRelease_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRelease.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkRuntime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRuntime.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkStudio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStudio.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkTagline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTagline.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkTitle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTitle.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkCountry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCountry.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkTrailer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrailer.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkVotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVotes.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkYear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYear.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub chkFallBackEng_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFallBackEng.CheckedChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub cbTMDBPrefLanguage_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTMDBPrefLanguage.SelectedIndexChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Private Sub txtTMDBApiKey_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTMDBApiKey.TextChanged
		RaiseEvent ModuleSettingsChanged()
	End Sub

	Public Sub New()
		InitializeComponent()
		Me.SetUp()
	End Sub

	Sub orderChanged()
		Dim order As Integer = ModulesManager.Instance.externalScrapersModules.FirstOrDefault(Function(p) p.AssemblyName = EmberTMDBScraperModule._AssemblyName).ScraperOrder
		btnDown.Enabled = (order < ModulesManager.Instance.externalScrapersModules.Where(Function(y) y.ProcessorModule.IsScraper).Count - 1)
		btnUp.Enabled = (order > 1)
	End Sub

	Private Sub SetUp()
		Me.Label18.Text = Master.eLang.GetString(854, "TMDB API Key:")
		Me.gbOptions.Text = Master.eLang.GetString(6, "Scraper Fields - Scraper specific")
		Me.chkStudio.Text = Master.eLang.GetString(395, "Studio", True)
		Me.chkRuntime.Text = Master.eLang.GetString(396, "Runtime", True)
		Me.chkOutline.Text = Master.eLang.GetString(64, "Plot Outline", True)
		Me.chkGenre.Text = Master.eLang.GetString(20, "Genres", True)
		Me.chkTagline.Text = Master.eLang.GetString(397, "Tagline", True)
		Me.chkCast.Text = Master.eLang.GetString(856, "Cast and Crew", True)
		Me.chkVotes.Text = Master.eLang.GetString(399, "Votes", True)
		Me.chkTrailer.Text = Master.eLang.GetString(151, "Trailer", True)
		Me.chkRating.Text = Master.eLang.GetString(400, "Rating", True)
		Me.chkRelease.Text = Master.eLang.GetString(57, "Release Date", True)
		Me.chkMPAA.Text = Master.eLang.GetString(859, "MPAA & Certification", True)
		Me.chkYear.Text = Master.eLang.GetString(278, "Year", True)
		Me.chkTitle.Text = Master.eLang.GetString(21, "Title", True)
		'Me.chkCertification.Text = Master.eLang.GetString(722, "Certification", True)
		Me.Label2.Text = Master.eLang.GetString(168, "Scrape Order", True)
		Me.cbEnabled.Text = Master.eLang.GetString(774, "Enabled", True)
		Me.chkFallBackEng.Text = Master.eLang.GetString(114, "Fall back on english")
		Me.Label3.Text = Master.eLang.GetString(115, "Preferred Language:")

		Me.Label1.Text = String.Format(Master.eLang.GetString(103, "These settings are specific to this module.{0}Please refer to the global settings for more options."), vbCrLf)
	End Sub

	
#End Region	'Methods

End Class