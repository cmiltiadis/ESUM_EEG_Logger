﻿// Copyright © 2009 James Galasyn 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace EmoEngineControlLibrary
{
    // The BoolToBrushConverter class is a value converter
    // that helps to bind a bool value to a brush property.
    [ValueConversion( typeof( bool ), typeof( Brush ) )]
    class BoolToBrushConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture )
        {
            Brush b = null;

            // Only apply the conversion if value is assigned and
            // is of type bool.
            if( value != null &&
                value.GetType() == typeof( bool ) )
            {
                // true is painted with a green brush, 
                // false with a red brush.
                b = (bool)value ? Brushes.Blue : Brushes.Gray ;
            }

            return b;
        }

        // Not used.
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture )
        {
            return null;
        }
    }
}
