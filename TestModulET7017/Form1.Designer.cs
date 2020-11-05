namespace TestModulET7017
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.butRangeMax = new System.Windows.Forms.Button();
            this.textValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMinRange = new System.Windows.Forms.TextBox();
            this.textBoxMaxRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxChanel1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxChanel2 = new System.Windows.Forms.CheckBox();
            this.checkBoxChanel3 = new System.Windows.Forms.CheckBox();
            this.checkBoxChanel4 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.timerOprosa = new System.Windows.Forms.Timer(this.components);
            this.butRangeMin = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butRangeMax
            // 
            this.butRangeMax.Location = new System.Drawing.Point(173, 206);
            this.butRangeMax.Name = "butRangeMax";
            this.butRangeMax.Size = new System.Drawing.Size(85, 30);
            this.butRangeMax.TabIndex = 0;
            this.butRangeMax.Text = "Range Max";
            this.butRangeMax.UseVisualStyleBackColor = true;
            this.butRangeMax.Click += new System.EventHandler(this.butRangeMax_Click);
            // 
            // textValue
            // 
            this.textValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textValue.Location = new System.Drawing.Point(120, 22);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(125, 20);
            this.textValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Значение, мВ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Заданный диапозон";
            // 
            // textBoxMinRange
            // 
            this.textBoxMinRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMinRange.Location = new System.Drawing.Point(127, 78);
            this.textBoxMinRange.Name = "textBoxMinRange";
            this.textBoxMinRange.Size = new System.Drawing.Size(49, 20);
            this.textBoxMinRange.TabIndex = 4;
            this.textBoxMinRange.Text = "val";
            // 
            // textBoxMaxRange
            // 
            this.textBoxMaxRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMaxRange.Location = new System.Drawing.Point(189, 78);
            this.textBoxMaxRange.Name = "textBoxMaxRange";
            this.textBoxMaxRange.Size = new System.Drawing.Size(56, 20);
            this.textBoxMaxRange.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Мин., мВ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max, мВ";
            // 
            // checkBoxChanel1
            // 
            this.checkBoxChanel1.AutoSize = true;
            this.checkBoxChanel1.Location = new System.Drawing.Point(15, 133);
            this.checkBoxChanel1.Name = "checkBoxChanel1";
            this.checkBoxChanel1.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel1.TabIndex = 8;
            this.checkBoxChanel1.Text = "Канал1";
            this.checkBoxChanel1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Состояние дискретных \r\nканалов:";
            // 
            // checkBoxChanel2
            // 
            this.checkBoxChanel2.AutoSize = true;
            this.checkBoxChanel2.Location = new System.Drawing.Point(15, 156);
            this.checkBoxChanel2.Name = "checkBoxChanel2";
            this.checkBoxChanel2.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel2.TabIndex = 10;
            this.checkBoxChanel2.Text = "Канал2";
            this.checkBoxChanel2.UseVisualStyleBackColor = true;
            // 
            // checkBoxChanel3
            // 
            this.checkBoxChanel3.AutoSize = true;
            this.checkBoxChanel3.Location = new System.Drawing.Point(15, 179);
            this.checkBoxChanel3.Name = "checkBoxChanel3";
            this.checkBoxChanel3.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel3.TabIndex = 11;
            this.checkBoxChanel3.Text = "Канал3";
            this.checkBoxChanel3.UseVisualStyleBackColor = true;
            // 
            // checkBoxChanel4
            // 
            this.checkBoxChanel4.AutoSize = true;
            this.checkBoxChanel4.Location = new System.Drawing.Point(15, 202);
            this.checkBoxChanel4.Name = "checkBoxChanel4";
            this.checkBoxChanel4.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel4.TabIndex = 12;
            this.checkBoxChanel4.Text = "Канал4";
            this.checkBoxChanel4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelConnect,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(270, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelConnect
            // 
            this.toolStripStatusLabelConnect.Name = "toolStripStatusLabelConnect";
            this.toolStripStatusLabelConnect.Size = new System.Drawing.Size(148, 17);
            this.toolStripStatusLabelConnect.Text = "Состояние подключения ";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // timerOprosa
            // 
            this.timerOprosa.Tick += new System.EventHandler(this.timerOprosa_Tick);
            // 
            // butRangeMin
            // 
            this.butRangeMin.Location = new System.Drawing.Point(173, 171);
            this.butRangeMin.Name = "butRangeMin";
            this.butRangeMin.Size = new System.Drawing.Size(85, 30);
            this.butRangeMin.TabIndex = 14;
            this.butRangeMin.Text = "Range Min";
            this.butRangeMin.UseVisualStyleBackColor = true;
            this.butRangeMin.Click += new System.EventHandler(this.butRangeMin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
            this.Controls.Add(this.butRangeMin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBoxChanel4);
            this.Controls.Add(this.checkBoxChanel3);
            this.Controls.Add(this.checkBoxChanel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxChanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMaxRange);
            this.Controls.Add(this.textBoxMinRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.butRangeMax);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butRangeMax;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMinRange;
        private System.Windows.Forms.TextBox textBoxMaxRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxChanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxChanel2;
        private System.Windows.Forms.CheckBox checkBoxChanel3;
        private System.Windows.Forms.CheckBox checkBoxChanel4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnect;
        private System.Windows.Forms.Timer timerOprosa;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.Button butRangeMin;
    }
}

