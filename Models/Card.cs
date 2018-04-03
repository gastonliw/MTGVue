using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.webapi.Models
{
    public class Card
    {       
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public int CMC { get; set; }
        public string[] Colors { get; set; }
        public string[] ColorIdentity { get; set; }
        public string Type { get; set; }
        public string[] Types { get; set; }
        public string[] Subtypes { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string Text { get; set; }
        public string Artist { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Layout { get; set; }
        public int Multiverseid { get; set; }
        public string ImageUrl { get; set; }
        public string[] Printings { get; set; }
        public string OriginalText { get; set; }
        public string OriginalType { get; set; }
        public Legality[] Legalities { get; set; }
        public string Id { get; set; }
        

        public class Legality
        {
            public string format { get; set; }
            public string legality { get; set; }
        }

    }
}
