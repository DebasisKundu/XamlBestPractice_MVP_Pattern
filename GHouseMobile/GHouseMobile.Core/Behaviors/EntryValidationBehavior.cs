using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GHouseMobile.Core.Behaviors.Base;
using GHouseMobile.Core.Controls;
using Xamarin.Forms;

namespace GHouseMobile.Core.Behaviors
{
    public class EntryValidationBehavior : BaseEntryBehavior<GHEntry>
    {
        private string _placeHolder = string.Empty;
        private Color _placeHolderColor;

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EntryValidationBehavior)
                , false, BindingMode.OneWayToSource);
        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        protected override void OnAttachedTo(GHEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;

            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
            base.OnAttachedTo(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.NewTextValue))
            {
                ((GHEntry)sender).IsBorderErrorVisible = false;
                ((GHEntry)sender).Placeholder = _placeHolder;
                ((GHEntry)sender).PlaceholderColor = _placeHolderColor;
                IsValid = true;
            }
            else
            {
                ((GHEntry)sender).IsBorderErrorVisible = true;
                ((GHEntry)sender).Placeholder = ((GHEntry)sender).ErrorText;
                ((GHEntry)sender).PlaceholderColor = ((GHEntry)sender).BorderErrorColor;
                ((GHEntry)sender).Text = string.Empty;
                IsValid = false;
            }
        }

        protected override void OnDetachingFrom(GHEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            // bindable.PropertyChanged -= OnPropertyChanged;
        }

        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{

        //    if (propertyName == IsValidProperty
        //       .PropertyName && control != null)
        //    {
        //        if (control.IsBorderErrorVisible)
        //        {
        //            control.Placeholder = control.ErrorText;
        //            control.PlaceholderColor = control.BorderErrorColor;
        //            control.Text = string.Empty;
        //            IsValid = false;
        //        }

        //        else
        //        {
        //            control.Placeholder = _placeHolder;
        //            control.PlaceholderColor = _placeHolderColor;
        //            IsValid = true;
        //        }
        //        base.OnPropertyChanged(propertyName);
        //    }
        //    //void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        //    //{
        //    //    if (e.PropertyName == GHEntry.IsBorderErrorVisibleProperty
        //    //        .PropertyName && control != null)
        //    //    {
        //    //        if (control.IsBorderErrorVisible)
        //    //        {
        //    //            control.Placeholder = control.ErrorText;
        //    //            control.PlaceholderColor = control.BorderErrorColor;
        //    //            control.Text = string.Empty;
        //    //        }

        //    //        else
        //    //        {
        //    //            control.Placeholder = _placeHolder;
        //    //            control.PlaceholderColor = _placeHolderColor;
        //    //        }
        //    //    }
        //    //}      
        //}
    }
}