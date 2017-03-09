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
	public partial class Menu : Page
	{
		public int BlueScore;
		public int RedScore;
		public int Nul;
		private int Total;

		public Menu()
		{
			InitializeComponent();
		}

		public Menu(int blueScore, int redScore, int nul)
		{
			BlueScore = blueScore;
			RedScore = redScore;
			Nul = nul;
			Total = nul + redScore + blueScore;
			InitializeComponent();
			if (Total % 2 == 0)
			{
				Text_Joueur1.Content = "Joueur 1";
				Text_Joueur2.Content = "";
			}
			else
			{
				Text_Joueur1.Content = "";
				Text_Joueur2.Content = "Joueur 2";
			}
		}

		private void O_Click(object sender, RoutedEventArgs e)
		{
			Jeu jeu = new Jeu("O", BlueScore, RedScore, Nul);
			NavigationService.Navigate(jeu);
		}

		private void X_Click(object sender, RoutedEventArgs e)
		{
			Jeu jeu = new Jeu("X", BlueScore, RedScore, Nul);
			NavigationService.Navigate(jeu);
		}
	}
}
