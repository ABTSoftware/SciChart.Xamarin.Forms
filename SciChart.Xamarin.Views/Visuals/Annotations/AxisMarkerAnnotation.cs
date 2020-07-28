using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    public partial class AxisMarkerAnnotation
    {
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == "BackgroundColor")
            {
                SetBackgroundColor(BackgroundColor);
            }
        }

        public void SetBackgroundColor(Color backgroundColor)
        {
            NativeSciChartObject.CastSciChartObject<IAxisMarkerAnnotation>().SetBackgroundColor(backgroundColor);
        }
    }
}