using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ColloquorClient {
    public partial class LoginForm:Form {

        //--------------------------------------------[Variables]--------------------------------------------
        private Colloquor.ColloquorClient MainClient;
        private Colloquor.ColloquorClient.CQUORConnectionResult ConnectResult;
        private StandbyForm MyStandbyForm;

        //--------------------------------------------[Constructor]--------------------------------------------

        public LoginForm() {InitializeComponent();}

        //--------------------------------------------[Buttons]--------------------------------------------

        private void CheckForEnter(object sender,KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {button1_Click("Hello",new EventArgs());}
        }

        private void pictureBox1_Click(object sender,EventArgs e) {new AboutForm().ShowDialog();}

        private void button1_Click(object sender,EventArgs e) {

            if(!int.TryParse(PortBox.Text,out int Port)) {
                MessageBox.Show("I could not parse the port into a number! Check your port","oopsie",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            MainClient = new Colloquor.ColloquorClient(IPBox.Text,Port,UsernameBox.Text,PasswordBox.Text);
            MyStandbyForm = new StandbyForm();

            MyStandbyForm.Show();
            Enabled = false;
            ConnectBW.RunWorkerAsync();
        }

        //--------------------------------------------[Connect Background worker]--------------------------------------------

        private void ConnectBW_DoWork(object sender,DoWorkEventArgs e) {ConnectResult = MainClient.Connect();}
        private void ConnectBW_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e) {

            Enabled = true;
            MyStandbyForm.Close();
            
            switch(ConnectResult) {
               case Colloquor.ColloquorClient.CQUORConnectionResult.NOCONNECT:
                   MessageBox.Show("Unable to connect to " + MainClient.GetIP(),"woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                   break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.LOGININVALID:
                    MessageBox.Show("Unable to login: Invalid Credentials","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MainClient.Close();
                break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.LOGINALREADY:
                    MessageBox.Show("Unable to login: Wait this isn't supposed to happen. Close the program and open it back up.","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MainClient.Close();
                break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.LOGINOTHERLOCALE:
                    MessageBox.Show("Unable to login: You're already logged in somewhere else!","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MainClient.Close();
                break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.LOGINOTHER:
                    MessageBox.Show("Unable to login: Something happened and the server couldn't log you in.","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MainClient.Close();
                break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.NOCOLLOQUOR:
                    MessageBox.Show("This server doesn't have the Colloquor extension!","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MainClient.Close();
                    break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.NOPERMISSION:
                    MessageBox.Show("You don't have permission to use the colloquor extension on this server","woops",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MainClient.Close();
                break;
                case Colloquor.ColloquorClient.CQUORConnectionResult.SUCCESS:
                    Hide();
                    new ChannelPicker(ref MainClient).ShowDialog();    
                    Show();
                    MainClient.Close();
                    break;
                default:
                    break;
                }

        }

    }
}
