using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views
{
    public enum SciChartPlatform
    {
        iOS,
        Android
    }

    public class SciChartLicenseManager : IDisposable
    {
        private readonly IDictionary<SciChartPlatform, string> _licenses = new Dictionary<SciChartPlatform, string>();

        public void AddLicense(SciChartPlatform platform, string licenseKey)
        {
            _licenses.Add(platform, licenseKey);
        }

        public string GetLicense(SciChartPlatform platform)
        {
            if (_licenses.TryGetValue(platform, out string licenseKey))
            {
                return licenseKey;
            }
            return null;
        }

        public void Dispose()
        {
            var provider = DependencyService.Get<INativeSciChartLicenseProvider>();
            var licenseKey = GetLicense(provider.Platform);

            provider.ApplyLicenseKey(licenseKey);
        }
    }

    public interface INativeSciChartLicenseProvider
    {
        void ApplyLicenseKey(string licenseKey);

        SciChartPlatform Platform { get; }
    }
}
