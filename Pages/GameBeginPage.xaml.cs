using WhatDidYouDraw.Classes;

namespace WhatDidYouDraw.Pages;

public partial class GameBeginPage : ContentPage
{
    List<int> rndNum = new List<int> { 0};
    Random rnd = new Random();

    public GameBeginPage()
	{
		InitializeComponent();
        //DrawingXLabel.Text = "Drawing " + HodnotyClass.RoundsElapsed + "/" + HodnotyClass.Rounds;
        Setup();
    }

    private async void Setup()
    {
        List<string> ListSlov = await LoadMauiAsset();
        int pocetslov = ListSlov.Count;
        HodnotyClass.PouzitaCisla = await Neopak(rndNum, pocetslov);
        HodnotyClass.VybraneSlovo = ListSlov[HodnotyClass.PouzitaCisla[HodnotyClass.PouzitaCisla.Count - 1]];
        HodnotyClass.PouzitaSlova.Add(HodnotyClass.VybraneSlovo);
        NakresliLabel.Text = HodnotyClass.VybraneSlovo;
    }

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        HodnotyClass.RoundsElapsed++;
    }
    async Task<List<string>> LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("words.txt");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        List<string> ListSlov = new List<string>(contents.Split(','));
        return ListSlov;
    }

    async Task <List <int>> Neopak( List<int> UsedNums, int pocetslov)
    {
        
        int nahoda = rnd.Next(0 , pocetslov);
        for (int i = 0; i < UsedNums.Count; i++)
        {
            if (UsedNums[i] == nahoda)
            {
                await Neopak(UsedNums, pocetslov);
            }

        }
        UsedNums.Add(nahoda);
        return UsedNums;
    }
}
