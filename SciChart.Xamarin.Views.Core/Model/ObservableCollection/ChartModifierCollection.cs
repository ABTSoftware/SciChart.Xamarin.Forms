﻿using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class ChartModifierCollection : ObservableCollection<IChartModifier>
    {
        public ChartModifierCollection() : this(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifierCollection())
        {
        }

        public ChartModifierCollection(INativeObservableCollection<IChartModifier> nativeObservableCollection) : base(nativeObservableCollection)
        {

        }
    }
}