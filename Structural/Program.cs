
#region Adapter
Structural.Adapter.Adaptee adaptee = new Structural.Adapter.Adaptee();
Structural.Adapter.ITarget target = new Structural.Adapter.Adapter(adaptee);

Console.WriteLine("Adaptee interface is incompatible with the client.");
Console.WriteLine("But with adapter client can call it's method.");

Console.WriteLine(target.GetRequest());
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Bridge
Structural.Bridge.Client bridgeClient = new Structural.Bridge.Client();

Structural.Bridge.Abstraction abstraction;
// The client code should be able to work with any pre-configured
// abstraction-implementation combination.
abstraction = new Structural.Bridge.Abstraction(new Structural.Bridge.ConcreteImplementationA());
bridgeClient.ClientCode(abstraction);

Console.WriteLine();

abstraction = new Structural.Bridge.ExtendedAbstraction(new Structural.Bridge.ConcreteImplementationB());
bridgeClient.ClientCode(abstraction);
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Composite
Structural.Composite.Client compositeClient = new Structural.Composite.Client();

// This way the client code can support the simple leaf
// components...
Structural.Composite.Leaf leaf = new Structural.Composite.Leaf();
Console.WriteLine("Client: I get a simple component:");
compositeClient.ClientCode(leaf);

// ...as well as the complex composites.
Structural.Composite.Composite tree = new Structural.Composite.Composite();
Structural.Composite.Composite branch1 = new Structural.Composite.Composite();
branch1.Add(new Structural.Composite.Leaf());
branch1.Add(new Structural.Composite.Leaf());
Structural.Composite.Composite branch2 = new Structural.Composite.Composite();
branch2.Add(new Structural.Composite.Leaf());
tree.Add(branch1);
tree.Add(branch2);
Console.WriteLine("Client: Now I've got a composite tree:");
compositeClient.ClientCode(tree);

Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
compositeClient.ClientCode2(tree, leaf);
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Decorator
Structural.Decorator.Client decoratorClient = new Structural.Decorator.Client();

var simple = new Structural.Decorator.ConcreteComponent();
Console.WriteLine("Client: I get a simple component:");
decoratorClient.ClientCode(simple);
Console.WriteLine();

// ...as well as decorated ones.
//
// Note how decorators can wrap not only simple components but the
// other decorators as well.
Structural.Decorator.ConcreteDecoratorA decorator1 = new Structural.Decorator.ConcreteDecoratorA(simple);
Structural.Decorator.ConcreteDecoratorB decorator2 = new Structural.Decorator.ConcreteDecoratorB(decorator1);
Console.WriteLine("Client: Now I've got a decorated component:");
decoratorClient.ClientCode(decorator2);
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Facade
// The client code may have some of the subsystem's objects already
// created. In this case, it might be worthwhile to initialize the
// Facade with these objects instead of letting the Facade create
// new instances.
Structural.Facade.Subsystem1 subsystem1 = new Structural.Facade.Subsystem1();
Structural.Facade.Subsystem2 subsystem2 = new Structural.Facade.Subsystem2();
Structural.Facade.Facade facade = new Structural.Facade.Facade(subsystem1, subsystem2);
Structural.Facade.Client.ClientCode(facade);
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region FlyWeight
// The client code usually creates a bunch of pre-populated
// flyweights in the initialization stage of the application.
var factory = new Structural.Flyweight.FlyweightFactory(
    new Structural.Flyweight.Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
    new Structural.Flyweight.Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
    new Structural.Flyweight.Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
    new Structural.Flyweight.Car { Company = "BMW", Model = "M5", Color = "red" },
    new Structural.Flyweight.Car { Company = "BMW", Model = "X6", Color = "white" }
);
factory.ListFlyweights();

AddCarToPoliceDatabase(factory, new Structural.Flyweight.Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "M5",
    Color = "red"
});

AddCarToPoliceDatabase(factory, new Structural.Flyweight.Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "X1",
    Color = "red"
});

factory.ListFlyweights();

static void AddCarToPoliceDatabase(Structural.Flyweight.FlyweightFactory factory, Structural.Flyweight.Car car)
{
    Console.WriteLine("\nClient: Adding a car to database.");

    var flyweight = factory.GetFlyweight(new Structural.Flyweight.Car
    {
        Color = car.Color,
        Model = car.Model,
        Company = car.Company
    });

    // The client code either stores or calculates extrinsic state and
    // passes it to the flyweight's methods.
    flyweight.Operation(car);
}
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Proxy
Structural.Proxy.Client proxyClient = new Structural.Proxy.Client();

Console.WriteLine("Client: Executing the client code with a real subject:");
Structural.Proxy.RealSubject realSubject = new Structural.Proxy.RealSubject();
proxyClient.ClientCode(realSubject);

Console.WriteLine();

Console.WriteLine("Client: Executing the same client code with a proxy:");
Structural.Proxy.Proxy proxy = new Structural.Proxy.Proxy(realSubject);
proxyClient.ClientCode(proxy);
#endregion



Console.Read();