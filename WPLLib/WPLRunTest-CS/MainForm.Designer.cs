namespace WPLRunTest_CS
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.MusicList = new System.Windows.Forms.ListBox();
            this.LoadBT = new System.Windows.Forms.Button();
            this.SaveBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MusicList
            // 
            this.MusicList.AllowDrop = true;
            this.MusicList.FormattingEnabled = true;
            this.MusicList.ItemHeight = 12;
            this.MusicList.Location = new System.Drawing.Point(12, 40);
            this.MusicList.Name = "MusicList";
            this.MusicList.ScrollAlwaysVisible = true;
            this.MusicList.Size = new System.Drawing.Size(350, 244);
            this.MusicList.TabIndex = 8;
            this.MusicList.DragDrop += new System.Windows.Forms.DragEventHandler(this.MusicList_DragDrop);
            this.MusicList.DragEnter += new System.Windows.Forms.DragEventHandler(this.MusicList_DragEnter);
            // 
            // LoadBT
            // 
            this.LoadBT.Location = new System.Drawing.Point(98, 11);
            this.LoadBT.Name = "LoadBT";
            this.LoadBT.Size = new System.Drawing.Size(75, 23);
            this.LoadBT.TabIndex = 7;
            this.LoadBT.Text = "Load";
            this.LoadBT.UseVisualStyleBackColor = true;
            this.LoadBT.Click += new System.EventHandler(this.LoadBT_Click);
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(17, 11);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(75, 23);
            this.SaveBT.TabIndex = 6;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 294);
            this.Controls.Add(this.MusicList);
            this.Controls.Add(this.LoadBT);
            this.Controls.Add(this.SaveBT);
            this.Name = "MainForm";
            this.Text = "MainForm CS";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox MusicList;
        internal System.Windows.Forms.Button LoadBT;
        internal System.Windows.Forms.Button SaveBT;

    }
}

