# What Did You Draw?

What Did You Draw? is a .NET MAUI mobile app inspired by the popular Google game where players draw images and an AI tries to guess what they drew. This app allows users to draw an image using their finger or stylus and then uses Google Cloud Vision API to guess what they drew.

## Requirements
* Visual Studio 2022 or later
* .NET MAUI

## Installation
1. Clone the repository
2. Open the solution in Visual Studio 2022 or later
3. Build and run the app on device of your choice

# Usage
When the app starts, the user is presented with a main menu with the following options:

* Start Game
* Settings

### Start Game
This option takes the user to the game screen where they can draw an image using their finger or stylus. After drawing an image, the user can tap the "What did I draw?" button to have the app use the Google Cloud Vision API to guess what they drew. The app displays the list of possible labels for the image, and the user can select the correct one or choose "Other" if none of the labels are correct.

The user can then tap the "Next" button to start a new round or tap the "Main Menu" button to return to the main menu.

### Settings
This option takes the user to the settings screen where they can adjust the number of rounds and time per round.

## Code Structure
The app is structured into the following classes:

* `MainPage` - The main menu screen
* `GamePage` - The game screen
* `SettingsPage` - The settings screen
* `HodnotyClass` - A static class that holds global variables and constants
* `ImageService` - A service that handles loading and resizing images
* `ResultPage` - A page for displaying the result of the Google Cloud Vision API

T he app uses the Google Cloud Vision API to guess what the user drew. The API is accessed using the ImageAnnotatorClient class from the Google.Cloud.Vision.V1 namespace.

## License
This project is licensed under the MIT License - see the <a href="https://github.com/jakibib/WhatDidYouDraw-/blob/master/LICENSE.txt">LICENSE</a> file for details.