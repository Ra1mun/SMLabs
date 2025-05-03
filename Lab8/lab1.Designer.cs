using System.ComponentModel;

namespace Lab8;

partial class lab1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Font = new System.Drawing.Font("Segoe UI", 14F);
        button1.Location = new System.Drawing.Point(241, 71);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(325, 75);
        button1.TabIndex = 0;
        button1.Text = "Ответ";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 16F);
        label1.Location = new System.Drawing.Point(131, 19);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(561, 70);
        label1.TabIndex = 1;
        label1.Text = "Сдать сегодня имитационку?";
        label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 16F);
        label2.Location = new System.Drawing.Point(330, 149);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(158, 33);
        label2.TabIndex = 2;
        // 
        // lab1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 241);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        Text = "lab1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;

    #endregion
}