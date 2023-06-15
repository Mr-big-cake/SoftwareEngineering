using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GraphExample.Launcher.App.MapComponent;

public sealed class VertexMapComponent : ViewModelBase, IMapComponent
{

    public class VertexClickEventArgs : EventArgs
    {
        
    }

    public static readonly double XRadius;
    public static readonly double YRadius; 

    private double _x;
    private double _y;
    private string _name;
    private readonly Lazy<ICommand> _clickCommand;

    public event Action<VertexMapComponent, VertexClickEventArgs> Clicked;

    static VertexMapComponent()
    {
        // TODO: read Width & Height values from configuration file...

        XRadius = 10;
        YRadius = 10;
    }

    public VertexMapComponent(string name = "vertex")
    {
        Name = name;
        
        _clickCommand = new Lazy<ICommand>(() => new RelayCommand(_ => Click()));
    }

    public double X
    {
        get =>
            _x;

        set
        {
            _x = value;
            RaisePropertyChanged(nameof(X));
        }
    }

    public double Y
    {
        get =>
            _y;
        
        set
        {
            _y = value;
            RaisePropertyChanged(nameof(Y));
        }
    }

    public string Name
    {
        get =>
            _name;

        private set
        {
            _name = value;
            RaisePropertyChanged(nameof(Name));
        }
    }

    public ICommand ClickCommand =>
        _clickCommand.Value;

    private void Click()
    {
        /*var msgBuilder = new StringBuilder();
        msgBuilder.Append("I am an vertex!")
            .Append(Environment.NewLine)
            .Append($"My name is {Name}!");
        MessageBox.Show(msgBuilder.ToString());*/
        
        Clicked?.Invoke(this, new VertexClickEventArgs());
    }

}