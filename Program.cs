using System;
using System.Collections.Generic;

class Manager
{
    private Dictionary<string, string> Paswords = new();
    public void Added(string login, string password)
    {
        if (!Paswords.ContainsKey(login))
        {
            Paswords[login] = password;
            Console.WriteLine("Yhe employee was added");
        }
        else
        {
            Console.WriteLine("This login already has");
        }
    }

    public void Deleted(string login)
    {
        if (Paswords.Remove(login))
            Console.WriteLine("The employee was deleted");
        else
            Console.WriteLine("I can`t found login");
    }

    public void Update(string login, string newPas)
    {
        if(Paswords.ContainsKey(login))
        {
            Paswords[login] = newPas;
            Console.WriteLine("Password was updated");
        }
        else
        {
            Console.WriteLine("I can`t found login");
        }
    }

    public void Found(string login)
    {
        if (Paswords.TryGetValue(login, out string pasword))
            Console.WriteLine($"Password for {login} - {pasword}");
        else
            Console.WriteLine("I can`t found");
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new Manager();

        manager.Added("darlin", "12345");
        manager.Added("adam", "lol67");
        manager.Added("marena", "cool123");

        manager.Found("adam");
        manager.Update("marena", "my_new");
        manager.Deleted("darlin");
    }
}