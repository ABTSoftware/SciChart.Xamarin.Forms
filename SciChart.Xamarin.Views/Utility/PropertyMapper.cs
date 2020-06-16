using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SciChart.Xamarin.Views.Utility
{
    public class PropertyMapper<TSourceType, TDestType> where TSourceType : class, INotifyPropertyChanged where TDestType : class
    {
        private readonly Dictionary<string, Action<TSourceType, TDestType>> _propertyMappingDictionary = new Dictionary<string, Action<TSourceType, TDestType>>();

        private TSourceType _source = null;
        private TDestType _dest = null;

        public bool IsAttached { get; private set; }

        public void AddMapping(string propertyName, Action<TSourceType, TDestType> propertyMapping)
        {
            _propertyMappingDictionary[propertyName] = propertyMapping;
        }

        public void Attach(TSourceType source, TDestType dest)
        {
            _source = source;
            _dest = dest;

            foreach (var action in _propertyMappingDictionary.Values)
            {
                action(source, dest);
            }

            IsAttached = true;
        }

        public void Detach()
        {
            IsAttached = false;
            _source = null;
            _dest = null;
        }

        public void OnSourcePropertyChanged(string propertyName)
        {
            if (IsAttached && _propertyMappingDictionary.TryGetValue(propertyName, out var handler))
            {
                handler(_source, _dest);
            }
        }
    }
}
