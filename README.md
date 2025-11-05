# SharpE2E

SharpE2E is a modern, code-centric UI test framework for automated end-to-end testing of Windows applications, built with .NET 8.0 and C#. Its primary focus is on WPF applications, with planned support for WinForms, WinUI, and web technologies (such as Razor Pages) in the future.

## Project Goals

- **Modular Architecture:** Clean separation of concerns for launching apps, finding UI elements, performing actions, waiting, assertions, and input simulation.
- **Developer-Friendly API:** Intuitive, readable, and maintainable test code with minimal boilerplate.
- **DSL-Ready:** Supports a fluent, declarative syntax for writing expressive UI tests.
- **Extensible:** Designed for easy extension to new UI platforms and test scenarios.

## Key Features

- **App Launching:** Start and manage the lifecycle of the application under test.
- **UI Element Discovery:** Locate windows and UI elements using Microsoft UI Automation (UIA).
- **Element Actions:** Interact with UI elements (e.g., click buttons, read text).
- **Polling & Waiting:** Wait for elements to become available using robust polling strategies.
- **Assertions (Planned):** Fluent assertions for verifying UI states and behaviors.
- **Input Simulation (Planned):** Keyboard and mouse input handling for advanced scenarios.
- **Inspector App (Planned):** Visual tool for inspecting UI elements and generating test code snippets.

## Example Usage

```
var app = AppLauncher.Launch("MyApp.exe"); 
var window = WaitHelper.WaitUntilElementExists(() => ElementFinder.FindWindowByTitle("MainWindow"));
var loginButton = ElementFinder.FindElementByAutomationId(window, "LoginButton");
new ElementWrapper(loginButton).Click();
```


## Project Structure

- `SharpE2E.Core`
  - `Fw/AppLauncher.cs` – Launches and manages the test app
  - `Ui/ElementFinder.cs` – Finds windows and UI elements
  - `ElementWrapper.cs` – Wraps UI elements for actions (Click, GetText, etc.)
  - `Utilities/WaitHelper.cs` – Waits for element availability
  - `Assertions/` – (Planned) Fluent assertions
  - `Input/` – (Planned) Keyboard and mouse input

## Technology

- **Language:** C# 12.0
- **Framework:** .NET 8.0 (Windows)
- **UI Automation:** Uses `System.Windows.Automation.AutomationElement` (UIA)

## Roadmap

1. Return `ElementWrapper` from element-finding helpers for easier, testable code.
2. Expand `ElementWrapper` with more actions and state checks.
3. Introduce a fluent DSL for readable, declarative test code.
4. Improve error handling and logging.
5. Build a WPF-based Inspector app for UI element discovery.
6. Prepare for NuGet packaging and public release.

---

SharpE2E aims to make UI automation for Windows apps robust, flexible, and enjoyable for developers.

# Disclaimer

This project is being developed with the assistance of AI tools to accelerate development and improve code quality. While I have a solid understanding of software development, I am still exploring the best practices and nuances of working with `System.Windows.Automation` for UI automation in .NET.

If you are experienced with `System.Windows.Automation` or have insights into building robust and developer-friendly UI test frameworks, I would greatly appreciate your feedback, suggestions, or contributions to this project. Your expertise could help refine the library and ensure it adheres to best practices.

Feel free to open an issue, submit a pull request, or reach out directly if you'd like to collaborate. Thank you! 🙌
