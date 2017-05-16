using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Pokemon
    {
        private string[] names = {"Gen I", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander",
            "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod",
            "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot",
            "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu",
            "Sandshrew", "Sandslash", "Nidoran_f", "Nidorina", "Nidoqueen", "Nidoran_m", "Nidorino",
            "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff",
            "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth",
            "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape",
            "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra",
            "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel",
            "Tentacool" , "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke",
            "Slowbro", "Magnemite", "Magneton", "Farfetchd", "Doduo", "Dodrio", "Seel", "Dewgong",
            "Grimer" , "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee",
            "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone",
            "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon",
            "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu",
            "Starmie", "Mr_Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros",
            "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon",
            "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno",
            "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew"};
        //                           1|  2|  3|  4|  5|  6|  7|  8|  9|  0|
        private int[] types = { -1, 18, 18, 18,  1,  1, 19,  3,  3,  3, 12,     //0
                                    12, 20, 21, 21, 21, 22, 22, 22,  0,  0,     //1
                                    22, 22,  6,  6,  7,  7,  8,  8,  6,  6,     //2
                                    23,  6,  6, 23, 17, 17,  1,  1, 24, 24,     //3
                                    25, 25, 18, 18, 18, 26, 26, 21, 21,  8,     //4
                                     8,  0,  0,  3,  3,  2,  2,  1,  1,  3,     //5 
                                     3, 27,  9,  9,  9,  2,  2,  2, 18, 18,     //6
                                    18, 28, 28, 29, 29, 29,  1,  1, 30, 30,     //7
                                    31, 31, 22, 22, 22,  3, 32,  6,  6, 32,     //8
                                    32, 33, 33, 33, 29,  9,  9,  3,  3,  7,     //9
                                     7, 34, 34,  8,  8,  2,  2,  0,  6,  6,     //10
                                    29, 29,  0,  5,  0,  3,  3,  3,  3,  3,     //11
                                    30, 35, 20, 36,  7,  1, 12,  0,  3, 37,     //12
                                    32,  0,  0,  3,  7,  1,  0, 38, 38, 38,     //13
                                    38, 39,  0, 40, 41, 42, 13, 13, 43,  9,     //14
                                     9};    
        private string[] typeList = {"Normal",  "Fire",   "Fighting", "Water", "Flying", //0-4
                "Grass", "Poison",  "Electric", "Ground", "Psychic",  "Rock",   "Ice", "Bug", //5-12
                "Dragon", "Ghost",  "Dark", "Steel", "Fairy",                                //13-17

            "Grass_Poison",  "Fire_Flying",   "Bug_Flying",    "Bug_Poison",      "Normal_Flying", //18-22
            "Poison_Ground", "Normal_Fairy",  "Poison_Flying", "Bug_Grass",       "Water_Fighting", //23-27
            "Water_Poison",  "Rock_Ground",   "Water_Psychic", "Electric_Steel",  "Water_Ice", //28-32
            "Ghost_Poison",  "Grass_Psychic", "Psychic_Fairy", "Ice_Psychic",     "Water_Flying", //33-37
            "Rock_Water",    "Rock_Flying",   "Ice_Flying",    "Electric_Flying", "Fire_Flying", //38-42
            "Dragon_Flying"}; //43
        private int[] backgroundList = {1, 4, 6, 2, 1,
                                        1, 1, 1, 3, 5, 3, 7, 1,
                                        8, 5, 5, 3, 1,

                                        1, 6, 1, 1, 1,
                                        1, 1, 1, 1, 8,
                                        2, 3, 8, 6, 7,
                                        5, 1, 6, 7, 8,
                                        3, 3, 7, 4, 4, 8};
        private string[] backgroundNames = {"", "Background1", "Background2", "Background3", "Background4",
                                                "Background5", "Background6", "Background7", "Background8"};
        private string[] currentTypes, currentNames;
        private int id;
        Random rnd = new Random();

        public Pokemon(int id)
        {
            this.id = id;
        }
        
        public string GetCorrectName()
        {
            return names[id];
        }

        public string[] GetNames()
        {
            currentNames = new string[4];
            currentNames[0] = GetCorrectName();
            int number = rnd.Next(1, 152);
            string wrongAnswer;
            for (int i = 1; i < 4; i++)
            {
                while (true)
                {
                    number = rnd.Next(1, 152);
                    wrongAnswer = names[number];
                    if (!Contains(currentNames, wrongAnswer, i)) break;
                }
                currentNames[i] = wrongAnswer;
            }
            return currentNames;
        }

        public string GetCorrectType()
        {
            return typeList[types[id]];
        }       

        public string[] GetTypes()
        {
            currentTypes = new string[4];
            currentTypes[0] = GetCorrectType();
            int number = rnd.Next(1, 43);
            string wrongAnswer;
            for(int i = 1; i < 4; i++)
            {
                while(true)
                {
                    number = rnd.Next(1, 43);
                    wrongAnswer = typeList[number];
                    if (!Contains(currentTypes, wrongAnswer, i)) break;
                }                
                currentTypes[i] = wrongAnswer;
            }
            return currentTypes;
        }

        public bool Contains(string[] array, string value,int i)
        {
            for(int j = 0; j < i; j++)
            {
                if (array[j].Equals(value)) return true;
            }
            return false;
        }

        public string GetBackgroundName()
        {
            return backgroundNames[backgroundList[types[id]]];
        }

        public int GetBackgroundNumber()
        {
            return backgroundList[types[id]];
        }
    }
}
