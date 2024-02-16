using MauiApp1.Models;
using Xamarin.KotlinX.Coroutines.Channels;
namespace MauiApp1;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Pensiune)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SavePensiuneAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Pensiune)BindingContext;
        await App.Database.DeletePensiuneAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExperientaPage((Pensiune)this.BindingContext) { BindingContext = new Experienta() });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Pensiune)BindingContext;
        listView.ItemsSource = await App.Database.GetPensiuniAsync(shopl.ID);
    }
}