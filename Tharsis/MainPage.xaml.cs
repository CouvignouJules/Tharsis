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
        private int membreSelected;
        // Indicateur de la semaine en cours
        private int semaine = 1;
        // Indicateur du nombre de membre morts (si ce nombre atteint 4, la partie est perdue)
        private int deadMembers = 0;

        int sallePrecedente;


        public MainPage()
        {
            this.InitializeComponent();
            InitEquipage();
            shipHealth.Text = Health(falcon);
            Tour.game(semaine, equipage, falcon);
            setPannes();
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

        // Affiche la semaine en cours et les pannes
        public void setPannes()
        {
            PanneInfo.Text = string.Format("Semaine {0}\n", semaine);
            foreach (Room salle in falcon.Rooms)
            {
                if(salle.Panne > 0)
                    PanneInfo.Text += salle.ToString() + "\n";
            }
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
                equipage[membreSelected].Room = 5;
                B_deplacement.IsEnabled = true;
                info.Text = equipage[membreSelected].Info(falcon);

                B_capitaine.IsEnabled = true;
                B_commandant.IsEnabled = true;
                B_medecin.IsEnabled = true;
                B_mecano.IsEnabled = true;

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if(falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente - 1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
            }
        }

        private void B_detente_Click(object sender, RoutedEventArgs e)
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

                B_pilotage.IsEnabled = true;
                B_serre.IsEnabled = true;
                B_infirmeri.IsEnabled = true;
                B_laboratoire.IsEnabled = true;
                B_survie.IsEnabled = true;
                B_maintenance.IsEnabled = true;
                B_detente.IsEnabled = true;

                if (falcon.Rooms[sallePrecedente-1].Panne > 0)
                {
                    equipage[membreSelected].HP--;
                    info.Text = equipage[membreSelected].Info(falcon);
                }
            }
        }

        // Active la capacité spéciale du membre d'équipage
        private void B_capaciter_Click(object sender, RoutedEventArgs e)
        {
            //info.Text = equipage[membreSelected].Info(falcon);
            info.Text = "";
            foreach(int i in SelectedDice)
            {
                if (equipage[membreSelected].CapaciteNumber < 3)
                {
                    if(equipage[membreSelected].MyDice[i] >= 5)
                    {
                        equipage[membreSelected].Capacite(falcon, equipage);
                        equipage[membreSelected].UsedDice.Add(i);
                        equipage[membreSelected].CapaciteNumber++;
                        info.Text = equipage[membreSelected].Info(falcon);
                        shipHealth.Text = Health(falcon);
                    }
                    else
                    {
                        info.Text += "\nDés invalides";
                    }
                }
                else
                {
                    info.Text += "\nPlus de capacité utilisable";
                }
            }

            SetDes();
            SelectedDice.Clear();
            setPannes();

            B_capaciter.IsEnabled = false;
            B_repare.IsEnabled = false;
            B_annule.IsEnabled = false;
        }

        /* Désactive le bouton de déplacement (ce qui permet de se déplacer en utilisant les méthodes citées plus haut) 
         * Désactive aussi les boutons de sélection des autres membres afin de ne pas déplacer un autre membre après avoir cliqué
         * Oblige le joueur à se déplacer une salle par une salle */
        private void B_deplacement_Click(object sender, RoutedEventArgs e)
        {
            sallePrecedente = equipage[membreSelected].Room;

            B_deplacement.IsEnabled = false;
            B_capitaine.IsEnabled = false;
            B_commandant.IsEnabled = false;
            B_medecin.IsEnabled = false;
            B_mecano.IsEnabled = false;

            switch (equipage[membreSelected].Room)
            {
                case 1: // Pilotage
                    B_infirmeri.IsEnabled = false;
                    B_laboratoire.IsEnabled = false;
                    B_survie.IsEnabled = false;
                    B_maintenance.IsEnabled = false;
                    B_detente.IsEnabled = false;
                    break;
                case 2: // Serre
                    B_laboratoire.IsEnabled = false;
                    B_survie.IsEnabled = false;
                    B_maintenance.IsEnabled = false;
                    B_detente.IsEnabled = false;
                    break;
                case 3: // Infirmerie
                    B_pilotage.IsEnabled = false;
                    B_maintenance.IsEnabled = false;
                    break;
                case 4: // Survie
                    B_pilotage.IsEnabled = false;
                    B_serre.IsEnabled = false;
                    B_survie.IsEnabled = false;
                    B_detente.IsEnabled = false;
                    B_maintenance.IsEnabled = false;
                    break;
                case 5: // Laboratoire
                    B_pilotage.IsEnabled = false;
                    B_serre.IsEnabled = false;
                    B_laboratoire.IsEnabled = false;
                    B_detente.IsEnabled = false;
                    B_maintenance.IsEnabled = false;
                    break;
                case 6: // Détente
                    B_pilotage.IsEnabled = false;
                    B_serre.IsEnabled = false;
                    B_survie.IsEnabled = false;
                    B_laboratoire.IsEnabled = false;
                    break;
                case 7: // Maintenance
                    B_pilotage.IsEnabled = false;
                    B_serre.IsEnabled = false;
                    B_infirmeri.IsEnabled = false;
                    B_survie.IsEnabled = false;
                    B_laboratoire.IsEnabled = false;
                    break;
            }
        }

        /* Pour chaque membre d'équipage : Établissement des dés, ouverture de la popup lui correspondant, 
         * vérification de son nombre de dés pour les lancer, affichage de ses infos dans la popup
         * puis appel de setDes décrite plus haut. La popup ne s'ouvre pas si le personnage est mort, l'empêchant de faire quoi que ce soit */
        private void B_capitaine_Click(object sender, RoutedEventArgs e)
        {
            membreSelected = 0;

            if (equipage[membreSelected].HP > 0)
            {
                ResetDes();
                menuaction.IsOpen = true;

                if (equipage[membreSelected].MyDice.Count != 0)
                    B_rollDices.IsEnabled = false;
                else
                    B_rollDices.IsEnabled = true;

                memberName.Text = "Capitaine";
                info.Text = equipage[membreSelected].Info(falcon);
                SetDes();
            } else
            {
                menuaction.IsOpen = false;
                memberName.Text = "Capitaine (mort)";
            }
        }

        private void B_commandant_Click(object sender, RoutedEventArgs e)
        {
            membreSelected = 1;

            if (equipage[membreSelected].HP > 0)
            {
                ResetDes();
                menuaction.IsOpen = true;

                if (equipage[membreSelected].MyDice.Count != 0)
                    B_rollDices.IsEnabled = false;
                else
                    B_rollDices.IsEnabled = true;

                memberName.Text = "Commandant";
                info.Text = equipage[membreSelected].Info(falcon);
                SetDes();

            }
            else
            {
                menuaction.IsOpen = false;
                memberName.Text = "Commandant (mort)";
            }
        }

        private void B_mecano_Click(object sender, RoutedEventArgs e)
        {
            membreSelected = 2;

            if (equipage[membreSelected].HP > 0)
            {
                ResetDes();
                menuaction.IsOpen = true;

                if (equipage[membreSelected].MyDice.Count != 0)
                    B_rollDices.IsEnabled = false;
                else
                    B_rollDices.IsEnabled = true;
                memberName.Text = "Mécanicien";
                info.Text = equipage[membreSelected].Info(falcon);
                SetDes();
            }
            else
            {
                menuaction.IsOpen = false;
                memberName.Text = "Mécanicien (mort)";
            }
        }

        private void B_medecin_Click(object sender, RoutedEventArgs e)
        {
            membreSelected = 3;

            if (equipage[membreSelected].HP > 0)
            {
                ResetDes();
                menuaction.IsOpen = true;
            
                if (equipage[membreSelected].MyDice.Count != 0)
                    B_rollDices.IsEnabled = false;
                else
                    B_rollDices.IsEnabled = true;

                memberName.Text = "Médecin";
                info.Text = equipage[membreSelected].Info(falcon);
                SetDes();
            }
            else
            {
                menuaction.IsOpen = false;
                memberName.Text = "Médecin (mort)";
            }
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

            if(equipage[membreSelected].CapaciteNumber < 3)
                B_capaciter.IsEnabled = true;

            B_repare.IsEnabled = true;
            B_annule.IsEnabled = true;
            // Attribue l'image du dé sélectionné         
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
            falcon.Rooms[equipage[membreSelected].Room-1].Panne -= totalRepart;

            if (falcon.Rooms[equipage[membreSelected].Room - 1].Panne < 0)
                falcon.Rooms[equipage[membreSelected].Room - 1].Panne = 0;

            foreach (int i in SelectedDice)
                equipage[membreSelected].UsedDice.Add(i);
            SetDes(); 
            SelectedDice.Clear();
            setPannes();

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

        // Effectue les opérations affectant les PV des membres et du vaisseau en fonction des pannes actives à la fin du tour
        private void nextTurn_Click(object sender, RoutedEventArgs e)
        {
            semaine++;
            foreach(Membre membre in equipage)
            {
                membre.MyDice.Clear();
                membre.UsedDice.Clear();
                info.Text = membre.Info(falcon);
            }

            foreach (Room salle in falcon.Rooms)
            {
                if (salle.Panne > 0)
                {
                    foreach(Membre membre in equipage)
                    {
                        if(membre.HP > 0)
                            membre.HP--;

                        if(membre.HP <= 0)
                        {
                            deadMembers++;
                        }

                        info.Text = membre.Info(falcon);
                        membre.CapaciteNumber = 0;
                    }

                    falcon.HP--;
                }
                shipHealth.Text = Health(falcon);
            }

            if(deadMembers >= 4 || falcon.HP <= 0)
            {
                this.Frame.Navigate(typeof(GameOverPage), null);
            }

            if(semaine <= 10)
            {
                Tour.game(semaine, equipage, falcon);
                setPannes();
            } else
            {
                this.Frame.Navigate(typeof(WinPage), null);
            }

            // Repasse sur le capitaine par défaut
            B_capitaine_Click(sender, e);
        }

        
    }
}
