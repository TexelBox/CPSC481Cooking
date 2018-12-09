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

using System.Diagnostics;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for RecipeCompletionPage.xaml
    /// </summary>
    /// 

    public partial class RecipeCompletionPage : Page
    {

        public Recipe currentRecipe;

        public RecipeCompletionPage(Recipe recipe)
        {
            InitializeComponent();

            currentRecipe = recipe;

            favHeart._recipe = currentRecipe;
            if (currentRecipe._isFavourite)
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                favHeart._isFilled = true;
            }
            else
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
                favHeart._isFilled = false;
            }

            rating._completionPage = this;
            rating.initStartingRating(currentRecipe._rating);

            _recipeImageBrush.ImageSource = currentRecipe._image;
            _recipeName.Text = currentRecipe._name;

            _back.initAppearance(TransitionPageButton.Orientation.BACK, "BACK TO STEPS");
            _next.initAppearance(TransitionPageButton.Orientation.FORWARD, "GO TO RECIPE PAGE");

            _back.transitionPageButton.Click += Back_Click;
            _next.transitionPageButton.Click += Next_Click;

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<String, RecipeProfilePage> recipes = GlobalData.Instance.recipePageList;
            RecipeProfilePage recipeProfile = recipes[currentRecipe._name];
            recipeProfile._completionPage = this;
            recipeProfile._currentStep = 0;
            recipeProfile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "TO RECIPE COMPLETION PAGE");
            this.NavigationService.Navigate(recipeProfile);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<String, RecipeProfilePage> recipes = GlobalData.Instance.recipePageList;
            RecipeProfilePage recipeProfile = recipes[currentRecipe._name];
            recipeProfile._completionPage = null;
            recipeProfile._currentStep = currentRecipe._steps.Count - 1;
            recipeProfile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "CONTINUE");

            StepByStepPage step = recipeProfile.mainStep.allSteps.ElementAt(currentRecipe._steps.Count - 1);

            this.NavigationService.Navigate(step);
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.signInBox.Visibility = System.Windows.Visibility.Hidden;
            completionMain.IsEnabled = true;
        }

        private bool modified;
        public bool Modified
        {
            get { return modified; }
            set
            {
                modified = value;
            }
        }


        //Number in list
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                //this.NumberText.Content = this.number + ".";
            }
        }

        private void onEdit(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < GlobalData.Instance.recipeList.Count; i++)
            {
                if (GlobalData.Instance.recipeList[i]._name == currentRecipe._name)
                {
                    Mod mod = new Mod(currentRecipe, i);
                    ((MainWindow)App.Current.MainWindow).Main.Content = mod;
                }
            }
            
            

        }

        private void shareButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en-gb.facebook.com/login/");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // update data that could have changed...

            // FAVOURITE...
            if (currentRecipe._isFavourite)
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                favHeart._isFilled = true;
            }
            else
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
                favHeart._isFilled = false;
            }

            // RATING...
            rating.initStartingRating(currentRecipe._rating);
        }
    }

}
