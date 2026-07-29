using AsyncAwaitExamples.Models;

namespace AsyncAwaitExamples.Services;

/// <summary>
/// Simulates calls to external APIs or databases.
/// All methods are intentionally delayed to demonstrate asynchronous programming.
/// </summary>
public static class FakeApi
{
    private static readonly List<Employee> Employees =
    [
        new()
        {
            Id = 1,
            Name = "John Smith",
            Department = "Information Technology",
            Designation = "Senior Software Engineer",
            Salary = 95000,
            Age = 32,
            Email = "john.smith@company.com",
            JoiningDate = new DateTime(2022, 4, 15)
        },

        new()
        {
            Id = 2,
            Name = "Alice Johnson",
            Department = "Human Resources",
            Designation = "HR Manager",
            Salary = 72000,
            Age = 35,
            Email = "alice.johnson@company.com",
            JoiningDate = new DateTime(2021, 1, 12)
        },

        new()
        {
            Id = 3,
            Name = "David Brown",
            Department = "Finance",
            Designation = "Financial Analyst",
            Salary = 81000,
            Age = 30,
            Email = "david.brown@company.com",
            JoiningDate = new DateTime(2020, 9, 10)
        },

        new()
        {
            Id = 4,
            Name = "Sophia Wilson",
            Department = "Information Technology",
            Designation = "Solution Architect",
            Salary = 125000,
            Age = 40,
            Email = "sophia.wilson@company.com",
            JoiningDate = new DateTime(2018, 6, 5)
        }
    ];

    /// <summary>
    /// Simulates fetching all employees from an external API.
    /// </summary>
    public static async Task<List<Employee>> GetEmployeesAsync(
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine("📡 Fetching employees...");

        await Task.Delay(2000, cancellationToken);

        Console.WriteLine("✅ Employees retrieved.");

        return Employees;
    }

    /// <summary>
    /// Simulates fetching a single employee.
    /// </summary>
    public static async Task<Employee?> GetEmployeeByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"📡 Fetching Employee {id}...");

        await Task.Delay(1500, cancellationToken);

        return Employees.FirstOrDefault(e => e.Id == id);
    }

    /// <summary>
    /// Simulates a salary lookup service.
    /// </summary>
    public static async Task<decimal> GetSalaryAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"💰 Fetching salary for Employee {employeeId}...");

        await Task.Delay(1200, cancellationToken);

        var employee = Employees.FirstOrDefault(e => e.Id == employeeId);

        return employee?.Salary ?? 0;
    }

    /// <summary>
    /// Simulates retrieving department information.
    /// </summary>
    public static async Task<string> GetDepartmentAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"🏢 Fetching department for Employee {employeeId}...");

        await Task.Delay(1000, cancellationToken);

        var employee = Employees.FirstOrDefault(e => e.Id == employeeId);

        return employee?.Department ?? "Unknown";
    }

    /// <summary>
    /// Simulates a slow external REST API.
    /// </summary>
    public static async Task<string> GetCompanyNewsAsync(
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine("📰 Calling Company News API...");

        await Task.Delay(3000, cancellationToken);

        return "Quarterly revenue increased by 18%.";
    }

    /// <summary>
    /// Simulates uploading a file.
    /// </summary>
    public static async Task<bool> UploadDocumentAsync(
        string fileName,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"📤 Uploading {fileName}...");

        await Task.Delay(2500, cancellationToken);

        Console.WriteLine("✅ Upload completed.");

        return true;
    }

    /// <summary>
    /// Simulates a failing external service.
    /// Useful for demonstrating async exception handling.
    /// </summary>
    public static async Task<string> ThrowExceptionAsync()
    {
        Console.WriteLine("⚠️ Calling unreliable API...");

        await Task.Delay(1500);

        throw new InvalidOperationException(
            "The remote service returned HTTP 500 (Internal Server Error).");
    }

    /// <summary>
    /// Simulates a long-running operation.
    /// Useful for demonstrating CancellationToken.
    /// </summary>
    public static async Task<string> LongRunningOperationAsync(
        CancellationToken cancellationToken)
    {
        Console.WriteLine("⏳ Long running operation started...");

        for (int i = 1; i <= 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Processing step {i}/10...");

            await Task.Delay(1000, cancellationToken);
        }

        return "Operation completed successfully.";
    }
}
