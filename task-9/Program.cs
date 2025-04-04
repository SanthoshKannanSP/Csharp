using System.Reflection;
using task_9;

var randomGenerator = new Random();
var currentNumber = 0;

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();
var allRunnableMethods = new List<MethodInfo>();

foreach (var type in types)
{
    var runnableMethods = type.GetMethods().Where(method => method.GetCustomAttributes(typeof(RunnableAttribute)).Any()).ToArray();
    allRunnableMethods.AddRange(runnableMethods);
}

for (var iteration = 0; iteration < 10; iteration++)
{
    currentNumber += randomGenerator.Next(0, 100);
    foreach (var runnableMethod in allRunnableMethods)
    {
        var attribute = (RunnableAttribute)runnableMethod.GetCustomAttribute(typeof(RunnableAttribute));
        Console.WriteLine(attribute.Description);
        var parameters = new object[] {currentNumber};
        runnableMethod.Invoke(null, parameters);
    }
}