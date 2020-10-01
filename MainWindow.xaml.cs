using CocktailApiLibrary;
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

namespace CocktailApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();   // kann auch in App.xaml
        }

        private async Task LoadCocktail()
        {
            // API Aufruf um zufälligen Cocktail zu laden
            CocktailModels.DrinkModel randomDrink = await CocktailProcessor.LoadRandomCocktail();

            // Cocktail Info anzeigen
            tbName.Text = randomDrink.strDrink;
            tbGlass.Text = randomDrink.strGlass;
            tbInstructions.Text = randomDrink.strInstructions;

            tbIngredients1.Text = randomDrink.strIngredient1;
            tbMeasures1.Text = randomDrink.strMeasure1;

            // Bild ist absolute URL => als Source des Image Elements
            var uriSrc = new Uri(randomDrink.strDrinkThumb, UriKind.Absolute);
            imgThumb.Source = new BitmapImage(uriSrc);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCocktail();
        }

        private async void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            await LoadCocktail();
        }
    }
}
