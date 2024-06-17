namespace Proiect
{
    partial class AfiseazaClienti
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
            this.components = new System.ComponentModel.Container();
            this.tvClienti = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificaDateleClientuluiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printeazaDateleClientuluiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salveazaClientulCaXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvClienti
            // 
            this.tvClienti.ContextMenuStrip = this.contextMenuStrip1;
            this.tvClienti.Location = new System.Drawing.Point(0, 27);
            this.tvClienti.Name = "tvClienti";
            this.tvClienti.Size = new System.Drawing.Size(486, 497);
            this.tvClienti.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Uighur", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(180, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "CLIENTI";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaDateleClientuluiToolStripMenuItem,
            this.printeazaDateleClientuluiToolStripMenuItem,
            this.salveazaClientulCaXMLToolStripMenuItem,
            this.stergeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 128);
            // 
            // modificaDateleClientuluiToolStripMenuItem
            // 
            this.modificaDateleClientuluiToolStripMenuItem.Name = "modificaDateleClientuluiToolStripMenuItem";
            this.modificaDateleClientuluiToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.modificaDateleClientuluiToolStripMenuItem.Text = "Modifica datele clientului";
            this.modificaDateleClientuluiToolStripMenuItem.Click += new System.EventHandler(this.modificaDateleClientuluiToolStripMenuItem_Click);
            // 
            // printeazaDateleClientuluiToolStripMenuItem
            // 
            this.printeazaDateleClientuluiToolStripMenuItem.Name = "printeazaDateleClientuluiToolStripMenuItem";
            this.printeazaDateleClientuluiToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.printeazaDateleClientuluiToolStripMenuItem.Text = "Printeaza datele clientului";
            this.printeazaDateleClientuluiToolStripMenuItem.Click += new System.EventHandler(this.printeazaDateleClientuluiToolStripMenuItem_Click);
            // 
            // salveazaClientulCaXMLToolStripMenuItem
            // 
            this.salveazaClientulCaXMLToolStripMenuItem.Name = "salveazaClientulCaXMLToolStripMenuItem";
            this.salveazaClientulCaXMLToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.salveazaClientulCaXMLToolStripMenuItem.Text = "Salveaza clientul ca XML";
            this.salveazaClientulCaXMLToolStripMenuItem.Click += new System.EventHandler(this.salveazaClientulCaXMLToolStripMenuItem_Click);
            // 
            // stergeToolStripMenuItem
            // 
            this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
            this.stergeToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.stergeToolStripMenuItem.Text = "Sterge";
            this.stergeToolStripMenuItem.Click += new System.EventHandler(this.stergeToolStripMenuItem_Click);
            // 
            // AfiseazaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 525);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tvClienti);
            this.Name = "AfiseazaClienti";
            this.Text = "AfiseazaClienti";
            this.Load += new System.EventHandler(this.AfiseazaClienti_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvClienti;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificaDateleClientuluiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printeazaDateleClientuluiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salveazaClientulCaXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeToolStripMenuItem;
    }
}