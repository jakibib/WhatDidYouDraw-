using WhatDidYouDraw.Classes;

namespace WhatDidYouDraw.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
	{
		InitializeComponent();
        RoundsStepper.Value = HodnotyClass.Rounds;
        TimeStepper.Value = HodnotyClass.Time;
    }

    private void ExitSettingsButton_Clicked(object sender, EventArgs e)
    {
        ExitSettingsButton.RelRotateTo(180, 100);
        HodnotyClass.Time = (int)TimeStepper.Value;
        HodnotyClass.Rounds = (int)RoundsStepper.Value;
        Navigation.PopModalAsync();
    }
}