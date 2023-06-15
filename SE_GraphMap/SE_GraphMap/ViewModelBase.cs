using System.ComponentModel;
using System.Linq;

namespace GraphExample.Launcher.App;

public class ViewModelBase : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void RaisePropertiesChanged(params string[] propertiesNames)
    {
        foreach (var propertyName in propertiesNames ?? Enumerable.Empty<string>())
        {
            RaisePropertyChanged(propertyName);
        }
    }

}