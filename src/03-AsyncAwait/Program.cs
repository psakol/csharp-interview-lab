using System.Diagnostics;
using AsyncAwaitExamples.Services;

Console.Title = "C# Async/Await Interview Lab";

var service = new EmployeeService();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("===============================================");
Console.WriteLine("      C# Async/Await Interview Lab");
Console.WriteLine("===============================================");
Console.ResetColor();

await BasicAsyncAwaitDemo();

await GetAllEmployeesDemo();

await TaskWhenAllDemo();

await SequentialVsParallelDemo();

await TaskWhenAnyDemo();

await ExceptionHandlingDemo();

await CancellationDemo();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n🎉 All demonstrations completed.");
Console.ResetColor();


//========================================================

async Task BasicAsyncAwaitDemo()
{
    Header("1. Basic async / await");

    var employees = await service.GetEmployeesAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine(employee);
    }

    Pause();
}

//========================================================

async Task GetAllEmployeesDemo()
{
    Header("2. Fetch Employee Summary");

    var summary = await service.GetEmployeeSummaryAsync(1);

    Console.WriteLine(summary);

    Pause();
}

//========================================================

async Task SequentialVsParallelDemo()
{
    Header("3. Sequential vs Parallel");

    var stopwatch = Stopwatch.StartNew();

    Console.WriteLine("Running Sequential...");

    await service.GetSalaryAsync(1);
    await service.GetDepartmentAsync(1);
    await service.GetCompanyNewsAsync();

    stopwatch.Stop();

    Console.WriteLine($"⏱ Sequential Time : {stopwatch.ElapsedMilliseconds} ms");

    Console.WriteLine();

    stopwatch.Restart();

    Console.WriteLine("Running Parallel...");

    var salaryTask = service.GetSalaryAsync(1);
    var departmentTask = service.GetDepartmentAsync(1);
    var newsTask = service.GetCompanyNewsAsync();

    await Task.WhenAll(
        salaryTask,
        departmentTask,
        newsTask);

    stopwatch.Stop();

    Console.WriteLine($"⚡ Parallel Time : {stopwatch.ElapsedMilliseconds} ms");

    Pause();
}

//========================================================

async Task TaskWhenAllDemo()
{
    Header("4. Task.WhenAll");

    var employeeTask = service.GetEmployeeAsync(2);

    var salaryTask = service.GetSalaryAsync(2);

    var departmentTask = service.GetDepartmentAsync(2);

    await Task.WhenAll(
        employeeTask,
        salaryTask,
        departmentTask);

    Console.WriteLine($"Employee : {(await employeeTask)?.Name}");
    Console.WriteLine($"Department : {await departmentTask}");
    Console.WriteLine($"Salary : ₹{await salaryTask:N0}");

    Pause();
}

//========================================================

async Task TaskWhenAnyDemo()
{
    Header("5. Task.WhenAny");

    var task1 = service.GetSalaryAsync(1);

    var task2 = service.GetCompanyNewsAsync();

    var completedTask = await Task.WhenAny(task1, task2);

    if (completedTask == task1)
    {
        Console.WriteLine($"🏆 Salary returned first : ₹{await task1:N0}");
    }
    else
    {
        Console.WriteLine($"🏆 News returned first : {await task2}");
    }

    Pause();
}

//========================================================

async Task ExceptionHandlingDemo()
{
    Header("6. Exception Handling");

    await service.DemonstrateExceptionHandlingAsync();

    Pause();
}

//========================================================

async Task CancellationDemo()
{
    Header("7. CancellationToken");

    using var cts = new CancellationTokenSource();

    cts.CancelAfter(TimeSpan.FromSeconds(4));

    await service.DemonstrateCancellationAsync(cts.Token);

    Pause();
}

//========================================================

void Header(string title)
{
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine();
    Console.WriteLine(new string('=', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('=', 60));

    Console.ResetColor();
}

//========================================================

void Pause()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;

    Console.WriteLine();
    Console.WriteLine("Press ENTER to continue...");
    Console.ResetColor();

    Console.ReadLine();
}
