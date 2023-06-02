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

        public List<ChartEntry> ChartEntries { get; set; }

        public StatisticsPage(List<Word> words)
        {
            InitializeComponent();
            this.words = words;
            BindingContext = this;
            UpdateChart();
        }

        private void UpdateChart()
        {
            int correctCount = words.Count(w => w.IsAnswered && w.IsCorrect);
            int incorrectCount = words.Count(w => w.IsAnswered && !w.IsCorrect);

            ChartEntries = new List<ChartEntry>
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

            OnPropertyChanged(nameof(ChartEntries));
        }
    }
}
