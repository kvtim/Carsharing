using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Carsharing
{
    class CarToWindow
    {
        protected RoutedEventHandler buttonClick;

        public CarToWindow(RoutedEventHandler buttonClick)
        {
            this.buttonClick = buttonClick;
        }

        public virtual Grid CreateNewCarGrid(string mark, string model, string picture, int price, string buttonContent)
        {
            Grid newCarGrid = new Grid();
            newCarGrid.Height = 110;

            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();

            colDef1.Width = new GridLength(128, GridUnitType.Star);
            colDef2.Width = new GridLength(123, GridUnitType.Star);
            colDef3.Width = new GridLength(96, GridUnitType.Star);

            newCarGrid.ColumnDefinitions.Add(colDef1);
            newCarGrid.ColumnDefinitions.Add(colDef2);
            newCarGrid.ColumnDefinitions.Add(colDef3);

            newCarGrid.Children.Add(CreateBorder());
            newCarGrid.Children.Add(CreateButton(buttonClick, buttonContent));
            newCarGrid.Children.Add(CreateCarDesciption(mark, model, price));
            newCarGrid.Children.Add(CreateImage(picture));

            return newCarGrid;
        }

        private Border CreateBorder()
        {
            Border border = new Border();
            border.BorderBrush = Brushes.Gray;
            border.BorderThickness = new Thickness(2);
            Grid.SetColumnSpan(border, 3);

            return border;
        }

        private Button CreateButton(RoutedEventHandler buttonClick, string buttonContent)
        {
            Button rentButton = new Button();
            rentButton.Content = buttonContent;
            rentButton.VerticalAlignment = VerticalAlignment.Center;
            rentButton.HorizontalAlignment = HorizontalAlignment.Center;
            rentButton.Height = 28;
            rentButton.Width = 75;
            rentButton.Click += buttonClick;
            Grid.SetColumn(rentButton, 2);

            return rentButton;
        }

        private TextBlock CreateCarDesciption(string mark, string model, int price)
        {
            TextBlock carDescription = new TextBlock();
            carDescription.Text = $"Mark: {mark}\nMode: {model}\nPrice: {price} $";
            carDescription.VerticalAlignment = VerticalAlignment.Center;
            carDescription.HorizontalAlignment = HorizontalAlignment.Center;
            carDescription.Margin = new Thickness(7, 0, 7, 0);
            carDescription.MaxHeight = 106;
            carDescription.Width = 116;
            carDescription.TextAlignment = TextAlignment.Center;
            carDescription.FontWeight = FontWeights.Medium;
            Grid.SetColumn(carDescription, 1);

            return carDescription;
        }

        private Image CreateImage(string picture)
        {
            Image newCarImage = new Image();
            newCarImage.Source = new BitmapImage(new Uri($"Images/{picture}", UriKind.Relative));
            newCarImage.Margin = new Thickness(4.5, 4, 4, 4);
            newCarImage.HorizontalAlignment = HorizontalAlignment.Center;
            newCarImage.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(newCarImage, 0);

            return newCarImage;
        }
    }
}