namespace Lab11
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MeanTextBox = new System.Windows.Forms.TextBox();
            this.VarianceTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TrialsTextBox = new System.Windows.Forms.TextBox();
            this.AverageLabel = new System.Windows.Forms.Label();
            this.VarianceLabel = new System.Windows.Forms.Label();
            this.ChiSquareLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(532, 23);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1044, 633);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Среднее";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дисперсия";
            // 
            // MeanTextBox
            // 
            this.MeanTextBox.Location = new System.Drawing.Point(192, 17);
            this.MeanTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.MeanTextBox.Name = "MeanTextBox";
            this.MeanTextBox.Size = new System.Drawing.Size(154, 31);
            this.MeanTextBox.TabIndex = 3;
            // 
            // VarianceTextBox
            // 
            this.VarianceTextBox.Location = new System.Drawing.Point(192, 83);
            this.VarianceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.VarianceTextBox.Name = "VarianceTextBox";
            this.VarianceTextBox.Size = new System.Drawing.Size(154, 31);
            this.VarianceTextBox.TabIndex = 4;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(84, 204);
            this.StartButton.Margin = new System.Windows.Forms.Padding(6);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(212, 44);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(26, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество эксперементов";
            // 
            // TrialsTextBox
            // 
            this.TrialsTextBox.Location = new System.Drawing.Point(334, 150);
            this.TrialsTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.TrialsTextBox.Name = "TrialsTextBox";
            this.TrialsTextBox.Size = new System.Drawing.Size(154, 31);
            this.TrialsTextBox.TabIndex = 7;
            // 
            // AverageLabel
            // 
            this.AverageLabel.AutoSize = true;
            this.AverageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.AverageLabel.Location = new System.Drawing.Point(526, 662);
            this.AverageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AverageLabel.Name = "AverageLabel";
            this.AverageLabel.Size = new System.Drawing.Size(99, 25);
            this.AverageLabel.TabIndex = 8;
            this.AverageLabel.Text = "Среднее";
            // 
            // VarianceLabel
            // 
            this.VarianceLabel.AutoSize = true;
            this.VarianceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.VarianceLabel.Location = new System.Drawing.Point(526, 708);
            this.VarianceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.VarianceLabel.Name = "VarianceLabel";
            this.VarianceLabel.Size = new System.Drawing.Size(121, 25);
            this.VarianceLabel.TabIndex = 9;
            this.VarianceLabel.Text = "Дисперсия";
            // 
            // ChiSquareLabel
            // 
            this.ChiSquareLabel.AutoSize = true;
            this.ChiSquareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.ChiSquareLabel.Location = new System.Drawing.Point(527, 752);
            this.ChiSquareLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ChiSquareLabel.Name = "ChiSquareLabel";
            this.ChiSquareLabel.Size = new System.Drawing.Size(125, 25);
            this.ChiSquareLabel.TabIndex = 10;
            this.ChiSquareLabel.Text = "Хи-квадрат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.ChiSquareLabel);
            this.Controls.Add(this.VarianceLabel);
            this.Controls.Add(this.AverageLabel);
            this.Controls.Add(this.TrialsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.VarianceTextBox);
            this.Controls.Add(this.MeanTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MeanTextBox;
        private System.Windows.Forms.TextBox VarianceTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TrialsTextBox;
        private System.Windows.Forms.Label AverageLabel;
        private System.Windows.Forms.Label VarianceLabel;
        private System.Windows.Forms.Label ChiSquareLabel;
    }
}