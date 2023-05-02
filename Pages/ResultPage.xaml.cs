using WhatDidYouDraw.Classes;
using Google.Cloud.Vision.V1;
using Google.Apis.Auth.OAuth2;

namespace WhatDidYouDraw.Pages;

public partial class ResultPage : ContentPage
{
    public string text;
    //Image image = new Image { Source = obrazek1.Source };)
    public ResultPage()
	{
		InitializeComponent();
        setcred();


    }

    private async void setcred()
    {
        var localPath = Path.Combine(FileSystem.CacheDirectory, "application_default_credentials.json");

        using var json = await FileSystem.OpenAppPackageFileAsync("application_default_credentials.json");
        using var dest = File.Create(localPath);
        await json.CopyToAsync(dest);

        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", localPath);
        dest.Close();

        var client = new ImageAnnotatorClientBuilder
        {
            GrpcAdapter = RestGrpcAdapter.Default
        }.Build();


    }

    private async void Request()
    {
        //string credential_path = "application_default_credentials.json";
        //System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

        //var client = ImageAnnotatorClient.Create(); 

        //var image = Google.Cloud.Vision.V1.Image.FromBytes(HodnotyClass.ByteObrazku[0]);

        //var response = client.DetectLabels(image);
        //foreach (var annotation in response)
        //{
        //    if (annotation.Description != null)
        //    {
        //        DisplayAlert("ok", annotation.Description , "ok");
        //    }
        //}
        // jsonPath is the path to the key.json file 
        string credential_path = @"C:\path\to\project\Resources\Raw\application_default_credentials.json";
        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

        var client = ImageAnnotatorClient.Create();
        // Load the image file into memory
        var image = Google.Cloud.Vision.V1.Image.FromBytes(HodnotyClass.ByteObrazku[0]);
        // Performs label detection on the image file
        var response = client.DetectLabels(image);
        foreach (var annotation in response)
        {
            if (annotation.Description != null)
            {
                await DisplayAlert("ok", annotation.Description , "ok");
            }
            break;
        }

        //// Instantiates a client
        //System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);

        //var client = ImageAnnotatorClient.Create();
        //// Load the image file into memory
        //var image = Google.Cloud.Vision.V1.Image.FromBytes(HodnotyClass.ByteObrazku[0]);
        //// Performs label detection on the image file
        //var response = client.DetectLabels(image);
        //foreach (var annotation in response)
        //{
        //}
    }

    private void MainmenuButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }

    private void PlayagainButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PopAsync();
        //string veci = "";
        //foreach (var annotation in odpoved)
        //{
        //    veci += odpoved + ", ";
        //}
        Request();

    }
}