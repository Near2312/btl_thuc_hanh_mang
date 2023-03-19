using Colloquor;
using System;
using System.Collections.Generic;

namespace Switchboard {
    
    /// <summary>Configuration of the Switchboard Server.</summary>
    public static class SwitchboardConfiguration {

        /// <summary>Name of this server</summary>
        public const String ServerName = "Colloquor Server";

        /// <summary>Version of this server</summary>
        public const String ServerVersion = "Version 1.0";

        /// <summary>Default IP for this server</summary>
        public const String DefaultIP = "127.0.0.1";

        /// <summary>Default port for this server</summary>
        public const int DefaultPort = 909;

        /// <summary>Allow Anonymous users by default or no</summary>
        public const bool AllowAnonymousDefault = false;

        /// <summary>Allow multiple logins wit the same account or no</summary>
        public const bool MultiLoginDefault = false;

        /// <summary>Default Welcome Message</summary>
        public const String DefaultWelcome = "Welcome to this Colloquor server!";

        /// <summary>Gets a list of the extensions from this server</summary>
        public static List<SwitchboardExtension> ServerExtensions() {

            List<SwitchboardExtension> List = new List<SwitchboardExtension>();

            //Here add/initialize your server extensions.
            //By default, the server will always have the DummyExtension, and the Switchboard Main Extension.

            List.Add(new ColloquorExtension()); //woop there it is.

            return List;

        }

    }
}
