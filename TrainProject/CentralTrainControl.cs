using System;
using System.ComponentModel;
using System.Windows.Forms;
using TrainProject;

namespace CTC
{
    public partial class CentralTrainControl : Form
    {
        class Block //temporary, just for demo
        {
            public int blockId { get; set; }

            public Block(int id)
            {
                blockId = id;
            }
        }

        private ListViewItem currentTrainSelection;
        private int currentBlockSelection;
        private int suggestedSpeed;
        private int suggestedAuth;
        private Block block0;
        private Block block1;
        private Block block2;
        private Block block3;
        private Block block4;
        private Block block5;
        private Block block6;
        private Block block7;
        private Block block8;
        private Block block9;
        private Block block10;
        private Block block11;
        private Block block12;
        private Block block13;
        private Train train0;
        private Train train1;
        private Train train2;
        private Train train3;
        private Train train4;
        private Train train5;
        private Train train6;
        private Train train7;
        private Train train8;
        private Train train9;
        private Train train10;
        private Train train11;
        private Train train12;
        private int numPass;
        private DateTime start;




        public CentralTrainControl()
        {
            InitializeComponent();
            createTrainObjects(); //this will be an "infinite" loop of creates, they'll be created as needed
            createTrainInfoList();
            createBlockObjects();
            fillScheduleBox();
            start = DateTime.Now.ToLocalTime();

        }

        public void createTrainObjects()
        {
            train0 = new Train(0, 0, 0);
            train0.suggestedSpeed = 0;
            train0.remainingAuthority = 0;
            train1 = new Train(1, 0, 0);
            train1.suggestedSpeed = 0;
            train1.remainingAuthority = 0;
            train2 = new Train(2, 0, 0);
            train2.suggestedSpeed = 0;
            train2.remainingAuthority = 0;
            train3 = new Train(3, 0, 0);
            train3.suggestedSpeed = 0;
            train3.remainingAuthority = 0;
            train4 = new Train(4, 0, 0);
            train4.suggestedSpeed = 0;
            train4.remainingAuthority = 0;
            train5 = new Train(5, 0, 0);
            train5.suggestedSpeed = 0;
            train5.remainingAuthority = 0;
            train6 = new Train(6, 0, 0);
            train6.suggestedSpeed = 0;
            train6.remainingAuthority = 0;
            train7 = new Train(7, 0, 0);
            train7.suggestedSpeed = 0;
            train7.remainingAuthority = 0;
            train8 = new Train(8, 0, 0);
            train8.suggestedSpeed = 0;
            train8.remainingAuthority = 0;
            train9 = new Train(9, 0, 0);
            train9.suggestedSpeed = 0;
            train9.remainingAuthority = 0;
            train10 = new Train(10, 0, 0);
            train10.suggestedSpeed = 0;
            train10.remainingAuthority = 0;
            train11 = new Train(11, 0, 0);
            train11.suggestedSpeed = 0;
            train11.remainingAuthority = 0;
            train12 = new Train(12, 0, 0);
            train12.suggestedSpeed = 0;
            train12.remainingAuthority = 0;
        }

