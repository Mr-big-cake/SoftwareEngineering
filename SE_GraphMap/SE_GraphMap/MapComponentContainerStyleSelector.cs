using System;
using System.Windows;
using System.Windows.Controls;
using GraphExample.Launcher.App.MapComponent;

namespace GraphExample.Launcher.App;

public class MapComponentContainerStyleSelector : StyleSelector
{
    
    public override Style SelectStyle(object item, DependencyObject container)
    {
        if (!(container is FrameworkElement frameworkElement))
        {
            throw new ArgumentException($"{nameof(container)} should be of type \"{typeof(FrameworkElement).FullName}\"",
                nameof(container));
        }
        
        if (!(item is IMapComponent mapComponent))
        {
            throw new ArgumentException($"{nameof(item)} should implement \"{typeof(IMapComponent).FullName}\"",
                nameof(item));
        }

        if (mapComponent is VertexMapComponent)
        {
            return frameworkElement.FindResource("VertexContainerStyle") as Style;
        }
        else if (mapComponent is EdgeMapComponent)
        {
            return frameworkElement.FindResource("EdgeContainerStyle") as Style;
        }
        else
        {
            throw new ArgumentException($"\"{typeof(IMapComponent).FullName}\" implementation is unknown",
                nameof(item));
        }
    }
    
}