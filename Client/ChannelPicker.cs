using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ColloquorClient {
    public partial class ChannelPicker:Form {

        //--------------------------------------------[Variables]--------------------------------------------

        public Colloquor.ColloquorClient MainClient;
        public Dictionary<String,Boolean> Channels;
        private StandbyForm MyStandbyForm;
        private Colloquor.ColloquorClient.CQUORJoinResult joinResult;

        //--------------------------------------------[Internal Classes]--------------------------------------------

        private class JoinInfo {
            public String Channel;
            public String Password;
            public bool NeedsPassword;
            public JoinInfo(String Channel, String Password) { this.Channel = Channel; this.Password = Password; NeedsPassword = true; }
            public JoinInfo(String Channel) { this.Channel = Channel; NeedsPassword = false; }
        }

        //--------------------------------------------[Constructor]--------------------------------------------

        public ChannelPicker(ref Colloquor.ColloquorClient Client) {
            InitializeComponent();

            MainClient = Client;
            if(!Client.Connected) { throw new ArgumentException("Client isn't connected"); }

            PasswordBox.Enabled = false;

            ChannelsListbox.Enabled = false;
            JoinChannelButton.Enabled = false;
            DisconnectButton.Enabled = false;
        }

        //--------------------------------------------[On Shown]--------------------------------------------

        private void OnShown(object sender,EventArgs e) {
            MyStandbyForm = new StandbyForm();
            MyStandbyForm.Show();
            ChannelsListbox.Items.Clear();
            GetChannelsBW.RunWorkerAsync();
        }

        //--------------------------------------------[Buttons and events]--------------------------------------------

        private void ChannelsListbox_SelectedIndexChanged(object sender,EventArgs e) {
            try { PasswordBox.Enabled = Channels[ChannelsListbox.SelectedItem.ToString()]; } catch { }
            JoinChannelButton.Enabled = true;
        }

        private void DisconnectButton_Click(object sender,EventArgs e) {Close();}
        private void JoinChannelButton_Click(object sender,EventArgs e) {

            JoinInfo Info;
            bool Passworded = false;

            try { Passworded = Channels[ChannelsListbox.SelectedItem.ToString()]; } 
            catch { MessageBox.Show("There's no channel selected!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }

            

            if(Passworded) { Info = new JoinInfo(ChannelsListbox.SelectedItem.ToString(),PasswordBox.Text);}
            else{ Info = new JoinInfo(ChannelsListbox.SelectedItem.ToString()); }

            Enabled = false;
            JoinChannelBW.RunWorkerAsync(Info);
        }

        //--------------------------------------------[Get Channels Background Worker]--------------------------------------------

        private void GetChannelsBW_DoWork(object sender,DoWorkEventArgs e) {Channels = MainClient.GetChannels();}
        private void GetChannelsBW_Done(object sender,RunWorkerCompletedEventArgs e) {
            MyStandbyForm.Close();

            ChannelsListbox.Items.Clear();
            foreach(String Channel in Channels.Keys) {ChannelsListbox.Items.Add(Channel);}
            
            ChannelsListbox.Enabled = true;
            DisconnectButton.Enabled = true;
        }

        //--------------------------------------------[Join Channels Background Worker]--------------------------------------------

        private void JoinChannelBW_DoWork(object sender,DoWorkEventArgs e) {
            try {
                JoinInfo Info = (JoinInfo)e.Argument;
                if(Info.NeedsPassword) { joinResult = MainClient.Join(Info.Channel,Info.Password); } else { joinResult = MainClient.Join(Info.Channel); }
            } catch(TimeoutException d) {
                joinResult = Colloquor.ColloquorClient.CQUORJoinResult.TIMEOUT;
            } catch(Exception d) {
                joinResult = Colloquor.ColloquorClient.CQUORJoinResult.UNKNOWN;
            }
        }

        private void JoinChannelBW_done(object sender,RunWorkerCompletedEventArgs e) {
            Enabled = true;

            switch(joinResult) {
                case Colloquor.ColloquorClient.CQUORJoinResult.TIMEOUT:
                    MessageBox.Show("Server timed out. Close the connection and try to reconnect","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.UNKNOWN:
                    MessageBox.Show("An Unknown error occurred while connecting to this channel","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.ALREADY:
                    if(MessageBox.Show("You're already connected on a different Colloquor Client! Force leave on the other client?","Woops",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes) {
                        MainClient.Leave();
                        MessageBox.Show("OK, Your account was kicked from the channel it was in. Try to join a channel again now.","OK",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    };
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.NOTFOUND:
                    MessageBox.Show("Uh oh the channel wasn't found! Did someone modify the settings?","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.NEEDPASS:
                    MessageBox.Show("This channel needs a password","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.WRONGPASS:
                    MessageBox.Show("Incorrect Password","Woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case Colloquor.ColloquorClient.CQUORJoinResult.SUCCESS:
                    Hide();
                    new MainForm(ref MainClient,ChannelsListbox.SelectedItem.ToString()).ShowDialog();
                    if(!MainClient.Connected) { Close(); }  //Catch if timed out
                    else { try { MainClient.Leave(); } catch(InvalidOperationException) { } Show(); } //Catch if kicked due to leave.
                    break;
                default:
                    break;
            }
        }

    }
}

