namespace DrawNotSoPerfect;

partial class RectangleDlg
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
            this.hWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.hHeight = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.hWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Width";
            // 
            // hWidth
            // 
            this.hWidth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hWidth.Location = new System.Drawing.Point(156, 177);
            this.hWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hWidth.Name = "hWidth";
            this.hWidth.Size = new System.Drawing.Size(120, 33);
            this.hWidth.TabIndex = 17;
            this.hWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Height";
            // 
            // hHeight
            // 
            this.hHeight.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hHeight.Location = new System.Drawing.Point(156, 237);
            this.hHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hHeight.Name = "hHeight";
            this.hHeight.Size = new System.Drawing.Size(120, 33);
            this.hHeight.TabIndex = 19;
            this.hHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // RectangleDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(545, 387);
            this.Controls.Add(this.hHeight);
            this.Controls.Add(this.hWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "RectangleDlg";
            this.Text = "RectangleDlg";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.hWidth, 0);
            this.Controls.SetChildIndex(this.hHeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion
    private Label label1;
    private NumericUpDown hWidth;
    private NumericUpDown hHeight;
    private Label label4;

}
