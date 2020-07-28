using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface INativeViewProvider
    {
        event EventHandler<NativeViewEventArgs> NativeViewChanged;
        
        object NativeView { get; set; }
    }

    public enum NativeViewAction
    {
        Detached,
        Attached
    }

    public class NativeViewEventArgs
    {
        public NativeViewEventArgs(NativeViewAction action)
        {
            Action = action;
        }

        public NativeViewAction Action { get; }
    }
}