# 🎯 C# Delegates Interview Guide

> A practical guide to understanding **Delegates** in C#. Learn how delegates work, when to use them, and how they power modern C# features such as **Events**, **LINQ**, **Lambda Expressions**, and **async/await**.

---

# 📖 Table of Contents

- 📌 What is a Delegate?
- 🎯 Why Use Delegates?
- ⚙️ How Delegates Work
- 🔧 Declaring a Delegate
- 💻 Using Delegates
- 🔄 Multicast Delegates
- ⚡ Built-in Delegates
  - Action
  - Func
  - Predicate
- 📝 Anonymous Methods
- 🚀 Lambda Expressions
- 📢 Delegates vs Events
- 🌍 Real-World Examples
- 💼 Frequently Asked Interview Questions
- 📈 Performance Considerations
- ❌ Common Mistakes
- ✅ Best Practices
- 🧪 Interview Challenges

---

# 📌 What is a Delegate?

A **delegate** is a **type-safe function pointer**.

It allows you to:

- 📞 Pass methods as parameters
- 🔄 Store references to methods
- 🚀 Execute methods dynamically
- 📢 Implement callbacks
- ⚡ Build event-driven applications

Unlike traditional function pointers in C/C++, delegates are **safe**, **object-oriented**, and **fully managed** by the .NET runtime.

---

# 🎯 Why Use Delegates?

| Benefit | Description |
|---------|-------------|
| 🔒 Type Safe | Only compatible methods can be assigned |
| 🔄 Flexible | Methods can be changed at runtime |
| 📢 Event Driven | Foundation of C# events |
| ⚡ Reusable | Encourages loose coupling |
| 🧩 Extensible | Makes applications easier to extend |
| 🚀 Supports Functional Programming | Enables LINQ and Lambda Expressions |

---

# ⚙️ How Delegates Work

```
+----------------------+
|      Program         |
+----------+-----------+
           |
           | invokes
           ▼
+----------------------+
|      Delegate        |
+----------+-----------+
           |
           | references
           ▼
+----------------------+
|        Method        |
+----------------------+
```

A delegate acts as an intermediary between the caller and the method.

---

# 🔧 Declaring a Delegate

```csharp
public delegate void DisplayMessage(string message);
```

The delegate can reference any method having the same signature.

```csharp
public static void Print(string message)
{
    Console.WriteLine(message);
}

DisplayMessage display = Print;

display("Hello World");
```

Output

```
Hello World
```

---

# 💻 Delegate Example

```csharp
public delegate int MathOperation(int a, int b);

public static int Add(int x, int y)
{
    return x + y;
}

MathOperation operation = Add;

Console.WriteLine(operation(10,20));
```

Output

```
30
```

---

# 🔄 Multicast Delegates

A multicast delegate can reference **multiple methods**.

```csharp
public delegate void Notification();

Notification notify = EmailNotification;
notify += SmsNotification;
notify += PushNotification;

notify();
```

Execution Order

```
Email
   ↓
SMS
   ↓
Push Notification
```

> 💡 **Interview Tip**
>
> Delegates invoke subscribed methods in the order they were added.

---

# ⚡ Built-in Delegates

## Action

Represents a method that **does not return a value**.

```csharp
Action<string> print = Console.WriteLine;

print("Hello");
```

---

## Func

Represents a method that **returns a value**.

```csharp
Func<int,int,int> add = (x,y) => x + y;

Console.WriteLine(add(10,20));
```

Output

```
30
```

---

## Predicate

Represents a method returning **bool**.

```csharp
Predicate<int> isEven = number => number % 2 == 0;

Console.WriteLine(isEven(10));
```

Output

```
True
```

---

# 📝 Anonymous Methods

Before Lambda Expressions, anonymous methods were introduced.

```csharp
Action message = delegate
{
    Console.WriteLine("Hello");
};

message();
```

Although still supported, Lambda Expressions are generally preferred.

---

# 🚀 Lambda Expressions

Lambda expressions provide a concise syntax for delegates.

Instead of

```csharp
delegate(int number)
{
    return number > 18;
}
```

Use

```csharp
number => number > 18
```

Example

```csharp
Func<int,int> square = x => x * x;

Console.WriteLine(square(8));
```

Output

```
64
```

---

# 📢 Delegates vs Events

| Delegate | Event |
|-----------|-------|
| Can be invoked directly | Can only be raised by the declaring class |
| Used for callbacks | Used for notifications |
| Allows direct invocation | Prevents outside invocation |
| More flexible | More secure |

> 💡 Every **Event** is built on top of a **Delegate**.

---

# 🌍 Real-World Examples

## 1️⃣ Logging Framework

```csharp
logger.Log(message => Console.WriteLine(message));
```

---

## 2️⃣ Sorting

