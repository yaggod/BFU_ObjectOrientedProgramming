﻿using EventSystem.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.Interfaces
{
    internal interface INotifyPropertyChanging<T> : INotifyElementChange<T, PropertyChangingEventArgs<T>>
    {
    }
}
