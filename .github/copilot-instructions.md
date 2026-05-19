# GitHub Copilot Instructions for Book of Bruh

## Project Overview

Book of Bruh is a WPF slot machine game built with .NET 10, following clean architecture principles with MVVM pattern, dependency injection, and comprehensive testing.

## Code Style and Conventions

### C# Conventions
- Use meaningful variable and method names that clearly convey intent
- Prefer explicit types over `var` unless the type is obvious from the right side
- Use expression-bodied members for simple properties and methods
- Follow Microsoft's C# coding conventions
- Use `this.` prefix for instance members consistently (as seen throughout the codebase)
- Keep methods small and focused on a single responsibility

### Naming Conventions
- **Interfaces**: Prefix with `I` (e.g., `ISlotMachine`, `IPatternMatcher`)
- **Private fields**: Use camelCase with `this.` prefix (e.g., `this.codeValidator`)
- **Properties**: Use PascalCase (e.g., `BruhCoins`, `Stake`)
- **Methods**: Use PascalCase with verb prefix (e.g., `Analyze()`, `Generate()`)
- **Events**: Use PascalCase with descriptive names (e.g., `StartedSpin`, `FinishedSpin`)

### File Organization
- One class per file
- File name must match the class name
- Organize files by feature/domain:
  - Core logic in `BookOfBruh.Core`
  - UI in `BookOfBruh.View`
  - Tests mirror the structure of what they test

## Architecture Guidelines

### Project Structure

#### BookOfBruh.Core (Business Logic)
- **Pure business logic**: No UI dependencies, no WPF references
- **Dependency Injection**: All dependencies injected via constructor
- **Immutability**: Prefer immutable data structures where appropriate
- **Functional patterns**: Use CSharpFunctionalExtensions for Result types and functional composition

