using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameForce.Interfaces
{
    internal interface IVideogames
    {
        string Name { get; set; }
        string Genre { get; set; }
        string ReleaseDate { get; set; }
        string Platform { get; set; }
        string Developer { get; set; }

        string Description { get; set; }


        //Methods
        void AddVideogame();
        void DeleteVideogame(string name);
        void ModifyVideogame(string Name);
        void SearchVideogame(string name);
        void ShowVideogame(string name);
    }
}
