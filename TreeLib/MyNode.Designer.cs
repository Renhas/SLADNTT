namespace TreeLib
{
    partial class MyNode
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.NodeBounds = new System.Windows.Forms.Label();
            this.NodeId = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ValueLabel);
            this.MainPanel.Controls.Add(this.CLabel);
            this.MainPanel.Controls.Add(this.NodeBounds);
            this.MainPanel.Controls.Add(this.NodeId);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(100, 100);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // ValueLabel
            // 
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueLabel.Location = new System.Drawing.Point(24, 65);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(50, 15);
            this.ValueLabel.TabIndex = 3;
            this.ValueLabel.Text = "Value";
            this.ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CLabel
            // 
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CLabel.Location = new System.Drawing.Point(9, 50);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(80, 15);
            this.CLabel.TabIndex = 2;
            this.CLabel.Text = "C";
            this.CLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NodeBounds
            // 
            this.NodeBounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodeBounds.Location = new System.Drawing.Point(9, 35);
            this.NodeBounds.Margin = new System.Windows.Forms.Padding(3);
            this.NodeBounds.Name = "NodeBounds";
            this.NodeBounds.Size = new System.Drawing.Size(80, 15);
            this.NodeBounds.TabIndex = 1;
            this.NodeBounds.Text = "A_B";
            this.NodeBounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NodeId
            // 
            this.NodeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NodeId.Location = new System.Drawing.Point(24, 10);
            this.NodeId.Name = "NodeId";
            this.NodeId.Size = new System.Drawing.Size(50, 20);
            this.NodeId.TabIndex = 0;
            this.NodeId.Text = "0";
            this.NodeId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "MyNode";
            this.Size = new System.Drawing.Size(100, 100);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label NodeId;
        private System.Windows.Forms.Label NodeBounds;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label CLabel;
    }
}
