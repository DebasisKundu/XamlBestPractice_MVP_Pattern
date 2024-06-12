using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GHouseMobile.Core.Abstraction
{
    public class BaseObservable : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T privateProperty, T value,
            [CallerMemberName] string propertyName = "",
            Action? onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(privateProperty, value))
                return false;

            privateProperty = value;
            onChanged?.Invoke();
            OnpropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
