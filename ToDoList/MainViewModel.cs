using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using System;

namespace ToDoList;

public class MainViewModel : BindableObject
{
    private int _index;
    private string _color;
    public string color
    {
        get => _color;
        set
        {
            _color = value;
            OnPropertyChanged(nameof(color));
        }
    }

    private bool _hist = false;
    public bool ChangeMode
    {
        get => _hist;
        set
        {
            _hist = value;
            OnPropertyChanged(nameof(ChangeMode));
        }
    }
    private bool _changeModeInverse = true;
    public bool ChangeModeInverse
    {
        get => _changeModeInverse;
        set
        {
            _changeModeInverse = value;
            OnPropertyChanged(nameof(ChangeModeInverse));
        }
    }
    private string _activeText = "";
    public string ActiveText
    {
        get => _activeText;
        set
        {
            _activeText = value;
            OnPropertyChanged(nameof(ActiveText));
        }
    }

    public MainViewModel()
    {
        _color = "red";
        AddItemCommand = new Command<string>(x =>
        {
            var item = new ToDoItem(x, color);
            ToDoItems.Add(item);
            ActiveText = "";
        }
        , x => string.IsNullOrWhiteSpace(x) == false);

        DeleteItemCommand = new Command<ToDoItem>(x => ToDoItems.Remove(x));
        ChangeCommand = new Command<ToDoItem>(x =>
        {
            ChangeMode = !ChangeMode;
            ChangeModeInverse = !ChangeModeInverse;
            _index = ToDoItems.IndexOf(x);
            ActiveText = x.Title;
        });

        SaveCommand = new Command<string>(title =>
        {
            ToDoItems[_index].Title = title;
            ToDoItems[_index].Color = Color.Parse(color);
            ChangeMode = !ChangeMode;
            ChangeModeInverse = !ChangeModeInverse;
            ActiveText = "";
        }
        , title => string.IsNullOrWhiteSpace(title) == false);

    }
    public ICommand AddItemCommand { get; }
    public ICommand DeleteItemCommand { get; }
    public ICommand ChangeCommand { get; }
    public ICommand SaveCommand { get; }
    public ObservableCollection<ToDoItem> ToDoItems { get; } = new ObservableCollection<ToDoItem>();
}

public class ToDoItem : BindableObject
{
    public ToDoItem(string title, string color)
    {
        _title = title;
        _color = Color.Parse(color);
    }

    private Color _color;
    public Color Color
    {
        get => _color;
        set
        {
            if (_color == value) return;
            _color = value;
            OnPropertyChanged(nameof(Color));
        }
    }
    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            if (_title == value) return;
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            if (_text == value) return;
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }
    public override string ToString()
    {
        return Title;
    }
}