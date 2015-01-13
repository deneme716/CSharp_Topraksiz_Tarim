using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using IrrKlang;
using System.Reflection;


namespace ReminderApp
{
  public partial class FrmMain : Form
  {

    public List<String> reminders = new List<String>();
    public string filename = Application.StartupPath + "\\remind.txt";
    public string settingFilename = Application.StartupPath + "\\settings.ini";
    
 

    public Settings settings;

    public FrmMain()
    {
      InitializeComponent();
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        btnDisconnect.Enabled = false;
        comboBox1.SelectedIndex = 2;
        timer2.Interval = Convert.ToInt32(comboBox1.Text) * 1000;

      
        cmbPort.DataSource = SerialPort.GetPortNames();
        
      //Create settings file if not exist
      if (!File.Exists(settingFilename)) {
        File.WriteAllText(settingFilename, Properties.Resources.settings);
      }

      //Load settings
      settings = new Settings(settingFilename);

      //Set all the default values for the listview
      listView1.View = View.Details;
      listView1.GridLines = true;
      listView1.FullRowSelect = true;
      listView1.MultiSelect = false;

      //Add the columns needed to the listview
      listView1.Columns.Add("Günler", 70);
      listView1.Columns.Add("Saat", 70);
      listView1.Columns.Add("Not", 95);
      listView1.Columns.Add("Tekrar", 60);
      listView1.Columns.Add("Aktif", 55);
      listView1.Columns.Add("Port", 82);
      listView1.Columns.Add("R", 35);
      listView1.Columns.Add("G", 35);
      listView1.Columns.Add("B", 35);
      listView1.Columns.Add("Durum", 45);
      AddReminders();

      //Make a mouseeventhandler for the listview
      listView1.MouseClick += new MouseEventHandler(listView1_MouseClick);
      
    }
   
    void listView1_MouseClick(object sender, MouseEventArgs e)
    {
      //If the right mouse button is pressed show the context menu
      if (e.Button == MouseButtons.Right) {
        listViewMenu.Show(new Point(MousePosition.X, MousePosition.Y));
      }
    }

    //Prevent the application from exiting when pressing the X
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      //Close application for real if windows is shutting down
      if (e.CloseReason == CloseReason.WindowsShutDown)
        return;

