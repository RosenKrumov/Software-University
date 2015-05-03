namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AnimalSystemTest
    {
        static void Main()
        {
            Frog froggy = new Frog("Frodo", 15, Gender.Male);
            Frog frogo = new Frog("Frogo", 120, Gender.Female);
            Dog doggy = new Dog("Dodo", 2, Gender.Male);
            Dog doggo = new Dog("Dogo", 1, Gender.Female);
            Cat misha = new Kitten("Misha", 1, Gender.Female);
            Cat kotka = new Tomcat("Kotka", 10, Gender.Male);

            Frog[] frogs = new Frog[] { froggy, frogo };
            Cat[] cats = new Cat[] { misha, kotka };
            Dog[] dogs = new Dog[] { doggy, doggo };

            double frogAvgAge = frogs.ToList().Average(frog => frog.Age);
            double catAvgAge = cats.ToList().Average(cat => cat.Age);
            double dogAvgAge = dogs.ToList().Average(dog => dog.Age);

            Console.WriteLine(doggo);

            kotka.ProduceSound();
        }
    }
}
