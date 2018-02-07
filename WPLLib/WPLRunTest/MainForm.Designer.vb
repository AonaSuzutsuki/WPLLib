<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SaveBT = New System.Windows.Forms.Button()
        Me.LoadBT = New System.Windows.Forms.Button()
        Me.MusicList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'SaveBT
        '
        Me.SaveBT.Location = New System.Drawing.Point(17, 13)
        Me.SaveBT.Name = "SaveBT"
        Me.SaveBT.Size = New System.Drawing.Size(75, 23)
        Me.SaveBT.TabIndex = 0
        Me.SaveBT.Text = "保存"
        Me.SaveBT.UseVisualStyleBackColor = True
        '
        'LoadBT
        '
        Me.LoadBT.Location = New System.Drawing.Point(98, 13)
        Me.LoadBT.Name = "LoadBT"
        Me.LoadBT.Size = New System.Drawing.Size(75, 23)
        Me.LoadBT.TabIndex = 1
        Me.LoadBT.Text = "読み込み"
        Me.LoadBT.UseVisualStyleBackColor = True
        '
        'MusicList
        '
        Me.MusicList.FormattingEnabled = True
        Me.MusicList.ItemHeight = 12
        Me.MusicList.Location = New System.Drawing.Point(12, 42)
        Me.MusicList.Name = "MusicList"
        Me.MusicList.ScrollAlwaysVisible = True
        Me.MusicList.Size = New System.Drawing.Size(350, 244)
        Me.MusicList.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 294)
        Me.Controls.Add(Me.MusicList)
        Me.Controls.Add(Me.LoadBT)
        Me.Controls.Add(Me.SaveBT)
        Me.Name = "MainForm"
        Me.Text = "Form1 VB"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveBT As System.Windows.Forms.Button
    Friend WithEvents LoadBT As System.Windows.Forms.Button
    Friend WithEvents MusicList As System.Windows.Forms.ListBox

End Class
