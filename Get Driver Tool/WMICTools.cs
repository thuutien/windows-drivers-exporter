using System.Management;


namespace Get_Driver_Tool
{
    internal class WMICTools
    {
        public static string getManufacturer()
        {
            string manufacturer = "";
            ManagementObjectSearcher s = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject wmi in s.Get())
            {
                try
                {
                    manufacturer = wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }

            return manufacturer;
        }

        public static string getModelName()
        {
            string modelName = "";
            ManagementObjectSearcher s = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            foreach (ManagementObject wmi in s.Get())
            {
                try
                {
                    modelName = wmi.GetPropertyValue("Model").ToString();
                }
                catch { }

            }

            return modelName;
        }


    }
}
