using DelegatesExamples.Models;
using DelegatesExamples.Services;

Console.Title = "C# Delegates Interview Lab";

var service = new EmployeeService();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("============================================================");
Console.WriteLine("              C# Delegates Interview Lab");
Console.WriteLine("============================================================");
Console.ResetColor();

BasicDelegateDemo();

ActionDemo();

FuncDemo();

PredicateDemo();

ComparisonDemo();

CallbackDemo();

MulticastDelegateDemo();

AnonymousMethodDemo();

LambdaExpressionDemo();

LoggingDemo();

PayrollDemo();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n🎉 All delegate demonstrations completed.");
Console.ResetColor();


//==============================================================
// Custom Delegate
//==============================================================

delegate decimal BonusCalculator(Employee employee);

void BasicDelegateDemo()
{
    Header("1. Basic Delegate");

    BonusCalculator calculator = CalculateBonus;

    var employee = service.GetEmployees().First();

    decimal bonus = calculator(employee);

    Console.WriteLine($"{employee.Name}");
    Console.WriteLine($"Bonus : ₹{bonus:N0}");

    Pause();
}

decimal CalculateBonus(Employee employee)
{
    return employee.Salary * 0.10m;
}

//==============================================================
// Action<T>
//==============================================================

void ActionDemo()
{
    Header("2. Action<T>");

    service.ProcessEmployees(employee =>
    {
        Console.WriteLine(employee);
    });

    Pause();
}

//==============================================================
// Func<T>
//==============================================================

void FuncDemo()
{
    Header("3. Func<T>");

    var names = service.SelectEmployees(e => e.Name);

    foreach (var name in names)
        Console.WriteLine(name);

    Pause();
}

//==============================================================
// Predicate<T>
//==============================================================

void PredicateDemo()
{
    Header("4. Predicate<T>");

    var itEmployees =
        service.FilterEmployees(e => e.Department == "IT");

    foreach (var employee in itEmployees)
        Console.WriteLine(employee);

    Pause();
}

//==============================================================
// Comparison<T>
//==============================================================

void ComparisonDemo()
{
    Header("5. Comparison<T>");

    var sortedEmployees =
        service.SortEmployees((x, y) =>
            y.Salary.CompareTo(x.Salary));

    foreach (var employee in sortedEmployees)
        Console.WriteLine(employee);

    Pause();
}

//==============================================================
// Callback
//==============================================================

void CallbackDemo()
{
    Header("6. Callback Delegate");

    var employee = service.GetEmployees().First();

    service.CalculateBonus(
        employee,

        emp => emp.Salary * 0.15m,

        (emp, bonus) =>
        {
            Console.WriteLine($"{emp.Name}");
            Console.WriteLine($"Bonus : ₹{bonus:N0}");
        });

    Pause();
}

//==============================================================
// Multicast Delegate
//==============================================================

delegate void Notification(Employee employee);

void MulticastDelegateDemo()
{
    Header("7. Multicast Delegate");

    Notification notify = EmailNotification;

    notify += SmsNotification;

    notify += PushNotification;

    notify(service.GetEmployees().First());

    Pause();
}

void EmailNotification(Employee employee)
{
    Console.WriteLine($"📧 Email sent to {employee.Name}");
}

void SmsNotification(Employee employee)
{
    Console.WriteLine($"📱 SMS sent to {employee.Name}");
}

void PushNotification(Employee employee)
{
    Console.WriteLine($"🔔 Push notification sent to {employee.Name}");
}

//==============================================================
// Anonymous Method
//==============================================================

void AnonymousMethodDemo()
{
    Header("8. Anonymous Method");

    Action<Employee> display = delegate (Employee employee)
    {
        Console.WriteLine(employee.Name);
    };

    display(service.GetEmployees().First());

    Pause();
}

//==============================================================
// Lambda Expression
//==============================================================

void LambdaExpressionDemo()
{
    Header("9. Lambda Expression");

    Func<int, int> square = x => x * x;

    Console.WriteLine($"Square of 12 = {square(12)}");

    Pause();
}

//==============================================================
// Logging
//==============================================================

void LoggingDemo()
{
    Header("10. Delegate for Logging");

    service.ExecuteWithLogging(

        () =>
        {
            Console.WriteLine("Business logic executing...");
        },

        message =>
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"LOG : {message}");
            Console.ResetColor();
        });

    Pause();
}

//==============================================================
// Payroll
//==============================================================

void PayrollDemo()
{
    Header("11. Payroll Calculation");

    decimal payroll =
        service.CalculatePayroll(
            employees => employees.Sum(e => e.Salary));

    Console.WriteLine($"Total Payroll : ₹{payroll:N0}");

    Pause();
}

//==============================================================

void Header(string title)
{
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine();
    Console.WriteLine(new string('=', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('=', 60));

    Console.ResetColor();
}

//==============================================================

void Pause()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;

    Console.WriteLine();
    Console.WriteLine("Press ENTER to continue...");
    Console.ResetColor();

    Console.ReadLine();
}