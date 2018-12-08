﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for StepPage.xaml
    /// </summary>

    public partial class StepPage : Page
    {
        public static List<StepByStepPage> allSteps = new List<StepByStepPage>();
        public StepPage(Recipe recipe)
        {
            InitializeComponent();

            for(int i = 0; i < recipe._steps.Count; i++)
            {
                StepByStepPage step = new StepByStepPage(recipe, i);
                allSteps.Add(step);
            }
            stepsMain.NavigationService.Navigate(allSteps.ElementAt(0)); // start cookbook at favourite page all the time
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
