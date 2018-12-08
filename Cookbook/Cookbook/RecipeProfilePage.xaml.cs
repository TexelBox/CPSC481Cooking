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

// ~~~~~~~~~~~~~~~NOTE: make sure to actually update the recipe instance when something changes (or create new recipe and add to 

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for RecipeProfilePage.xaml
    /// </summary>
    public partial class RecipeProfilePage : Page
    {
        public Recipe _recipe;
        public int _currentStep = 0;
        public Page _completionPage;
      

        public RecipeProfilePage(Recipe recipe)
        {
            InitializeComponent();

            // init components...

            _recipe = recipe; 

            //This was done by me, BRYAN. I would've initialized heartButton user control so that it is filled if the recipe is fave or not. 
            //but I was running into problems there (i think because _recipe is null even though you make it equal to this _recipe...)
            //but it works if try it on this page. Had to add function in HeartButton.xaml and made isfilled public.

            // FAVOURITE...
            _heartButton._recipe = _recipe;
            if (_recipe._isFavourite)
            {
                _heartButton.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                _heartButton._isFilled = true;
            }
            else
            {
                _heartButton.HeartIconImage = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
                _heartButton._isFilled = false;
            }


            // DIFFICULTY...
            if (_recipe._difficulty == Recipe.Difficulties.EASY)
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["easyIconIcon"];
            }
            else if (_recipe._difficulty == Recipe.Difficulties.MEDIUM)
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["medIconIcon"];
            }
            else
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["hardIconIcon"];
            }

            // RATING...
            _ratingControl.initStartingRating(_recipe._rating);

            // DURATION...
            _durationText.Content = _recipe._duration.ToString() + "m";


            // NAME...
            _recipeNameTextBlock.Text = _recipe._name;

            // IMAGE...
            _recipeImageBrush.ImageSource = _recipe._image;

            // DESCRIPTION...
            _descTextBlock.Text = _recipe._description;


            // TRANSITION BUTTONS...
            _backButton.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");

            _startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "START");

            _startButton.transitionPageButton.Click += StartButton_Click;


            AddIngredientTabs();

            AddEquipmentList();
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_completionPage == null && _currentStep == 0 )
            {
                StepPage mainStep = new StepPage(_recipe);
                this.NavigationService.Navigate(mainStep);
            }
            else if(_completionPage == null && _currentStep > 0)
            {
                StepByStepPage step = StepPage.allSteps.ElementAt(_currentStep);
                this.NavigationService.Navigate(step);
            }else if(_completionPage != null)
            {
                this.NavigationService.Navigate(_completionPage);
            }
            
        }

        
        private void AddIngredientTabs()
        {

            TextBlock header = new TextBlock();
            header.Text = "INGREDIENT CHECKLIST:";
            header.TextAlignment = TextAlignment.Center;
            header.FontSize = 24;
            stackPanel.Children.Add(header);

            foreach(Ingredient ingredient in _recipe._ingredients)
            {
                stackPanel.Children.Add(new IngredientTab(ingredient));
            }

        }


        private void AddEquipmentList()
        {
            TextBlock header = new TextBlock();
            header.Text = "EQUIPMENT LIST:";
            header.TextAlignment = TextAlignment.Center;
            header.FontSize = 24;
            stackPanel.Children.Add(header);
        }




    }
}
