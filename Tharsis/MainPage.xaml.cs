using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Equipage;
using Vaisseau;
using Dice;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tharsis
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Ferme l'application
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        // jete les dés du membre d'équipage puis affiche le résultat dans un bloc de texte
        private void rollDices_Click(object sender, RoutedEventArgs e)
        {
            Membre membre = (Membre)sender;
            int[] dicesRolled ;

               dicesRolled = Dice.Roll.RollTheDices(6,6);
            

            foreach (int result in dicesRolled)
            {
                diceResults.Text += result + "\n";
            }
        }

         //Activation de la capacité spéciale du membre d'équipage
         void specialAbility_Click(object sender, Appareille vaisseau, List<Membre> menbres, RoutedEventArgs e)
        {
            
        }

        // Affiche les PV du vaisseau
        public String Health(Vaisseau.Appareille vaisseau)
        {
            return vaisseau.ToString();
        }
    }
}
