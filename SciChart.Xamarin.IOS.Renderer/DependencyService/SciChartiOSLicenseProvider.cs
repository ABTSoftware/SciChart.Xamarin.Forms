using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(SciChartiOSLicenseProvider))]
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