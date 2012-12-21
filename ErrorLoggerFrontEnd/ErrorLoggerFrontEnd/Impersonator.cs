using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;


namespace ErrorLoggerFrontEnd
{
    public class Impersonator
    {
        private IntPtr _tokenHandle = new IntPtr(0);
        private WindowsImpersonationContext _impersonatedUser;
        private const string _DOMAIN = "lord.local";

        public Impersonator(string userName, string password)
        {
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_INTERACTIVE = 2;

            this._tokenHandle = IntPtr.Zero;

            // Use LogonUser to get a handle to an access token
            bool returnValue = LogonUser(userName, _DOMAIN, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref this._tokenHandle);

            if (!returnValue)
            {
                // OH NOES!!
                int ret = Marshal.GetLastWin32Error();
                System.ComponentModel.Win32Exception up = new System.ComponentModel.Win32Exception(ret);
                throw up; // he he
            }
        }

        public void Impersonate()
        {
            // Create the new Identity from the token
            WindowsIdentity impersonatedID = new WindowsIdentity(this._tokenHandle);

            // Start impersonating as the new ID
            this._impersonatedUser = impersonatedID.Impersonate();
        }

        public void EndImpersonating()
        {
            // This stops impersonating by reverting back to the original user
            if (this._impersonatedUser != null)
                this._impersonatedUser.Undo();

            // Release that token
            if (this._tokenHandle != IntPtr.Zero)
                CloseHandle(this._tokenHandle);
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonTupe,
            int dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool CloseHandle(IntPtr handle);
    }
}
