using EventSystem.EventArgs;
using EventSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem
{
    internal class ExamplePropertyChanger : INotifyPropertyChanged<string>, INotifyPropertyChanging<string>
    {
        private string stringProperty = "";

        public string StringProperty
        {
            get => stringProperty;
            set
            {
                PropertyChangingEventArgs<string> propertyChangingEventArgs = new(value);
                PropertyChangingCallback.Invoke(this, propertyChangingEventArgs);

                if(propertyChangingEventArgs.ShouldChange)
                {
                    stringProperty = value;
                    PropertyChangedEventArgs<string> propertyChangedEventArgs = new(value);
                    PropertyChangedCallback.Invoke(this, propertyChangedEventArgs);
                }
            }
        }

        Callback<PropertyChangingEventArgs<string>> PropertyChangingCallback
        {
            get;
        } = new();


        Callback<PropertyChangedEventArgs<string>> PropertyChangedCallback
        {
            get;
        } = new();


        Callback<PropertyChangingEventArgs<string>> INotifyElementChange<string, PropertyChangingEventArgs<string>>.Callback => PropertyChangingCallback;


        Callback<PropertyChangedEventArgs<string>> INotifyElementChange<string, PropertyChangedEventArgs<string>>.Callback => PropertyChangedCallback;



        
        void INotifyElementChange<string, PropertyChangingEventArgs<string>>.AddHandler(Action<object, PropertyChangingEventArgs<string>> action)
        {
            PropertyChangingCallback.Add(action);
        }

        void INotifyElementChange<string, PropertyChangedEventArgs<string>>.AddHandler(Action<object, PropertyChangedEventArgs<string>> action)
        {
            PropertyChangedCallback.Add(action);
        }

        bool INotifyElementChange<string, PropertyChangingEventArgs<string>>.RemoveHandler(Action<object, PropertyChangingEventArgs<string>> action)
        {
            return PropertyChangingCallback.Remove(action);
        }

        bool INotifyElementChange<string, PropertyChangedEventArgs<string>>.RemoveHandler(Action<object, PropertyChangedEventArgs<string>> action)
        {
            return PropertyChangedCallback.Remove(action);
        }



        public override string ToString()
        {
            return StringProperty;
        }

    }
}
