using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carsharing
{
    class CarToUserPageWindow : CarToWindow
    {
        private string startDate;
        private string endDate;

        public CarToUserPageWindow(RoutedEventHandler buttonClick) : base(buttonClick)
        {
        }

        public override Grid CreateNewCarGrid(string mark, string model, string picture, int price, string buttonContent)
        {
            Grid carsWithDates = new Grid();

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            Grid carGrid = base.CreateNewCarGrid(mark, model, picture, price, buttonContent);

            Grid datesGrid = CreateDatesGrid(IsExpired());

            carsWithDates.RowDefinitions.Add(rowDef1);
            carsWithDates.RowDefinitions.Add(rowDef2);
            carsWithDates.RowDefinitions.Add(rowDef3);

            Grid.SetRow(carGrid, 1);
            Grid.SetRow(datesGrid, 2);

            carsWithDates.Children.Add(CreateYourCarText());
            carsWithDates.Children.Add(carGrid);
            carsWithDates.Children.Add(datesGrid);

            return carsWithDates;
        }

        private Grid CreateDatesGrid(bool expired)
        {
            Grid newDatesGrid = new Grid();

            newDatesGrid.Children.Add(CreateStartDateText(startDate));
            newDatesGrid.Children.Add(CreateEndDateText(endDate, expired, newDatesGrid));

            Grid.SetRow(newDatesGrid, 0);

            return newDatesGrid;
        }

        private TextBlock CreateYourCarText()
        {
            TextBlock yourCarText = new TextBlock();
            yourCarText.Text = "You have this car:";
            yourCarText.VerticalAlignment = VerticalAlignment.Top;
            yourCarText.HorizontalAlignment = HorizontalAlignment.Center;
            yourCarText.Margin = new Thickness(3, 10, 3, 10);
            yourCarText.FontSize = 18;
            yourCarText.TextAlignment = TextAlignment.Center;
            yourCarText.FontWeight = FontWeights.DemiBold;

            return yourCarText;
        }

        private TextBlock CreateStartDateText(string startDate)
        {
            TextBlock startDateText = new TextBlock();
            startDateText.Text = $"Start date: {startDate}";
            startDateText.VerticalAlignment = VerticalAlignment.Top;
            startDateText.HorizontalAlignment = HorizontalAlignment.Left;
            startDateText.Margin = new Thickness(3, 5, 3, 10);
            startDateText.TextAlignment = TextAlignment.Left;
            startDateText.FontSize = 14;
            startDateText.FontWeight = FontWeights.DemiBold;

            return startDateText;
        }

        private TextBlock CreateEndDateText(string endDate, bool expired, Grid newDatesGrid)
        {
            TextBlock endDateText = new TextBlock();

            if (expired)
            {
                endDateText.Text = $"End date: {endDate}\n\n You did not return the car on time.\nYou will have to pay the fine!";
                endDateText.Foreground = Brushes.Red;
            }
            else
            {
                endDateText.Text = $"End date: {endDate}";
                endDateText.Foreground = Brushes.LimeGreen;
            }

            endDateText.VerticalAlignment = VerticalAlignment.Top;
            endDateText.HorizontalAlignment = HorizontalAlignment.Right;
            endDateText.Margin = new Thickness(3, 5, 3, 10);
            endDateText.TextAlignment = TextAlignment.Right;
            endDateText.FontSize = 14;
            endDateText.FontWeight = FontWeights.DemiBold;

            return endDateText;
        }

        private TextBlock CreateUserHaveNotCarsText()
        {
            TextBlock yourCarText = new TextBlock();

            yourCarText.Text = "You don't have a rented car, you can rent \nby clicking on the button \"Go to cars\".";
            yourCarText.VerticalAlignment = VerticalAlignment.Top;
            yourCarText.HorizontalAlignment = HorizontalAlignment.Center;
            yourCarText.Margin = new Thickness(3, 10, 3, 18);
            yourCarText.FontSize = 16;
            yourCarText.TextAlignment = TextAlignment.Center;
            yourCarText.FontWeight = FontWeights.DemiBold;

            return yourCarText;
        }

        public UIElement DoesUserHaveCar()
        {
            if (CurrentUser.user.Car == 0)
            {
                return CreateUserHaveNotCarsText();
            }
            else
            {
                CarsList carsList = new CarsList();

                foreach (Car car in carsList.listOfCars)
                {
                    if (CurrentUser.user.Car == car.id)
                    {
                        this.startDate = CurrentUser.user.Start_date;
                        this.endDate = CurrentUser.user.End_date;
                        return CreateNewCarGrid(car.Mark, car.Model, car.Picture, car.Price, "return");
                    }
                }
            }
            throw new ArgumentException();
        }

        private bool IsExpired()
        {
            if (DateTime.TryParse(startDate, out DateTime startDateTime) && DateTime.TryParse(endDate, out DateTime endDateTime))
            {
                return (endDateTime.AddDays(1) < DateTime.Now);
            }
            else
                throw new TypeLoadException();
        }
    }
}
