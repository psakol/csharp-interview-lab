namespace DelegatesExamples.Models;

/// <summary>
/// Represents an employee used throughout the Delegates examples.
/// </summary>
public sealed class Employee
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Department { get; init; }

    public required string Designation { get; init; }

    public decimal Salary { get; init; }

    public int Age { get; init; }

    public bool IsActive { get; init; }

    public override string ToString()
    {
        return
            $"{Id,-2} | " +
            $"{Name,-18} | " +
            $"{Department,-15} | " +
            $"{Designation,-22} | " +
            $"₹{Salary:N0}";
    }
}