
#region ChainOfResponsibility
// The other part of the client code constructs the actual chain.
var monkey = new Behavioral.ChainOfResponsibility.MonkeyHandler();
var squirrel = new Behavioral.ChainOfResponsibility.SquirrelHandler();
var dog = new Behavioral.ChainOfResponsibility.DogHandler();

monkey.SetNext(squirrel).SetNext(dog);

// The client should be able to send a request to any handler, not
// just the first one in the chain.
Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
Behavioral.ChainOfResponsibility.Client.ClientCode(monkey);
Console.WriteLine();

Console.WriteLine("Subchain: Squirrel > Dog\n");
Behavioral.ChainOfResponsibility.Client.ClientCode(squirrel);
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Iterator
// The client code may or may not know about the Concrete Iterator
// or Collection classes, depending on the level of indirection you
// want to keep in your program.
var collection = new Behavioral.Iterator.WordsCollection();
collection.AddItem("First");
collection.AddItem("Second");
collection.AddItem("Third");

Console.WriteLine("Straight traversal:");

foreach (var element in collection)
{
    Console.WriteLine(element);
}

Console.WriteLine("\nReverse traversal:");

collection.ReverseDirection();

foreach (var element in collection)
{
    Console.WriteLine(element);
}
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Memento
// Client code.
Behavioral.Memento.Originator originator = new Behavioral.Memento.Originator("Super-duper-super-puper-super.");
Behavioral.Memento.Caretaker caretaker = new Behavioral.Memento.Caretaker(originator);

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

Console.WriteLine();
caretaker.ShowHistory();

Console.WriteLine("\nClient: Now, let's rollback!\n");
caretaker.Undo();

Console.WriteLine("\n\nClient: Once more!\n");
caretaker.Undo();

Console.WriteLine();
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region State
// The client code.
var context = new Behavioral.State.Context(new Behavioral.State.ConcreteStateA());
context.Request1();
context.Request2();
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region TemplateMethod
Console.WriteLine("Same client code can work with different subclasses:");

Behavioral.TemplateMethod.Client.ClientCode(new Behavioral.TemplateMethod.ConcreteClass1());

Console.Write("\n");

Console.WriteLine("Same client code can work with different subclasses:");
Behavioral.TemplateMethod.Client.ClientCode(new Behavioral.TemplateMethod.ConcreteClass2());
#endregion


Console.WriteLine("*************************************");
Console.WriteLine("*************************************");

#region Command
// The client code can parameterize an invoker with any commands.
Behavioral.Command.Invoker invoker = new Behavioral.Command.Invoker();
invoker.SetOnStart(new Behavioral.Command.SimpleCommand("Say Hi!"));
Behavioral.Command.Receiver receiver = new Behavioral.Command.Receiver();
invoker.SetOnFinish(new Behavioral.Command.ComplexCommand(receiver, "Send email", "Save report"));

invoker.DoSomethingImportant();
#endregion


Console.WriteLine("*************************************");
Console.WriteLine("*************************************");


#region Mediator
// The client code.
Behavioral.Mediator.Component1 component1 = new Behavioral.Mediator.Component1();
Behavioral.Mediator.Component2 component2 = new Behavioral.Mediator.Component2();
new Behavioral.Mediator.ConcreteMediator(component1, component2);

Console.WriteLine("Client triggets operation A.");
component1.DoA();

Console.WriteLine();

Console.WriteLine("Client triggers operation D.");
component2.DoD();
#endregion


Console.WriteLine("*************************************");
Console.WriteLine("*************************************");


#region Observer
// The client code.
var subject = new Behavioral.Observer.Subject();
var observerA = new Behavioral.Observer.ConcreteObserverA();
subject.Attach(observerA);

var observerB = new Behavioral.Observer.ConcreteObserverB();
subject.Attach(observerB);

subject.SomeBusinessLogic();
subject.SomeBusinessLogic();

subject.Detach(observerB);

subject.SomeBusinessLogic();
#endregion

Console.WriteLine("*************************************");
Console.WriteLine("*************************************");


#region Strategy
// The client code picks a concrete strategy and passes it to the
// context. The client should be aware of the differences between
// strategies in order to make the right choice.
var strategyContext = new Behavioral.Strategy.Context();

Console.WriteLine("Client: Strategy is set to normal sorting.");
strategyContext.SetStrategy(new Behavioral.Strategy.ConcreteStrategyA());
strategyContext.DoSomeBusinessLogic();

Console.WriteLine();

Console.WriteLine("Client: Strategy is set to reverse sorting.");
strategyContext.SetStrategy(new Behavioral.Strategy.ConcreteStrategyB());
strategyContext.DoSomeBusinessLogic();
#endregion


Console.WriteLine("*************************************");
Console.WriteLine("*************************************");


#region Visitor
List<Behavioral.Visitor.IComponent> components = new List<Behavioral.Visitor.IComponent>
            {
                new Behavioral.Visitor.ConcreteComponentA(),
                new Behavioral.Visitor.ConcreteComponentB()
            };

Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
var visitor1 = new Behavioral.Visitor.ConcreteVisitor1();
Behavioral.Visitor.Client.ClientCode(components, visitor1);

Console.WriteLine();

Console.WriteLine("It allows the same client code to work with different types of visitors:");
var visitor2 = new Behavioral.Visitor.ConcreteVisitor2();
Behavioral.Visitor.Client.ClientCode(components, visitor2);
#endregion



Console.Read();