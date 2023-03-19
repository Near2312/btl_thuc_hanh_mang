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

            //Wait for the mainclient to not be busy
            for(int i = 0; i < 500; i++) {
                if(!Mainclient.IsBusy()) { break; }
                Thread.Sleep(10);
            }

            if(Mainclient.IsBusy()) {MessageBox.Show("Could not send message, Client is likely about to time out","Woops",MessageBoxButtons.OK,MessageBoxIcon.Warning); return;}

            //Send the message
            try { Mainclient.SendMessage(SendBox.Text); } 
            catch(InvalidOperationException) { MessageBox.Show("It appears you may have been kicked from this channe. Stand by...","Algo paso",MessageBoxButtons.OK,MessageBoxIcon.Warning); }

            SendBox.Text = "";

        }

        //--------------------------------------------[ChatboxBackgroundWorker]--------------------------------------------

        private void ChatboxKeepUpdated_Start(object sender,DoWorkEventArgs e) {

            String NewLastMessage;

            CKUR = ChatboxKeepUpdatedResult.UNKNOWN;

            while(!ChatboxKeepUpdated.CancellationPending) {
                
                Thread.Sleep(50); //Make sure we have a moment to breathe
                while(Mainclient.IsBusy()) { } //Wait for the client to not be busy

                try {
                    NewLastMessage = Mainclient.RequestMessage();

                    if(NewLastMessage == "NOT CONNECTED") { CKUR = ChatboxKeepUpdatedResult.KICKED; return; } //If we were kicked, kick out the user.
                    if(!(NewLastMessage == LastMessage)) {
                        LastMessage = NewLastMessage;
                        ChatboxKeepUpdated.ReportProgress(0);
                    } //If this isn't the same as our previous message, update the cosa

                } catch(TimeoutException) {
                    CKUR = ChatboxKeepUpdatedResult.TIMEOUT; return; //If the connection times out, kick out the server.
                } catch(InvalidOperationException) {
                    CKUR = ChatboxKeepUpdatedResult.KICKED;
                    return;
                }

                Thread.Sleep(50); //Make sure we have a moment to breathe
            }

            if(CKUR == ChatboxKeepUpdatedResult.UNKNOWN) { CKUR = ChatboxKeepUpdatedResult.NORMAL_EXIT; }
        }

        //Update the textbox
        private void ChatboxKeepUpdated_Update(object sender, ProgressChangedEventArgs e) {ChatBox.AppendText(Environment.NewLine + LastMessage);}

        private void ChatboxKeepUpdated_Done(object sender,RunWorkerCompletedEventArgs e) {
            switch(CKUR) {
                case ChatboxKeepUpdatedResult.TIMEOUT:
                    MessageBox.Show("Server connection timeout. Log in again","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Mainclient.Close();
                    Close();
                    break;
                case ChatboxKeepUpdatedResult.KICKED:
                    if(!AlreadyClosed) { 
                        MessageBox.Show("You've been kicked from this channel","Algo paso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Close();
                    }
                    break;
                case ChatboxKeepUpdatedResult.NORMAL_EXIT:
                    break;
                default:
                    MessageBox.Show("Chatbox Keep Update Routine abruptly closed. Kicking you from the chatroom","Algo paso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    try { Mainclient.Leave(); } catch { }; //try in case the abrupt disconnection caused them to already leave.
                    Close();
                    break;
            }
        }

    }
}
