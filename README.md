# Book of Bruh

A WPF-based slot machine game built with .NET 10, featuring custom symbols, pattern matching, and animated reels.

## Overview

**Book of Bruh** is a desktop slot machine application that simulates a gambling experience with custom "Bruh" themed symbols. The game features:

- 5 animated reels with 3 visible symbols each
- Multiple winning patterns (lines, diagonals, triangles, U-shapes, and flash patterns)
- Virtual currency system (BruhCoins)
- Customizable stake amounts
- Wild symbol substitution
- Pattern-based win multipliers

## Architecture

The solution follows a clean architecture approach with clear separation of concerns:

### Projects

#### BookOfBruh.Core
Core business logic and game mechanics:
- **SlotMachine**: Main game engine coordinating reel spins, analysis, and state management
- **Symbols**: Symbol definitions (A, J, K, Q, 10, Joegi, Simi, Vinc, Wild)
- **SlotAnalysation**: Win detection through pattern matchers (Line, Diagonal, Triangle, U-Pattern, Flash)
- **SlotGeneration**: Random symbol generation and reel creation
- **Reels**: Reel spinning mechanics with speed calculations
- **CodeValidation**: Input validation for cheat codes
- **State Machine**: Game state management (NotEnoughBruhCoin, CanBuy, CanSpin states)

#### BookOfBruh.View
WPF presentation layer:
- **MVVM Architecture**: ViewModels with PropertyChanged.Fody for automatic INotifyPropertyChanged
- **Dependency Injection**: Ninject for IoC container
- **Custom Controls**: Slot display, control panel, stake selection, wallet management, win display
- **Animations**: Reel spinning with WpfAnimatedGif
- **Commands**: Async relay commands for responsive UI

#### BookOfBruh.Core.Test
Unit tests for core logic:
- Pattern matcher tests (all pattern types)
- Slot analyzer integration tests
- Symbol generator tests
- Reel mechanics tests
- Code validator tests
- Uses: xUnit v3, AwesomeAssertions, Ninject

#### BookOfBruh.View.AcceptanceTest
Acceptance/integration tests for UI:
- SpecFlow BDD tests
- Control flow tests
- Slot interaction tests
- Stake management tests
- Uses: SpecFlow, xUnit v3, AwesomeAssertions

## Technology Stack

- **.NET 10.0**: Latest .NET framework
- **WPF**: Windows Presentation Foundation for UI
- **C#**: Primary language
- **Ninject**: Dependency injection
- **PropertyChanged.Fody**: Automatic property change notifications
- **CSharpFunctionalExtensions**: Result pattern and functional programming utilities
- **xUnit v3**: Testing framework
- **SpecFlow**: BDD acceptance testing
- **AwesomeAssertions**: Fluent assertion library
- **WpfAnimatedGif**: GIF animation support

## Getting Started

### Prerequisites

- Visual Studio 2026 or later
- .NET 10.0 SDK
- Windows OS (for WPF)

### Building the Solution

1. Clone the repository:
   ```bash
   git clone https://github.com/SimonRuckli/Book-of-Bruh.git
   cd Book-of-Bruh
   ```

2. Open `BookOfBruh.sln` in Visual Studio

3. Restore NuGet packages (automatic in VS 2026)

4. Build the solution:
   - Press `Ctrl+Shift+B` or
   - Build → Build Solution

### Running the Application

1. Set `BookOfBruh.View` as the startup project
2. Press `F5` to run with debugging or `Ctrl+F5` to run without debugging
3. The slot machine window will appear

### Running Tests

#### Unit Tests
```bash
dotnet test src\BookOfBruh.Core.Test\BookOfBruh.Core.Test.csproj
```

#### Acceptance Tests
```bash
dotnet test src\BookOfBruh.View.AcceptanceTest\BookOfBruh.View.AcceptanceTest.csproj
```

Or use Visual Studio Test Explorer:
- Test → Test Explorer
- Click "Run All Tests"

## How to Play

1. **Starting Balance**: You begin with a set amount of BruhCoins in your wallet
2. **Set Stake**: Click the stake button to select your bet amount per spin
3. **Spin**: Click the spin button to start the reels
4. **Winning**: Matching symbols in recognized patterns award multiplied wins
5. **Wild Symbols**: Wild symbols substitute for any other symbol to complete patterns

