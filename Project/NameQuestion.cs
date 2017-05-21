using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class NameQuestion : Question
    {
        private string[] answers = new string[4];
        private Pokemon pokemon;
        private string correctAnswer;
        public NameQuestion(int pokemonID)
        {
            
            pokemon = new Pokemon(pokemonID);   //Create new Pokemon
            answers = pokemon.GetNames();       //fill up array with answers
            correctAnswer = answers[0];         //store correct answer
            Shuffle(answers);                   //shuffle array

        }

        public override string GetQuestion()
        { return "Who is that Pokémon?"; }
        public override string GetCorrectAnswer()
        { return correctAnswer; }
        public override string GetRandomAnswer1()
        { return answers[0]; }
        public override string GetRandomAnswer2()
        { return answers[1]; }
        public override string GetRandomAnswer3()
        { return answers[2]; }
        public override string GetRandomAnswer4()
        { return answers[3]; }
        public override Pokemon GetPokemon()
        { return pokemon; }
    }
}
