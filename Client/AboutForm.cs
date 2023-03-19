using System;
using System.IO;
using System.Windows.Forms;

namespace ColloquorClient {
    public partial class AboutForm:Form {
        public AboutForm() {InitializeComponent();}
        private void OKBTN_Click(object sender,EventArgs e) {Close();}

        private void ExtractColloquorBTN_Click(object sender,EventArgs e) {
            if(File.Exists("Colloquor2.4.zip")) { File.Delete("Colloquor2.4.zip"); }
            File.WriteAllBytes("Colloquor2.4.zip",Properties.Resources.Colloquor2_4);
            MessageBox.Show("Colloquor2.4.zip was extracted to the directory this client is located in. Enjoy!","Thanks",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
