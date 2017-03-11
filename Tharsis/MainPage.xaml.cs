using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Dice;
using Equipage;
using Vaisseau;
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
            Equipage.Equipage membre = (Equipage.Equipage)sender;

            List<String> dicesRolled = new List<string>();

            for (int i = 0; i < membre.Dices; i++) {
                dicesRolled.Add(Dice.Dice.Roll(6,6));
            }

            foreach (String result in dicesRolled)
            {
                diceResults.Text += result + "\n";
            }
        }

        // Activation de la capacité spéciale du membre d'équipage
        private void specialAbility_Click(object sender, Vaisseau.Vaisseau vaisseau, List<Equipage.Equipage> equipage, RoutedEventArgs e)
        {
            Equipage.Equipage membre = (Equipage.Equipage)sender;

            membre.Capacite(vaisseau, equipage);
        }

        // Affiche les PV du vaisseau
        public String Health(Vaisseau.Vaisseau vaisseau)
        {
            return vaisseau.ToString();
        }
    }
}
