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
                int trueCount = answerStatistic.TrueCount;
                int falseCount = answerStatistic.FalseCount;

                var chartEntries = new List<ChartEntry>
                {
                    new ChartEntry(trueCount)
                    {
                        Color = SKColor.Parse("#9ACD32"),
                        Label = "Õige",
                        ValueLabel = trueCount.ToString()
                    },
                    new ChartEntry(falseCount)
                    {
                        Color = SKColor.Parse("#FF4500"),
                        Label = "Vale",
                        ValueLabel = falseCount.ToString()
                    }
                };

                var chart = new DonutChart
                {
                    Entries = chartEntries,
                    BackgroundColor = SKColor.Empty,
                    LabelTextSize = 45,
                    HoleRadius = 0.6f // Adjust the hole radius as desired
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
