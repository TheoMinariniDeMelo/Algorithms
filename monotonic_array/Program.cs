// See https://aka.ms/new-console-template for more information
if (args.Length < 1)
{
    Console.Error.WriteLine("There aren't minimum amount of arguments");
}
var arr = new int[args.Length];

for(var i = 0; i < args.Length; i++) 
{
    if (!Int32.TryParse(args[i], out var number))
    {
        Console.WriteLine($"{args[i]} is not a number");
        return;
    };
    arr[i] = number;
}
bool growing = true;

for (int i = 1; i < arr.Length; i++)
{
    if ((arr[0] - arr[i]) > 0)
    {
        growing = false;
        break;
    }
    else if ((arr[0] - arr[i]) < 0)
    {
        break;
    }
    else if (i == arr.Length - 1)
    {
        Console.WriteLine($"The given sequence is constant! {arr}");
    }
}

if (growing)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (arr[j] > arr[i])
            {
                Console.Write($"The given sequence is not monotonic!");
                foreach (var k in arr)
                {
                    Console.Write($" {k} ");   
                } 
                return;
            }
        }
    }
    Console.Write($"The given sequence is monotonic!");
    foreach (var i in arr)
    {
        Console.Write($" {i} ");   
    } 
}