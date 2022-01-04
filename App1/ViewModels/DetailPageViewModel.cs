using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class DetailPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailPageViewModel(string note)
        {
            DismissPageCommad = new Command(async() => 
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            NoteText = note;
        }

        private string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }    
        public Command DismissPageCommad { get; }

    }
}
