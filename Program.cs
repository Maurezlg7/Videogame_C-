using System;
using GameForce.Services;
class program {
    static void Main(string[] args) {
        Menu();
    }

    static void Options() {
        Console.Clear();
        Console.WriteLine("Elija una opcion.");
        Console.WriteLine("1. Ver juegos.");
        Console.WriteLine("2. Agregar juego.");
        Console.WriteLine("3. Eliminar juego.");
        Console.WriteLine("4. Modificar juego.");
        Console.WriteLine("5. Buscar juego.");
        Console.WriteLine("6. Salir.");
        Console.Write("Opcion: ");
    }

    static void Clean() {
        Console.Write("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void Menu() {
        Videogames videogames = new Videogames();
        Options();
        string op = Console.ReadLine() ?? "Error";
        while (op != "6" && op != "Error" && op != null)
        {
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        videogames.ShowVideogame();
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                    case "2":
                        Console.Clear();
                        videogames.AddVideogame();
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                    case "3":
                        Console.Clear();
                        videogames.DeleteVideogame();
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                    case "4":
                        Console.Clear();
                        videogames.ModifyVideogame();
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                    case "5":
                        Console.Clear();
                        videogames.SearchVideogame();
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Programa finalizado.");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion no valida intente de nuevo.");
                        Clean();
                        Options();
                        op = Console.ReadLine() ?? "Error";
                        break;
                }
        }
    }
}