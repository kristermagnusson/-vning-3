





//try                                                                                                                          //Test av Person
//{
//Person person = new Person("Anders", "Andersson");
//    Person person2 = new Person(1, "Erik", "Björnsson", 200, 100);
//Console.WriteLine($"   {person.Age}  {person.LName}   {person.FName}  {person.Height}   {person.Weight}");                   //Test med overload
//Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}");
//}
//catch (ArgumentException e)
//{ Console.WriteLine(e); }




//try                                                                                                                          //Test av PersonHandler avslutad med ett error
//{
//    PersonHandler personHandler = new PersonHandler();


//    Person person2 = new Person("anders", "andersson");


//    Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}");

//    personHandler.SetAge(person2, 1000);
//    Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}");
//    personHandler.ChangeFirstName(person2, "Peppe");
//    Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}"); 
//    personHandler.ChangeLastName(person2, "Persson");
//    Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}");
//    personHandler.ChangeHeight(person2, 185);
//    personHandler.ChangeWeight(person2, 70);
//    Console.WriteLine($"   {person2.Age}  {person2.LName}   {person2.FName}  {person2.Height}   {person2.Weight}");
//    personHandler.SetAge(person2, -1);
//}
//catch (ArgumentException e)
//{ Console.WriteLine(e); }






List<UserError> UserErrors = new List<UserError>();                                                                              //Test av UserError
UserErrors.Add(new PersonError());
UserErrors.Add(new NumericInputError());
UserErrors.Add(new TextinputError());
UserErrors.Add(new IntInputError());
UserErrors.Add(new doubleError());
UserErrors.Add(new charError());
foreach (var UserError in UserErrors)
{
    Console.WriteLine(UserError);
    Console.WriteLine(UserError.UEMessage());
}



List<Animal> Animals = new List<Animal>();                                                                                    //Test av Animals lista

Animals.Add(new Dog());
Animals.Add(new Horse());
Animals.Add(new Hedgehog());
Animals.Add(new Worm());
Animals.Add(new Wolf());
Animals.Add(new Wolfman());
Animals.Add(new Pelican());
Animals.Add(new Flamingo());
Animals.Add(new Swan());

foreach (var Animal in Animals)                                             //Test av Animals och IPerson
{
    if (Animal is Dog) Console.WriteLine("Dog!");
    if (Animal is Horse) Console.WriteLine("Horse!");
    if (Animal is Worm) Console.WriteLine("Worm!");
    if (Animal is Wolf) Console.WriteLine("Wolf");
    if (Animal is Wolfman) Console.WriteLine("Wolfman?");
    if (Animal is Swan) Console.WriteLine("Swan!");
    if (Animal is Hedgehog) Console.WriteLine("Hedgehog!");
    if (Animal is Pelican) Console.WriteLine("Pelican!");
    if (Animal is Flamingo) Console.WriteLine("Flamingo!");
    Animal.DoSound();
    Console.WriteLine();
    if (Animal is IPerson)
    {
        Console.WriteLine("Interface");
        var test = (IPerson)Animal; test.Talk();  
    }                           // ToDo   
}

List<Dog> DogList = new List<Dog>();
//   DogList.Add(new Horse());                         är inte i samma arvskedja

foreach (var Animal in Animals)                                                 //Test av stats()  med defaultvärden

{ Console.WriteLine(Animal.Stats());
    Console.WriteLine();
}

Console.WriteLine(" hundar");

foreach (var Animal in Animals)
{
    if (Animal is Dog) 
    {
        Console.WriteLine(Animal.Stats());
        Console.WriteLine();
        var test = Animal as Dog;
        Console.WriteLine( test.Valfri());                                                                  // var skapar en typ för test som  referensen i Dog kan kopieras till
    }                                                                                                       // varefter Valfri() kan nås indirekt.
}



public class PersonHandler                                                                           //PersonHandler 
{
    public void SetAge(Person pers, int age)
    { pers.Age = age; }
    public  Person CreatePerson(int age, string fname, string lname, double height, double weight)
    {
        Person person = new Person(age, fname, lname, height, weight);
        return person;
    }

    public  void ChangeFirstName(Person pers, string fname)                           
    { pers.FName = fname; }



    public void ChangeLastName(Person pers, string lname)
    { pers.LName = lname; }

    public void ChangeHeight(Person pers, double height)
    { pers.Height = height; }


    public void ChangeWeight(Person pers, double height)
    { pers.Weight = height; }


}










