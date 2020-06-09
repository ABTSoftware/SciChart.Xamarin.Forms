using System;
using TestApp.UI.Application;
using Xamarin.Forms;

namespace TestApp.UI
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
		    try
		    {
		        InitializeComponent();
            }
		    catch (Exception e)
		    {
		        Console.WriteLine(e);
		        throw;
		    }
			
		    this.BindingContext = new MainViewModel();            
		}

        private void OnExampleItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var example = e.SelectedItem as Example;
            if (example != null)
            {
                var examplePage = (Page) Activator.CreateInstance(example.ExampleType);
               
                examplePage.Title = example.Title;

                Navigation.PushAsync(examplePage);
            }
        }
    }
}
