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
        private List<Word> words;

        public StatisticsPage(List<Word> words)
        {
            InitializeComponent();
            this.words = words;
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
                int correctCount = words.Count(w => w.IsAnswered && w.IsCorrect);
                int incorrectCount = words.Count(w => w.IsAnswered && !w.IsCorrect);

                var chartEntries = new List<ChartEntry>
                {
                    new ChartEntry(correctCount)
                    {
                        Color = SKColor.Parse("#9ACD32"),
                        Label = "Õige",
                        ValueLabel = correctCount.ToString()
                    },
                    new ChartEntry(incorrectCount)
                    {
                        Color = SKColor.Parse("#FF4500"),
                        Label = "Vale",
                        ValueLabel = incorrectCount.ToString()
                    }
                };

                var chart = new DonutChart
                {
                    Entries = chartEntries,
                    BackgroundColor = SKColor.Empty,
                    LabelTextSize = 45
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