        private void createTrainInfoList()
        {
            trainInfoList.View = View.Details;

            trainInfoList.Columns.Add("Train ID", 80);
            trainInfoList.Columns.Add("Block Location", 120);
            trainInfoList.Columns.Add("Sug. Speed", 100);
            trainInfoList.Columns.Add("Sug. Auth", 100);

            trainInfoList.Items.Add(train0.trainId.ToString(), 0);
            trainInfoList.Items[0].SubItems.Add(train0.currBlock.ToString());
            trainInfoList.Items[0].SubItems.Add(train0.suggestedSpeed.ToString());
            trainInfoList.Items[0].SubItems.Add(train0.remainingAuthority.ToString());
            trainInfoList.Items.Add(train1.trainId.ToString(), 1);
            trainInfoList.Items[1].SubItems.Add(train1.currBlock.ToString());
            trainInfoList.Items[1].SubItems.Add(train1.suggestedSpeed.ToString());
            trainInfoList.Items[1].SubItems.Add(train1.remainingAuthority.ToString());
            trainInfoList.Items.Add(train2.trainId.ToString(), 2);
            trainInfoList.Items[2].SubItems.Add(train2.currBlock.ToString());
            trainInfoList.Items[2].SubItems.Add(train2.suggestedSpeed.ToString());
            trainInfoList.Items[2].SubItems.Add(train2.remainingAuthority.ToString());
            trainInfoList.Items.Add(train3.trainId.ToString(), 3);
            trainInfoList.Items[3].SubItems.Add(train3.currBlock.ToString());
            trainInfoList.Items[3].SubItems.Add(train3.suggestedSpeed.ToString());
            trainInfoList.Items[3].SubItems.Add(train3.remainingAuthority.ToString());
            trainInfoList.Items.Add(train4.trainId.ToString(), 4);
            trainInfoList.Items[4].SubItems.Add(train4.currBlock.ToString());
            trainInfoList.Items[4].SubItems.Add(train4.suggestedSpeed.ToString());
            trainInfoList.Items[4].SubItems.Add(train4.remainingAuthority.ToString());
            trainInfoList.Items.Add(train5.trainId.ToString(), 5);
            trainInfoList.Items[5].SubItems.Add(train5.currBlock.ToString());
            trainInfoList.Items[5].SubItems.Add(train5.suggestedSpeed.ToString());
            trainInfoList.Items[5].SubItems.Add(train5.remainingAuthority.ToString());
            trainInfoList.Items.Add(train6.trainId.ToString(), 6);
            trainInfoList.Items[6].SubItems.Add(train6.currBlock.ToString());
            trainInfoList.Items[6].SubItems.Add(train6.suggestedSpeed.ToString());
            trainInfoList.Items[6].SubItems.Add(train6.remainingAuthority.ToString());
            trainInfoList.Items.Add(train7.trainId.ToString(), 7);
            trainInfoList.Items[7].SubItems.Add(train7.currBlock.ToString());
            trainInfoList.Items[7].SubItems.Add(train7.suggestedSpeed.ToString());
            trainInfoList.Items[7].SubItems.Add(train7.remainingAuthority.ToString());
            trainInfoList.Items.Add(train8.trainId.ToString(), 8);
            trainInfoList.Items[8].SubItems.Add(train8.currBlock.ToString());
            trainInfoList.Items[8].SubItems.Add(train8.suggestedSpeed.ToString());
            trainInfoList.Items[8].SubItems.Add(train8.remainingAuthority.ToString());
            trainInfoList.Items.Add(train9.trainId.ToString(), 9);
            trainInfoList.Items[9].SubItems.Add(train9.currBlock.ToString());
            trainInfoList.Items[9].SubItems.Add(train9.suggestedSpeed.ToString());
            trainInfoList.Items[9].SubItems.Add(train9.remainingAuthority.ToString());
            trainInfoList.Items.Add(train10.trainId.ToString(), 10);
            trainInfoList.Items[10].SubItems.Add(train10.currBlock.ToString());
            trainInfoList.Items[10].SubItems.Add(train10.suggestedSpeed.ToString());
            trainInfoList.Items[10].SubItems.Add(train10.remainingAuthority.ToString());
            trainInfoList.Items.Add(train11.trainId.ToString(), 11);
            trainInfoList.Items[11].SubItems.Add(train11.currBlock.ToString());
            trainInfoList.Items[11].SubItems.Add(train11.suggestedSpeed.ToString());
            trainInfoList.Items[11].SubItems.Add(train11.remainingAuthority.ToString());
            trainInfoList.Items.Add(train12.trainId.ToString(), 12);
            trainInfoList.Items[12].SubItems.Add(train12.currBlock.ToString());
            trainInfoList.Items[12].SubItems.Add(train12.suggestedSpeed.ToString());
            trainInfoList.Items[12].SubItems.Add(train12.remainingAuthority.ToString());
        }

        private void createBlockObjects() //normally I wont be creating the block, just doing this for demo
        {
            block0 = new Block(0);
            block1 = new Block(1);
            block2 = new Block(2);
            block3 = new Block(3);
            block4 = new Block(4);
            block5 = new Block(5);
            block6 = new Block(6);
            block7 = new Block(7);
            block8 = new Block(8);
            block9 = new Block(9);
            block10 = new Block(10);
            block11 = new Block(11);
            block12 = new Block(12);
            block13 = new Block(13);
        }

        private void fillScheduleBox()
        {
            selectScheduleComboBox.Items.Add(block0.blockId.ToString());
            selectScheduleComboBox.Items.Add(block1.blockId.ToString());
            selectScheduleComboBox.Items.Add(block2.blockId.ToString());
            selectScheduleComboBox.Items.Add(block3.blockId.ToString());
            selectScheduleComboBox.Items.Add(block4.blockId.ToString());
            selectScheduleComboBox.Items.Add(block5.blockId.ToString());
            selectScheduleComboBox.Items.Add(block6.blockId.ToString());
            selectScheduleComboBox.Items.Add(block7.blockId.ToString());
            selectScheduleComboBox.Items.Add(block8.blockId.ToString());
            selectScheduleComboBox.Items.Add(block9.blockId.ToString());
            selectScheduleComboBox.Items.Add(block10.blockId.ToString());
            selectScheduleComboBox.Items.Add(block11.blockId.ToString());
            selectScheduleComboBox.Items.Add(block12.blockId.ToString());
            selectScheduleComboBox.Items.Add(block13.blockId.ToString());

        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            //setSpeed()
            //sendSpeedAndAuthority
        }

        private void authTrackBar_Scroll(object sender, EventArgs e)
        {
            //setAuthority()
            //sendSpeedAndAuthority

        }

