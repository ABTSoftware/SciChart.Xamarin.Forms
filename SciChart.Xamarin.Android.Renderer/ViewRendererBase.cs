using System.ComponentModel;
using Android.Content;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms.Platform.Android;

namespace SciChart.Xamarin.Android.Renderer
{
    public class ViewRendererBase<TView, TNativeView> : ViewRenderer<TView, TNativeView> where TView : NativeViewProvider where TNativeView : global::Android.Views.View
    {
        private readonly PropertyMapper<TView, TNativeView> _propertyMapper;

        public ViewRendererBase(Context context, PropertyMapper<TView, TNativeView> propertyMapper) : base(context)
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