﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;




namespace Cookbook
{
    public class GlobalData
    {
        private static GlobalData instance = new GlobalData();

        public static GlobalData Instance
        {
            get { return instance; }
        }


        //public Recipe recipe1 = new Recipe(); // something like this, then each component like a HeartButton could have a field set to 1 recipe.
        //public Recipe recipe2 = new Recipe();

        //public Page page1 = new Page();
        //public SearchPage1 search;


        // RECIPES:
        // 1.) Shanghai Noodles:
        #region SHANGAI NOODLES
        // ~~~~~~init the ingredients and fill ingredients list here
        public Recipe _shanghaiNoodlesRecipe = new Recipe()
        {
            _isFavourite = true,
            _name = "Shanghai Noodles",
            _image = (BitmapImage)Application.Current.Resources["shanghaiNoodlesIcon"],
            _difficulty = Recipe.Difficulties.HARD,
            _rating = 0,
            _duration = 15,
            _description = "\"Easy, quick and incredibly delicious, these Chinese fried noodles are street food at its best!\"",
            _servings = 4,
            _ingredientCount = 14,
            _category = Recipe.Categories.CHINESE,

            _ingredients = new List<Ingredient>
            {
                new Ingredient((double)1/3, "1/3", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "dark soy sauce"),
                new Ingredient(0.25, "1/4", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "oyster sauce"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sugar"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "fresh ginger"),
                new Ingredient(1.0, "1", Ingredient.UnitType.MASS, Ingredient.LBS, "pork tenderloin"),
                new Ingredient(1.0, "1", Ingredient.UnitType.MASS, Ingredient.LBS, "Chinese egg noodles"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cooking oil"),
                new Ingredient(2.0, "2", Ingredient.UnitType.SPECIAL, "cloves", "garlic"),
                new Ingredient(6.0, "6", Ingredient.UnitType.NONE, "NO UNIT", "green onions"),
                new Ingredient(0.5, "1/2", Ingredient.UnitType.SPECIAL, "head", "Napa cabbage"),
                new Ingredient(1.0, "1", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "chicken stock"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cornstarch"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sesame oil"),
                new Ingredient(0, "", Ingredient.UnitType.NONE, "NO UNIT", "ground white pepper"),
            },
            //public Ingredient(double measurement, string measurementStr, UnitType unitType, string unitStr, string mainText)

            _equipment = new List<string> { "1 wok or heavy skillet", "stirring utensils" },
            _steps = new List<string> { @"To make the marinade, combine the soy sauce, oyster sauce, sugar and ginger and stir until the sugar is dissolved."
                                        +" Place the pork in the marinade and let sit for 10 minutes.",
                                        @"Heat the oil in a wok or heavy skillet on high heat and fry the pork for one minute or until done (set the reserved aside)."
                                        +" Remove the pork and set aside.",
                                        @"Next fry the white parts of the cabbage and green onions along with the garlic for 30 seconds or until tender.",
                                        @"Return the pork to the pan along with the reserved marinade, the sesame oil, chicken/cornstarch mixture and the green parts of the cabbage and green onions." +
                                        " Cook for 30 seconds."+
                                        " Add the noodles and stir until combined."+
                                        " Add white pepper to taste."+
                                        " Serve immediately."},
            _timerValuesForSteps = new List<int> { 600, 60, 30, 30}
        };
        #endregion

        // 2.) Burger:
        #region BURGER
        // ~~~~~~init the ingredients and fill ingredients list here
        public Recipe _burger = new Recipe()
        {
            _isFavourite = true,
            _name = "Steamed Hams",
            _image = (BitmapImage)Application.Current.Resources["burgerIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 2,
            _duration = 20,
            _description = "\"Blah blah blah!\"",
            _servings = 1,
            _ingredientCount = 3,
            _category = Recipe.Categories.BEEF,

            _ingredients = new List<Ingredient>
            {
                new Ingredient(2.0, "2", Ingredient.UnitType.NONE, "NO UNIT", "hamburger buns"),
                new Ingredient(2.0, "2", Ingredient.UnitType.NONE, "NO UNIT", "hamburger patties"),
                new Ingredient(5.0, "5", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "ketchup"),
            },

            _equipment = new List<string> { "Frying Pan", "Grill", "Oven" },
            _steps = new List<string> { @"Grill patty.",
                                        @"Fry patty.", @"Steam patty for 10 minutes.", @"Delicately place on buns.", @"Pour your entire 5 cups of ketchup all over for the finish!" }
        };
        #endregion 

        // 3.) Holy Mackeral
        #region HOLY MACKERAL
        public Recipe _holymackeral = new Recipe()
        {
            _isFavourite = true,
            _name = "Holy Mackeral",
            _image = (BitmapImage)Application.Current.Resources["holymackeralIcon"],
            _difficulty = Recipe.Difficulties.MEDIUM,
            _rating = 4,
            _duration = 50,
            _description = "\"A divine fish... a divine dish!\"",
            _servings = 4,
            _ingredientCount = 4,
            _category = Recipe.Categories.FISH,
            //_ingredients = new List<Ingredient> {mackeral, sage, garlic, cookingoil},

            _ingredients = new List<Ingredient>
            {
                new Ingredient(2.0, "2", Ingredient.UnitType.SPECIAL, "filets", "mackeral"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sage"),
                new Ingredient(2.0, "2", Ingredient.UnitType.SPECIAL, "cloves", "garlic"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cooking oil"),
            },



            _equipment = new List<string> { "Oven", "4\" Chef knife","Baking tray", "Blender" },
            _steps = new List<string> { @"Gut the mackeral, if not already gutted.", @"Chop cloves of garlic", @"Heat cooking oil and briefly"
                                        + " fry with the garlic, a sprig of sage and the fish.", @"Place fish on baking tray and cook at 350°F.",
                                        @"Once done, put the whole thing in the blender."}
        };
        #endregion

        // 4.) Chow mein
        #region

        public Recipe _chowmein = new Recipe()
        {
            _isFavourite = true,
            _name = "Chicken Chow Mein",
            _image = (BitmapImage)Application.Current.Resources["chowmeinIcon"],
            _difficulty = Recipe.Difficulties.MEDIUM,
            _rating = 3,
            _duration = 25,
            _description = "\"A traditional Chinese dish.\"",
            _servings = 4,
            _ingredientCount = 6,
            _category = Recipe.Categories.CHINESE,

            _ingredients = new List<Ingredient>
            {
                new Ingredient(170, "170", Ingredient.UnitType.MASS, Ingredient.G, "chow mein noodles"),
                new Ingredient(454, "454", Ingredient.UnitType.MASS, Ingredient.G, "chicken thighs"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "broth"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sesame oil"),
                new Ingredient((double)1/3, "1/3", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "dark soy sauce"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cornstarch"),
            },

            _equipment = new List<string> { "Whisk", "Non-Stick-Skillet" },
            _steps = new List<string> { @"In a small bowl, whisk together dark soy sauce, cornstarch and broth. Set aside.", @"Cook chow mein noodles according to package instructions.",
                                        @"In a large non-stick skillet, heat oil over medium high heat. Add chicken and cook until chicken is browned. Stir in the carrots and cook for 2 minutes.",
                                        @"Pour in broth mixture and bring to a boil. Cook until sauce is slightly thickened. Stir in seasame oil.",
                                        @"Spread noodles onto a platter and pour chicken mixture over top. Serve immediately."}
        };


        #endregion

        // 5.) Salad
        #region
        public Recipe _salad = new Recipe()
        {
            _isFavourite = true,
            _name = "Head of Lettuce",
            _image = (BitmapImage)Application.Current.Resources["saladIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 1,
            _duration = 5,
            _description = "\"Literally a head of lettuce\"",
            _servings = 2,
            _ingredientCount = 1,
            _category = Recipe.Categories.VEGETARIAN,
            //_ingredients = new List<Ingredient> { lettuce },

            _ingredients = new List<Ingredient>
            {
                new Ingredient(1, "1", Ingredient.UnitType.SPECIAL, "head", "lettuce"),
            },

            _equipment = new List<string> { },
            _steps = new List<string> { @"Wash head of lettuce.", @"Enjoy." }
        };
        #endregion

        public List<Recipe> recentList = new List<Recipe>(); //List of recently viewed recipe
        public List<Recipe> recipeList = new List<Recipe>(); //List of recipes
        public List<Recipe> modRecipeList = new List<Recipe>(); //List of MODIFIED recipes
        public Dictionary<String, RecipeProfilePage> recipePageList = new Dictionary<string, RecipeProfilePage>(); //Used to access profile pages
        public List<RecipeProfilePage> modrecipePageList = new List<RecipeProfilePage>(); //Used to access modified profile pages

        public  Dictionary<String, String> lookUpTerms = new Dictionary<String, String>(); //map of dictionary words

        public RecipeCompletionPage completionPage;

        //Main page
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();

        public bool signedIn = false;

        //Current recipe
        public Recipe currentRecipe;

        public List<string> accountList = new List<string>();

        //Store previous page...using this for back button for now. Unless better solution comes up
        public Page prevPage;

        private GlobalData()
        {
            recipeList.Add(_shanghaiNoodlesRecipe);
            recipeList.Add(_burger);
            recipeList.Add(_holymackeral);
            recipeList.Add(_chowmein);
            recipeList.Add(_salad);
            //Adds a profile page for each recipe
            for (int i = 0; i < recipeList.Count; i++)
            {
                RecipeProfilePage recipeProfilePage = new RecipeProfilePage(recipeList[i]);
                recipePageList.Add(recipeProfilePage._recipe._name, recipeProfilePage);
            }

            lookUpTerms.Add("marinade", "A marinade is a sauce, typically made of oil, vinegar, spices, and herbs, in which meat, fish, or other food is soaked before cooking in order to flavor or soften it.");
            lookUpTerms.Add("Chop", "cut into small pieces with repeated sharp blows a knife.");

            accountList.Add("foodluver123");
            accountList.Add("ilovefood456@food.com");
            accountList.Add("123456789");
            accountList.Add("1");
            accountList.Add("2");

            accountList.Add("foodisLIFE");
            accountList.Add("burgers@food.com");
            accountList.Add("123456789123456789123456789");
            accountList.Add("2");
            accountList.Add("2");
        }

    }
}
