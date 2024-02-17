using MauiApp1.Models;
namespace MauiApp1;

public partial class ExperientaPage : ContentPage
{
    Pensiune sl;
    public ExperientaPage(Pensiune slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var experienta = (Experienta)BindingContext;
        await App.Database.SaveExperientaAsync(experienta);
        listView.ItemsSource = await App.Database.GetExperienteAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var experienta = (Experienta)BindingContext;
        await App.Database.DeleteExperientaAsync(experienta);
        listView.ItemsSource = await App.Database.GetExperienteAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetExperienteAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Experienta p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Experienta;
            var lp = new ListExperienta()
            {
                PensiuneID = sl.ID,
                ExperientaID = p.ID
            };
            await App.Database.SaveListExperientaAsync(lp);
            p.ListExperiente = new List<ListExperienta> { lp };
            await Navigation.PopAsync();
        }
    }
}