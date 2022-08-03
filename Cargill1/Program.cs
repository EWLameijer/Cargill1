Computer mn = new Computer(CardType.Network, MonitorType.Mono);
Computer mc = new Computer(CardType.CDRom, MonitorType.Mono);
Computer mt = new Computer(CardType.Tape, MonitorType.Mono);
Computer cn = new Computer(CardType.Network, MonitorType.Color);
Computer cc = new Computer(CardType.CDRom, MonitorType.Color);
Computer ct = new Computer(CardType.Tape, MonitorType.Color);

mn.Print();
mc.Print();
mt.Print();
cn.Print();
cc.Print();
ct.Print();

internal enum CardType { CDRom, Tape, Network };

internal enum MonitorType { Mono, Color };

internal abstract class Card
{
    public abstract int Price();

    public abstract string Name();

    public virtual int Rebate()
    {
        return 45;
    }
}

internal class Network : Card
{
    public override int Price()
    {
        return 600;
    }

    public override string Name()
    {
        return "Network";
    }
}

internal class CDRom : Card
{
    public override int Price()
    {
        return 1500;
    }

    public override string Name()
    {
        return "CDRom";
    }

    public override int Rebate()
    {
        return 135;
    }
}

internal class Tape : Card
{
    public override int Price()
    {
        return 1000;
    }

    public override string Name()
    {
        return "Tape";
    }
}

internal abstract class Monitor
{
    public abstract int Price();

    public abstract string Name();
}

internal class Color : Monitor
{
    public override int Price()
    {
        return 1500;
    }

    public override string Name()
    {
        return "Color";
    }
}

internal class Monochrome : Monitor
{
    public override int Price()
    {
        return 500;
    }

    public override string Name()
    {
        return "Mono";
    }
}

internal class Computer
{
    private Card _card;
    private Monitor _monitor;

    public Computer(CardType cardType, MonitorType monitorType)
    {
        switch (cardType)
        {
            case CardType.Network:
                _card = new Network();
                break;
            case CardType.CDRom:
                _card = new CDRom();
                break;
            case CardType.Tape:
                _card = new Tape();
                break;
        }

        switch (monitorType)
        {
            case MonitorType.Mono:
                _monitor = new Monochrome();
                break;
            case MonitorType.Color:
                _monitor = new Color();
                break;
        }
    }

    private int NetPrice()
    {
        return _monitor.Price() + _card.Price() - _card.Rebate();
    }

    public void Print()
    {
        Console.WriteLine("{0} {1}, net price = {2}", _card.Name(), _monitor.Name(), NetPrice());
    }
}




