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
        Appareil Falconne = new Appareil();
        List<Membre> equipage = new List<Membre>();
        int MembreSelected;

        public MainPage()
        {
            this.InitializeComponent();
            InitEquipage();
        }

        public void InitEquipage()
        {
            equipage.Add(new Capitaine());
            equipage.Add(new Commandant());
            equipage.Add(new Mecanicien());
            equipage.Add(new Medecin());
        }

        // Ferme l'application
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        // jete les dés du membre d'équipage puis affiche le résultat dans un bloc de texte
        private void rollDices_Click(object sender, RoutedEventArgs e)
        {
            int[] dicesRolled;
            dicesRolled = Roll.RollTheDices(6,6);
            foreach (int result in dicesRolled)
            {
                diceResults.Text += result + "\n";
            }
        }

        // Affiche les PV du vaisseau
        public String Health(Appareil vaisseau)
        {
            return vaisseau.ToString();
        }

        private void B_survie_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[6].ToString();
        }

        private void B_laboratoire_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[4].ToString();
        }

        private void B_infirmeri_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[3].ToString();
        }

        private void B_serre_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[2].ToString();
        }

        private void B_pilotage_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[1].ToString();
        }

        private void B_maintenance_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = Falconne.Rooms[7].ToString();
        }

        private void B_detente_Click(object sender, RoutedEventArgs e)
        {
            
            infoRomm.Text = Falconne.Rooms[5].ToString();
        }

        private void keepDice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B_capaciter_Click(object sender, RoutedEventArgs e)
        {
            equipage[MembreSelected].Capacite(Falconne, equipage);
            info .Text = string.Format("Hp : {0} \nDice: {1} \nsalle : {2} \n ", equipage[MembreSelected].HP, equipage[MembreSelected].Dices, Falconne.getRommName(equipage[MembreSelected].Room));
        }

        private void B_deplacement_Click(object sender, RoutedEventArgs e)
        {
            /*if (equipage[MembreSelected].Room != roomMoving.SelectedIndex)
            {
                equipage[MembreSelected].Room = roomMoving.SelectedIndex;
                //B_info_Click(sender, e);
            } else {
                infoRomm.Text = "Ce membre d'équipage se situe déjà dans cette salle !";
            }*/
        }


        private void B_capitaine_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            MembreSelected = 0;
            info.Text = string.Format("Hp : {0} \nDice:{1} \nsalle : {2} ", equipage[0].HP, equipage[0].Dices, Falconne.getRommName(equipage[0].Room));
        }

        private void B_commandant_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            MembreSelected = 1;
            info.Text = string.Format("Hp : {0} \nDice:{1} \nsalle : {2} ", equipage[1].HP, equipage[1].Dices, Falconne.getRommName(equipage[1].Room));
        }

        private void B_medecin_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            MembreSelected = 3;
            info.Text = string.Format("Hp : {0} \nDice:{1} \nsalle : {2} ", equipage[2].HP, equipage[2].Dices, Falconne.getRommName(equipage[2].Room));
        }

        private void B_mecano_Click_1(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            MembreSelected = 2;
            info.Text = string.Format("Hp : {0} \nDice:{1} \nsalle : {2} ", equipage[3].HP, equipage[3].Dices, Falconne.getRommName(equipage[3].Room));
        }
    }
}
