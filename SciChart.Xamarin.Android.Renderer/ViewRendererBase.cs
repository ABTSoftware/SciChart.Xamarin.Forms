using System.ComponentModel;
using Android.Content;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SciChart.Xamarin.Android.Renderer
{
    public class ViewRendererBase<TView, TNativeView> : ViewRenderer<TView, TNativeView> where TView : View where TNativeView : global::Android.Views.View
    {
        private readonly PropertyMapper<TView, TNativeView> _propertyMapper;

        public ViewRendererBase(Context context, PropertyMapper<TView, TNativeView> propertyMapper) : base(context)
        {
            _propertyMapper = propertyMapper;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                _propertyMapper.Detach();
            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    // Create the native control 
                    this.SetNativeControl(CreateNativeControl());
                }

                _propertyMapper.Attach(e.NewElement, Control);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
            _propertyMapper.OnSourcePropertyChanged(e.PropertyName);
        }
    }
}