namespace SLADNTT
{
    partial class MyTree
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
            this.FilePathButton = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.TreeCheckButton = new System.Windows.Forms.Button();
            this.TreeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.IncomeButton = new System.Windows.Forms.Button();
            this.ExpenseButton = new System.Windows.Forms.Button();
            this.ProfitButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.WindowSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMostButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilePathButton
            // 
            this.FilePathButton.Location = new System.Drawing.Point(12, 27);
            this.FilePathButton.Name = "FilePathButton";
            this.FilePathButton.Size = new System.Drawing.Size(100, 23);
            this.FilePathButton.TabIndex = 0;
            this.FilePathButton.Text = "Изменить путь";
            this.FilePathButton.UseVisualStyleBackColor = true;
            this.FilePathButton.Click += new System.EventHandler(this.FilePathButton_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(118, 29);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(376, 20);
            this.FilePathBox.TabIndex = 1;
            this.FilePathBox.TextChanged += new System.EventHandler(this.FilePathBox_TextChanged);
            // 
            // TreeCheckButton
            // 
            this.TreeCheckButton.Enabled = false;
            this.TreeCheckButton.Location = new System.Drawing.Point(11, 56);
            this.TreeCheckButton.Name = "TreeCheckButton";
            this.TreeCheckButton.Size = new System.Drawing.Size(100, 37);
            this.TreeCheckButton.TabIndex = 2;
            this.TreeCheckButton.Text = "Проверить на совместность";
            this.TreeCheckButton.UseVisualStyleBackColor = true;
            this.TreeCheckButton.Click += new System.EventHandler(this.TreeCheckButton_Click);
            // 
            // TreeLayout
            // 
            this.TreeLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeLayout.AutoScroll = true;
            this.TreeLayout.BackColor = System.Drawing.SystemColors.Control;
            this.TreeLayout.ColumnCount = 2;
            this.TreeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 686F));
            this.TreeLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TreeLayout.Location = new System.Drawing.Point(13, 99);
            this.TreeLayout.Name = "TreeLayout";
            this.TreeLayout.RowCount = 5;
            this.TreeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TreeLayout.Size = new System.Drawing.Size(786, 403);
            this.TreeLayout.TabIndex = 11;
            this.TreeLayout.Visible = false;
            // 
            // IncomeButton
            // 
            this.IncomeButton.Enabled = false;
            this.IncomeButton.Location = new System.Drawing.Point(500, 27);
            this.IncomeButton.Name = "IncomeButton";
            this.IncomeButton.Size = new System.Drawing.Size(75, 23);
            this.IncomeButton.TabIndex = 12;
            this.IncomeButton.Text = "Доход";
            this.IncomeButton.UseVisualStyleBackColor = true;
            this.IncomeButton.Click += new System.EventHandler(this.IncomeButton_Click);
            // 
            // ExpenseButton
            // 
            this.ExpenseButton.Enabled = false;
            this.ExpenseButton.Location = new System.Drawing.Point(581, 27);
            this.ExpenseButton.Name = "ExpenseButton";
            this.ExpenseButton.Size = new System.Drawing.Size(75, 23);
            this.ExpenseButton.TabIndex = 14;
            this.ExpenseButton.Text = "Расход";
            this.ExpenseButton.UseVisualStyleBackColor = true;
            this.ExpenseButton.Click += new System.EventHandler(this.ExpenseButton_Click);
            // 
            // ProfitButton
            // 
            this.ProfitButton.Enabled = false;
            this.ProfitButton.Location = new System.Drawing.Point(662, 27);
            this.ProfitButton.Name = "ProfitButton";
            this.ProfitButton.Size = new System.Drawing.Size(75, 23);
            this.ProfitButton.TabIndex = 15;
            this.ProfitButton.Text = "Прибыль";
            this.ProfitButton.UseVisualStyleBackColor = true;
            this.ProfitButton.Click += new System.EventHandler(this.ProfitButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WindowSettings});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 18;
            this.MainMenu.Text = "menuStrip1";
            // 
            // WindowSettings
            // 
            this.WindowSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMostButton});
            this.WindowSettings.Name = "WindowSettings";
            this.WindowSettings.Size = new System.Drawing.Size(108, 20);
            this.WindowSettings.Text = "Настройки окна";
            // 
            // TopMostButton
            // 
            this.TopMostButton.CheckOnClick = true;
            this.TopMostButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TopMostButton.Name = "TopMostButton";
            this.TopMostButton.Size = new System.Drawing.Size(172, 22);
            this.TopMostButton.Text = "Поверх всех окон";
            this.TopMostButton.CheckedChanged += new System.EventHandler(this.TopMostButton_CheckedChanged);
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(500, 53);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(288, 40);
            this.ResultBox.TabIndex = 19;
            this.ResultBox.Text = "";
            this.ResultBox.Visible = false;
            // 
            // MyTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.ProfitButton);
            this.Controls.Add(this.ExpenseButton);
            this.Controls.Add(this.IncomeButton);
            this.Controls.Add(this.TreeLayout);
            this.Controls.Add(this.TreeCheckButton);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.FilePathButton);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Name = "MyTree";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Объёмное планирование";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FilePathButton;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button TreeCheckButton;
        private System.Windows.Forms.TableLayoutPanel TreeLayout;
        private System.Windows.Forms.Button IncomeButton;
        private System.Windows.Forms.Button ExpenseButton;
        private System.Windows.Forms.Button ProfitButton;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem WindowSettings;
        private System.Windows.Forms.ToolStripMenuItem TopMostButton;
        private System.Windows.Forms.RichTextBox ResultBox;
    }
}

