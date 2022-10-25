using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAplication.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            if(EqualityComparer<T>.Default.Equals(field, newValue)) return false;

            field = newValue;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            NotifyPropertyChanged(propertyName);

            return true;
        }

        public bool SetPropery<T, TModel>(T oldValue, T newValue, TModel model, Action<TModel, T> action, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(propertyName);

            if (EqualityComparer<T>.Default.Equals(oldValue, newValue)) return false;

            action.Invoke(model, newValue);

            NotifyPropertyChanged(propertyName);

            return true;
        }

        public void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
