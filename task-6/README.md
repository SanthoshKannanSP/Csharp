# Task-6 - Delegates, Events, and Basic Event Handling

## Requirements
- Build a console-based event-driven application (e.g., a counter that triggers an event at a threshold).
- Define a delegate and an event that fires when a counter reaches a specific value.
- Create multiple event handler methods that perform actions when the event is raised.
- In your main loop, increment the counter and raise the event when appropriate.
- Demonstrate how events can decouple the producer and consumer logic

## Overview of program
This program implements a **Counter** that increments by random value and raises an **OnCounterChanged** event when the counter value changes.

The **OnCounterChanged** event is listened to by
- **EvenListener** that prints to console whenever the counter value is even.
- **Logger** that logs the counter value to a file (`log.txt`).

## How to run
```
dotnet run
```

## References
- https://www.youtube.com/watch?v=gOuAqRaDdHA
- https://www.udemy.com/course/ultimate-csharp-masterclass
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
- https://learn.microsoft.com/en-us/dotnet/standard/events/