using System.Collections.Generic;
using SciChart.Xamarin.Views.Core;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class ObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
    {
        public INativeObservableCollection<T> NativeObservableCollection { get; }

        public ObservableCollection(INativeObservableCollection<T> nativeObservableCollection)
        {
            NativeObservableCollection = nativeObservableCollection;
        }

        public ObservableCollection(INativeObservableCollection<T> nativeObservableCollection, IEnumerable<T> collection) : base(collection)
        {
            NativeObservableCollection = nativeObservableCollection;
        }

        protected override void ClearItems()
        {
            NativeObservableCollection.ClearItems();

            base.ClearItems();
        }

        protected override void InsertItem(int index, T item)
        {
            NativeObservableCollection.InsertItem(index, item);

            base.InsertItem(index, item);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            NativeObservableCollection.MoveItem(oldIndex, newIndex);

            base.MoveItem(oldIndex, newIndex);
        }

        protected override void RemoveItem(int index)
        {
            NativeObservableCollection.RemoveItem(index);

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            NativeObservableCollection.SetItem(index, item);

            base.SetItem(index, item);
        }
    }
}