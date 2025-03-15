using System;
using System.Collections.Generic;

class Eng_French
{
    private Dictionary<string, List<string>> dictionary = new();
    public void Added(string english, List<string> french)
    {
        if (!dictionary.ContainsKey(english))
        {
            dictionary[english] = new List<string>(french);
            Console.WriteLine("Word was added");
        }
        else
        {
            Console.WriteLine("Word already has");
        }
    }

    public void Delete_W(string english)
    {
        if (dictionary.Remove(english))
            Console.WriteLine("Word was deleted");
        else
            Console.WriteLine("I cant` found this word");
    }

    public void Delete_T(string english, string french)
    {
        if (dictionary.ContainsKey(english))
        {
            if (dictionary[english].Remove(french))
                Console.WriteLine("Translated deleted");
            else
                Console.WriteLine("Translated not found");
        }
        else{
            Console.WriteLine("I can`t found word");
        }
           
    }


    public void Update_W(string old, string neww)
    {
        if (dictionary.ContainsKey(old))
        {
            dictionary[neww] = dictionary[old];
            dictionary.Remove(old);
            Console.WriteLine("Word was updated");
        }
        else
        {
            Console.WriteLine("I can`t found old word");
        }
    }


    public void Update_T(string english, string old, string neww)
    {
        if (dictionary.ContainsKey(english))
        {
            if (dictionary[english].Remove(old))
            {
                dictionary[english].Add(neww);
                Console.WriteLine("Translated was updated");
            }
            else
            {
                Console.WriteLine("I can`t found old translated");
            }
        }
        else
        {
            Console.WriteLine("I can`t found word");
        }
    }


    public void Search(string english)
    {
        if(dictionary.TryGetValue(english, out List<string> translations))
        {
            Console.WriteLine($"Translated for {english}: {string.Join(", ", translations)}");
        }
        else
        {
            Console.WriteLine("I can`t found");
        }

    }

}

class Program
{
    static void Main()
    {
        Eng_French dictionary = new Eng_French();

        
        dictionary.Added("apple", new List<string> { "pomme" });
        dictionary.Delete_W("apple");
        dictionary.Search("apple");

        dictionary.Added("hello", new List<string> { "bonjour", "salut" });
        dictionary.Search("hello");
        dictionary.Update_T("hello", "salut", "coucou");
        dictionary.Search("hello");
        dictionary.Delete_T("hello", "bonjour");
        dictionary.Search("hello");


    }
}