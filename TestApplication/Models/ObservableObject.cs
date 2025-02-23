﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestApplication.Models
{
    /// <summary>
    /// Description of ObservableObject.
    /// Inherit from this to be able to react to Property changes
    /// Add the Method OnPropertyChanged to the setter of Properties that should be observered in views
    /// </summary>
    /// 
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

