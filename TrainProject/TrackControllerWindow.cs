using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainProject
{
    public partial class TrackControllerWindow : Form
    {

        public static TrackControllerModule controllerModule;
        public static PLCProgram plc = new PLCProgram();
        //need to make call to track controller module?
        //set up tabs for individual controllers
        public TrackControllerWindow()
        {
            InitializeComponent();

            //check if controllerModule has already been instantiated from office
            controllerModule = new TrackControllerModule();
        }


        //function displays all the active controllers, and the switches/crossings they control
        public void initializeControllerTable()
        {
            activeControllersListView.Items.Clear();
            foreach(TrackController ctrl in TrackControllerModule.activeControllers)
            {
                String switchIds = "", crossingIds = "";
                for (int i = 0; i < ctrl.getSwitches().Count; i++)
                {
                    switchIds += ctrl.getSwitches().ElementAt(i).switchId + ",";
                }

                if(switchIds.Length != 0)
                {
                    switchIds = switchIds.Substring(0, switchIds.Length - 1);
                }
                    
                for (int i = 0; i < ctrl.getCrossings().Count; i++)
                {
                    crossingIds += ctrl.getCrossings().ElementAt(i).crossingId + ",";
                }
                if(crossingIds.Length != 0)
                {
                    crossingIds = crossingIds.Substring(0, crossingIds.Length - 1);
                }
                    
                activeControllersListView.Items.Add(new ListViewItem(new[] { ctrl.controllerId.ToString(), switchIds, crossingIds }));
            }
        }

        public void initializeCrossingTable()
        {
            foreach(TrackController ctrl in TrackControllerModule.activeControllers)
            {
                try
                {
                    ListView temp = (ListView)this.Controls.Find(ctrl.controllerName + "CrossingListView", true)[0];
                    Console.WriteLine("Found list view");
                    Console.WriteLine(temp);
                    //green1CrossingListView.FullRowSelect = true;
                    //ListViewExtender extendo = new ListViewExtender(green1CrossingListView);
                    //ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
                    //buttonAction.Click += toggleCrossing;
                    //buttonAction.FixedWidth = true;
                    //extendo.AddColumn(buttonAction);
                    temp.FullRowSelect = true;
                    ListViewExtender extendo = new ListViewExtender(temp);
                    ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
                    buttonAction.Click += toggleCrossing;
                    buttonAction.FixedWidth = true;
                    extendo.AddColumn(buttonAction);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateCrossings()
        {
            foreach(TrackController ctrl in TrackControllerModule.activeControllers)
            {
                try
                {

                    ListView temp = (ListView)this.Controls.Find(ctrl.controllerName + "CrossingListView", true)[0];
                    temp.Items.Clear();
                    foreach (Crossing c in ctrl.getCrossings())
                    {
                        temp.Items.Add(new ListViewItem(new[] { c.blockId.ToString(), c.activated.ToString(), "Toggle" }));
                    }
                }
                catch(Exception e)
                {

                }
            }  
        }

        private void toggleCrossing(object sender, ListViewColumnMouseEventArgs e)
        {
            int crossingId = Int32.Parse(e.Item.SubItems[0].Text); //get switch id
            Console.WriteLine(crossingId);
            //bool newState = TrackControllerModule.greenLineCtrl1.toggleCrossing(crossingId);
            //e.Item.SubItems[1].Text = newState.ToString();
            
            foreach (TrackController ctrl in TrackControllerModule.activeControllers)
            {
                Console.WriteLine(ctrl.controllerName);
                if (ctrl.getCrossings().Find(x => x.blockId == crossingId) != null)
                {
                    bool newState = ctrl.toggleCrossing(crossingId);
                    e.Item.SubItems[1].Text = newState.ToString();
                    MessageBox.Show(this, @"Crossing at block " + crossingId + ": Activated - " + newState);
                }
            }
        }

        public void initializeSwitchTable()
        {
            foreach (TrackController ctrl in TrackControllerModule.activeControllers)
            {
                try{
                    ListView temp = (ListView)this.Controls.Find(ctrl.controllerName + "SwitchListView", true)[0];
                    temp.FullRowSelect = true;
                    ListViewExtender extendo = new ListViewExtender(temp);
                    ListViewButtonColumn buttonAction = new ListViewButtonColumn(3);
                    buttonAction.Click += changeSwitch;
                    buttonAction.FixedWidth = true;
                    extendo.AddColumn(buttonAction);
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateSwitches()
        {
            foreach (TrackController ctrl in TrackControllerModule.activeControllers)
            {
                try
                {
                    ListView temp = (ListView)Controls.Find(ctrl.controllerName + "SwitchListView", true)[0];
                    temp.Items.Clear();
                    foreach (Switch s in ctrl.getSwitches())
                    {
                        temp.Items.Add(new ListViewItem(new[] { s.switchId.ToString(), s.sourceBlockId.ToString(), s.currentState.ToString(), "Change" }));
                    }
                }
                catch(Exception e)
                {

                }
            }
            updateSwitchLights();
        }

        public void updateSwitchLights()
        {
            foreach(TrackController ctrl in TrackControllerModule.activeControllers)
            {
                try
                {
                    ListView temp = (ListView)Controls.Find(ctrl.controllerName + "SwitchLightView", true)[0];
                    temp.Items.Clear();
                    int i = 0;
                    foreach (Switch s in ctrl.getSwitches())
                    {
                        String sourceLight, t1Light, t2Light;
                        sourceLight = (s.sourceLight) == true ? "Green" : "Red";
                        t1Light = (s.t1Light) == true ? "Green" : "Red";
                        t2Light = (s.t2Light) == true ? "Green" : "Red";
                        temp.Items.Add(new ListViewItem(new[] { s.switchId.ToString(), sourceLight, t1Light, t2Light }));
                        temp.Items[i].UseItemStyleForSubItems = false;
                        temp.Items[i].SubItems[1].BackColor = System.Drawing.Color.GreenYellow;
                        temp.Items[i].SubItems[1].BackColor = (s.sourceLight) == true ? System.Drawing.Color.GreenYellow : System.Drawing.Color.OrangeRed;
                        temp.Items[i].SubItems[2].BackColor = (s.t1Light) == true ? System.Drawing.Color.GreenYellow : System.Drawing.Color.OrangeRed;
                        temp.Items[i].SubItems[3].BackColor = (s.t2Light) == true ? System.Drawing.Color.GreenYellow : System.Drawing.Color.OrangeRed;
                        i++;
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
        public void updateTrains()
        {
            try
            {
                ListView temp = (ListView)Controls.Find("trainsSummaryView", true)[0];
                temp.Items.Clear();
                foreach (var train in TrackControllerModule.activeTrains)
                {
                    temp.Items.Add(new ListViewItem(new[] { train.getTrainId().ToString(), train.getCurrBlock().ToString(), train.getCurrSpeed().ToString(), train.getTC().getRemainingAuthority().ToString() }));
                }
            }
            catch (Exception e)
            {

            }
        }

        private void changeSwitch(object sender, ListViewColumnMouseEventArgs e)
        {
            Console.WriteLine("Changing switch");
            Console.WriteLine(e.Button);
            int switchId = Int32.Parse(e.Item.SubItems[0].Text); //get switch id
            foreach(TrackController ctrl in TrackControllerModule.activeControllers)
            {
                if(ctrl.getSwitches().Find(x => x.switchId == switchId) != null)
                {
                    int? newState = ctrl.changeSwitchState(switchId);
                    e.Item.SubItems[2].Text = newState.ToString();
                    MessageBox.Show(this, @"Switch " + switchId + " changed to block " + newState);
                    updateSwitchLights();
                    break;
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String testBlocks = textBox2.Text;
            if (string.IsNullOrEmpty(testBlocks))
            {
                return;
            }
            String[] vectors = testBlocks.Split(' ');
            TrackControllerModule.redLineCtrl1.blocks.Clear();
            richTextBox1.Text = "Test Inputs:\n ";
            richTextBox1.Text += "Occupancy\tTowards/Away\n";
            foreach (String v in vectors)
            {
                if (string.IsNullOrEmpty(v))
                {
                    return;
                }
                String v2 = v.Trim('{');
                v2 = v2.Trim('}');
                //vector[0] represents block, vector[1] represents direction
                String[] vector = v2.Split(',');
                Block b = new Block(Int32.Parse(vector[0]), Int32.Parse(vector[1]));
                TrackControllerModule.redLineCtrl1.addNewBlock(b);
                //Console.WriteLine(vector[0] + " " + vector[1]);
                richTextBox1.Text += vector[0] + "\t\t\t" + (Int32.Parse(vector[1])>0).ToString() + "\n";
            }
            TrackControllerModule.redLineCtrl1.monitorSwitches();
            TrackControllerModule.redLineCtrl1.monitorCrossings();
            updateSwitches();
            updateCrossings();
            richTextBox1.Text += "\n---------\nTest Complete";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openPLCFile.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader reader = File.OpenText(openPLCFile.FileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if(plc.handleLine(line) == false)
                {
                    MessageBox.Show(this, @"Error parsing plc file. Line: " + line);
                }
            }
            reader.Close();
            MessageBox.Show(this, @"PLC File parsed");
        }
    }
}
