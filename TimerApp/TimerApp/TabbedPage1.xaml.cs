// <copyright file="TabbedPage1.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// TabbedPage1 class inheriting from TabbedPage.
    /// </summary>
    public partial class TabbedPage1 : TabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedPage1"/> class.
        /// </summary>
        public TabbedPage1()
        {
            this.InitializeComponent();
        }
    }
}