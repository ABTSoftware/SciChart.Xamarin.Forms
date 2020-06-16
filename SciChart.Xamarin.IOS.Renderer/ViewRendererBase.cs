using System.ComponentModel;
using System.Runtime.Remoting.Contexts;
using SciChart.Xamarin.Views.Utility;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class ViewRendererBase<TView, TNativeView> : ViewRenderer<TView, TNativeView> where TView : View where TNativeView : UIView
    {
        private readonly PropertyMapper<TView, TNativeView> _propertyMapper;

        public ViewRendererBase(PropertyMapper<TView, TNativeView> propertyMapper)
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