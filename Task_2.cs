using System;

abstract class Chart
{
    public abstract void Draw();
}
class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Line Chart");

    }
}

class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Bar Chart");
  
    }
}

class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Pie Chart");
    }
}

abstract class GraphFactory
{
    public abstract Chart CreateChart();
}

class LineChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new LineChart();
    }
}

class BarChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new BarChart();
    }
}

class PieChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of chart (line/bar/pie): ");
        string chartType = Console.ReadLine().ToLower();

        GraphFactory factory = null;

        switch (chartType)
        {
            case "line":
                factory = new LineChartFactory();
                break;
            case "bar":
                factory = new BarChartFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid chart type.");
                return;
        }

        Chart chart = factory.CreateChart();

        chart.Draw();

        Console.ReadLine();
    }
}
