namespace DrawNotSoPerfect;

partial class CircleDlg
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
            this.label3 = new System.Windows.Forms.Label();
            this.hRadius = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.hRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Radius";
            // 
            // hRadius
            // 
            this.hRadius.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hRadius.Location = new System.Drawing.Point(156, 172);
            this.hRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hRadius.Name = "hRadius";
            this.hRadius.Size = new System.Drawing.Size(120, 33);
            this.hRadius.TabIndex = 5;
            this.hRadius.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // CircleDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 387);
            this.Controls.Add(this.hRadius);
            this.Controls.Add(this.label3);
            this.Name = "CircleDlg";
            this.Text = "CirkelDlg";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.hRadius, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown hRadius;
}
