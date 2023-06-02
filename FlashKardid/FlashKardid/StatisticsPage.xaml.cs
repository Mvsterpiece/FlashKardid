using FlashKardid.Models;
using Microcharts;
using Microcharts.Forms;
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

        public StatisticsPage()
        {
            InitializeComponent();
            words = App.Database.GetItems().ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateChart();
        }

        private void UpdateChart()
        {
            int correctCount = words.Count(w => w.IsCorrect);
            int incorrectCount = words.Count(w => !w.IsCorrect);

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
                    ValueLabel = incorrectCount.ToString(),
                    
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
    }
}
