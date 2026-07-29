# 🚀 Async/Await Interview Guide

> A practical guide to understanding **Asynchronous Programming** in C#. Learn how `async` and `await` work, avoid common pitfalls, and write scalable, responsive .NET applications.

---

# 📖 Table of Contents

- 📌 What is Asynchronous Programming?
- 🎯 Why Use async/await?
- 🔄 Synchronous vs Asynchronous
- ⚙️ How async/await Works
- 🧵 Understanding Task
- 🚀 Task.Run()
- ⏳ Task.Delay()
- ⚡ Task.WhenAll()
- 🏁 Task.WhenAny()
- ❌ Exception Handling
- 🛑 CancellationToken
- 🔄 ConfigureAwait(false)
- 📊 Task vs Thread
- 💼 Interview Questions
- 📈 Performance Tips
- ❌ Common Mistakes
- ✅ Best Practices

---

# 📌 What is Asynchronous Programming?

Asynchronous programming allows your application to **continue executing other work while waiting for long-running operations to complete**.

Typical long-running operations include:

- 🌐 HTTP API calls
- 🗄️ Database queries
- 📁 File I/O
- ☁️ Cloud storage access
- 📧 Email sending

Instead of blocking the current thread, C# allows the operation to complete in the background while the thread is free to perform other work.

---

# 🎯 Why Use async/await?

| Benefit | Description |
|---------|-------------|
| ⚡ Better Responsiveness | Keeps UI and APIs responsive |
| 🚀 Higher Scalability | Frees threads while waiting |
| 🔄 Easier to Read | Looks like synchronous code |
| 💰 Better Resource Utilization | Uses fewer blocked threads |
| 📈 Improved Throughput | Handles more concurrent requests |

---

# 🔄 Synchronous vs Asynchronous

## Synchronous

```csharp
DownloadFile();
ProcessFile();
SendEmail();
```

Execution Flow

```
Download
   ↓
Process
   ↓
Email
```

Every operation waits for the previous one to finish.

---

## Asynchronous

```csharp
await DownloadFileAsync();
await ProcessFileAsync();
await SendEmailAsync();
```

The calling thread is **not blocked** while waiting.

---

# ⚙️ How async/await Works

```csharp
public async Task GetEmployeesAsync()
{
    var employees = await repository.GetAsync();

    Console.WriteLine(employees.Count);
}
```

### Step-by-Step

1. Method starts executing.
2. Execution reaches `await`.
3. The method pauses.
4. The current thread is released.
5. The asynchronous operation completes.
6. Execution resumes after `await`.

> 💡 **Interview Tip:**  
> `await` **does not create a new thread**. It simply waits asynchronously for an existing operation to complete.

---

# 🧵 Understanding Task

A `Task` represents an asynchronous operation.

```csharp
Task task = DoWorkAsync();
```

Generic Task:

```csharp
Task<int> GetEmployeeCountAsync();
```

| Type | Meaning |
|------|---------|
| Task | No return value |
| Task<T> | Returns a value |
| ValueTask | Lightweight alternative for certain scenarios |

---

# 🚀 Task.Run()

`Task.Run()` executes CPU-bound work on a ThreadPool thread.

```csharp
await Task.Run(() =>
{
    Console.WriteLine("Processing...");
});
```

✅ Good for

- Image processing
- PDF generation
- Complex calculations

❌ Not required for

- Database calls
- HTTP requests
- Entity Framework

---

# ⏳ Task.Delay()

Simulates asynchronous waiting without blocking the thread.

```csharp
Console.WriteLine("Starting...");

await Task.Delay(2000);

Console.WriteLine("Completed");
```

Output

```
Starting...
(wait 2 seconds)
Completed
```

---

# ⚡ Task.WhenAll()

Runs multiple asynchronous operations concurrently.

```csharp
var customerTask = GetCustomerAsync();
var policyTask = GetPolicyAsync();
var paymentTask = GetPaymentsAsync();

await Task.WhenAll(customerTask, policyTask, paymentTask);
```

Advantages

- 🚀 Faster execution
- 🔥 Better scalability
- ⚡ Ideal for multiple API calls

---

# 🏁 Task.WhenAny()

Returns the first completed task.

```csharp
var fastest = await Task.WhenAny(task1, task2, task3);

await fastest;
```

Useful for

- Multi-region APIs
- Timeouts
- Fallback services

---

# ❌ Exception Handling

Always wrap awaited code in `try-catch`.

```csharp
try
{
    await GetEmployeeAsync();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

Avoid

```csharp
async void SaveData()
{
}
```

Except for event handlers.

---

# 🛑 CancellationToken

Supports cooperative cancellation.

```csharp
var cts = new CancellationTokenSource();

await DownloadAsync(cts.Token);

cts.Cancel();
```

Benefits

- Stops unnecessary work
- Improves scalability
- Saves server resources

---

# 🔄 ConfigureAwait(false)

```csharp
await repository.GetAsync()
    .ConfigureAwait(false);