```csharp
employees.Sort((x,y) =>
    x.Salary.CompareTo(y.Salary));
```

---

## 3️⃣ Filtering

```csharp
employees.Where(e => e.Department == "IT");
```

---

## 4️⃣ Callbacks

```csharp
DownloadFile(OnCompleted);
```

---

## 5️⃣ Events

```csharp
button.Click += SaveButton_Click;
```

---

# 📊 Delegate Family

| Type | Returns Value | Parameters |
|--------|---------------|------------|
| Delegate | Optional | Any |
| Action | No | Up to 16 |
| Func | Yes | Up to 16 |
| Predicate | bool | One |

---

# 🔍 Delegate vs Interface

| Delegate | Interface |
|-----------|-----------|
| Represents one method | Represents a contract |
| Runtime flexibility | Compile-time implementation |
| Better for callbacks | Better for object behavior |

---

# 🧠 Delegate Execution Flow

```
Program
   │
   ▼
Delegate Variable
   │
   ▼
Method Reference
   │
   ▼
Method Execution
```

---

# 💼 Frequently Asked Interview Questions

<details>

<summary><strong>❓ What is a Delegate?</strong></summary>

A delegate is a type-safe object that references one or more methods with the same signature.

</details>

---

<details>

<summary><strong>❓ Why are Delegates called Type Safe?</strong></summary>

Because only methods with matching signatures can be assigned.

</details>

---

<details>

<summary><strong>❓ What is a Multicast Delegate?</strong></summary>

A delegate capable of invoking multiple methods sequentially.

</details>

---

<details>

<summary><strong>❓ Difference between Action and Func?</strong></summary>

| Action | Func |
|---------|------|
| Returns void | Returns a value |

</details>

---

<details>

<summary><strong>❓ Difference between Func and Predicate?</strong></summary>

Predicate always returns **bool**.

Func can return any type.

</details>

---

<details>

<summary><strong>❓ Can delegates return values?</strong></summary>

Yes.

Only the last method's return value is available when using multicast delegates.

</details>

---

<details>

<summary><strong>❓ Are delegates reference types?</strong></summary>

Yes.

All delegates inherit from `System.MulticastDelegate`.

</details>

---

<details>

<summary><strong>❓ Why are delegates used in LINQ?</strong></summary>

Methods like `Where()`, `Select()`, and `OrderBy()` accept delegates (usually as lambda expressions) to define filtering, projection, and sorting behavior.

</details>

---

<details>

<summary><strong>❓ Why are delegates important for async/await?</strong></summary>

The Task Parallel Library, callbacks, continuations, and many asynchronous APIs rely on delegates to execute work and resume operations.

</details>

---

# 📈 Performance Considerations

| Scenario | Recommendation |
|----------|----------------|
| Frequent callbacks | ✅ Use delegates |
| Event notifications | ✅ Use events |
| Heavy object contracts | ✅ Use interfaces |
| Performance critical loops | Avoid unnecessary delegate allocations |

---

# ❌ Common Mistakes

- ❌ Confusing delegates with events
- ❌ Using custom delegates instead of `Action` or `Func`
- ❌ Forgetting to unsubscribe from events
- ❌ Overusing multicast delegates
- ❌ Creating unnecessary delegate instances inside loops
- ❌ Ignoring null checks before invocation

---

# ✅ Best Practices

- ✔️ Prefer `Action`, `Func`, and `Predicate` over custom delegates when appropriate.
- ✔️ Use delegates for callbacks.
- ✔️ Use events for notifications.
- ✔️ Keep delegate methods short and focused.
- ✔️ Use lambda expressions for readability.
- ✔️ Avoid capturing unnecessary variables in lambdas.
- ✔️ Unsubscribe from events to prevent memory leaks.

---

# 🧪 Interview Challenge

Try implementing the following using delegates:

1. Build a simple calculator using delegates.
2. Create a logging framework using `Action<string>`.
3. Filter employees using `Predicate<Employee>`.
4. Sort employees by salary using `Comparison<Employee>`.
5. Implement a notification system using multicast delegates.
6. Pass a delegate as a callback after downloading a file.
7. Replace custom delegates with `Func` and `Action`.
8. Convert anonymous methods into lambda expressions.

---

# 🎯 Key Takeaways

- 🎯 Delegates are **type-safe function pointers**.
- ⚡ They enable callbacks, events, LINQ, and asynchronous programming.
- 🚀 `Action`, `Func`, and `Predicate` cover most delegate scenarios.
- 📢 Events are built on top of delegates.
- 🧠 Lambda expressions are simply a concise way to create delegates.
- 💼 Delegates are one of the most frequently asked topics in C# interviews.

---

⭐ **If you found this guide useful, consider giving this repository a ⭐ and explore the remaining modules in the CSharp Interview Lab!**