﻿using System;
using SciChart.Xamarin.Views.Model.DataSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class DataSeriesFactoryAndroid : IDataSeriesFactory
    {
        public Views.Model.DataSeries.IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable
        {
            return new XyDataSeriesAndroid<TX, TY>();
        }
    }
}