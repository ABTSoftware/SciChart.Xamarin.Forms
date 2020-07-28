using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Synchronization
{
    public partial class SciChartVerticalGroup
    {
        public static readonly BindableProperty VerticalGroupProperty = BindableProperty.CreateAttached("VerticalGroup", typeof(SciChartVerticalGroup), typeof(SciChartVerticalGroup), null, propertyChanged: OnVerticalGroupAttachedPropertyChanged);

        public static SciChartVerticalGroup GetVerticalGroup(BindableObject view)
        {
            return (SciChartVerticalGroup)view.GetValue(VerticalGroupProperty);
        }

        public static void SetVerticalGroup(BindableObject view, SciChartVerticalGroup value)
        {
            view.SetValue(VerticalGroupProperty, value);
        }

        private static void OnVerticalGroupAttachedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var surface = (SciChartSurface)bindable;

            if (oldValue != null)
            {
                surface.NativeViewChanged -= OnNativeViewChanged;

                if (surface.NativeView != null)
                {
                    var oldGroup = (SciChartVerticalGroup) oldValue;

                    oldGroup.RemoveSurfaceFromGroup(surface);
                }
            }

            if (newValue != null)
            {
                surface.NativeViewChanged += OnNativeViewChanged;

                if (surface.NativeView != null)
                {
                    var newGroup = (SciChartVerticalGroup) newValue;

                    newGroup.AddSurfaceToGroup(surface);
                }
            }
        }

        private static void OnNativeViewChanged(object sender, NativeViewEventArgs e)
        {
            var surface = (SciChartSurface)sender;
            var verticalGroup = GetVerticalGroup(surface);
            switch (e.Action)
            {
                case NativeViewAction.Attached:
                    verticalGroup.AddSurfaceToGroup(surface);
                    break;

                case NativeViewAction.Detached:
                    verticalGroup.RemoveSurfaceFromGroup(surface);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}