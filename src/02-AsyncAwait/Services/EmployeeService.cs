using AsyncAwaitExamples.Models;

namespace AsyncAwaitExamples.Services;

/// <summary>
/// Provides business operations for working with employees.
/// This class demonstrates how a typical service layer uses asynchronous methods.
/// </summary>
public class EmployeeService
{
    /// <summary>
    /// Retrieves all employees.
    /// </summary>
    public async Task<List<Employee>> GetEmployeesAsync(
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .GetEmployeesAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves an employee by identifier.
    /// </summary>
    public async Task<Employee?> GetEmployeeAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .GetEmployeeByIdAsync(employeeId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves an employee's salary.
    /// </summary>
    public async Task<decimal> GetSalaryAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .GetSalaryAsync(employeeId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves an employee's department.
    /// </summary>
    public async Task<string> GetDepartmentAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .GetDepartmentAsync(employeeId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves company news.
    /// </summary>
    public async Task<string> GetCompanyNewsAsync(
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .GetCompanyNewsAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Uploads a document.
    /// </summary>
    public async Task<bool> UploadDocumentAsync(
        string fileName,
        CancellationToken cancellationToken = default)
    {
        return await FakeApi
            .UploadDocumentAsync(fileName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Demonstrates Task.WhenAll by fetching salary and department concurrently.
    /// </summary>
    public async Task<EmployeeSummary> GetEmployeeSummaryAsync(
        int employeeId,
        CancellationToken cancellationToken = default)
    {
        var employeeTask = FakeApi.GetEmployeeByIdAsync(employeeId, cancellationToken);
        var salaryTask = FakeApi.GetSalaryAsync(employeeId, cancellationToken);
        var departmentTask = FakeApi.GetDepartmentAsync(employeeId, cancellationToken);

        await Task
            .WhenAll(employeeTask, salaryTask, departmentTask)
            .ConfigureAwait(false);

        var employee = await employeeTask.ConfigureAwait(false);

        if (employee is null)
        {
            throw new InvalidOperationException(
                $"Employee with Id {employeeId} was not found.");
        }

        return new EmployeeSummary
        {
            EmployeeId = employee.Id,
            Name = employee.Name,
            Department = await departmentTask.ConfigureAwait(false),
            Salary = await salaryTask.ConfigureAwait(false)
        };
    }

    /// <summary>
    /// Demonstrates async exception handling.
    /// </summary>
    public async Task DemonstrateExceptionHandlingAsync()
    {
        try
        {
            await FakeApi
                .ThrowExceptionAsync()
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"❌ Exception: {ex.Message}");

            Console.ResetColor();
        }
    }

    /// <summary>
    /// Demonstrates cooperative cancellation.
    /// </summary>
    public async Task DemonstrateCancellationAsync(
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await FakeApi
                .LongRunningOperationAsync(cancellationToken)
                .ConfigureAwait(false);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(result);

            Console.ResetColor();
        }
        catch (OperationCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("⚠️ Operation cancelled by the user.");

            Console.ResetColor();
        }
    }
}

/// <summary>
/// DTO used by the Task.WhenAll example.
/// </summary>
public sealed class EmployeeSummary
{
    public int EmployeeId { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Department { get; init; } = string.Empty;

    public decimal Salary { get; init; }

    public override string ToString()
    {
        return
            $"👤 {Name}\n" +
            $"🆔 Employee Id : {EmployeeId}\n" +
            $"🏢 Department  : {Department}\n" +
            $"💰 Salary      : ₹{Salary:N0}";
    }
}
