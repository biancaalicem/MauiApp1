using MauiApp1.Models;
namespace MauiApp1;

public partial class LocatiePage : ContentPage
{
	public LocatiePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{ var locatie = (Locatie)BindingContext; 
	 await App.Database.SaveLocatieAsync(locatie);
	 await Navigation.PopAsync(); 
	}
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var locatie
            = (Locatie)BindingContext; var address = locatie.Adress; var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions { Name = "Pensiunea mea preferata" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync(); var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }
}