```

### Why?

Prevents capturing the synchronization context.

Useful for

- Libraries
- Background services
- Reusable components

Not generally required in ASP.NET Core because it does not use a synchronization context like classic ASP.NET or desktop UI frameworks.

---

# 📊 Task vs Thread

| Feature | Task | Thread |
|----------|------|--------|
| Lightweight | ✅ | ❌ |
| Uses ThreadPool | ✅ | ❌ |
| Easy to compose | ✅ | ❌ |
| Supports async/await | ✅ | ❌ |
| Manual management | ❌ | ✅ |

> 💡 Prefer **Task** unless you have a specific need for a dedicated thread.

---

# 📚 Common Async Methods

| Method | Purpose |
|---------|----------|
| Task.Run() | Execute CPU-bound work |
| Task.Delay() | Non-blocking delay |
| Task.WhenAll() | Wait for all tasks |
| Task.WhenAny() | Wait for first task |
| Task.FromResult() | Return completed task |
| Task.CompletedTask | Completed Task with no result |
| Task.Yield() | Yield execution |
| WaitAsync() | Timeout support (.NET 6+) |

---

# 💼 Frequently Asked Interview Questions

<details>

<summary><strong>❓ What is async?</strong></summary>

Marks a method as asynchronous and allows the use of the `await` keyword.

</details>

---

<details>

<summary><strong>❓ What is await?</strong></summary>

Suspends execution until the awaited asynchronous operation completes without blocking the current thread.

</details>

---

<details>

<summary><strong>❓ Does await create a new thread?</strong></summary>

**No.**

This is one of the most common interview questions.

`await` pauses the method and resumes it when the task completes. It does not create a new thread.

</details>

---

<details>

<summary><strong>❓ Difference between Task and Thread?</strong></summary>

Task is a higher-level abstraction built on top of ThreadPool threads.

Tasks are lightweight, easier to manage, and integrate naturally with async/await.

</details>

---

<details>

<summary><strong>❓ Difference between Task.WhenAll() and Task.WhenAny()?</strong></summary>

| Task.WhenAll | Task.WhenAny |
|--------------|--------------|
| Waits for every task | Waits for the first task |
| Throws aggregate exceptions | Returns first completed task |
| Used for parallel execution | Used for racing tasks |

</details>

---

<details>

<summary><strong>❓ async Task vs async void?</strong></summary>

| async Task | async void |
|------------|------------|
| Awaitable | Not awaitable |
| Supports exception propagation | Difficult to handle exceptions |
| Preferred | Event handlers only |

</details>

---

<details>

<summary><strong>❓ Why avoid .Result and .Wait()?</strong></summary>

These methods block the calling thread and can cause deadlocks in applications that have a synchronization context.

Prefer `await` whenever possible.

</details>

---

# 📈 Performance Tips

✅ Use asynchronous APIs whenever available.

✅ Start independent tasks before awaiting them.

```csharp
var customerTask = GetCustomerAsync();
var policyTask = GetPolicyAsync();

await Task.WhenAll(customerTask, policyTask);
```

✅ Avoid unnecessary `Task.Run()` for I/O operations.

✅ Pass `CancellationToken` to long-running operations.

---

# ❌ Common Mistakes

- ❌ Using `.Result` instead of `await`
- ❌ Calling `.Wait()`
- ❌ Using `async void`
- ❌ Wrapping database calls in `Task.Run()`
- ❌ Forgetting to await a Task
- ❌ Ignoring exceptions from background tasks
- ❌ Starting tasks sequentially when they can run concurrently
- ❌ Blocking the thread with `Thread.Sleep()`

---

# ✅ Best Practices

- ✔️ Prefer `async Task` over `async void`
- ✔️ Use `await` instead of `.Result`
- ✔️ Use `Task.WhenAll()` for independent operations
- ✔️ Use `CancellationToken` for long-running work
- ✔️ Keep asynchronous methods asynchronous from end to end
- ✔️ Avoid mixing synchronous and asynchronous code
- ✔️ Name asynchronous methods with the `Async` suffix
- ✔️ Measure performance before optimizing

---

# 🧪 Interview Challenge

Try solving these using async/await:

1. Download data from three APIs in parallel.
2. Read five files concurrently.
3. Cancel an API request after five seconds.
4. Implement a timeout using `Task.WhenAny()`.
5. Compare sequential vs parallel execution time.
6. Build an asynchronous file uploader.
7. Retry a failed API call with exponential backoff.
8. Write a console application that fetches employee, policy, and payment data simultaneously.

---

# 📚 Further Reading

- 📖 C# Language Reference
- 📖 Task Parallel Library (TPL)
- 📖 Asynchronous Programming in .NET
- 📖 Entity Framework Core Async Queries

---

## 🎯 Key Takeaways

- `async` enables asynchronous methods.
- `await` **does not create a new thread**.
- Prefer `Task` over `Thread`.
- Use `Task.WhenAll()` for parallel operations.
- Avoid `.Result` and `.Wait()`.
- Keep your code asynchronous from top to bottom.
- Always write async code with scalability and readability in mind.

---

⭐ **If you found this guide helpful, consider giving this repository a star and exploring the other topics in the CSharp Interview Lab!**
