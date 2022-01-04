using App1.Views;
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

            SelectedNoteChangedCommand = new Command(async() =>
            {
                DetailPageViewModel detailVM = new DetailPageViewModel(SelectedNote);

                DetailPage detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);

            });

        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                // indica a la vista que la propiedad cambió
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }

        }

        private string selectedNote;
        public string SelectedNote { get => selectedNote; 
            set
            {
                selectedNote = value;

                PropertyChangedEventArgs args = new PropertyChangedEventArgs(nameof(selectedNote));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command SelectedNoteChangedCommand { get; }

    }
}
