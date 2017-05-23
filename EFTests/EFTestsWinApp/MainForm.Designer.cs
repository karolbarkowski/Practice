namespace EFTestsWinApp
{
    partial class MainForm
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
            this.btnRunAndLogQuery = new System.Windows.Forms.Button();
            this.panelLogPreview = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectByRelation = new System.Windows.Forms.Button();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSelectFromView = new System.Windows.Forms.Button();
            this.lblIterations = new System.Windows.Forms.Label();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunAndLogQuery
            // 
            this.btnRunAndLogQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAndLogQuery.Location = new System.Drawing.Point(0, 0);
            this.btnRunAndLogQuery.Name = "btnRunAndLogQuery";
            this.btnRunAndLogQuery.Size = new System.Drawing.Size(138, 23);
            this.btnRunAndLogQuery.TabIndex = 1;
            this.btnRunAndLogQuery.Text = "Run And Log Query";
            this.btnRunAndLogQuery.UseVisualStyleBackColor = true;
            this.btnRunAndLogQuery.Click += new System.EventHandler(this.BtnRunAndLogQuery_Click);
            // 
            // panelLogPreview
            // 
            this.panelLogPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogPreview.AutoScroll = true;
            this.panelLogPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelLogPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogPreview.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLogPreview.Location = new System.Drawing.Point(156, 12);
            this.panelLogPreview.Name = "panelLogPreview";
            this.panelLogPreview.Size = new System.Drawing.Size(638, 431);
            this.panelLogPreview.TabIndex = 3;
            this.panelLogPreview.WrapContents = false;
            // 
            // btnSelectByRelation
            // 
            this.btnSelectByRelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectByRelation.Location = new System.Drawing.Point(0, 159);
            this.btnSelectByRelation.Name = "btnSelectByRelation";
            this.btnSelectByRelation.Size = new System.Drawing.Size(138, 23);
            this.btnSelectByRelation.TabIndex = 4;
            this.btnSelectByRelation.Text = "Select By Relation";
            this.btnSelectByRelation.UseVisualStyleBackColor = true;
            this.btnSelectByRelation.Click += new System.EventHandler(this.btnSelectByRelation_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnSelectFromView);
            this.pnlControls.Controls.Add(this.lblIterations);
            this.pnlControls.Controls.Add(this.numIterations);
            this.pnlControls.Controls.Add(this.btnRunAndLogQuery);
            this.pnlControls.Controls.Add(this.btnSelectByRelation);
            this.pnlControls.Location = new System.Drawing.Point(12, 12);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(138, 213);
            this.pnlControls.TabIndex = 0;
            // 
            // btnSelectFromView
            // 
            this.btnSelectFromView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFromView.Location = new System.Drawing.Point(0, 130);
            this.btnSelectFromView.Name = "btnSelectFromView";
            this.btnSelectFromView.Size = new System.Drawing.Size(138, 23);
            this.btnSelectFromView.TabIndex = 5;
            this.btnSelectFromView.Text = "Select From View";
            this.btnSelectFromView.UseVisualStyleBackColor = true;
            this.btnSelectFromView.Click += new System.EventHandler(this.btnSelectFromView_Click);
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(3, 190);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(50, 13);
            this.lblIterations.TabIndex = 0;
            this.lblIterations.Text = "Iterations";
            // 
            // numIterations
            // 
            this.numIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numIterations.Location = new System.Drawing.Point(73, 188);
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(65, 20);
            this.numIterations.TabIndex = 0;
            this.numIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 455);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.panelLogPreview);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRunAndLogQuery;
        private System.Windows.Forms.FlowLayoutPanel panelLogPreview;
        private System.Windows.Forms.Button btnSelectByRelation;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Button btnSelectFromView;
    }
}

