using System.ComponentModel;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class ViewRendererBase<TView, TNativeView> : ViewRenderer<TView, TNativeView> where TView : NativeViewProvider where TNativeView : UIView
    {
        private readonly PropertyMapper<TView, TNativeView> _propertyMapper;

        public ViewRendererBase(PropertyMapper<TView, TNativeView> propertyMapper)
        {
            _propertyMapper = propertyMapper;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TView> e)
        {
            base.OnElementChanged(e);

            var oldElement = e.OldElement;
            if (oldElement != null)
            {
                _propertyMapper.Detach();
                oldElement.OnNativeViewDetached(Control);
            }

            var newElement = e.NewElement;
            if (newElement != null)
            {
                if (Control == null)
                {
                    // Create the native control 
                    this.SetNativeControl(CreateNativeControl());
                }

                _propertyMapper.Attach(newElement, Control);
                newElement.OnNativeViewAttached(Control);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            _propertyMapper.OnSourcePropertyChanged(e.PropertyName);
        }
    }
}