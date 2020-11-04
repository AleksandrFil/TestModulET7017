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
            this.butDiapozon = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // butDiapozon
            // 
            this.butDiapozon.Location = new System.Drawing.Point(114, 209);
            this.butDiapozon.Name = "butDiapozon";
            this.butDiapozon.Size = new System.Drawing.Size(144, 40);
            this.butDiapozon.TabIndex = 0;
            this.butDiapozon.Text = "Переключение диапозона";
            this.butDiapozon.UseVisualStyleBackColor = true;
            this.butDiapozon.Click += new System.EventHandler(this.butDiapozon_Click);
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
            this.checkBoxChanel1.Location = new System.Drawing.Point(15, 163);
            this.checkBoxChanel1.Name = "checkBoxChanel1";
            this.checkBoxChanel1.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel1.TabIndex = 8;
            this.checkBoxChanel1.Text = "Канал1";
            this.checkBoxChanel1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Состояние дискретных \r\nканалов:";
            // 
            // checkBoxChanel2
            // 
            this.checkBoxChanel2.AutoSize = true;
            this.checkBoxChanel2.Location = new System.Drawing.Point(15, 186);
            this.checkBoxChanel2.Name = "checkBoxChanel2";
            this.checkBoxChanel2.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel2.TabIndex = 10;
            this.checkBoxChanel2.Text = "Канал2";
            this.checkBoxChanel2.UseVisualStyleBackColor = true;
            // 
            // checkBoxChanel3
            // 
            this.checkBoxChanel3.AutoSize = true;
            this.checkBoxChanel3.Location = new System.Drawing.Point(15, 209);
            this.checkBoxChanel3.Name = "checkBoxChanel3";
            this.checkBoxChanel3.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel3.TabIndex = 11;
            this.checkBoxChanel3.Text = "Канал3";
            this.checkBoxChanel3.UseVisualStyleBackColor = true;
            // 
            // checkBoxChanel4
            // 
            this.checkBoxChanel4.AutoSize = true;
            this.checkBoxChanel4.Location = new System.Drawing.Point(15, 232);
            this.checkBoxChanel4.Name = "checkBoxChanel4";
            this.checkBoxChanel4.Size = new System.Drawing.Size(63, 17);
            this.checkBoxChanel4.TabIndex = 12;
            this.checkBoxChanel4.Text = "Канал4";
            this.checkBoxChanel4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
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
            this.Controls.Add(this.butDiapozon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDiapozon;
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
    }
}

