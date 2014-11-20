﻿using System;
using System.Windows;

namespace MassivePixel.Common
{
    /// <summary>
    /// Definition of alternative attached properties for various
    /// controls.
    /// </summary>
    public static class Alt
    {
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached(
            "IsVisible", typeof(bool?), typeof(Alt), new PropertyMetadata(default(bool?), IsVisibleChangedCallback));

        private static void IsVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;
            if (fe == null)
                return;

            fe.Visibility = ((bool?)e.NewValue) == true
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public static void SetIsVisible(DependencyObject element, bool? value)
        {
            element.SetValue(IsVisibleProperty, value);
        }

        public static bool? GetIsVisible(DependencyObject element)
        {
            return (bool?)element.GetValue(IsVisibleProperty);
        }
    }
}
