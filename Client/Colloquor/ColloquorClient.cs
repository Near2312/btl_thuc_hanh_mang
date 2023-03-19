using System;
using System.Collections.Generic;
using Switchboard;

namespace Colloquor {
    public class ColloquorClient:SwitchboardClient {

        private String Username;
        private String Password;

        /// <summary>Holds the welcome message so that the head can read it after noticing a connection was successfull.</summary>
        public String WelcomeHolder;

        public enum CQUORConnectionResult:int {
            NOCONNECT = 0,
            LOGININVALID = 1,
            LOGINALREADY = 2,
            LOGINOTHERLOCALE = 3,
            LOGINOTHER = 4,
            NOCOLLOQUOR = 5,
            NOPERMISSION = 6,
            SUCCESS = 7
        }

        public enum CQUORJoinResult:int {
            TIMEOUT = -2,
            UNKNOWN = -1,
            ALREADY = 0,
            NOTFOUND = 1,
            NEEDPASS = 2,
            WRONGPASS = 3,
            SUCCESS = 4
        }

        public ColloquorClient(String IP,int Port,String Username,String Password) : base(IP,Port) {
            this.Username = Username;
            this.Password = Password;
        }

        /// <summary>Connects to the Colloquor Server</summary>
        public new CQUORConnectionResult Connect() {
            
            //Connect to the server
            if(!base.Connect()) { return CQUORConnectionResult.NOCONNECT; }
            
            //Login to the server
            switch(Login(Username,Password)) {
                case LoginResult.SUCCESS:
                    break;
                case LoginResult.INVALID:
                    return CQUORConnectionResult.LOGININVALID;
                case LoginResult.ALREADY:
                   return  CQUORConnectionResult.LOGINALREADY;
                case LoginResult.OTHERLOCALE:
                    return CQUORConnectionResult.LOGINOTHERLOCALE;
                default:
                    return CQUORConnectionResult.LOGINOTHER;
            }

            //Check for Colloquor
            switch(SendReceive("CQUOR PING")) {
                case "PONG":
                    return CQUORConnectionResult.SUCCESS;
                case "NOEXECUTE":
                    return CQUORConnectionResult.NOPERMISSION;
                default:
                    return CQUORConnectionResult.NOCOLLOQUOR;

            }

        }

        /// <summary>Gets all channels on the colloquor server</summary>
        /// <returns>A dictionary, where the key is the Channel's Name, and the value is wether or not the channel has a password.</returns>
        public Dictionary<String,Boolean> GetChannels() {
            //no need to check if the server is connected or not. Send/Receive throws it already.

            //Create the dictionary
            Dictionary<String,Boolean> Channels = new Dictionary<string,bool>();
            
            String[] AllChannels = SendReceive("CQUOR ListChannels").Split(',');

            foreach(String Channel in AllChannels) {
                String[] ChannelSplit = Channel.Split(':');
                if(ChannelSplit.Length == 2) { Channels.Add(ChannelSplit[0],bool.Parse(ChannelSplit[1])); }
            }

            return Channels;
        
        }

        public String SendMessage(String Message) {
            String Reply = SendReceive("CQUOR SEND " + Message);
            if(Reply == "NOT CONNECTED") { throw new InvalidOperationException("User has not connected to a channel"); }
            return Reply;

        }

        public String RequestMessage() {
            String Reply = SendReceive("CQUOR REQUEST");
            if(Reply == "NOT CONNECTED") { throw new InvalidOperationException("User has not connected to a channel"); }
            return Reply;
        }

        public Boolean Leave() {
            String Reply = SendReceive("CQUOR LEAVE");
            if(Reply == "NOT CONNECTED") { throw new InvalidOperationException("User has not connected to a channel"); }
            return true;
        }

        public CQUORJoinResult Join(String Channel) {return Join(Channel,"");}

        public CQUORJoinResult Join(String Channel,String Password) {
            String Holder = SendReceive("CQUOR JOIN " + Channel + " " +Password);
            switch(Holder) {
                case "ALREADY CONNECTED":
                    return CQUORJoinResult.ALREADY;
                case "NOT FOUND":
                    return CQUORJoinResult.NOTFOUND;
                case "NEEDS PASS":
                    return CQUORJoinResult.NEEDPASS;
                case "WRONG PASS":
                    return CQUORJoinResult.WRONGPASS;
                default:
                    WelcomeHolder = Holder;
                    return CQUORJoinResult.SUCCESS;
            }

        }




    }
}
