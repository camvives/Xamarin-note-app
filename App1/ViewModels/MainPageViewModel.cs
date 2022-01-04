using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() => 
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);

                TheNote = string.Empty;
            });

        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote 
        { 
            get => theNote;
            set
            {
                theNote = value;
                // indica a la vista que la propiedad cambió
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }

        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

    }
}
