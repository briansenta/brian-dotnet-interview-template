using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterview
{
    public interface ISoftwareReporter
    {
        Task ReportSoftwareInstallationStatus(string softwareName);
    }

    public class SoftwareReporter : ISoftwareReporter
    {
        // TODO: Finish implementing this class so the unit tests
        // in SoftwareReporterTests are passing.

        private readonly IRegistryService _registryService;
        private readonly IApiService _apiService;
        private readonly ILogger<SoftwareReporter> _logger;

        public SoftwareReporter
        (
            IRegistryService registryService,
            IApiService apiService,
            ILogger<SoftwareReporter> logger
        )
        {
            _registryService = registryService;
            _apiService = apiService;
            _logger = logger;
        }

        public Task ReportSoftwareInstallationStatus(string softwareName)
        {
            if (string.IsNullOrWhiteSpace(softwareName))
            {
                _logger.LogInformation("uh oh");
                throw new ArgumentNullException(nameof(softwareName));
            }

            _logger.LogInformation($"checking for '{softwareName}' ...");
            bool isInstalled = _registryService.CheckIfInstalled(softwareName);
            _logger.LogInformation(isInstalled ? "bingo" : "nope");
            return _apiService.SendInstalledSoftware(softwareName, isInstalled);
        }
    }
}
