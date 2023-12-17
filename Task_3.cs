using System;

interface Screen
{
    string GetScreenDetails();
}

interface Processor
{
    string GetProcessorDetails();
}

interface Camera
{
    string GetCameraDetails();
}

class SmartphoneScreen : Screen
{
    public string GetScreenDetails()
    {
        return "Smartphone Screen: AMOLED";
    }
}

class SmartphoneProcessor : Processor
{
    public string GetProcessorDetails()
    {
        return "Smartphone Processor: Snapdragon";
    }
}

class SmartphoneCamera : Camera
{
    public string GetCameraDetails()
    {
        return "Smartphone Camera: Dual Lens";
    }
}

class LaptopScreen : Screen
{
    public string GetScreenDetails()
    {
        return "Laptop Screen: LED";
    }
}

class LaptopProcessor : Processor
{
    public string GetProcessorDetails()
    {
        return "Laptop Processor: Intel Core i7";
    }
}

class LaptopCamera : Camera
{
    public string GetCameraDetails()
    {
        return "Laptop Camera: Integrated";
    }
}

class TabletScreen : Screen
{
    public string GetScreenDetails()
    {
        return "Tablet Screen: IPS";
    }
}

class TabletProcessor : Processor
{
    public string GetProcessorDetails()
    {
        return "Tablet Processor: MediaTek";
    }
}

class TabletCamera : Camera
{
    public string GetCameraDetails()
    {
        return "Tablet Camera: Single Lens";
    }
}

interface TechProductFactory
{
    Screen CreateScreen();
    Processor CreateProcessor();
    Camera CreateCamera();
}

class SmartphoneFactory : TechProductFactory
{
    public Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

class LaptopFactory : TechProductFactory
{
    public Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

class TabletFactory : TechProductFactory
{
    public Screen CreateScreen()
    {
        return new TabletScreen();
    }

    public Processor CreateProcessor()
    {
        return new TabletProcessor();
    }

    public Camera CreateCamera()
    {
        return new TabletCamera();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of tech product to create (smartphone/laptop/tablet): ");
        string productType = Console.ReadLine().ToLower();

        TechProductFactory factory = null;

        switch (productType)
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            case "tablet":
                factory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid product type.");
                return;
        }

        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        Console.WriteLine(screen.GetScreenDetails());
        Console.WriteLine(processor.GetProcessorDetails());
        Console.WriteLine(camera.GetCameraDetails());

        Console.ReadLine();
    }
}
