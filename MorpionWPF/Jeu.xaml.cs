using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MorpionWPF
{
	/// <summary>
	/// Interaction logic for Menu.xaml
	/// </summary>
	public partial class Jeu : Page
	{
		private string BlueSymbol;
		private string RedSymbol;

		private int BlueScore = 0;
		private int RedScore = 0;
		private int Nul = 0;
		private int Total;

		private short TurnNumber = 1;

		private bool BluePlays = true;
		private bool Ended = false;

		private bool TopLeftPlayed = false;
		private bool TopMidPlayed = false;
		private bool TopRightPlayed = false;
		private bool MidLeftPlayed = false;
		private bool MidMidPlayed = false;
		private bool MidRightPlayed = false;
		private bool BotLeftPlayed = false;
		private bool BotMidPlayed = false;
		private bool BotRightPlayed = false;

		/// <summary>
		/// Constructeur.
		/// </summary>
		public Jeu()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructeur qui transmet le choix du joueur.
		/// </summary>
		/// <param name="choice">Le symbole que le joueur a choisi.</param>
		/// <param name="blueScore">Transmet le score du Bleu.</param>
		/// <param name="redScore">Transmet le score du Rouge.</param>
		/// <param name="nul">Transmet le score actuel de l'égalité.</param>
		public Jeu(string choice, int blueScore, int redScore, int nul)
		{
			BlueScore = blueScore;
			RedScore = redScore;
			Nul = nul;
			Total = nul + redScore + blueScore;

			InitializeComponent();

			if (Total % 2 == 0)
			{
				if (choice == "X")
				{
					BlueSymbol = "X";
					RedSymbol = "O";
				}
				else if (choice == "O")
				{
					BlueSymbol = "O";
					RedSymbol = "X";
				}
				else
				{
					BlueSymbol = "ERROR";
					RedSymbol = "ERROR";
				}
			}
			else
			{
				if (choice == "X")
				{
					BlueSymbol = "O";
					RedSymbol = "X";
				}
				else if (choice == "O")
				{
					BlueSymbol = "X";
					RedSymbol = "O";
				}
				else
				{
					BlueSymbol = "ERROR";
					RedSymbol = "ERROR";
				}
			}
			SetScore();
		}

		/// <summary>
		/// Met à jour les scores.
		/// </summary>
		private void SetScore()
		{
			BlueScoreNumber.Content = BlueScore;
			RedScoreNumber.Content = RedScore;
			NulNumber.Content = Nul;
		}

		/// <summary>
		/// Changement du Bleu au Rouge et Inversement.
		/// </summary>
		private void SwitchSide()
		{
			if (BluePlays)
			{
				BluePlays = false;
				BlueTurn.Content = "";
				RedTurn.Content = "Your Turn !";
			}
			else
			{
				BluePlays = true;
				BlueTurn.Content = "Your Turn !";
				RedTurn.Content = "";
			}
			TurnNumber++;
			Ending();
		}

		/// <summary>
		/// Insertion du Symbole du joueur en cours.
		/// </summary>
		/// <param name="button">Le bouton sur lequel on a cliqué.</param>
		private void InsertSymbol(Button button)
		{
			if (BluePlays)
			{
				button.Content = BlueSymbol;
				button.Foreground = Brushes.Blue;
			}
			else
			{
				button.Content = RedSymbol;
				button.Foreground = Brushes.Red;
			}
			SwitchSide();
		}

		/// <summary>
		/// Les conditions de victoire et l'affectation du score.
		/// </summary>
		private void Ending()
		{
			if (
				((string)TopLeft.Content == BlueSymbol && (string)TopMid.Content == BlueSymbol && (string)TopRight.Content == BlueSymbol)
				|| ((string)MidLeft.Content == BlueSymbol && (string)MidMid.Content == BlueSymbol && (string)MidRight.Content == BlueSymbol)
				|| ((string)BotLeft.Content == BlueSymbol && (string)BotMid.Content == BlueSymbol && (string)BotRight.Content == BlueSymbol)
				|| ((string)TopLeft.Content == BlueSymbol && (string)MidLeft.Content == BlueSymbol && (string)BotLeft.Content == BlueSymbol)
				|| ((string)TopMid.Content == BlueSymbol && (string)MidMid.Content == BlueSymbol && (string)BotMid.Content == BlueSymbol)
				|| ((string)TopRight.Content == BlueSymbol && (string)MidRight.Content == BlueSymbol && (string)BotRight.Content == BlueSymbol)
				|| ((string)TopLeft.Content == BlueSymbol && (string)MidMid.Content == BlueSymbol && (string)BotRight.Content == BlueSymbol)
				|| ((string)BotLeft.Content == BlueSymbol && (string)MidMid.Content == BlueSymbol && (string)TopRight.Content == BlueSymbol)
				)
			{
				MessageBox.Show("Blue Wins", "Victoire", MessageBoxButton.OK);
				BlueScore++;
				Ended = true;
			}

			if ( !Ended && (
				((string)TopLeft.Content == RedSymbol && (string)TopMid.Content == RedSymbol && (string)TopRight.Content == RedSymbol)
				|| ((string)MidLeft.Content == RedSymbol && (string)MidMid.Content == RedSymbol && (string)MidRight.Content == RedSymbol)
				|| ((string)BotLeft.Content == RedSymbol && (string)BotMid.Content == RedSymbol && (string)BotRight.Content == RedSymbol)
				|| ((string)TopLeft.Content == RedSymbol && (string)MidLeft.Content == RedSymbol && (string)BotLeft.Content == RedSymbol)
				|| ((string)TopMid.Content == RedSymbol && (string)MidMid.Content == RedSymbol && (string)BotMid.Content == RedSymbol)
				|| ((string)TopRight.Content == RedSymbol && (string)MidRight.Content == RedSymbol && (string)BotRight.Content == RedSymbol)
				|| ((string)TopLeft.Content == RedSymbol && (string)MidMid.Content == RedSymbol && (string)BotRight.Content == RedSymbol)
				|| ((string)BotLeft.Content == RedSymbol && (string)MidMid.Content == RedSymbol && (string)TopRight.Content == RedSymbol)
				))
			{
				MessageBox.Show("Red Wins", "Victoire", MessageBoxButton.OK);
				RedScore++;
				Ended = true;
			}

			if (!Ended && TurnNumber == 10 )
			{
				Nul++;
				Ended = true;
			}

			if (Ended)
			{
				Menu menu = new Menu(BlueScore, RedScore, Nul);
				NavigationService.Navigate(menu);
			}

			SetScore();
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void TopLeft_Click(object sender, RoutedEventArgs e)
		{
			if (!TopLeftPlayed)
			{
				InsertSymbol(TopLeft); TopLeftPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void TopMid_Click(object sender, RoutedEventArgs e)
		{
			if (!TopMidPlayed)
			{
				InsertSymbol(TopMid); TopMidPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void TopRight_Click(object sender, RoutedEventArgs e)
		{
			if (!TopRightPlayed)
			{
				InsertSymbol(TopRight); TopRightPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void MidLeft_Click(object sender, RoutedEventArgs e)
		{
			if (!MidLeftPlayed)
			{
				InsertSymbol(MidLeft); MidLeftPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void MidMid_Click(object sender, RoutedEventArgs e)
		{
			if (!MidMidPlayed)
			{
				InsertSymbol(MidMid); MidMidPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void MidRight_Click(object sender, RoutedEventArgs e)
		{
			if (!MidRightPlayed)
			{
				InsertSymbol(MidRight); MidRightPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void BotLeft_Click(object sender, RoutedEventArgs e)
		{
			if (!BotLeftPlayed)
			{
				InsertSymbol(BotLeft); BotLeftPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void BotMid_Click(object sender, RoutedEventArgs e)
		{
			if (!BotMidPlayed)
			{
				InsertSymbol(BotMid); BotMidPlayed = true;
			}
		}

		/// <summary>
		/// Les Cases Cliquables du plateau.
		/// </summary>
		private void BotRight_Click(object sender, RoutedEventArgs e)
		{
			if (!BotRightPlayed)
			{
				InsertSymbol(BotRight); BotRightPlayed = true;
			}
		}
	}
}
