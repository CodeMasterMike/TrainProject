using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProject;

namespace TrackController
{
    public partial class TrackControllerWindow : Form
    {

        public TrackController ctrl = new TrackController();

        public TrackControllerWindow()
        {
            InitializeComponent();
            Switch s1 = new Switch(0, 12, 1, 13);
            Switch s2 = new Switch(1, 29, 28, 150);
            Switch s3 = new Switch(2, 50, 57, 151);
            Train t1 = new Train(1, 15.0, 20);
            Crossing c1 = new Crossing(0, 19);
            ctrl.addNewSwitch(s1);
            ctrl.addNewSwitch(s2);
            ctrl.addNewSwitch(s3);
            ctrl.addNewTrain(t1);
            ctrl.addNewCrossing(c1);
            updateTrains();
            initializeSwitchTable();
            initializeCrossingTable();
            updateSwitches();
            updateCrossings();
            initializeControllerTable();
        }

        private void initializeControllerTable()
        {
            listView4.Items.Clear();
            String switchIds = "", crossingIds = "";
            for(int i = 0; i < ctrl.getSwitches().Count; i++)
            {
                switchIds += ctrl.getSwitches().ElementAt(i).switchId + ",";
            }
            switchIds = switchIds.Substring(0, switchIds.Length -1 );
            for (int i = 0; i < ctrl.getCrossings().Count; i++)
            {
                crossingIds += ctrl.getCrossings().ElementAt(i).crossingId + ",";
            }
            crossingIds = crossingIds.Substring(0, crossingIds.Length-1 );
            listView4.Items.Add(new ListViewItem(new[] { ctrl.controllerId.ToString(), switchIds, crossingIds }));
        }

        private void initializeCrossingTable()
        {
            listView3.FullRowSelect = true;
            ListViewExtender extendo = new ListViewExtender(listView3);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
            buttonAction.Click += toggleCrossing;
            buttonAction.FixedWidth = true;
            extendo.AddColumn(buttonAction);
        }

        private void updateCrossings()
        {
            listView3.Items.Clear();
            foreach (Crossing c in ctrl.getCrossings())
            {
                listView3.Items.Add(new ListViewItem(new[] { c.blockId.ToString(), c.activated.ToString(), "Toggle" }));
            }
        }

        private void toggleCrossing(object sender, ListViewColumnMouseEventArgs e)
        {
            Console.WriteLine(ctrl.getCrossings());
            int crossingId = Int32.Parse(e.Item.SubItems[0].Text); //get switch id
            Console.WriteLine(crossingId);
            bool newState = ctrl.toggleCrossing(crossingId);
            e.Item.SubItems[1].Text = newState.ToString();
            MessageBox.Show(this, @"Crossing at block " + crossingId + ": Activated - " + newState);
        }

        private void initializeSwitchTable()
        {
            
            listView2.FullRowSelect = true;
            ListViewExtender extendo = new ListViewExtender(listView2);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(3);
            buttonAction.Click += changeSwitch;
            buttonAction.FixedWidth = true;
            extendo.AddColumn(buttonAction);
            
        }

        private void updateSwitches()
        {
            listView2.Items.Clear();
            foreach (var s in ctrl.getSwitches())
            {
                listView2.Items.Add(new ListViewItem(new[] { s.switchId.ToString(), s.sourceBlockId.ToString(), s.currentState.ToString(), "Change" }));
            }
        }
        private void updateTrains()
        {
            listView1.Items.Clear();
            foreach (var train in ctrl.getTrains())
            {
                listView1.Items.Add(new ListViewItem(new[] { train.trainId.ToString(), train.currBlock.ToString(), train.actualSpeed.ToString(), train.remainingAuthority.ToString() }));
            }
        }

        private void changeSwitch(object sender, ListViewColumnMouseEventArgs e)
        {
            int switchId = Int32.Parse(e.Item.SubItems[0].Text); //get switch id
            int newState = ctrl.changeSwitchState(switchId);
            e.Item.SubItems[2].Text = newState.ToString();
            MessageBox.Show(this, @"Switch " + switchId + " changed to block " + newState);
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
            ctrl.blocks.Clear();
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
                ctrl.addNewBlock(b);
                //Console.WriteLine(vector[0] + " " + vector[1]);
                richTextBox1.Text += vector[0] + "\t\t\t" + (Int32.Parse(vector[1])>0).ToString() + "\n";
            }
            ctrl.monitorSwitches();
            ctrl.monitorCrossings();
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
    }
}
