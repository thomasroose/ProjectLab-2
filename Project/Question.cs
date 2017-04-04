using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Question
    {
        public abstract string GetQuestion();
        public abstract string GetCorrectAnswer();
        public abstract string GetRandomAnswer1();
        public abstract string GetRandomAnswer2();
        public abstract string GetRandomAnswer3();
        public abstract string GetRandomAnswer4();
        public abstract Pokemon GetPokemon();

        public void Shuffle<T>(IList<T> items)
        {
            Random random = new Random();

            for (int i = items.Count; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                                        // Swap.
                T tmp = items[j];
                items[j] = items[i - 1];
                items[i - 1] = tmp;
            }
        }
    }
}
