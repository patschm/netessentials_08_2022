namespace DrawNotSoPerfect;

partial class TriangleDlg
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
            this.hBase = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.hHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.hAngle = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // hBase
            // 
            this.hBase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hBase.Location = new System.Drawing.Point(156, 178);
            this.hBase.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hBase.Name = "hBase";
            this.hBase.Size = new System.Drawing.Size(120, 33);
            this.hBase.TabIndex = 13;
            this.hBase.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Base";
            // 
            // hHeight
            // 
            this.hHeight.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hHeight.Location = new System.Drawing.Point(156, 227);
            this.hHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hHeight.Name = "hHeight";
            this.hHeight.Size = new System.Drawing.Size(120, 33);
            this.hHeight.TabIndex = 17;
            this.hHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Height";
            // 
            // hAngle
            // 
            this.hAngle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hAngle.Location = new System.Drawing.Point(156, 275);
            this.hAngle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hAngle.Name = "hAngle";
            this.hAngle.Size = new System.Drawing.Size(120, 33);
            this.hAngle.TabIndex = 19;
            this.hAngle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Angle";
            // 
            // TriangleDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(529, 370);
            this.Controls.Add(this.hAngle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hBase);
            this.Controls.Add(this.label3);
            this.Name = "TriangleDlg";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.hBase, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.hHeight, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.hAngle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
#endregion
    private NumericUpDown hBase;
    private Label label3;
    private NumericUpDown hHeight;
    private Label label4;
    private NumericUpDown hAngle;
    private Label label5;
}
