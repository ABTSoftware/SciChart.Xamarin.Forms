using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(SciChartAndroidLicenseProvider))]
namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class SciChartAndroidLicenseProvider : INativeSciChartLicenseProvider
    {
        public void ApplyLicenseKey(string licenseKey)
        {
            SciChartSurface.SetRuntimeLicenseKey(licenseKey);
        }

        public SciChartPlatform Platform => SciChartPlatform.Android;
    }
}