        private void openBlockButton_Click(object sender, EventArgs e)
        {
            //openBlock()
        }

        private void closeBlockButton_Click(object sender, EventArgs e)
        {
            //closeBlock()
        }

        private void lineSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectLineToShow()

        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            //setSystemMode = manual
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            //setSystemMode() = automatic
        }

        private void mboRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setAutomaticMode() = MBO
        }

        private void fbRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setAutomaticMode() = FB
        }

        private void selectScheduleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String temp = selectScheduleComboBox.SelectedItem.ToString();
            int tempInt = Convert.ToInt32(temp);
            currentBlockSelection = tempInt;
        }

        private void dispatchTrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int trainIndex = currentTrainSelection.Index;
                switch (trainIndex)
                {
                    case 0:
                        train0.suggestedSpeed = suggestedSpeed;
                        train0.remainingAuthority = suggestedAuth;
                        train0.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 1:
                        train1.suggestedSpeed = suggestedSpeed;
                        train1.remainingAuthority = suggestedAuth;
                        train1.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 2:
                        train2.suggestedSpeed = suggestedSpeed;
                        train2.remainingAuthority = suggestedAuth;
                        train2.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 3:
                        train3.suggestedSpeed = suggestedSpeed;
                        train3.remainingAuthority = suggestedAuth;
                        train3.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 4:
                        train4.suggestedSpeed = suggestedSpeed;
                        train4.remainingAuthority = suggestedAuth;
                        train4.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 5:
                        train5.suggestedSpeed = suggestedSpeed;
                        train5.remainingAuthority = suggestedAuth;
                        train5.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 6:
                        train6.suggestedSpeed = suggestedSpeed;
                        train6.remainingAuthority = suggestedAuth;
                        train6.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 7:
                        train7.suggestedSpeed = suggestedSpeed;
                        train7.remainingAuthority = suggestedAuth;
                        train7.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 8:
                        train8.suggestedSpeed = suggestedSpeed;
                        train8.remainingAuthority = suggestedAuth;
                        train8.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 9:
                        train9.suggestedSpeed = suggestedSpeed;
                        train9.remainingAuthority = suggestedAuth;
                        train9.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 10:
                        train10.suggestedSpeed = suggestedSpeed;
                        train10.remainingAuthority = suggestedAuth;
                        train10.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 11:
                        train11.suggestedSpeed = suggestedSpeed;
                        train11.remainingAuthority = suggestedAuth;
                        train11.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    case 12:
                        train12.suggestedSpeed = suggestedSpeed;
                        train12.remainingAuthority = suggestedAuth;
                        train12.currBlock = currentBlockSelection;
                        trainInfoList.Clear();
                        createTrainInfoList();
                        break;
                    default:
                        break;


                }
            }

            catch (NullReferenceException)
            {
                MessageBox.Show("You have to select a Train before Dispatching.");
                return;
            }



        }

        private void wallClockRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setSystemSpeed() = wallClock
        }

        private void tenTimesLabel_CheckedChanged(object sender, EventArgs e)
        {
            //setSystemSpeed() = tenTime
        }

        private void fixTrainButton_Click(object sender, EventArgs e)
        {
            //sendTrainMaintenance()
        }

        private void fixTrackButton_Click(object sender, EventArgs e)
        {
            //sendTrackMaintenance()
        }

        private void trainInfoList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            currentTrainSelection = e.Item;
            numTrainsInServValue.Text = trainInfoList.Items.Count.ToString();
            try
            {
                trainNumberValue.Text = currentTrainSelection.Index.ToString();
            }
            catch (NullReferenceException)
            {
                trainNumberValue.Text = "-";
            }

            blockNumberValue.Text = currentBlockSelection.ToString();
            currentAuthValue.Text = suggestedAuth.ToString();
            currentSpeedValue.Text = suggestedSpeed.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal temp = numericUpDown1.Value;
            suggestedSpeed = (int)temp;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            decimal temp = numericUpDown2.Value;
            suggestedAuth = (int)temp;
        }

        private void updateTime()
        {
            timeValue.Text = DateTime.Now.ToShortTimeString();
        }

        private void numPassengersUpDown_ValueChanged(object sender, EventArgs e)
        {
            updateTime();
            string numPassString = numPassengersUpDown.Value.ToString();
            numPass = Convert.ToInt32(numPassString);

            calculateThroughput(numPass);
        }

        private void calculateThroughput(int np)
        {
            TimeSpan timePassed = DateTime.Now.Subtract(start);
            Console.Out.WriteLine(timePassed.Seconds);
            string timePassStr = Convert.ToString(timePassed.Seconds);
            double timePassDoub = Convert.ToDouble(timePassStr);
            double throughput = np / (timePassDoub / 3600);
            throughputValue.Text = throughput.ToString();
        }
    }
}

