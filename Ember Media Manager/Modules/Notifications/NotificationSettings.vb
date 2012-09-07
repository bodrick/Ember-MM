Imports EmberMediaManger.API

Namespace Modules.Notifications

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

    Public Class NotificationSettings

        Protected Overrides Sub LoadSettings()
            chkOnError.Checked = AdvancedSettings.GetBooleanSetting("NotifyOnError", True)
            chkOnNewMovie.Checked = AdvancedSettings.GetBooleanSetting("NotifyOnNewMovie", False)
            chkOnMovieScraped.Checked = AdvancedSettings.GetBooleanSetting("NotifyOnMovieScraped", True)
            chkOnNewEp.Checked = AdvancedSettings.GetBooleanSetting("NotifyOnNewEp", False)
        End Sub

        Public Overrides Sub SaveSettings()
            AdvancedSettings.SetBooleanSetting("NotifyOnError", chkOnError.Checked)
            AdvancedSettings.SetBooleanSetting("NotifyOnNewMovie", chkOnNewMovie.Checked)
            AdvancedSettings.SetBooleanSetting("NotifyOnMovieScraped", chkOnMovieScraped.Checked)
            AdvancedSettings.SetBooleanSetting("NotifyOnNewEp", chkOnNewEp.Checked)
        End Sub
        Protected Overrides Sub LoadResources()            
            chkOnError.Text = Languages.On_Error
            chkOnNewMovie.Text = Languages.On_New_Movie_Added
            chkOnMovieScraped.Text = Languages.On_Movie_Scraped
            chkOnNewEp.Text = Languages.On_New_Episode_Added            
        End Sub
    End Class
End Namespace