      //If user close the window minimize
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
        this.Hide();
      }
    }

    private void exitBtn_Click(object sender, EventArgs e)
    {
        if (serialPort1.IsOpen)
        {
            serialPort1.Write("A");
            serialPort1.Write("B");
            serialPort1.Write("C");
            serialPort1.Write("D");
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Red;
            panel3.BackColor = Color.Red;
            panel4.BackColor = Color.Red;
            serialPort1.Write("R0,0,0\n");
            panel5.BackColor = Color.Black;

            serialPort1.Close();
            btnDisconnect.Enabled = false;
            button1.Enabled = true;
            cmbPort.Enabled = true;
        }
        Application.Exit();
    }

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Show();
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Show();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //Set variables for the current time
      DateTime dt = DateTime.Now;
      String timeNow = dt.ToString("HH:mm");
      String day = dt.ToString("dddd", new CultureInfo("en-US"));

      //For loop to check all the reminders if it's time to remind.
      for (int i = 0; i < reminders.Count; i++) {
        String[] info = reminders[i].Split(';');

        //Checks if the reminder is active
        if (info[4] != "No") {

          //If the time contains AM or PM convert to 24h time
          if (info[1].Contains("AM") || info[1].Contains("PM")) {
            DateTime nwdt = new DateTime();
            nwdt = Convert.ToDateTime(info[1]);
            info[1] = nwdt.ToString("HH:mm");
          }

          //If the time and day is correct
          if (timeNow == info[1] &&
            (day == info[0] ||
            info[0].ToUpper() == "EVERYDAY" ||
            (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday") &&
            info[0].ToUpper() == "WORKDAYS") ||
            (day == "Saturday" || day == "Sunday") && info[0].ToUpper() == "WEEKEND") {

            //If it's not going to recurr set active to "No"
            if (info[3] != "Yes") {

              List<String> remindList = new List<String>();

              using (StreamReader sr = new StreamReader(filename)) {
                string line;

                while ((line = sr.ReadLine()) != null) {
                  remindList.Add(line);
                }
              }

              String[] remind = remindList[i].Split(';');
              remind[4] = "No";
              string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4] + ";" + remind[5] + ";" + remind[6] + ";" + remind[7] + ";" + remind[8] + ";" + remind[9];
              remindList[i] = reminder;

              File.WriteAllLines(filename, remindList.ToArray());
              AddReminders();

            }

            //Show the message for the reminder

            if (settings.GetBool("Messagebox")) {
             // MessageBox.Show(info[2]);
              textBox1.AppendText(timeNow + " : " + info[5] + " - " + info[9] + Environment.NewLine);
              if (info[5] == "PORT1")
              {
                  if (info[9] == "on")
                  {
                      serialPort1.Write("a");
                      panel1.BackColor = Color.Green;
                  }
                  if (info[9] == "off")
                  {
                      serialPort1.Write("A");
                      panel1.BackColor = Color.Red;

                  }
              }
              if (info[5] == "PORT2")
              {
                  if (info[9] == "on")
                  {
                      serialPort1.Write("b");
                      panel2.BackColor = Color.Green;
                  }
                  if (info[9] == "off")
                  {
                      serialPort1.Write("B");
                      panel2.BackColor = Color.Red;
                  }
              }
              if (info[5] == "PORT3")
              {
                  if (info[9] == "on")
                  {
                      serialPort1.Write("c");
                      panel3.BackColor = Color.Green;
                  }
                  if (info[9] == "off")
                  {
                      serialPort1.Write("C");
                      panel3.BackColor = Color.Red;
                  }
              }
              if (info[5] == "PORT4")
              {
                  if (info[9] == "on")
                  {
                      serialPort1.Write("d");
                      panel4.BackColor = Color.Green;
                  }
                  if (info[9] == "off")
                  {
                      serialPort1.Write("D");
                      panel4.BackColor = Color.Red;
                  }
              }
              if (info[5] == "RGB")
              {
                  if (info[9] == "off")
                  {
                      serialPort1.Write("R0,0,0\n");
                      panel5.BackColor = Color.Black;
                  }
                  if (info[9] == "on")
                  {
                      serialPort1.Write("R"+info[6]+","+info[7]+","+info[8]+"\n");
                      panel5.BackColor = Color.FromArgb(Convert.ToInt32(info[6]), Convert.ToInt32(info[7]), Convert.ToInt32(info[8]));
                  }
              }
            }

          }
          else {
            string[] days = info[0].Split(',');
            foreach(string str in days){
              if (day == str) {

                //If it's not going to recurr set active to "No"
                if (info[3] != "Yes") {

                  List<String> remindList = new List<String>();

                  using (StreamReader sr = new StreamReader(filename)) {
                    string line;

                    while ((line = sr.ReadLine()) != null) {
                      remindList.Add(line);
                    }
                  }

                  String[] remind = remindList[i].Split(';');
                  remind[4] = "No";
                  string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4];
                  remindList[i] = reminder;

                  File.WriteAllLines(filename, remindList.ToArray());
                  AddReminders();

                }

                //Show the message for the reminder
                if (settings.GetBool("Bubble")) {
                  notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                  notifyIcon.BalloonTipTitle = "Reminder";
                  notifyIcon.BalloonTipText = info[2];
                  notifyIcon.ShowBalloonTip(2000);
                }
                if (settings.GetBool("Messagebox")) {
                  MessageBox.Show(info[2]);
                }

              }
            }
          }

        }
      }

    }

    //Check for update


    //Function returning a list of the reminders in reminder.txt
    private List<String> ReadReminders()
    {
      List<String> reminders = new List<String>();
      try {

        //If the remind.txt file don't exist, create it
        if (!File.Exists(filename)) {
          var remindtxt = File.Create("remind.txt");
          remindtxt.Close();
        }

        //Open the remind.txt file and read all the reminders
        using (StreamReader sr = new StreamReader(filename)) {
          string line;

          while ((line = sr.ReadLine()) != null) {
            //Add the reminders to the list of reminders
            reminders.Add(line);
          }

        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }

      //Return the list of reminders
      return reminders;
    }

    //Adds the reminbers to the listview
    public void AddReminders()
    {
      try {
        //Clear the reminders list so we don't get doubles
        reminders.Clear();

        //Read and add all the reminders to the list
        reminders = ReadReminders();

        //Clear the listview to prevent doubles
        listView1.Items.Clear();

        //Split and add all the reminders to the listview
        for (int i = 0; i < reminders.Count; i++) {
          String[] info = reminders[i].Split(';');
          listView1.Items.Add(new ListViewItem(new string[] { info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7], info[8], info[9] }));
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Open the form for adding reminders
      FrmAddReminder frmAddReminder = new FrmAddReminder(this, false, 0);
      frmAddReminder.Show();
      frmAddReminder.radioButton1.Checked = true;
      frmAddReminder.dayBox.Text = "Everyday";
    }

    private void removeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try {
        //Get the index of the reminder
        int index = 0;
        if (listView1.SelectedItems.Count > 0)
          index = listView1.SelectedIndices[0];

        //Open and read all the lines in the reminder.txt
        List<string> lst = File.ReadAllLines(filename).ToList();

        //Remove the reminder with index
        lst.RemoveAt(index);

        //Rewrite everything to the reminder.txt file
        File.WriteAllLines(filename, lst.ToArray());

        //Remove it from the listview
        listView1.Items.RemoveAt(index);

        //Add reminders
        AddReminders();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Get the index of the reminder
      int index = 0;
      if (listView1.SelectedItems.Count > 0)
        index = listView1.SelectedIndices[0];

      //Open the form for adding/editing reminders
      FrmAddReminder frmAddReminder = new FrmAddReminder(this, true, index);

      //Split the reminder with index to get all info
      String[] info = reminders[index].Split(';');

      //Convert the time to DateTime for use in datetimepicker
      DateTime nwdt = new DateTime();
      nwdt = Convert.ToDateTime(info[1]);

      //Set all the values in the form to edit
      frmAddReminder.Show();
      List<int> days = dayToInt(info[0]);
      for (int i = 0; i < days.Count; i++) {
        frmAddReminder.dayBox.SetItemChecked(days[i], true);
      }
      frmAddReminder.timePicker.Value = nwdt;
      frmAddReminder.textBox1.Text = info[2];
      if (info[3] == "Yes") {
        frmAddReminder.recurringBox.Checked = true;
      }
      else {
        frmAddReminder.recurringBox.Checked = false;
      }
      if (info[4] == "Yes") {
        frmAddReminder.activeBox.Checked = true;
      }
      else {
        frmAddReminder.activeBox.Checked = false;
      }
      frmAddReminder.comboBox1.SelectedItem = info[5];
      frmAddReminder.textBox2.Text = info[6];
      frmAddReminder.textBox3.Text = info[7];
      frmAddReminder.textBox4.Text = info[8];
      frmAddReminder.trackBar1.Value = Convert.ToInt32(info[6]);
      frmAddReminder.trackBar2.Value = Convert.ToInt32(info[7]);
      frmAddReminder.trackBar3.Value = Convert.ToInt32(info[8]);
      frmAddReminder.panel1.BackColor = Color.FromArgb(Convert.ToInt32(info[6]), Convert.ToInt32(info[7]), Convert.ToInt32(info[8]));
      //Show the form
      //frmAddReminder.Show();
      if (info[9] == "on")
      {
          frmAddReminder.radioButton1.Checked = true;
          frmAddReminder.radioButton2.Checked = false;
      }
      if (info[9] == "off")
      {
          frmAddReminder.radioButton1.Checked = false;
          frmAddReminder.radioButton2.Checked = true;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void settingsBtn_Click(object sender, EventArgs e)
    {
      FrmSettings frmSettings = new FrmSettings(this);
      frmSettings.Show();
    }

    private void activateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try {
        //Get the index of the reminder
        int index = 0;
        if (listView1.SelectedItems.Count > 0)
          index = listView1.SelectedIndices[0];

        //Open and read all the lines in the reminder.txt
        List<string> lst = File.ReadAllLines(filename).ToList();

        //Remove the reminder with index
        String[] info = lst[index].Split(';');

        String fullInfo = info[0] + ";" + info[1] + ";" + info[2] + ";" + info[3] + ";Yes";

        lst[index] = fullInfo;

        //Rewrite everything to the reminder.txt file
        File.WriteAllLines(filename, lst.ToArray());

        //Reload reminders
        AddReminders();
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex);
      }
    }

    private List<int> dayToInt(string day)
    {
      List<int> days = new List<int>();
      string[] dayArr = day.Split(',');
      for (int i = 0; i < dayArr.Length; i++) {
        switch (dayArr[i].ToLower()) {
          case "monday":
            days.Add(0);
            break;
          case "tuesday":
            days.Add(1);
            break;
          case "wednesday":
            days.Add(2);
            break;
          case "thursday":
            days.Add(3);
            break;
          case "friday":
            days.Add(4);
            break;
          case "saturday":
            days.Add(5);
            break;
          case "sunday":
            days.Add(6);
            break;
          case "workdays":
            days.Add(7);
            break;
          case "weekend":
            days.Add(8);
            break;
          case "everyday":
            days.Add(9);
            break;
        }
      }
      return days;
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e)
    {
     
    }

    private void listViewMenu_Opening(object sender, CancelEventArgs e)
    {

    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        serialPort1.PortName = cmbPort.Text;
        serialPort1.BaudRate = 9600;

        serialPort1.Open();
        if (serialPort1.IsOpen)
        {
            btnDisconnect.Enabled = true;
            timer2.Enabled = true;
            button1.Enabled = false;
            cmbPort.Enabled = false;
            serialPort1.Write("A");
            serialPort1.Write("B");
            serialPort1.Write("C");
            serialPort1.Write("D");
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Red;
            panel3.BackColor = Color.Red;
            panel4.BackColor = Color.Red;
        }
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        if (serialPort1.IsOpen)
        {   serialPort1.Write("A");
            serialPort1.Write("B");
            serialPort1.Write("C");
            serialPort1.Write("D");
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Red;
            panel3.BackColor = Color.Red;
            panel4.BackColor = Color.Red;
            serialPort1.Write("R0,0,0\n");
            panel5.BackColor = Color.Black;
            timer2.Enabled = false;
            serialPort1.Close();
            btnDisconnect.Enabled = false;
            button1.Enabled = true;
            cmbPort.Enabled = true;
 
        }
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {

        if (serialPort1.IsOpen)
        {
            serialPort1.Write("A");
            serialPort1.Write("B");
            serialPort1.Write("C");
            serialPort1.Write("D");
            serialPort1.Close();
        }
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
       
    }

    private void button3_Click(object sender, EventArgs e)
    {
      
    }

    private void button2_Click_2(object sender, EventArgs e)
    {
        Snapshot_Maker.MainForm sForm1 = new Snapshot_Maker.MainForm();
        sForm1.Show();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        if (serialPort1.IsOpen)
        {
            serialPort1.Write("S");
           // serialPort1.ReadLine();
            textBox2.AppendText(DateTime.Now.ToString("h:mm:ss") + " ; " +serialPort1.ReadLine() + Environment.NewLine);
        }
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
       
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        timer2.Interval = Convert.ToInt32(comboBox1.Text) * 1000;
    }
  }
}
