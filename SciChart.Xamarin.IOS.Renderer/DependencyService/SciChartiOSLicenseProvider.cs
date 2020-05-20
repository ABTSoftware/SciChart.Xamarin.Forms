using SciChart.iOS.Charting;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(SciChart.Xamarin.iOS.Renderer.DependencyService.SciChartiOSLicenseProvider))]
namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class SciChartiOSLicenseProvider : INativeSciChartLicenseProvider
    {
        public void ApplyLicenseKey(string licenseKey)
        {
           SCIChartSurface.SetRuntimeLicenseKey(licenseKey);
        }

        public SciChartPlatform Platform => SciChartPlatform.iOS;
    }
}