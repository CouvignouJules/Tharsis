﻿using System;
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
        Appareille Falconne = new Appareille();
        List<Membre> equipage = new List<Membre>();

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

         //Activation de la capacité spéciale du membre d'équipage
         void specialAbility_Click(object sender, Appareille vaisseau, List<Membre> menbres, RoutedEventArgs e)
        {
            
        }

        // Affiche les PV du vaisseau
        public String Health(Appareille vaisseau)
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            infoRomm.Text = equipage[0].info(Falconne);            
        }
    }
}
