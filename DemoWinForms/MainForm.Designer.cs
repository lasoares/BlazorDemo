
namespace DemoWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listEpcs = new System.Windows.Forms.ListView();
            this.colEPC = new System.Windows.Forms.ColumnHeader();
            this.colAntenna = new System.Windows.Forms.ColumnHeader();
            this.colRssi = new System.Windows.Forms.ColumnHeader();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltotalReads = new System.Windows.Forms.Label();
            this.lbltotalEpcs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMqtt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(279, 22);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Location = new System.Drawing.Point(279, 56);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btDisconnect.TabIndex = 1;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(134, 22);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(125, 23);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Text = "192.168.1.166";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reader Address";
            // 
            // listEpcs
            // 
            this.listEpcs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEPC,
            this.colAntenna,
            this.colRssi});
            this.listEpcs.HideSelection = false;
            this.listEpcs.Location = new System.Drawing.Point(40, 103);
            this.listEpcs.Name = "listEpcs";
            this.listEpcs.Size = new System.Drawing.Size(314, 240);
            this.listEpcs.TabIndex = 4;
            this.listEpcs.UseCompatibleStateImageBehavior = false;
            this.listEpcs.View = System.Windows.Forms.View.Details;
            // 
            // colEPC
            // 
            this.colEPC.Name = "colEPC";
            this.colEPC.Text = "EPC";
            this.colEPC.Width = 180;
            // 
            // colAntenna
            // 
            this.colAntenna.Name = "colAntenna";
            this.colAntenna.Text = "Antenna";
            // 
            // colRssi
            // 
            this.colRssi.Name = "colRssi";
            this.colRssi.Text = "RSSI";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(40, 361);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 5;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(40, 405);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 6;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(150, 441);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total Reads:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total EPCs:";
            // 
            // lbltotalReads
            // 
            this.lbltotalReads.AutoSize = true;
            this.lbltotalReads.Location = new System.Drawing.Point(339, 365);
            this.lbltotalReads.Name = "lbltotalReads";
            this.lbltotalReads.Size = new System.Drawing.Size(13, 15);
            this.lbltotalReads.TabIndex = 10;
            this.lbltotalReads.Text = "0";
            // 
            // lbltotalEpcs
            // 
            this.lbltotalEpcs.AutoSize = true;
            this.lbltotalEpcs.Location = new System.Drawing.Point(339, 409);
            this.lbltotalEpcs.Name = "lbltotalEpcs";
            this.lbltotalEpcs.Size = new System.Drawing.Size(13, 15);
            this.lbltotalEpcs.TabIndex = 11;
            this.lbltotalEpcs.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Broker Address";
            // 
            // txtMqtt
            // 
            this.txtMqtt.Location = new System.Drawing.Point(134, 56);
            this.txtMqtt.Name = "txtMqtt";
            this.txtMqtt.Size = new System.Drawing.Size(125, 23);
            this.txtMqtt.TabIndex = 12;
            this.txtMqtt.Text = "192.168.220.177";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 476);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMqtt);
            this.Controls.Add(this.lbltotalEpcs);
            this.Controls.Add(this.lbltotalReads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.listEpcs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.btConnect);
            this.Name = "MainForm";
            this.Text = "Demo RFID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listEpcs;
        private System.Windows.Forms.ColumnHeader colEPC;
        private System.Windows.Forms.ColumnHeader colAntenna;
        private System.Windows.Forms.ColumnHeader colRssi;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltotalReads;
        private System.Windows.Forms.Label lbltotalEpcs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMqtt;
    }
}

