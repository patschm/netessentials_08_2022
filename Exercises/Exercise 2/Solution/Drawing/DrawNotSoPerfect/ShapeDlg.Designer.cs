namespace DrawNotSoPerfect;

partial class ShapeDlg
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
            this.hY = new System.Windows.Forms.NumericUpDown();
            this.hX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.hLineWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.hY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // hY
            // 
            this.hY.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hY.Location = new System.Drawing.Point(156, 70);
            this.hY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hY.Name = "hY";
            this.hY.Size = new System.Drawing.Size(120, 33);
            this.hY.TabIndex = 8;
            this.hY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // hX
            // 
            this.hX.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hX.Location = new System.Drawing.Point(156, 18);
            this.hX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hX.Name = "hX";
            this.hX.Size = new System.Drawing.Size(120, 33);
            this.hX.TabIndex = 7;
            this.hX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnColor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnColor.Location = new System.Drawing.Point(335, 19);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(183, 136);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "LineWidth";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(433, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Location = new System.Drawing.Point(342, 333);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 31);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // hLineWidth
            // 
            this.hLineWidth.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hLineWidth.Location = new System.Drawing.Point(156, 122);
            this.hLineWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hLineWidth.Name = "hLineWidth";
            this.hLineWidth.Size = new System.Drawing.Size(120, 33);
            this.hLineWidth.TabIndex = 13;
            this.hLineWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ShapeDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 388);
            this.Controls.Add(this.hLineWidth);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hY);
            this.Controls.Add(this.hX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ShapeDlg";
            this.Text = "ShapeDlg";
            ((System.ComponentModel.ISupportInitialize)(this.hY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hLineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private NumericUpDown hY;
    private NumericUpDown hX;
    private Label label3;
    private Label label2;
    private ColorDialog colorDialog1;
    private Button btnColor;
    private Label label1;
    private Button btnCancel;
    private Button btnOk;
    private NumericUpDown hLineWidth;
}