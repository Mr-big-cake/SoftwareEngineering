using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GraphExample.Launcher.App.MapComponent;

public sealed class EdgeMapComponent : ViewModelBase, IMapComponent
{

    public static readonly double Thickness; 

    private VertexMapComponent? _first;
    private VertexMapComponent? _second;
    private readonly Lazy<ICommand> _clickCommand;

    static EdgeMapComponent()
    {
        // TODO: read Width & Height values from configuration file...
        
        Thickness = 10;
    }
    
    public EdgeMapComponent()
    {
        _clickCommand = new Lazy<ICommand>(() => new RelayCommand(_ => Click()));
    }

    public VertexMapComponent? First
    {
        get =>
            _first;

        set
        {
            _first = value;
            RaisePropertyChanged(nameof(First));
        }
    }

    public VertexMapComponent? Second
    {
        get =>
            _second;

        set
        {
            _second = value;
            RaisePropertyChanged(nameof(Second));
        }
    }
    
    public ICommand ClickCommand =>
        _clickCommand.Value;

    private void Click()
    {
        var msgBuilder = new StringBuilder();
        msgBuilder.Append("I am an edge!")
            .Append(Environment.NewLine)
            .Append($"Connected vertices: {First.Name} and {Second.Name}!");
        MessageBox.Show(msgBuilder.ToString());
    }

}