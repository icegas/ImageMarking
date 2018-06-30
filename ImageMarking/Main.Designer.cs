namespace ImageMarking
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboObjName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.objName = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Images = new System.Windows.Forms.PictureBox();
            this.Next = new System.Windows.Forms.Button();
            this.Select = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Images)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object Name:";
            // 
            // comboObjName
            // 
            this.comboObjName.FormattingEnabled = true;
            this.comboObjName.Location = new System.Drawing.Point(144, 20);
            this.comboObjName.Name = "comboObjName";
            this.comboObjName.Size = new System.Drawing.Size(121, 24);
            this.comboObjName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add Object Name:";
            // 
            // objName
            // 
            this.objName.Location = new System.Drawing.Point(144, 55);
            this.objName.Name = "objName";
            this.objName.Size = new System.Drawing.Size(121, 22);
            this.objName.TabIndex = 3;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(286, 20);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 58);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Images
            // 
            this.Images.Location = new System.Drawing.Point(12, 100);
            this.Images.Name = "Images";
            this.Images.Size = new System.Drawing.Size(100, 50);
            this.Images.TabIndex = 5;
            this.Images.TabStop = false;
            this.Images.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Images_MouseDown);
            this.Images.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Images_MouseMove);
            this.Images.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Images_MouseUp);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(377, 20);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 58);
            this.Next.TabIndex = 6;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(479, 20);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(75, 58);
            this.Select.TabIndex = 7;
            this.Select.Text = "Select";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(584, 20);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 58);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(952, 617);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Select);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Images);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.objName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboObjName);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.Images)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboObjName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox objName;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.PictureBox Images;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.Button Save;
    }
}