### Winning Patterns

- **Line**: 3+ matching symbols in a horizontal row
- **Diagonal**: Matching symbols in diagonal formations
- **Triangle**: Triangle-shaped matching patterns
- **U-Pattern**: U-shaped matching patterns
- **Flash**: Full screen of the same symbol (highest payout)

### Symbol Values

Each symbol has a specific multiplier value (example values):
- **Wild**: Substitutes for any symbol
- **High-Value Symbols**: Joegi (2.3x), Simi, Vinc
- **Mid-Value Symbols**: A, K, Q, J
- **Low-Value Symbols**: 10

## Project Structure

```
Book-of-Bruh/
├── src/
│   ├── BookOfBruh.Core/                 # Core game logic
│   │   ├── CodeValidation/              # Input validation
│   │   ├── GameData/                    # Game data models
│   │   ├── Reels/                       # Reel mechanics
│   │   ├── SlotAnalysation/             # Win detection
│   │   │   └── PatternMatchers/         # Pattern algorithms
│   │   ├── SlotGeneration/              # Symbol generation
│   │   ├── Symbols/                     # Symbol definitions
│   │   ├── SlotMachine.cs               # Main game engine
│   │   └── SlotMachineState.cs          # State machine
│   │
│   ├── BookOfBruh.View/                 # WPF application
│   │   ├── Control/                     # Control panel UI
│   │   ├── Images/                      # Symbol images
│   │   ├── Infrastructure/              # DI, commands, events
│   │   ├── Main/                        # Main window
│   │   ├── Slot/                        # Slot display
│   │   ├── Stake/                       # Stake selection
│   │   ├── Wallet/                      # Wallet management
│   │   ├── Win/                         # Win display
│   │   └── Styles/                      # XAML styles
│   │
│   ├── BookOfBruh.Core.Test/            # Unit tests
│   │   ├── Helper/                      # Test helpers
│   │   ├── SlotAnalysation/             # Pattern tests
│   │   └── ...
│   │
│   └── BookOfBruh.View.AcceptanceTest/  # Acceptance tests
│       ├── Infrastructure/              # Test infrastructure
│       └── ...                          # SpecFlow features
│
└── README.md
```

## Design Patterns

- **State Pattern**: Game state management (NotEnoughBruhCoin, CanBuy, CanSpin states)
- **Strategy Pattern**: Pattern matchers for different winning combinations
- **Observer Pattern**: Event-driven communication between ViewModels
- **Repository Pattern**: Symbol and reel generation
- **MVVM Pattern**: Separation of UI and business logic
- **Dependency Injection**: Ninject for loose coupling

## Key Features

### Pattern Matching System
The game uses a sophisticated pattern matching system with multiple strategies:
- Each pattern type (Line, Diagonal, Triangle, U, Flash) is implemented independently
- Composite pattern matcher coordinates all strategies
- Extensible design allows easy addition of new pattern types

### Reel Animation
- Smooth spinning animation with configurable speed
- Speed calculation with acceleration/deceleration
- Async/await for non-blocking UI

### State Management
- Clean state machine implementation
- States: NotEnoughBruhCoin, CanBuy, CanSpin
- Automatic state transitions based on wallet balance and stake

### Wild Symbol Logic
- Wild symbols substitute for any symbol
- Intelligent pattern matching with wild consideration
- Separate calculator for wild symbol multipliers

## Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Code Style
- Follow existing C# coding conventions
- Use meaningful variable and method names
- Add XML documentation for public APIs
- Write unit tests for new features
- Ensure all tests pass before submitting PR

## Testing Strategy

- **Unit Tests**: Test individual components in isolation
- **Integration Tests**: Test component interactions
- **Acceptance Tests**: BDD-style tests for user scenarios
- **Test Coverage**: Aim for high coverage of core logic

## License

This project is available under the terms specified by the repository owner.

## Authors

- **Simon Ruckli** - [GitHub Profile](https://github.com/SimonRuckli)

## Acknowledgments

- Built with WPF and .NET 10
- Uses modern C# features and functional programming concepts
- Inspired by classic slot machine games

---

**Note**: This is a demonstration/educational project. No real money is involved.