public class Person                                                                               //Person
{
    private int age;
    public int Age
    {
        get { return age; }
        set
        {

            if (value < 0)
            { throw new ArgumentException("Åldern får ej var under 0" ); }           // kommer ej åt private direkt utifrän, endast public
            else
            { age = value; };
        }
    }
    private string fName;
    public string FName 
    { 
      get { return fName; } 
      set 
        { if((value.Length > 10) || (value.Length < 2))
                    { throw new ArgumentException("För kort förnamn"); }
          else { fName = value; }
        }
      
    }
    private string lName;
    public string LName 
    { 
        get { return lName; } 
        set { 
            if ((value.Length < 3) || (value.Length > 12)) { throw new ArgumentException("För kort efternamn"); }
            else lName = value; }
            }
    private double height;
    public double Height 
    { get { return height; } set { height = value; }}
    private double weight;
    public double Weight 
    { get { return weight; } set { weight = value; }}
                                                                                                                   //Overloaded
    public Person(string fName, string lName)
    
    {; FName = fName; LName = lName; }
    public Person(int age, string fName, string lName, double height, double weight)
    {
        Age = age;  FName = fName; LName=lName; Height = height; Weight = weight; 

    }
 }








    public abstract class UserError
{
    public abstract string UEMessage();
}



public class PersonError: UserError
{
    public override string UEMessage()
    { return "You tried to use a numeric input in a text only field. This fired an error"; }
}



public class NumericInputError : UserError  
{
    public override string UEMessage()
    { return "You tried to use a numeric input in a text only field. This fired an error"; }
}



public class TextinputError : UserError
{
    public override string UEMessage()
    { return "You tried to use a text input in a numeric only field. This fired an error"; }

}



public class IntInputError : UserError
{
    public override string UEMessage()
    { return "You tried to use a integer input in a text only field. This fired an error"; }

}




public class doubleError : UserError
{
    public override string UEMessage()
    { return "You tried to use a double input in a integer only field. This fired an error"; }

}




public class charError : UserError
{
    public override string UEMessage()
    { return "You tried to use a char input in a integer only field. This fired an error"; }

}











public abstract class Animal                                               //3.3
{                                                                          // F13: Bird
    public string Name;                                                    // F14: Animal
    public int Age;
    public int Weight;
    public abstract void DoSound();

    public virtual string Stats()
    {
        return $" Name: {Name}  Age: {Age}  Weigh: {Weight} ";
    }
    public Animal()
    {

    }
                                                                         //3.4
}                                                                        // F9: Både hästar och hundar är djur  hästar är inte hundar, de ligger inte i samma "arvskedja"
                                                                         //F10: Animal
                                                                         //F13 stats() för den här klassen + föregående version(er) av stats

    public class Horse : Animal
    {
        public bool DoesBite;
        public override void DoSound()
        {
            Console.WriteLine("Neigh");
        }
        public override string Stats()
        {
            return base.Stats() + $"Bites: {DoesBite}";
        }
    }


    public class Dog : Animal
    {
        public bool IsQute;
        public override void DoSound()
        {
            Console.WriteLine("Voff");
        }
    public string Valfri()
    { return "Valfri"; 
    }
    public override string Stats()
    {
        return base.Stats() + $"IsQuite: {IsQute}";
    }

}


    public class Hedgehog : Animal
    {
        public double Speed;
        public override void DoSound()
        {
            Console.WriteLine("Swich");
        }
    public override string Stats()
    {
        return base.Stats() + $"Speed: {Speed}";
    }
}


    public class Worm : Animal
    {
        public bool DoDig;
        public override void DoSound()
        {
            Console.WriteLine("Mmmmm");
        }
    public override string Stats()
    {
        return base.Stats() + $"Digs: {DoDig}";
    }
}


    public class Bird : Animal
    {
        public double WingSpan;
        public override void DoSound()
        {
            Console.WriteLine("piip");
        }
    public override string Stats()
    {
        return base.Stats() + $"Wingspan: {WingSpan} ";
    }
}




    public class Wolf : Animal
    {
        public bool HaveTeeth;
        public override void DoSound()
        {
            Console.WriteLine("Grrr");
        }
    public override string Stats()
    {
        return base.Stats() + $"Have Teeth: {HaveTeeth}";
    }
}


    public class Pelican : Bird
    {
        public bool IsWhite;

    public override string Stats()
    {
        return base.Stats() + $"Is white : {IsWhite}";
    }
}


    public class Flamingo : Bird
    {
        public bool IsPink;
    public override string Stats()
    {
        return base.Stats() + $"Is pink: {IsPink}";
    }
}


    public class Swan : Bird
    {
        public bool IsBlack;

    public override string Stats()
    {
        return base.Stats() + $"Is pink: {IsBlack}";
    }
}


    public class Wolfman : Wolf, IPerson
    {
        public void Talk()
        {
            DoSound();
        }

    public  string stats ()

    { return base.Stats(); }
       
    }




    public interface IPerson
    {
        public void Talk();
    }


