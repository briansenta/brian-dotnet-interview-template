using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterview
{
    public interface IRegistryService
    {
        bool CheckIfInstalled(string softwareName);
    }

    public class RegistryService : IRegistryService
    {
        private ILogger<RegistryService> _logger;

        public RegistryService(ILogger<RegistryService> logger)
        {
            _logger = logger;
        }

        public bool CheckIfInstalled(string softwareName)
        {
            // TODO: Implement this method to check if the given software name
            // can be found as an installed application in the Windows registry.

            // The search should be case insensitive and should
            // include partial matches.

            if (string.IsNullOrWhiteSpace(softwareName))
            {
                throw new ArgumentNullException(nameof(softwareName));
            }

            _logger.LogInformation("Querying for installed apps. This may take a minute or so ...");
            List<string> installedApplications = new List<string>();
            var mos = new ManagementObjectSearcher("select * from Win32_Product");
            foreach (ManagementObject mo in mos.Get())
            {
                var appName = mo["Name"]?.ToString();
                if (!string.IsNullOrWhiteSpace(appName))
                {
                    installedApplications.Add(appName);
                }
            }

            return installedApplications.Any(a => a.ToLower().Contains(softwareName.ToLower()));
        }
    }
}
