using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GraphExample.Launcher.App.MapComponent;

namespace GraphExample.Launcher.App;

public sealed class MainViewModel : ViewModelBase
{

    private readonly ObservableCollection<IMapComponent>? _components = new();
    private VertexMapComponent _selectedVertex;
    private int _counter = 0;

    private void OnVertexClicked(VertexMapComponent vertex, VertexMapComponent.VertexClickEventArgs eventArgs)
    {
        if (_selectedVertex is null)
        {
            _selectedVertex = vertex;
            return;
        }

        if (ReferenceEquals(vertex, _selectedVertex))
        {
            return;
        }

        var existingEdgeByVertices = Components
            .OfType<EdgeMapComponent>()
            .SingleOrDefault(edge =>
                ReferenceEquals(edge.First, vertex) && ReferenceEquals(edge.Second, _selectedVertex)
                || ReferenceEquals(edge.First, _selectedVertex) && ReferenceEquals(edge.Second, vertex));

        if (existingEdgeByVertices is null)
        {
            Components.Insert(0, new EdgeMapComponent
            {
                First = _selectedVertex,
                Second = vertex
            });
        }
        else
        {
            Components.Remove(existingEdgeByVertices);
        }
        
        _selectedVertex = null;
    }

    public ObservableCollection<IMapComponent> Components
    {
        get =>
            _components;
    }

    public void CreateVertex(Point coord)
    {
        var vertex = new VertexMapComponent($"Vertex {++_counter}")
        {
            X = coord.X - VertexMapComponent.XRadius,
            Y = coord.Y - VertexMapComponent.YRadius
        };

        vertex.Clicked += OnVertexClicked;
        
        Components.Add(vertex);
    }

}