using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameForce.Interfaces;

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
        public bool ReadJson(){
            if (File.Exists(json)) {
                return true;
            }
            return false;
        }
        public void AddVideogame() {
            if (ReadJson() == false) {
                Console.WriteLine("No existe el archivo JSON.");
                return;
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
        }
    }
}
