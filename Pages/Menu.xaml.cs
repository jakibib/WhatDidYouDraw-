

using WhatDidYouDraw.Classes;

namespace WhatDidYouDraw.Pages;

public partial class Menu : ContentPage
{

    public Menu()
	{
		InitializeComponent();
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        WifiStateImage.Source = (Connectivity.NetworkAccess == NetworkAccess.Internet) ? "wifion.png" : "wifioff.png";

    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        WifiStateImage.Source = (e.NetworkAccess == NetworkAccess.Internet) ? "wifion.png" : "wifioff.png";

    }

    private async void DropMenuButton_Clicked(object sender, EventArgs e)
    {
        MenuOpen();
    }
    private async Task MenuOpen()
    {
        if (!DropMenu.IsVisible)
        {
            DropMenu.IsVisible = true;
            DropMenu.ScaleYTo(1, 100);
            await DropMenuButton.RelRotateTo(180, 100);
        }
        else
        {
            MenuClose();
        }
    }
    private async void MenuClose()
    {
        if (DropMenu.IsVisible)
        {
            DropMenuButton.RelRotateTo(180, 100);
            await DropMenu.ScaleYTo(0.2, 100);
            DropMenu.IsVisible = false;
        }
    }

    private void PlayButton_Clicked(object sender, EventArgs e)
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            OpenPlay();
        }
        else
        {
            DisplayAlert("Warning!", "Please connect to the internet", "Ok");
        }
        
    }
    private void OpenPlay()
    {
        MenuClose();
        PlayMenu.IsVisible = true;
        PlayMenu.TranslateTo(X, 0, 100);
        PlayMenu.ScaleXTo(1, 100);
        PlayMenu.ScaleYTo(1, 100);
        HodnotyClass.RoundsElapsed = 1;
        HodnotyClass.PouzitaCisla = null;


    }

    private void PlayClose()
    {
        PlayMenu.IsVisible = false;
        PlayMenu.TranslationY = PlayButton.Y;

    }

    
    private async void SingleplayerButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DrawGamePage(), false);
        PlayClose();
    }


    private async void MultiplayerButton_Clicked(object sender, EventArgs e)
    {

    }

   
    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        MenuClose();
        await Navigation.PushModalAsync(new SettingsPage());
    }

    private async void TiktokButton_Clicked(object sender, EventArgs e)
    {
        MenuClose();
        await Browser.Default.OpenAsync("https://www.tiktok.com/@jakibib", BrowserLaunchMode.SystemPreferred);
    }

    private async void TwitterButton_Clicked(object sender, EventArgs e)
    {
        MenuClose();
        await Browser.Default.OpenAsync("https://twitter.com/Jakibib", BrowserLaunchMode.SystemPreferred);
    }

    private async void BigGridTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (PlayMenu.IsVisible)
        {
            PlayClose();
        }
        if (DropMenu.IsVisible)
        {
            MenuClose();

        }
    }
}