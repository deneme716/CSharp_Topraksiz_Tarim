namespace ReminderApp
{
  partial class FrmMain
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
      if (disposing && (components != null)) {
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.listView1 = new System.Windows.Forms.ListView();
        this.addBtn = new System.Windows.Forms.Button();
        this.exitBtn = new System.Windows.Forms.Button();
        this.listViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.okBtn = new System.Windows.Forms.Button();
        this.settingsBtn = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.cmbPort = new System.Windows.Forms.ComboBox();
        this.button1 = new System.Windows.Forms.Button();
        this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
        this.btnDisconnect = new System.Windows.Forms.Button();
        this.panel1 = new System.Windows.Forms.Panel();
        this.label2 = new System.Windows.Forms.Label();
        this.panel2 = new System.Windows.Forms.Panel();
        this.label3 = new System.Windows.Forms.Label();
        this.panel3 = new System.Windows.Forms.Panel();
        this.label4 = new System.Windows.Forms.Label();
        this.panel4 = new System.Windows.Forms.Panel();
        this.label5 = new System.Windows.Forms.Label();
        this.button2 = new System.Windows.Forms.Button();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.timer2 = new System.Windows.Forms.Timer(this.components);
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.label6 = new System.Windows.Forms.Label();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.panel5 = new System.Windows.Forms.Panel();
        this.label7 = new System.Windows.Forms.Label();
        this.notifyIconMenu.SuspendLayout();
        this.listViewMenu.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // notifyIcon
        // 
        this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
        this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        this.notifyIcon.Text = "Reminder app";
        this.notifyIcon.Visible = true;
        this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
        // 
        // notifyIconMenu
        // 
        this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
        this.notifyIconMenu.Name = "notifyIconMenu";
        this.notifyIconMenu.Size = new System.Drawing.Size(117, 70);
        // 
        // updateToolStripMenuItem
        // 
        this.updateToolStripMenuItem.Image = global::ReminderApp.Properties.Resources.reload_16;
        this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
        this.updateToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.updateToolStripMenuItem.Text = "Update";
        this.updateToolStripMenuItem.Visible = false;
        this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
        // 
        // showToolStripMenuItem
        // 
        this.showToolStripMenuItem.Image = global::ReminderApp.Properties.Resources.settings_16;
        this.showToolStripMenuItem.Name = "showToolStripMenuItem";
        this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.showToolStripMenuItem.Text = "Settings";
        this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.exitToolStripMenuItem.Text = "Exit";
        this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
        // 
        // listView1
        // 
        this.listView1.Location = new System.Drawing.Point(12, 12);
        this.listView1.Name = "listView1";
        this.listView1.Size = new System.Drawing.Size(589, 265);
        this.listView1.TabIndex = 1;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = System.Windows.Forms.View.List;
        // 
        // addBtn
        // 
        this.addBtn.Location = new System.Drawing.Point(447, 283);
        this.addBtn.Name = "addBtn";
        this.addBtn.Size = new System.Drawing.Size(71, 23);
        this.addBtn.TabIndex = 2;
        this.addBtn.Text = "Ekle";
        this.addBtn.UseVisualStyleBackColor = true;
        this.addBtn.Click += new System.EventHandler(this.button1_Click);
        // 
        // exitBtn
        // 
        this.exitBtn.Location = new System.Drawing.Point(709, 318);
        this.exitBtn.Name = "exitBtn";
        this.exitBtn.Size = new System.Drawing.Size(89, 23);
        this.exitBtn.TabIndex = 3;
        this.exitBtn.Text = "Çıkış";
        this.exitBtn.UseVisualStyleBackColor = true;
        this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
        // 
        // listViewMenu
        // 
        this.listViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
        this.listViewMenu.Name = "contextMenuStrip1";
        this.listViewMenu.Size = new System.Drawing.Size(117, 48);
        this.listViewMenu.Opening += new System.ComponentModel.CancelEventHandler(this.listViewMenu_Opening);
        // 
        // editToolStripMenuItem
        // 
        this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        this.editToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.editToolStripMenuItem.Text = "Düzenle";
        this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
        // 
        // removeToolStripMenuItem
        // 
        this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
        this.removeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.removeToolStripMenuItem.Text = "Sil";
        this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
        // 
        // timer1
        // 
        this.timer1.Enabled = true;
        this.timer1.Interval = 60000;
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // okBtn
        // 
        this.okBtn.Location = new System.Drawing.Point(615, 318);
        this.okBtn.Name = "okBtn";
        this.okBtn.Size = new System.Drawing.Size(88, 23);
        this.okBtn.TabIndex = 5;
        this.okBtn.Text = "Tamam";
        this.okBtn.UseVisualStyleBackColor = true;
        this.okBtn.Click += new System.EventHandler(this.button2_Click);
        // 
        // settingsBtn
        // 
        this.settingsBtn.Location = new System.Drawing.Point(524, 283);
        this.settingsBtn.Name = "settingsBtn";
        this.settingsBtn.Size = new System.Drawing.Size(75, 23);
        this.settingsBtn.TabIndex = 6;
        this.settingsBtn.Text = "Ayarlar";
        this.settingsBtn.UseVisualStyleBackColor = true;
        this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
        // 
        // textBox1
        // 
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.Location = new System.Drawing.Point(615, 28);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBox1.Size = new System.Drawing.Size(202, 249);
        this.textBox1.TabIndex = 7;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(612, 12);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(91, 13);
        this.label1.TabIndex = 8;
        this.label1.Text = "Olay Hareketleri  :";
        // 
        // cmbPort
        // 
        this.cmbPort.FormattingEnabled = true;
        this.cmbPort.Location = new System.Drawing.Point(13, 283);
        this.cmbPort.Name = "cmbPort";
        this.cmbPort.Size = new System.Drawing.Size(121, 21);
        this.cmbPort.TabIndex = 9;
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(140, 283);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 11;
        this.button1.Text = "Bağlan";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click_1);
        // 
        // btnDisconnect
        // 
        this.btnDisconnect.Location = new System.Drawing.Point(222, 283);
        this.btnDisconnect.Name = "btnDisconnect";
        this.btnDisconnect.Size = new System.Drawing.Size(95, 23);
        this.btnDisconnect.TabIndex = 12;
        this.btnDisconnect.Text = "Bağlantıyı Kes";
        this.btnDisconnect.UseVisualStyleBackColor = true;
        this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
        // 
        // panel1
        // 
        this.panel1.Location = new System.Drawing.Point(56, 311);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(13, 14);
        this.panel1.TabIndex = 13;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(13, 311);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(41, 13);
        this.label2.TabIndex = 14;
        this.label2.Text = "Port 1 :";
        // 
        // panel2
        // 
        this.panel2.Location = new System.Drawing.Point(56, 328);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(13, 14);
        this.panel2.TabIndex = 13;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(13, 328);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(41, 13);
        this.label3.TabIndex = 14;
        this.label3.Text = "Port 2 :";
        // 
        // panel3
        // 
        this.panel3.Location = new System.Drawing.Point(118, 312);
        this.panel3.Name = "panel3";
        this.panel3.Size = new System.Drawing.Size(13, 14);
        this.panel3.TabIndex = 13;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(75, 312);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(41, 13);
        this.label4.TabIndex = 14;
        this.label4.Text = "Port 3 :";
        // 
        // panel4
        // 
        this.panel4.Location = new System.Drawing.Point(118, 329);
        this.panel4.Name = "panel4";
        this.panel4.Size = new System.Drawing.Size(13, 14);
        this.panel4.TabIndex = 13;
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(75, 329);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(41, 13);
        this.label5.TabIndex = 14;
        this.label5.Text = "Port 4 :";
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(615, 283);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(183, 23);
        this.button2.TabIndex = 15;
        this.button2.Text = "Kamera Zamanlayıcı";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click_2);
        // 
        // textBox2
        // 
        this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox2.Location = new System.Drawing.Point(6, 49);
        this.textBox2.Multiline = true;
        this.textBox2.Name = "textBox2";
        this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBox2.Size = new System.Drawing.Size(202, 219);
        this.textBox2.TabIndex = 7;
        // 
        // timer2
        // 
        this.timer2.Enabled = true;
        this.timer2.Interval = 5000;
        this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30",
            "60",
            "120",
            "360",
            "720",
            "1800",
            "3600"});
        this.comboBox1.Location = new System.Drawing.Point(121, 22);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(72, 21);
        this.comboBox1.TabIndex = 16;
        this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(6, 27);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(109, 13);
        this.label6.TabIndex = 17;
        this.label6.Text = "Data Alma Periyodu  :";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.label6);
        this.groupBox1.Controls.Add(this.comboBox1);
        this.groupBox1.Controls.Add(this.textBox2);
        this.groupBox1.Location = new System.Drawing.Point(823, 12);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(216, 274);
        this.groupBox1.TabIndex = 19;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Sıcaklık ve Nem";
        // 
        // panel5
        // 
        this.panel5.Location = new System.Drawing.Point(206, 311);
        this.panel5.Name = "panel5";
        this.panel5.Size = new System.Drawing.Size(54, 19);
        this.panel5.TabIndex = 14;
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(142, 313);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(65, 13);
        this.label7.TabIndex = 20;
        this.label7.Text = "LED Rengi :";
        // 
        // FrmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1043, 349);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.panel5);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.panel4);
        this.Controls.Add(this.panel2);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.panel3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.btnDisconnect);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.cmbPort);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.settingsBtn);
        this.Controls.Add(this.okBtn);
        this.Controls.Add(this.exitBtn);
        this.Controls.Add(this.addBtn);
        this.Controls.Add(this.listView1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "FrmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Röle & RGB Led Zamanlayıcı (murat.kantas@arcelik.com)";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
        this.Load += new System.EventHandler(this.FrmMain_Load);
        this.notifyIconMenu.ResumeLayout(false);
        this.listViewMenu.ResumeLayout(false);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.Button addBtn;
    private System.Windows.Forms.Button exitBtn;
    private System.Windows.Forms.ContextMenuStrip listViewMenu;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
    private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button okBtn;
    private System.Windows.Forms.Button settingsBtn;
    private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbPort;
    private System.Windows.Forms.Button button1;
    private System.IO.Ports.SerialPort serialPort1;
    private System.Windows.Forms.Button btnDisconnect;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Label label7;
  }
}

