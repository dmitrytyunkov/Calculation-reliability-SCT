namespace ControlWork
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.numericUpDownVariant = new System.Windows.Forms.NumericUpDown();
            this.labelVariant = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.buttonWork1 = new System.Windows.Forms.Button();
            this.buttonWork2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariant)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownVariant
            // 
            this.numericUpDownVariant.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownVariant.Location = new System.Drawing.Point(86, 12);
            this.numericUpDownVariant.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownVariant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVariant.Name = "numericUpDownVariant";
            this.numericUpDownVariant.Size = new System.Drawing.Size(53, 22);
            this.numericUpDownVariant.TabIndex = 0;
            this.numericUpDownVariant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelVariant
            // 
            this.labelVariant.AutoSize = true;
            this.labelVariant.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVariant.Location = new System.Drawing.Point(12, 14);
            this.labelVariant.Name = "labelVariant";
            this.labelVariant.Size = new System.Drawing.Size(68, 15);
            this.labelVariant.TabIndex = 2;
            this.labelVariant.Text = "Вариант №";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "Сухопутная",
            "Морская"});
            this.comboBoxGroup.Location = new System.Drawing.Point(200, 11);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(121, 23);
            this.comboBoxGroup.TabIndex = 3;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGroup.Location = new System.Drawing.Point(145, 14);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(49, 15);
            this.labelGroup.TabIndex = 4;
            this.labelGroup.Text = "Группа";
            // 
            // buttonWork1
            // 
            this.buttonWork1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWork1.Location = new System.Drawing.Point(53, 40);
            this.buttonWork1.Name = "buttonWork1";
            this.buttonWork1.Size = new System.Drawing.Size(86, 23);
            this.buttonWork1.TabIndex = 5;
            this.buttonWork1.Text = "Задание №1";
            this.buttonWork1.UseVisualStyleBackColor = true;
            this.buttonWork1.Click += new System.EventHandler(this.buttonWork1_Click);
            // 
            // buttonWork2
            // 
            this.buttonWork2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWork2.Location = new System.Drawing.Point(200, 40);
            this.buttonWork2.Name = "buttonWork2";
            this.buttonWork2.Size = new System.Drawing.Size(86, 23);
            this.buttonWork2.TabIndex = 6;
            this.buttonWork2.Text = "Задание №2";
            this.buttonWork2.UseVisualStyleBackColor = true;
            this.buttonWork2.Click += new System.EventHandler(this.buttonWork2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 78);
            this.Controls.Add(this.buttonWork2);
            this.Controls.Add(this.buttonWork1);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.labelVariant);
            this.Controls.Add(this.numericUpDownVariant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Контрольная работа по ЭР ЗАС";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownVariant;
        private System.Windows.Forms.Label labelVariant;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button buttonWork1;
        private System.Windows.Forms.Button buttonWork2;
    }
}

