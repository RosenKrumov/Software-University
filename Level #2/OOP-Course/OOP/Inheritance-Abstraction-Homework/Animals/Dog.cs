namespace Animals
{
    using System;

    class Dog : Animal
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("I am dog and I bark!");
        }
    }
}
