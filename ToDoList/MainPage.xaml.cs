using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel() { };
    }

    private async void OnAboutNote(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        ToDoItem note = NoteListView.SelectedItem as ToDoItem;

        await Navigation.PushAsync(new AboutNotePage.AboutNote(note.Title));
    }
}