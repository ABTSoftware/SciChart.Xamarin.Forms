using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public class NativeViewProvider : View, INativeViewProvider
    {
        public void OnNativeViewDetached(object nativeView)
        {
            NativeViewChanged?.Invoke(this, new NativeViewEventArgs(NativeViewAction.Detached));

            NativeView = null;
        }

        public void OnNativeViewAttached(object nativeView)
        {
            NativeView = nativeView;

            NativeViewChanged?.Invoke(this, new NativeViewEventArgs(NativeViewAction.Attached));
        }

        public event EventHandler<NativeViewEventArgs> NativeViewChanged;

        public object NativeView { get; set; }
    }
}