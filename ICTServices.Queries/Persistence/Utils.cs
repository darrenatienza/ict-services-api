using API.Queries.Core.Domain;
using API.Queries.Core.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API.Queries.Persistence
{
    public class Utils
    {


        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static string GetAliasName(string firstName, string lastName)
        {
            return string.Format("{0} {1}", firstName.Substring(0,1), lastName);
        }
        public static string ToValidFullNameFormat(string firstName, string middleName, string lastName)
        {
            if (middleName != "")
            {
                return string.Format("{0} {1}. {2}", firstName, middleName.Substring(0, 1), lastName);
            }
            return string.Format("{0} {1}", firstName, lastName);
        }
        public static string RandomNumbers(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        public static void EncryptConnectionString(bool encrypt, string fileName)
        {
            Configuration configuration = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        //this line will encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt && configSection.SectionInformation.IsProtected)//encrypt is true so encrypt
                    {
                        //this line will decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration

                    configuration.Save();
                    //configFile.FilePath 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Concat all string values separated by comma (,)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GetConcatString(params string[] values){
            var val = "";
            foreach (var item in values)
            {
                val = val + "," + item;
            }
            return val;
        }
    }
    public class ItemX
    {
        public string Name;
        public string Value;
        public ItemX(string name, string value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }

    public static class CurrentUser
    {
        public static User User { get; set; }
        public static bool HasPermission(string permissionName)
        {
            if (User.UserID == 1)
            {
                return true;
            }

            var permission = User.Permissions.Where(p => p.Description.ToUpper() == permissionName.ToUpper()).FirstOrDefault();
            if (permission != null)
            {
                return true;
            }

            return false;
        }
    }
    public static class SysRole
    {
        /// <summary>
        /// Administrator Role
        /// </summary>
        public  const string Admin = "Admin";
        /// <summary>
        /// Security Services Office Role
        /// </summary>
        public  const string SSO = "SSO";
        /// <summary>
        /// Library Services
        /// </summary>
        public const string LIB = "LIB";
        public const string SOAHead = "SOAHead";
        /// <summary>
        /// Administrator Role or Security Services Office Role
        /// </summary>
        public  const string Admin_SSO_LIB  = Admin + "," + SSO + "," + LIB;
        public const string Admin_SOAHead = Admin + "," + SOAHead;
    }
    internal class ProcessConnection
    {
        public static ConnectionOptions ProcessConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Authentication = AuthenticationLevel.Default;
            options.EnablePrivileges = true;
            return options;
        }
        public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
        {
            ManagementScope connectScope = new ManagementScope();
            connectScope.Path = new ManagementPath(@"\\" + machineName + path);
            connectScope.Options = options;
            connectScope.Connect();
            return connectScope;
        }
    }
    public class COMPortInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public COMPortInfo()
        {

        }
        public static List<COMPortInfo> GetCOMPortsInfo()
        {
            List<COMPortInfo> comPortInfoList = new List<COMPortInfo>();
            ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
            ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");
            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);
            using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj != null)
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                COMPortInfo comPortInfo = new COMPortInfo();
                                comPortInfo.Name = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                                comPortInfo.Description = caption;
                                comPortInfoList.Add(comPortInfo);
                            }
                        }
                    }
                }
                return comPortInfoList;
            }

        }
    }
    public enum ReservationStatus
    {
        None,
        Borrowed,
        Returned
    }
}
