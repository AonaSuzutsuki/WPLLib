Option Strict On

Imports System.Xml
Imports System.Text
Imports WPLLib

Public Class MainForm

    Dim media As ArrayList
    Dim wplclass As New WPLControl
    Private Sub SaveBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBT.Click
        Dim sfd As New SaveFileDialog()

        sfd.FileName = ""
        sfd.InitialDirectory = "C:\"
        sfd.Filter = _
         "Windows Play List(*.wpl)|*.wpl|すべてのファイル(*.*)|*.*"
        sfd.FilterIndex = 1
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        sfd.OverwritePrompt = True
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then
            wplclass.WPLCreate(sfd.FileName, media)
        End If
    End Sub

    Private Sub LoadBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadBT.Click
        Dim ofd As New OpenFileDialog()

        ofd.FileName = ""
        ofd.InitialDirectory = "C:\"
        ofd.Filter = _
            "Windows Play List(*.wpl)|*.wpl|すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then
            media = wplclass.WPLLoad(ofd.FileName)
            For i = 0 To media.Count - 1
                MusicList.Items.Add(media.Item(i).ToString())
            Next
        End If
    End Sub
End Class
