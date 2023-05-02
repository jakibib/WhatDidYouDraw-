using CommunityToolkit.Maui.Views;
using WhatDidYouDraw.Classes;

namespace WhatDidYouDraw.Pages;

public partial class DrawGamePage : ContentPage
{
    IDispatcherTimer timer;
    bool FirstVisit = true;
    public int Odpocet = HodnotyClass.Time;
    public DrawGamePage()
	{
		InitializeComponent();
        DrawingBoard.IsEnabled = true;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;

    }
    private async void BlinkingRed()
    {
        while (Odpocet != 0) 
        {
            OdpocetLabel.TextColor = OdpocetLabel.TextColor == Colors.Red ? Colors.Black : Colors.Red;
            await Task.Delay(100);
        }
        OdpocetLabel.TextColor = Colors.Black;
    }

    private void CheckOdpocetLenght()
    {
        if (Odpocet.ToString().Length > 1)
        {
            OdpocetLabel.Text = "00:" + Odpocet.ToString();
        }
        else
        {
            OdpocetLabel.Text = "00:0" + Odpocet.ToString();
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (Odpocet == 5)
        {
            BlinkingRed();
        }
        Odpocet--;
        CheckOdpocetLenght();
        if (Odpocet == 0)
        {
            NextRound();
        }
    }

    private async void NextRound()
    {
        //DrawingBoard.IsEnabled = false;
        //using var stream = await DrawingBoard.GetImageStream(200, 200);
        //using var memoryStream = new MemoryStream();
        //stream.CopyTo(memoryStream);
        //stream.Position = 0;
        //memoryStream.Position = 0;
        //HodnotyClass.ListObrazku.Add(ImageSource.FromStream(() => memoryStream));

        using var stream = await DrawingBoard.GetImageStream(200, 200);
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        HodnotyClass.ByteObrazku.Add(memoryStream.ToArray());
        byte[] imageData = memoryStream.ToArray();
        var imageStream = new MemoryStream(imageData);
        imageStream.Position = 0;
        HodnotyClass.ListObrazku.Add(ImageSource.FromStream(() => imageStream));



        Odpocet = 0;
        timer.Stop();
        DrawingBoard.Clear();
        if (HodnotyClass.RoundsElapsed == HodnotyClass.Rounds + 1)
        {
            await Navigation.PushAsync(new ResultPage());
            timer.Stop();
            FirstVisit = true;
        }
        else
        {
            await Navigation.PushModalAsync(new GameBeginPage());
            SkipButton.IsEnabled = true;
        }
    }

    private void SkipButton_Clicked(object sender, EventArgs e)
    {
        SkipButton.IsEnabled = false;
        NextRound();
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        DrawingBoard.Clear();
    }

    private async void DrawGamePage_Appearing(object sender, EventArgs e)
    {
        DrawingBoard.Clear();
        if (FirstVisit)
        {
            //HodnotyClass.VybraneSlovo = null;
            //HodnotyClass.RoundsElapsed = 1;
            //HodnotyClass.PouzitaSlova = new List<string>(6);
            //HodnotyClass.PouzitaCisla = null;
            //HodnotyClass.ListObrazku = new List<ImageSource>(6);
            await Navigation.PushModalAsync(new GameBeginPage());
            FirstVisit = false;
        }
        else
        {
            Odpocet = HodnotyClass.Time;
            CheckOdpocetLenght();
            timer.Start();
            SkipButton.IsEnabled = true;
            DrawingBoard.IsEnabled = true;
        }
        DrawLabel.Text = HodnotyClass.VybraneSlovo;
    }
}