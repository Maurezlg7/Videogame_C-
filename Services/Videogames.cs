using GameForce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameForce.Services
{
    internal class Videogames : IVideogames
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string Platform { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        
        public string json = "C:\\Users\\gomez\\source\\repos\\GameForce\\GameForce\\Data\\videogames.json";

        public Videogames() {
            this.Name = Name;
            this.Genre = Genre;
            this.ReleaseDate = ReleaseDate;
            this.Platform = Platform;
            this.Developer = Developer;
            this.Description = Description;
        }
        public void AddVideogame() {
            int ID = 0;
            if (!File.Exists(json) || new FileInfo(json).Length == 0)
            {
                File.WriteAllText(json, "[]");
            }
            Console.WriteLine("Agregar juego.");
            Console.Write("Nombre: ");
            Name = Console.ReadLine() ?? "Error";
            Console.Write("Genero: ");
            Genre = Console.ReadLine() ?? "Error";
            Console.Write("Fecha de lanzamiento: ");
            ReleaseDate = Console.ReadLine() ?? "Error";
            Console.Write("Plataforma: ");
            Platform = Console.ReadLine() ?? "Error";
            Console.Write("Desarrollador: ");
            Developer = Console.ReadLine() ?? "Error";
            Console.Write("Descripcion: ");
            Description = Console.ReadLine() ?? "Error";
            string jsonString = File.ReadAllText(json);
            var videogames = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString) ?? new List<Dictionary<string, object>>();
            if (videogames.Count > 0 && videogames.Last().ContainsKey("ID"))
            {
                ID = int.Parse(videogames.Last()["ID"].ToString()) + 1;
            }
            else
            {
                ID = 1;
            }
            Dictionary<string, object> videogame = new Dictionary<string, object>() {
                { "ID", ID},
                { "Name", Name},
                { "Genre", Genre},
                { "ReleaseDate", ReleaseDate},
                { "Platform", Platform},
                { "Developer", Developer},
                { "Description", Description}
            };
            videogames.Add(videogame);
            string jsonString2 = JsonSerializer.Serialize(videogames, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(json, jsonString2);
            Console.WriteLine("Juego agregado correctamente.");
        }

        public void DeleteVideogame()
        {
            string file = File.ReadAllText(json);
            var ListGame = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(file);
            if (ListGame.Count > 0 && ListGame != null)
            {
                Console.Write("Ingrese el nombre del juego a eliminar: ");
                string name = Console.ReadLine() ?? "Error";
                for (int i = 0; i < ListGame.Count; i++)
                {
                    if (ListGame[i]["Name"].ToString() == name)
                    {
                        ListGame.RemoveAt(i);
                        break;
                    }
                }
                string jsonString2 = JsonSerializer.Serialize(ListGame, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(json, jsonString2);
                Console.WriteLine("Eliminado con exito.");
            }
            else {
                Console.WriteLine("Todavia no hay juegos para eliminar.");
            }
        }

        public void ModifyVideogame()
        {
            Console.WriteLine("¿Que juego quieres modificar?");
            ShowVideogame();
            Console.Write("Ingrese el nombre del juego a modificar: ");
            string name = Console.ReadLine() ?? "Error";
            string file = File.ReadAllText(json);
            var ListGame = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(file);
            if (ListGame.Count > 0 && ListGame != null)
            {
                for (int i = 0; i < ListGame.Count; i++)
                {
                    if (ListGame[i]["Name"].ToString() == name)
                    {
                        Console.Write("Nuevo nombre: ");
                        ListGame[i]["Name"] = Console.ReadLine() ?? "Error";
                        Console.Write("Nuevo genero: ");
                        ListGame[i]["Genre"] = Console.ReadLine() ?? "Error";
                        Console.Write("Nueva fecha de lanzamiento: ");
                        ListGame[i]["ReleaseDate"] = Console.ReadLine() ?? "Error";
                        Console.Write("Nueva plataforma: ");
                        ListGame[i]["Platform"] = Console.ReadLine() ?? "Error";
                        Console.Write("Nuevo desarrollador: ");
                        ListGame[i]["Developer"] = Console.ReadLine() ?? "Error";
                        Console.Write("Nueva descripcion: ");
                        ListGame[i]["Description"] = Console.ReadLine() ?? "Error";
                        break;
                    }
                }
                string jsonString2 = JsonSerializer.Serialize(ListGame, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(json, jsonString2);
                Console.WriteLine("Juego modificado correctamente.");
            }
            else {
                Console.WriteLine("No hay juegos para modificar.");
            }
        }

        public void SearchVideogame()
        {
            string file = File.ReadAllText(json);
            var ListGame = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(file);
            if (ListGame.Count > 0 && ListGame != null)
            {
                Console.Write("Ingrese el juego a buscar: ");
                string name = Console.ReadLine() ?? "Error";
                for (int i = 0; i < ListGame.Count; i++)
                {
                    if (ListGame[i]["Name"].ToString() == name)
                    {
                        Console.WriteLine($"Nombre: {ListGame[i]["Name"]}\n" +
                            $"Genero: {ListGame[i]["Genre"]}\n" +
                            $"Fecha de Lanzamiento: {ListGame[i]["ReleaseDate"]}\n" +
                            $"Plataforma: {ListGame[i]["Platform"]}\n" +
                            $"Desarrollador: {ListGame[i]["Developer"]}\n" +
                            $"Descripcion: {ListGame[i]["Description"]}");
                        break;
                    }
                }
            }
            else {
                Console.WriteLine("No hay juegos cargados aun.");
            }
        }

        public void ShowVideogame()
        {
            string file = File.ReadAllText(json);
            var ListGame = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(file);
            if (ListGame.Count > 0 && ListGame != null)
            {
                for (int i = 0; i < ListGame.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ListGame[i]["Name"]}");
                }
            }
            else { 
                Console.WriteLine("No hay juegos en la lista.");
            }
        }
    }
}
