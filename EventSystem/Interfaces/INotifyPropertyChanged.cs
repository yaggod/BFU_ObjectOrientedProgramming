﻿using EventSystem.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.Interfaces
{
    internal interface INotifyPropertyChanged<T> : INotifyElementChange<T, PropertyChangedEventArgs<T>>
    {
    }
}
