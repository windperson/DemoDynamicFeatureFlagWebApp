using DemoDynamicFeatureFlagWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDynamicFeatureFlagWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManager _featureManager;

        public HomeController(ILogger<HomeController> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            if (await _featureManager.IsEnabledAsync("FeatureA-1"))
            {
                _logger.LogInformation("Feature A-1 is enabled");
            }
            else
            {
                _logger.LogInformation("Feature A-1 is disabled");
            }

            if (await _featureManager.IsEnabledAsync("FeatureA-2"))
            {
                _logger.LogInformation("Feature A-2 is enabled");
            }
            else
            {
                _logger.LogInformation("Feature A-2 is disabled");
            }

            if (await _featureManager.IsEnabledAsync("FeatureB-1"))
            {
                _logger.LogInformation("Feature B-1 is enabled");
            }
            else
            {
                _logger.LogInformation("Feature B-1 is disabled");
            }

            if (await _featureManager.IsEnabledAsync("FeatureB-2"))
            {
                _logger.LogInformation("Feature B-2 is enabled");
            }
            else
            {
                _logger.LogInformation("Feature B-2 is disabled");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}