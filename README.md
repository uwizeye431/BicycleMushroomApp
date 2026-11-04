# BicycleMushroomApp

A Windows Forms application written in C# with two programs behind one login.

## Features

1. **Login page**: the user signs in before using anything else.
2. **Choose page**: the user picks Bicycle Rental or Mushroom Identifier.
3. **Bicycle Rental**: enter a starting hour and an ending hour, and the total cost in RWF is shown on the form. Input is validated (empty values, letters, decimals, out of range values and a start hour that is not before the end hour are all rejected).
4. **Mushroom Identifier**: answer Yes or No questions (never more than three) and the mushroom is shown in a MessageBox.
5. **Logout**: both programs have a Logout button that returns to the login page.

## Login details

| Username | Password |
|----------|----------|
| admin    | 1234     |

## How to run

1. Install Visual Studio with the .NET desktop development workload and the .NET 10 SDK.
2. Open `BicycleMushroomApp.slnx` (or the `.csproj` file) in Visual Studio.
3. Press Ctrl+F5 to build and run.

## Project structure

| File | Purpose |
|------|---------|
| Program.cs | Starts the app on the login form |
| LoginForm | Login page |
| ChooseForm | Choose between the two programs |
| BicycleForm | Bicycle rental cost calculator |
| MushroomForm | Mushroom identifier |

## Author

UWIZEYE KEVIN, Registration number 27477