#### BookOfBruh.View (Presentation)
- **MVVM Pattern**: Strict separation of View (XAML) and ViewModel (C#)
- **PropertyChanged.Fody**: All ViewModels inherit from `NotifyPropertyChangedBase`
- **No code-behind logic**: ViewModels contain all presentation logic
- **Commands**: Use `RelayCommand` or `AsyncRelayCommand` for user actions
- **Dependency Injection**: Ninject for IoC container (configured in `BookOfBruhModule`)

### Dependency Injection

All dependencies are registered in `BookOfBruhModule.cs`:
```csharp
this.Bind<IInterface>().To<Implementation>().InSingletonScope();
```

- Use constructor injection exclusively
- Register interfaces, not concrete types (except ViewModels)
- ViewModels are singletons to maintain state across the application
- Core services (SlotMachine, Analyzers, Generators) are singletons

### State Management

The project uses the **State Pattern** for game state management:
- `SlotMachineState` base class
- Concrete states: `NotEnoughBruhCoinState`, `CanBuyState`, `CanSpinState`
- State transitions are automatic based on game conditions
- Always use `this.State.Handle()` after modifying relevant properties

## Design Patterns in Use

### Strategy Pattern
Used for pattern matching:
- `IPatternMatcher` interface with multiple implementations
- `LinePatternMatcher`, `DiagonalPatternMatcher`, `TrianglePatternMatcher`, `UPatternMatcher`, `FlashPatternMatcher`
- Composite pattern matcher coordinates all strategies

### Observer Pattern
Event-driven communication between ViewModels:
```csharp
public event EventHandler<StakeEventArgs> StakeChanged;
```
- Use strongly typed EventArgs for event data
- Subscribe in constructors, unsubscribe in Dispose (if needed)

### Repository Pattern
Symbol and reel generation:
- `ISymbolGenerator`, `IReelsGenerator`, `ISymbolListGenerator`
- Encapsulate random generation logic

## Testing Guidelines

### Unit Tests (BookOfBruh.Core.Test)
- **Framework**: xUnit v3
- **Assertions**: AwesomeAssertions for fluent syntax
- **Naming**: `[MethodName]_[Scenario]_[ExpectedResult]`
- **Structure**: Arrange-Act-Assert pattern
- **Helpers**: Use `PatternTestHelper` and `SymbolTestHelper` for common test setup
- **DI**: Use `TestModule` for test-specific bindings

Example:
```csharp
[Fact]
public void Analyze_LinePattern_ReturnsCorrectMultiplier()
{
	// Arrange
	var slots = PatternTestHelper.CreateSlotsWithLine();

	// Act
	var result = slotAnalyzer.Analyze(slots);

	// Assert
	result.Multiplier.Should().BeGreaterThan(0);
}
```

### Acceptance Tests (BookOfBruh.View.AcceptanceTest)
- **Framework**: SpecFlow with xUnit v3
- **Pattern**: Given-When-Then BDD style
- **Step Definitions**: Use step classes (e.g., `ControlStep`, `SlotStep`, `StakeStep`)
- **Test Infrastructure**: Use `BookOfBruhTestModule` for test DI setup
- **Fakes**: Use `FakeSlotConverter` and similar for controlled testing

## WPF and XAML Guidelines

### XAML
- Use meaningful `x:Name` attributes for controls that need code-behind access
- Leverage data binding: `{Binding PropertyName}`
- Use converters for complex binding logic (e.g., `SymbolConverter`, `IsPatternConverter`)
- Separate styles in `Styles\Styles.xaml`
- Use `Microsoft.Xaml.Behaviors.Wpf` for interactions

### ViewModels
- Inherit from `NotifyPropertyChangedBase`
- PropertyChanged.Fody automatically implements INotifyPropertyChanged
- No manual property setters needed (Fody weaves them in)
- Use backing fields for properties that need validation or side effects

Example:
```csharp
public class MyViewModel : NotifyPropertyChangedBase
{
	private double stake;

	public double Stake
	{
		get => stake;
		set
		{
			stake = value;
			this.State.Handle(); // Side effect
			OnPropertyChanged(); // Fody handles this automatically
		}
	}
}
```

### Commands
- Use `RelayCommand` for synchronous operations
- Use `AsyncRelayCommand` for async operations (spinning reels, etc.)
- Define commands as properties in ViewModels
- Bind to XAML: `Command="{Binding SpinCommand}"`

## Symbol and Pattern System

### Symbols
All symbols implement `ISymbol`:
```csharp
public interface ISymbol
{
	double Value { get; }
}
```

- Each symbol has a multiplier value
- Wild symbol substitutes for any symbol
- Symbols are structs for performance

### Pattern Matching
Pattern matching is extensible:
1. Create new interface (e.g., `INewPatternMatcher`)
2. Implement the interface
3. Add to `PatternMatcher` constructor
4. Register in `BookOfBruhModule`

## Async/Await Guidelines

- Use `async Task` for operations that return void in ViewModels
- Use `AsyncRelayCommand` for async user actions
- Reel spinning is async: `await Task.Delay()` for animation timing
- Never block on async code: no `.Result` or `.Wait()`

## Common Pitfalls to Avoid

1. **Don't add WPF references to Core project**: Keep Core pure business logic
2. **Don't put logic in code-behind**: Use ViewModels for all logic
3. **Don't forget state transitions**: Call `this.State.Handle()` after property changes
4. **Don't hardcode speeds**: Use `ISpeedCalculator` for reel speeds
5. **Don't bypass dependency injection**: Always inject dependencies, never use `new` for services
6. **Don't forget to update tests**: Add tests for new features

## Adding New Features

### Adding a New Symbol
1. Create a new struct in `BookOfBruh.Core/Symbols/` implementing `ISymbol`
2. Add image to `BookOfBruh.View/Images/`
3. Update `SymbolConverter` to handle the new symbol
4. Add to symbol generation logic in `SymbolGenerator`
5. Write unit tests in `BookOfBruh.Core.Test`

### Adding a New Pattern Type
1. Create interface in `BookOfBruh.Core/SlotAnalysation/PatternMatchers/`
2. Implement the matcher
3. Add to `PatternMatcher` constructor and `FindMatches` method
4. Register in `BookOfBruhModule`
5. Write unit tests in `BookOfBruh.Core.Test/SlotAnalysation/PatternMatcherTests/`

### Adding a New ViewModel
1. Create ViewModel class inheriting from `NotifyPropertyChangedBase`
2. Create corresponding View (UserControl with XAML)
3. Define events for communication with parent ViewModels
4. Register in `BookOfBruhModule`
5. Wire up events in `MainWindowViewModel`
6. Write acceptance tests

## Performance Considerations

- **Reel spinning**: Use `Task.Delay()` for smooth animation without blocking UI
- **Pattern matching**: Short-circuit on first match when appropriate
- **Symbol generation**: Use `Random` instance (already initialized in `SlotMachine`)
- **WPF binding**: Minimize property change notifications (Fody helps here)

## Code Review Checklist

Before committing code, ensure:
- [ ] All tests pass (unit and acceptance)
- [ ] New features have corresponding tests
- [ ] No WPF dependencies in Core project
- [ ] ViewModels properly raise property change notifications
- [ ] Dependencies are injected, not instantiated
- [ ] Async/await used correctly (no blocking)
- [ ] State transitions are handled properly
- [ ] Meaningful variable and method names
- [ ] Code follows existing style conventions
- [ ] No commented-out code

## Build and Debug

- **Solution**: All projects target .NET 10
- **Startup Project**: `BookOfBruh.View`
- **Build Configuration**: Debug for development, Release for production
- **Test Discovery**: xUnit v3 with Visual Studio Test Explorer
- **NuGet**: Central Package Management (versions in Directory.Packages.props if present)

## Version Control

- **Branch**: Currently on `feature/upgradeToDotnet10`
- **Commits**: Use clear, descriptive commit messages
- **PR**: Ensure all tests pass before creating pull request

## Additional Notes

- This is a demonstration/educational project (no real money)
- Custom "Bruh" themed symbols (Joegi, Simi, Vinc)
- Cheat code system exists (see `CodeValidator`)
- PropertyChanged.Fody requires `FodyWeavers.xml` configuration
- SonarLint is configured for code quality analysis

## Resources

- [WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [MVVM Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm)
- [Ninject Documentation](http://www.ninject.org/)
- [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged)
- [xUnit Documentation](https://xunit.net/)
- [SpecFlow Documentation](https://specflow.org/)
