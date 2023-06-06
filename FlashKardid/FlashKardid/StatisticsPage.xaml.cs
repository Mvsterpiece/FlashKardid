using FlashKardid.Models;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashKardid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        private AnswerStatistic answerStatistic;

        public StatisticsPage(AnswerStatistic answerStatistic)
        {
            InitializeComponent();
            this.answerStatistic = answerStatistic;



            var titleLabel = new Label
            {
                Text = "Sõna-tõlk",
                FontSize = 20,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var customTitleView = new ContentView
            {
                Content = titleLabel,
                Padding = new Thickness(10, 0)
            };


            NavigationPage.SetTitleView(this, customTitleView);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateChart();
        }

        private void UpdateChart()
        {
            try
            {
                var chartEntries = new List<ChartEntry>
                {
                    new ChartEntry(answerStatistic.FalseCount)
                    {
                        Color = SKColor.Parse("#FF4500"),
                        Label = "Vale",
                        ValueLabelColor = SKColor.Parse("#FF4500"),
                        ValueLabel = answerStatistic.FalseCount.ToString()
                    },
                    new ChartEntry(answerStatistic.TrueCount)
                    {
                        Color = SKColor.Parse("#9ACD32"),
                        Label = "Õige",
                        ValueLabelColor = SKColor.Parse("#9ACD32"),
                        ValueLabel = answerStatistic.TrueCount.ToString(),

                    }
                };

                var chart = new DonutChart
                {
                    Entries = chartEntries,
                    BackgroundColor = SKColor.Empty,
                    LabelTextSize = 45,
                    HoleRadius = 0.6f
                };

                chartView.Chart = chart;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating chart: {ex.Message}");
            }
        }
    }
}
