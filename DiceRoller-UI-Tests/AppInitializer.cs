using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DiceRollerUITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
                return ConfigureApp
                .Android
                .InstalledApp("com.savitha.diceroller")
                .StartApp();  
        }
    }
}
