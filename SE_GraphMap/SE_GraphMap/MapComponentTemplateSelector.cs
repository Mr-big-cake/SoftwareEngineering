using System;
using System.Windows;
using System.Windows.Controls;
using GraphExample.Launcher.App.MapComponent;

namespace GraphExample.Launcher.App;

public sealed class MapComponentTemplateSelector : DataTemplateSelector
{
    
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
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
            return frameworkElement.FindResource("VertexTemplate") as DataTemplate;
        }
        else if (mapComponent is EdgeMapComponent)
        {
            return frameworkElement.FindResource("EdgeTemplate") as DataTemplate;
        }
        else
        {
            throw new ArgumentException($"\"{typeof(IMapComponent).FullName}\" implementation is unknown",
                nameof(item));
        }
    }
    
}