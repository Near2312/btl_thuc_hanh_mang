using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColloquorClient {
    public partial class MainForm:Form {

        //--------------------------------------------[Variables]--------------------------------------------

        private Colloquor.ColloquorClient Mainclient;
        private String LastMessage;
        private ChatboxKeepUpdatedResult CKUR;
        private bool AlreadyClosed = false;

        private enum ChatboxKeepUpdatedResult { 
            UNKNOWN=-3,
            TIMEOUT=-2,
            KICKED=-1,
            NORMAL_EXIT=0,
        }

        //--------------------------------------------[Constructor]--------------------------------------------

        public MainForm(ref Colloquor.ColloquorClient Client, String ChannelName) {
            InitializeComponent();
            Mainclient = Client;
            LastMessage = "";
            Text = "Colloquor : " + ChannelName;
        }

        //--------------------------------------------[Form Events]--------------------------------------------

        public void Showtime(object sender, EventArgs e) {
            ChatBox.Text = Mainclient.WelcomeHolder;
            ChatboxKeepUpdated.RunWorkerAsync();
        }

        public void ClosingTime(object sender,FormClosingEventArgs e) {
            AlreadyClosed = true;

            //Wait for the client to not be busy before closing
            while(Mainclient.IsBusy()) { }

            ChatboxKeepUpdated.CancelAsync();
        }

        //--------------------------------------------[Buttons]--------------------------------------------

        private void leaveToolStripMenuItem_Click(object sender,EventArgs e) {Close();}
        private void aboutToolStripMenuItem_Click(object sender,EventArgs e) {new AboutForm().Show();}

        private void CheckEnter(object sender,KeyEventArgs e) {if(e.KeyCode == Keys.Enter) { SendBTN_Click("hello it is me",new EventArgs()); }}
        private void SendBTN_Click(object sender,EventArgs e) {

        }

        //--------------------------------------------[ChatboxBackgroundWorker]--------------------------------------------

        private void ChatboxKeepUpdated_Start(object sender,DoWorkEventArgs e) {

          
           
        }

        //Update the textbox
        private void ChatboxKeepUpdated_Update(object sender, ProgressChangedEventArgs e) {ChatBox.AppendText(Environment.NewLine + LastMessage);}

        private void ChatboxKeepUpdated_Done(object sender, RunWorkerCompletedEventArgs e)
        {
        }

    }
}
