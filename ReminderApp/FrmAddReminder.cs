using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ReminderApp
{
  public partial class FrmAddReminder : Form
  {

    FrmMain frm;
    bool edit;
    int index;
    string filename = "remind.txt";
    string onoff;



    public FrmAddReminder(FrmMain main, bool edit, int index)
    {
      InitializeComponent();
      frm = main;
      this.edit = edit;
      this.index = index;
    }

    private void FrmAddReminder_Load(object sender, EventArgs e)
    {

        checkcombo();
        comboBox1.SelectedIndex = 0;
       
      //Disblae the dropdown
      timePicker.ShowUpDown = true;

      //If not in edit mode set timepicker value to current time
      if (!edit) {
        timePicker.Value = DateTime.Now;
      }

      string[] daysArr = { "Monday", "Tuesday", "Wednesday",
                              "Thursday", "Friday", "Saturday",
                              "Sunday", "Workdays", "Weekend", 
                              "Everyday" };

      for (int i = 0; i < daysArr.Length; i++) {
        string item = daysArr[i];
          dayBox.Items.Add(item);
      }

     
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Get the short time of the timepicker
      DateTime dt = timePicker.Value;
      String timeNow = dt.ToShortTimeString();

      //If not edit mode just add the reminder to the end of remind.txt
      if(dayBox.Text != null)
      if (!edit) {
        if (!textBox1.Text.Contains(";")) {
          try {
            using (StreamWriter sw = File.AppendText(filename)) {

              string recurr;
              string active;
              string sound;
              

              if (recurringBox.Checked) {
                recurr = "Yes";
              }
              else {
                recurr = "No";
              }

              if (activeBox.Checked) {
                active = "Yes";
              }
              else {
                active = "No";
              }
                if( radioButton1.Checked)
                {
                    onoff="on";
                }
                if (radioButton2.Checked)
                {
                    onoff = "off";
                }

              sound = comboBox1.Text;
              if (textBox1.Text == "")
              {
                  textBox1.Text = comboBox1.Text;
              }
              //Write the new reminder to the remind.txt
              sw.WriteLine(dayBox.Text + ";" + timeNow + ";" + textBox1.Text + ";" + recurr + ";" + active + ";" + sound + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";" + onoff);
              sw.Close();
            }
          }
          catch (Exception ex) {
            MessageBox.Show("Error: " + ex);
          }

          //Reload the reminders in the main form and application
          frm.AddReminders();
          this.Close();
        }
        else {
          MessageBox.Show("No ; sign is allowed in message");
        }
      }
      else {
        //Re read all the reminders into memory
        List<String> remindList = new List<String>();
        try {
          using (StreamReader sr = new StreamReader(filename)) {
            string line;

            while ((line = sr.ReadLine()) != null) {
              remindList.Add(line);
            }
          }

          string recurr;
          string active;
          string sound;

          if (recurringBox.Checked) {
            recurr = "Yes";
          }
          else {
            recurr = "No";
          }

          if (activeBox.Checked) {
            active = "Yes";
          }
          else {
            active = "No";
          }

          if (radioButton1.Checked)
          {
              onoff = "on";
          }
          if (radioButton2.Checked)
          {
              onoff = "off";
          }       
            sound =comboBox1.Text;

          //Split and change the information for remind with index
          String[] remind = remindList[index].Split(';');
          remind[0] = dayBox.Text;
          remind[1] = timeNow;
          remind[2] = textBox1.Text;
          remind[3] = recurr;
          remind[4] = active;
          remind[5] = textBox2.Text;
          remind[6] = textBox3.Text;
          remind[7] = textBox4.Text;
          string reminder = remind[0] + ";" + remind[1] + ";" + remind[2] + ";" + remind[3] + ";" + remind[4] + ";" + sound + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";" + onoff;
          remindList[index] = reminder;
         
          //Rewrite the remind.txt file with changes
          File.WriteAllLines(filename, remindList.ToArray());
        }
        catch (Exception ex) {
          MessageBox.Show("Error: " + ex);
        }
        frm.AddReminders();
        this.Close();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Point pt = this.PointToScreen(button1.Location);
        ThemeColorPickerWindow f = new ThemeColorPickerWindow(
            pt,
            System.Windows.Forms.FormBorderStyle.FixedToolWindow,
            ThemeColorPickerWindow.Action.CloseWindow,
            ThemeColorPickerWindow.Action.CloseWindow);
        f.ColorSelected += new ThemeColorPickerWindow.colorSelected(f_ColorSelected);
        f.Show();
    }
    void f_ColorSelected(object sender, ColorSelectedArg e)
    {
     
    }
    void checkcombo()
    {
        if (comboBox1.Text == "RGB")
        {
            groupBox1.Enabled = true;

            
            
        }
        else
        {
            
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            updatepanel();
          groupBox1.Enabled = false;
        }


    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        checkcombo();
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        textBox2.Text = Convert.ToString(trackBar1.Value);
        updatepanel();
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
        textBox3.Text = Convert.ToString(trackBar2.Value);
        updatepanel();
    }

    private void trackBar3_Scroll(object sender, EventArgs e)
    {
        textBox4.Text = Convert.ToString(trackBar3.Value);
        updatepanel();
    }


    void updatepanel()
    {
        panel1.BackColor = Color.FromArgb(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        
   
        


    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
       
        

    }


  }
}
