using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{

    static void Main(string[] args)
    {
        var rebateService = SmartwyreFactory.CreateRebateService();

        var request = GetRequest();

        var result = rebateService.ProcessRequest(request);

        if (result.Success)
        {
            Console.WriteLine($"Your Amount: {result.Success}");
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }

    }

    private static CalculateRebateRequest GetRequest()
    {
        var request = new CalculateRebateRequest();
        Console.WriteLine("Please enter a RebateIdentifier :");
        request.RebateIdentifier = Console.ReadLine();
        Console.WriteLine("Please enter a ProductIdentifier :");
        request.ProductIdentifier = Console.ReadLine();
        Console.WriteLine("Please enter a Volume :");
        if (int.TryParse(Console.ReadLine(), out int volume))
        {
            request.Volume = volume;
        }
        else
        {
            request.Volume = 0;
        }

        return request;
    }
}
