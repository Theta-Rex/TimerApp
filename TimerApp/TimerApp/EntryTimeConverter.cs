// <copyright file="EntryTimeConverter.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Xamarin.Forms;

    /// <summary>
    /// EntryTimeConverter class.
    /// </summary>
    public class EntryTimeConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var entryTime = value as string;

            if (string.IsNullOrEmpty(entryTime))
            {
                return value;
            }
            else
            {
                int convertedEntryTime = int.Parse(entryTime);
                return convertedEntryTime;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
