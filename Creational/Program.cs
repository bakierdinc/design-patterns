

#region FactoryMethod
new Creational.FactoryMethod.Client().Main();
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region AbstractFactory
new Creational.AbstractFactory.Client().Main();
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Builder
// The client code creates a builder object, passes it to the
// director and then initiates the construction process. The end
// result is retrieved from the builder object.
var director = new Creational.Builder.Director();
var builder = new Creational.Builder.ConcreteBuilder();
director.Builder = builder;

Console.WriteLine("Standard basic product:");
director.BuildMinimalViableProduct();
Console.WriteLine(builder.GetProduct().ListParts());

Console.WriteLine("Standard full featured product:");
director.BuildFullFeaturedProduct();
Console.WriteLine(builder.GetProduct().ListParts());

// Remember, the Builder pattern can be used without a Director
// class.
Console.WriteLine("Custom product:");
builder.BuildPartA();
builder.BuildPartC();
Console.Write(builder.GetProduct().ListParts());
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Singelton
Creational.Singleton.Singleton s1 = Creational.Singleton.Singleton.GetInstance();
Creational.Singleton.Singleton s2 = Creational.Singleton.Singleton.GetInstance();

if (s1 == s2)
{
    Console.WriteLine("Singleton works, both variables contain the same instance.");
}
else
{
    Console.WriteLine("Singleton failed, variables contain different instances.");
}
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Prototype
Creational.Prototype.Person p1 = new Creational.Prototype.Person();
p1.Age = 42;
p1.BirthDate = Convert.ToDateTime("1977-01-01");
p1.Name = "Jack Daniels";
p1.IdInfo = new Creational.Prototype.IdInfo(666);

// Perform a shallow copy of p1 and assign it to p2.
Creational.Prototype.Person p2 = p1.ShallowCopy();
// Make a deep copy of p1 and assign it to p3.
Creational.Prototype.Person p3 = p1.DeepCopy();

// Display values of p1, p2 and p3.
Console.WriteLine("Original values of p1, p2, p3:");
Console.WriteLine("   p1 instance values: ");
DisplayValues(p1);
Console.WriteLine("   p2 instance values:");
DisplayValues(p2);
Console.WriteLine("   p3 instance values:");
DisplayValues(p3);

// Change the value of p1 properties and display the values of p1,
// p2 and p3.
p1.Age = 32;
p1.BirthDate = Convert.ToDateTime("1900-01-01");
p1.Name = "Frank";
p1.IdInfo.IdNumber = 7878;
Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
Console.WriteLine("   p1 instance values: ");
DisplayValues(p1);
Console.WriteLine("   p2 instance values (reference values have changed):");
DisplayValues(p2);
Console.WriteLine("   p3 instance values (everything was kept the same):");
DisplayValues(p3);

static void DisplayValues(Creational.Prototype.Person p)
{
    Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
        p.Name, p.Age, p.BirthDate);
    Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
}
#endregion



Console.Read();