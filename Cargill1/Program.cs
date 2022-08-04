// mooier dan herhaalde code zijn loops

List<Monitor> monitors = new()
{
    new() { Price = 500, Name = "Mono" },
    new() { Price = 1500, Name = "Color" }
};

List<Card> cards = new()
{
    new() { Price = 600, Name = "Network" },
    new() { Price = 1500, Name = "CDRom", Rebate = 135 },
    new() { Price = 1000, Name = "Tape" }
};

foreach (Monitor monitor in monitors)
{
    foreach (Card card in cards)
    {
        Computer computer = new(card, monitor);
        computer.Print();
    }
}

// Monitors en cards hebben allebei een name en price. Dus laat ik ze erven van een
// component die WEL abstract is, want je wil geen generieke componenten kunnen maken.
internal abstract class Component
{
    public int Price { get; init; }

    public string? Name { get; init; }

    virtual public int Rebate { get; init; } = 0;

    public int NetPrice => Price - Rebate;
}

// Een card heeft een rebate. 
internal class Card : Component
{
    override public int Rebate { get; init; } = 45;
}

class Monitor : Component { }

internal record Computer(Card Card, Monitor Monitor)
{
    private int NetPrice =>
        Monitor.NetPrice + Card.NetPrice;

    public void Print() =>
        Console.WriteLine($"{Card.Name} {Monitor.Name}, net price = {NetPrice}");
}




