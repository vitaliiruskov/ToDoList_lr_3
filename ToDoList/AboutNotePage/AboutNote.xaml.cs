namespace ToDoList.AboutNotePage;

public partial class AboutNote : ContentPage
{
    public string AboutNotes;

    public AboutNote(string AN)
    {
        InitializeComponent();
        AboutNoteLabel.Text = AN;
    }
}