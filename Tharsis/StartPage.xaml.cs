using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Tharsis
{
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        // Navigue jusqu'à la page du jeu
        private void play_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        // Ferme l'application
        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        // Passe le jeu en mode difficile
        private void hard_Click(object sender, RoutedEventArgs e)
        {
            /*TODO: 
                - Page Hardmode
                - Mode difficile
             
             */
        }
    }
}
