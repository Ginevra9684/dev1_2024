﻿using Microsoft.EntityFrameworkCore.Sqlite;

class Program 
{
    public static void Main(string[] args)
    {
        Console.Clear();
        var db = new Database();    
        var view = new View(db);    
        var controller = new Controller(db, view);
        controller.MainMenu();  
    }
}
