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
using Windows.UI.Xaml.Media.Imaging;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tharsis
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //creation du vaisseau
        Appareil falcon = new Appareil();
        //list contenent le menbre dequipage
        List<Membre> equipage = new List<Membre>();
        int membreSelected;
 
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
           
            equipage[membreSelected].MyDice = Roll.RollTheDices(equipage[membreSelected].Dices,6);
            SetDes();                              
        }

        public void SetDes()
        {
            for (int i = 1; i <= equipage[membreSelected].MyDice.Count; i++)
            {
                string nomImage = string.Format("ms-appx:///Assets//d{0}.jpeg", equipage[membreSelected].MyDice[i - 1]);
                switch (i)
                {
                    case 1:
                        dés1.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 2:
                        dés2.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 3:
                        dés3.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 4:
                        dés4.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 5:
                        dés5.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 6:
                        dés6.Source = new BitmapImage(new Uri(nomImage));
                        break;
                }
            }
        }

        public void ResetDes()
        {
            dés1.Source = null;
            dés2.Source = null;
            dés3.Source = null;
            dés4.Source = null;
            dés5.Source = null;
            dés6.Source = null;
        }

        // Affiche les PV du vaisseau
        public String Health(Appareil vaisseau)
        {
            return vaisseau.ToString();
        }

        private void B_survie_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 6;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_laboratoire_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 4;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_infirmeri_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 3;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_serre_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 2;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_pilotage_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 1;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_maintenance_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 7;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_detente_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 5;
                B_deplacement.IsEnabled = true;
            }
        }

        private void B_capaciter_Click(object sender, RoutedEventArgs e)
        {
            equipage[membreSelected].Capacite(falcon, equipage);
            info.Text = equipage[membreSelected].Info(falcon);
        }

        private void B_deplacement_Click(object sender, RoutedEventArgs e)
        {
            B_deplacement.IsEnabled = false;
        }

        private void B_capitaine_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            membreSelected = 0;
            memberName.Text = "Capitaine";
            info.Text = equipage[membreSelected].Info(falcon);
            if (equipage[0].MyDice.Count == 0)
            {
                ResetDes();
            }
            else
            {
                SetDes();
            }
        }

        private void B_commandant_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            membreSelected = 1;
            memberName.Text = "Commandant";
            info.Text = equipage[membreSelected].Info(falcon);
            if (equipage[1].MyDice.Count == 0)
            {
                ResetDes();
            }
            else
            {
                SetDes();
            }
        }

        private void B_medecin_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            membreSelected = 2;
            memberName.Text = "Médecin";
            info.Text = equipage[membreSelected].Info(falcon);
            if (equipage[3].MyDice.Count == 0)
            {
                ResetDes();
            }
            else
            {
                SetDes();
            }
        }

        private void B_mecano_Click(object sender, RoutedEventArgs e)
        {
            menuaction.IsOpen = true;
            membreSelected = 3;
            memberName.Text = "Mécanicien";
            info.Text = equipage[membreSelected].Info(falcon);
            if (equipage[2].MyDice.Count == 0)
            {
                ResetDes();
            }
            else
            {
                SetDes();
            }
        }
        
        List<int> SelectedDice = new List<int>();
        private void B_d_Click(object sender, RoutedEventArgs e)
        {
            Button But = (Button)sender;
            string nomImage = string.Format("ms-appx:///Assets//d{0}_select.jpeg", equipage[membreSelected].MyDice[Int32.Parse(But.Tag.ToString())]);
            SelectedDice.Add(Int32.Parse(But.Tag.ToString()));
            But.IsEnabled = false;
            B_annule.IsEnabled = true;
            //atribut limage du des selectione
            switch (But.Tag.ToString())
            {
                case "0":
                    dés1.Source = new BitmapImage(new Uri(nomImage));
                    break;
                case "1":
                    dés2.Source = new BitmapImage(new Uri(nomImage));
                    break;
                case "2":
                    dés3.Source = new BitmapImage(new Uri(nomImage));
                    break;
                case "3":
                    dés4.Source = new BitmapImage(new Uri(nomImage));
                    break;
                case "4":
                    dés5.Source = new BitmapImage(new Uri(nomImage));
                    break;
                case "5":
                    dés6.Source = new BitmapImage(new Uri(nomImage));
                    break;
            }
        }

        private void B_repare_Click(object sender, RoutedEventArgs e)
        {
            int totalRepart = 0;
            foreach(int nDés in SelectedDice)
            {               
                totalRepart += equipage[membreSelected].MyDice[nDés];
            }
            falcon.Rooms[equipage[membreSelected].Room].Panne -= totalRepart;
            info.Text += string.Format("\npanne {0} - {1}", falcon.getRommName(equipage[membreSelected].Room),totalRepart);
            

            foreach(int des in SelectedDice)
            {
                string nomImage = string.Format("ms-appx:///Assets//d{0}_utiliser.jpeg", equipage[membreSelected].MyDice[des]);
                switch (des)
                {
                    case 0:
                        dés1.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 1:
                        dés2.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 2:
                        dés3.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 3:
                        dés4.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 4:
                        dés5.Source = new BitmapImage(new Uri(nomImage));
                        break;
                    case 5:
                        dés6.Source = new BitmapImage(new Uri(nomImage));
                        break;
                }
            }
            SelectedDice.Clear();
            B_annule.IsEnabled = false;
        }

        private void B_annule_Click(object sender, RoutedEventArgs e)
        {
            SelectedDice.Clear();
            B_dés1.IsEnabled = true;
            B_dés2.IsEnabled = true;
            B_dés3.IsEnabled = true;
            B_dés4.IsEnabled = true;
            B_dés5.IsEnabled = true;
            B_dés6.IsEnabled = true;
            SetDes();
            B_annule.IsEnabled = false;
        }
    }
}
