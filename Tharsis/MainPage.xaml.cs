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
        // Création du vaisseau
        Appareil falcon = new Appareil();
        // Liste contenant les membres d'equipage
        List<Membre> equipage = new List<Membre>();
        // Indicateur du membre d'équipage sélectionné
        int membreSelected;
 
        public MainPage()
        {
            this.InitializeComponent();
            InitEquipage();
            shipHealth.Text = falcon.ToString();
        }

        // Remplissage de la liste par les membres d'équipage
        public void InitEquipage()
        {
            equipage.Add(new Capitaine());
            equipage.Add(new Commandant());
            equipage.Add(new Mecanicien());
            equipage.Add(new Medecin());
        }

        // Lance les dés du membre d'équipage puis désactive le bouton pour empêcher le joueur de relancer les dés
        private void B_rollDices_Click(object sender, RoutedEventArgs e)
        {
            equipage[membreSelected].MyDice = Roll.RollTheDices(equipage[membreSelected].Dices,6);
            SetDes();
            B_rollDices.IsEnabled = false;     
        }

        // Affichage des dés lancés par le membre d'équipage et grisage des dés sélectionnés (utilisés)
        public void SetDes()
        {
            for (int i = 1; i <= equipage[membreSelected].MyDice.Count; i++)
            {
                string nomImage = string.Format("ms-appx:///Assets//d{0}.jpeg", equipage[membreSelected].MyDice[i - 1]);
                switch (i)
                {
                    case 1:
                        dés1.Source = new BitmapImage(new Uri(nomImage));
                        B_dés1.IsEnabled = true;
                        break;
                    case 2:
                        dés2.Source = new BitmapImage(new Uri(nomImage));
                        B_dés2.IsEnabled = true;
                        break;
                    case 3:
                        dés3.Source = new BitmapImage(new Uri(nomImage));
                        B_dés3.IsEnabled = true;
                        break;
                    case 4:
                        dés4.Source = new BitmapImage(new Uri(nomImage));
                        B_dés4.IsEnabled = true;
                        break;
                    case 5:
                        dés5.Source = new BitmapImage(new Uri(nomImage));
                        B_dés5.IsEnabled = true;
                        break;
                    case 6:
                        dés6.Source = new BitmapImage(new Uri(nomImage));
                        B_dés6.IsEnabled = true;
                        break;
                }
            }
            foreach(int i in equipage[membreSelected].UsedDice)
            {
                string nomImage = string.Format("ms-appx:///Assets//d{0}_utiliser.jpeg", equipage[membreSelected].MyDice[i]);
                switch (i)
                {
                    case 0:
                        dés1.Source = new BitmapImage(new Uri(nomImage));
                        B_dés1.IsEnabled = false;
                        break;
                    case 1:
                        dés2.Source = new BitmapImage(new Uri(nomImage));
                        B_dés2.IsEnabled = false;
                        break;
                    case 2:
                        dés3.Source = new BitmapImage(new Uri(nomImage));
                        B_dés3.IsEnabled = false;
                        break;
                    case 3:
                        dés4.Source = new BitmapImage(new Uri(nomImage));
                        B_dés4.IsEnabled = false;
                        break;
                    case 4:
                        dés5.Source = new BitmapImage(new Uri(nomImage));
                        B_dés5.IsEnabled = false;
                        break;
                    case 5:
                        dés6.Source = new BitmapImage(new Uri(nomImage));
                        B_dés6.IsEnabled = false;
                        break;
                }
            }
        }

        // Rétablissement des dés pour les autres membres qui n'ont pas encore lancé
        public void ResetDes()
        {
            dés1.Source = null;
            B_dés1.IsEnabled = true;
            dés2.Source = null;
            B_dés2.IsEnabled = true;
            dés3.Source = null;
            B_dés3.IsEnabled = true;
            dés4.Source = null;
            B_dés4.IsEnabled = true;
            dés5.Source = null;
            B_dés5.IsEnabled = true;
            dés6.Source = null;
            B_dés6.IsEnabled = true;
        }

        // Affiche les PV du vaisseau
        public String Health(Appareil vaisseau)
        {
            return vaisseau.ToString();
        }

        // Pour chaque salle : Si le bouton de déplacement du membre est désactivé, alors le membre sélectionné va se déplacer dans la salle sélectionnée
        private void B_survie_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 6;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_laboratoire_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 4;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_infirmeri_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 3;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_serre_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 2;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_pilotage_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 1;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_maintenance_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 7;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        private void B_detente_Click(object sender, RoutedEventArgs e)
        {
            if (!B_deplacement.IsEnabled)
            {
                equipage[membreSelected].Room = 5;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;
            }
        }

        // Active la capacité spéciale du membre d'équipage
        private void B_capaciter_Click(object sender, RoutedEventArgs e)
        {
            equipage[membreSelected].Capacite(falcon, equipage);
            info.Text = equipage[membreSelected].Info(falcon);
            shipHealth.Text = falcon.ToString();
            foreach (int i in SelectedDice)
                equipage[membreSelected].UsedDice.Add(i);
            SetDes();
            SelectedDice.Clear();

            B_capaciter.IsEnabled = false;
            B_repare.IsEnabled = false;
            B_annule.IsEnabled = false;
        }

        // Désactive le bouton de déplacement (ce qui permet de se déplacer en utilisant les méthodes citées plus haut)
        // Désactive aussi les boutons de sélection des autres membres afin de ne pas déplacer un autre membre après avoir cliqué
        private void B_deplacement_Click(object sender, RoutedEventArgs e)
        {
            B_deplacement.IsEnabled = false;
            B_capitaine.IsEnabled = false;
            B_commandant.IsEnabled = false;
            B_medecin.IsEnabled = false;
            B_mecano.IsEnabled = false;
        }

        /* Pour chaque membre d'équipage : Établissement des dés, ouverture de la popup lui correspondant, 
         * vérification de son nombre de dés pour les lancer, affichage de ses infos dans la popup
         * puis appel de setDes décrite plus haut */
        private void B_capitaine_Click(object sender, RoutedEventArgs e)
        {
            ResetDes();
            menuaction.IsOpen = true;
            membreSelected = 0;
            if (equipage[membreSelected].MyDice.Count != 0)
                B_rollDices.IsEnabled = false;
            else
                B_rollDices.IsEnabled = true;
            memberName.Text = "Capitaine";
            info.Text = equipage[membreSelected].Info(falcon);
            SetDes();
        }

        private void B_commandant_Click(object sender, RoutedEventArgs e)
        {
            ResetDes();
            menuaction.IsOpen = true;
            membreSelected = 1;
            if (equipage[membreSelected].MyDice.Count != 0)
                B_rollDices.IsEnabled = false;
            else
                B_rollDices.IsEnabled = true;
            memberName.Text = "Commandant";
            info.Text = equipage[membreSelected].Info(falcon);
            SetDes();
        }

        private void B_medecin_Click(object sender, RoutedEventArgs e)
        {
            ResetDes();
            menuaction.IsOpen = true;
            membreSelected = 2;
            if (equipage[membreSelected].MyDice.Count != 0)
                B_rollDices.IsEnabled = false;
            else
                B_rollDices.IsEnabled = true;
            memberName.Text = "Médecin";
            info.Text = equipage[membreSelected].Info(falcon);
            SetDes();
        }

        private void B_mecano_Click(object sender, RoutedEventArgs e)
        {
            ResetDes();
            menuaction.IsOpen = true;
            membreSelected = 3;
            if (equipage[membreSelected].MyDice.Count != 0)
                B_rollDices.IsEnabled = false;
            else
                B_rollDices.IsEnabled = true;
            memberName.Text = "Mécanicien";
            info.Text = equipage[membreSelected].Info(falcon);
            SetDes();
        }
        
        // Sélection des dés
        List<int> SelectedDice = new List<int>();
        private void B_d_Click(object sender, RoutedEventArgs e)
        {
            Button But = (Button)sender;
            string nomImage = string.Format("ms-appx:///Assets//d{0}_select.jpeg", equipage[membreSelected].MyDice[Int32.Parse(But.Tag.ToString())]);
            SelectedDice.Add(Int32.Parse(But.Tag.ToString()));
            But.IsEnabled = false;

            if(!equipage[membreSelected].ValidateDice)
                B_reRollDices.IsEnabled = true;
            B_capaciter.IsEnabled = true;
            B_repare.IsEnabled = true;
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

        // Utilisation des dés sélectionnés pour réparer la salle
        private void B_repare_Click(object sender, RoutedEventArgs e)
        {
            int totalRepart = 0;
            foreach(int nDés in SelectedDice)
            {               
                totalRepart += equipage[membreSelected].MyDice[nDés];
            }
            falcon.Rooms[equipage[membreSelected].Room].Panne -= totalRepart;
            info.Text += string.Format("panne {0} - {1}", falcon.getRommName(equipage[membreSelected].Room),totalRepart);

            foreach (int i in SelectedDice)
                equipage[membreSelected].UsedDice.Add(i);
            SetDes(); 
            SelectedDice.Clear();

            B_capaciter.IsEnabled = false;
            B_repare.IsEnabled = false;
            B_annule.IsEnabled = false;
        }

        // Annulation des sélections
        private void B_annule_Click(object sender, RoutedEventArgs e)
        {
            SelectedDice.Clear();
            SetDes();

            B_capaciter.IsEnabled = false;
            B_repare.IsEnabled = false;
            B_annule.IsEnabled = false;
        }

        // Relancement des dés qui n'on pas été sélectionnés
        private void B_reRollDices_Click(object sender, RoutedEventArgs e)
        {
            B_reRollDices.IsEnabled = false;
            B_capaciter.IsEnabled = false;
            B_annule.IsEnabled = false;
            B_repare.IsEnabled = false;
            foreach(int des in SelectedDice)
            {
                equipage[membreSelected].MyDice[des] = Roll.RollTheDices(1,6)[0];
            }
            equipage[membreSelected].ValidateDice = true;
            SetDes();
            SelectedDice.Clear();
        }
    }
}
