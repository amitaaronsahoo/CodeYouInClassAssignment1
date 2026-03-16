using System; //need this for Console.WriteLine
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic; //ai showed me this for making a list of objects

//program needs to have a class for the drinks, with getters. Need to override the default display of the class
//program needs to have a class for the drink menu, with a way to build the spot for the list in ram, and a constructor that then makes the actual list and adds drinks to the list
//program needs a method to just display the drink menu
public class Drink 
{
    public string Name {get;} //{get;} is like a getter in java
    public string Size {get;}
    public double Price {get;}
    public bool HasIce {get;}


//need constructor for drink class
//AI told me that in c#, instead of using this.Name = name
//I can just use Name = name;
public Drink(string name, string size, double price, bool hasIce)
{
    Name = name;
    Size = size;
    Price = price;
    HasIce = hasIce;
}

    //now have to override what the default toString displays
public override string ToString()
{
    //declare a variable we only calculate when calling string method
    //boolean HasIce = Condition ? WhatToDoIfTrue : WhatToDoIfFalse;
    //
    //could also write it as
    //
    //string iceStatus;
    // if (HasIce == true) 
    // {
    //     iceStatus = "with ice";
    // } 
    // else 
    // {
    //     iceStatus = "no ice";
    // }
    string iceStatus = HasIce ? "with ice" : "no ice";
    
    
    
    //we return a templated string using $ at the front to show the name, the (size) the price
    //Price:C is just formating the double Price to a format that is currency
    //idk AI taught me this
    //Price:C apparently is format the number to a currency
    return $"{Name} ({Size}) - {Price:C} [{iceStatus}]";
}
}

//now have to build a class for the drink menu
public class DrinkMenu
{
    //need a private list variable that no one else can change later on
    private List<Drink> availableDrinks; //planning the list
    //think of this as allocating the data to be written
    //not the actual data itself
    //this is a pointer to what will be a private list of drink objects called avaliableDrinks
    //can think of this as like a parking space
        public DrinkMenu()
        //this is the constructor for the drink menu object
        //in the main function it would look like new DrinkMenu()
        {
            //this is were we actually construct the physical list and place it in our reserved avaliableDrinks parking space 
            availableDrinks = new List<Drink>(); //building the list
            
            //this is were we actually add the data to the pointer we just made
            //now use .Add to add new Drink
            //java uses .add
            availableDrinks.Add(new Drink("Cold Brew Coffee", "Large", 4.50, true));
            availableDrinks.Add(new Drink("Matcha Latte", "Medium", 5.00, false));
            availableDrinks.Add(new Drink("Mango Smoothie", "Small", 6.00, true));    
        }

//now need a method that just displays the menu without returning a value
public void DisplayMenu()
{
    Console.WriteLine("=== Cafe Menu ===");
    //this is the top of the text menu
    //now need this for the for each loop
    int itemNumber = 1;
        //for each loop will go through the avaliableDrinks list and print each drink one by one
        foreach (Drink currentDrink in availableDrinks)
            //this labels each drink value we set above as currentDrink
            //this then goes through all the drink values in the drink list called avaliableDrinks
            {
            Console.WriteLine($"{itemNumber}. {currentDrink}");
            //now printing the itemNumber followed by the drink
            itemNumber++; // Add 1 to the counter for the next drink
            }
    Console.WriteLine("=================");
}
}
class Program
    {
        static void Main(String[] args)
        {
            //start by making a new drink menu object
            DrinkMenu NewCafeMenu = new DrinkMenu();
            //display message to user
            Console.WriteLine("Welcome to the cafe!\n");
            //run the method that displays the drink menu
            NewCafeMenu.DisplayMenu();
            //prompt for input, using write so that user can write on the same line
            Console.Write("\nPlease enter the number of the drink you want: ");
            //set what the user types next as a string value
            string userChoice = Console.ReadLine();
            //display the user choice
            Console.WriteLine($"\nYou selected option {userChoice}. Coming right up!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }