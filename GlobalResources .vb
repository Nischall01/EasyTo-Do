Imports System.Drawing.Text
Imports System.Media

Module GlobalResources
    'Embedded Font

    Public ReadOnly DefaultFont As New Font(MainWindow.PrivateFonts.Families(0), 13)

    ' Image cache variables

    Public ReadOnly ModeSwitch_Light As Image = My.Resources.ModeSwitch_Light_
    Public ReadOnly ModeSwitch_Dark As Image = My.Resources.ModeSwitch_Dark_

    Public ReadOnly FullscreenIcon_White As Image = My.Resources.FullscreenIcon_White_
    Public ReadOnly FullscreenIcon_Black As Image = My.Resources.FullScreenIcon_Black_
    Public ReadOnly CancelIcon_White As Image = My.Resources.CloseIcon_White_
    Public ReadOnly CancelIcon_Black As Image = My.Resources.CloseIcon_Black_
    Public ReadOnly MinimizeIcon_White As Image = My.Resources.MinimizeIcon_White_
    Public ReadOnly MinimizeIcon_Black As Image = My.Resources.MinimizeIcon_Black_
    Public ReadOnly RestoreIcon_White As Image = My.Resources.RestoreIcon_White_
    Public ReadOnly RestoreIcon_Black As Image = My.Resources.RestoreIcon_Black_

    Public ReadOnly SettingsIcon_Black As Image = My.Resources.SettingsIcon_Black_
    Public ReadOnly SettingsIcon_White As Image = My.Resources.SettingsIcon_White_

    Public ReadOnly ImportantIcon_Unchecked_Black As Image = My.Resources.ImportantIcon_Black_
    Public ReadOnly ImportantIcon_Unchecked_White As Image = My.Resources.ImportantIcon_White_
    Public ReadOnly ImportantIcon_Checked As Image = My.Resources.ImportantIcon_HoverAndMark_
    Public ReadOnly ImportantIcon_Disabled As Image = My.Resources.ImportantIcon_Disabled_

    Public ReadOnly ReminderIcon_White As Image = My.Resources.ReminderIcon_White_
    Public ReadOnly ReminderIcon_Black As Image = My.Resources.ReminderIcon_Black_
    Public ReadOnly RepeatIcon_White As Image = My.Resources.RepeatIcon_White_
    Public ReadOnly RepeatIcon_Black As Image = My.Resources.RepeatIcon_Black_
    Public ReadOnly DueDateIcon_White As Image = My.Resources.DueDateIcon_White_
    Public ReadOnly DueDateIcon_Black As Image = My.Resources.DueDateIcon_Black_

    Public ReadOnly DeleteIcon_White As Image = My.Resources.DeleteIcon_White_
    Public ReadOnly DeleteIcon_Black As Image = My.Resources.DeleteIcon_Black_
    Public ReadOnly DeleteIcon_Hover As Image = My.Resources.DeleteIcon_Hover_

    ' Indicators

    Public ReadOnly importantTaskIndicator As String = "[ ! ]"
    Public ReadOnly repeatedTaskIndicator As String = "[R]"

    Public ReadOnly sound_FilePath As String = "D:\_Programs\_Visual_Studio_Workspace\EasyTo-Do\Resources\Bling.wav"
    Public SFXPlayer As New SoundPlayer(sound_FilePath)

End Module