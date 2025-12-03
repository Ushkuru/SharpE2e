using System.Windows;
using System.Windows.Automation;
using SharpE2e.Core.Enum;
using SharpE2e.Core.Input;

namespace SharpE2e.Core
{
    public class ElementWrapper
    {

        public string Name => this._element.Current.Name;

        public string ClassName => this._element.Current.ClassName;

        public bool IsEnabled => this._element.Current.IsEnabled;

        protected Rect BoundingRect => this._element.Current.BoundingRectangle;

        protected bool IsOffscreen => this._element.Current.IsOffscreen;

        internal readonly AutomationElement _element;

        public ElementWrapper(AutomationElement element)
        {
            this._element = element;
        }

        public void Click()
        {
            this.SetFocus();

            this.Click((int)this.BoundingRect.Width / 2, (int)this.BoundingRect.Height / 2);
        }

        public void Click(int x, int y)
        {
            if (this.BoundingRect.IsEmpty)
            {
                throw new InvalidOperationException("The element's bounding rectangle is empty. Cannot perform a click.");
            }
            else if (!this.IsEnabled)
            {
                throw new InvalidOperationException("The element isn't enabled. Cannot perform a click.");
            }
            else if (this.IsOffscreen)
            {
                throw new InvalidOperationException("The element is Offscreen. Cannot perform a click.");
            }

            x = (int)this.BoundingRect.Left + x;
            y = (int)this.BoundingRect.Top + y;

            Mouse.SetCursorPosition(x, y);
            this.MouseClick();
        }

        public void SetFocus()
        {
            this._element.SetFocus();
        }


        private void MouseClick()
        {
            Mouse.MouseEvent(MouseEvent.LeftDown);
            Mouse.MouseEvent(MouseEvent.LeftUp);
        }
    }
}


//This is the prompt for the generation of this Project:
//Ziel: Ich baue ein modernes, codezentriertes UI-Test-Framework in .NET 8 für Windows-Anwendungen, das modular, DSL-fähig und developerfreundlich ist.

//Ich entwickle eine eigene .NET-Library (C#, NuGet-kompatibel) für automatisierte End-to-End-Tests von Windows-Anwendungen, primär mit WPF, später evtl. auch WinForms, WinUI oder Web (Razor Pages).

//Der Projektname ist derzeit „SharpE2E“.

//Ich habe bereits ein funktionierendes Basisprojekt/Bibliothek diese basiert auf Microsoft UI Automation (UIA). Ich verwende .NET 8.0 mit `TargetFramework=net8.0-windows`, sodass ich Zugriff auf `System.Windows.Automation.AutomationElement` habe.

//Derzeitiger Stand der Projektstruktur:

//SharpE2E.Core /
//├── Fw / AppLauncher.cs      → Startet und verwaltet die zu testende App
//├── Ui/ElementFinder.cs      → Findet Fenster und UI-Elemente (aktuell: AutomationElement)
//├── ElementWrapper.cs        → Führt Aktionen auf Elementen aus (Click, GetText, ...)
//├── Utilities/WaitHelper.cs  → Wartet auf Elementverfügbarkeit via Polling
//├── Assertions/              → Derzeit leer, geplant um Zustände zu prüfen (und/oder Fluent Assertions)
//├── Input/                   → Derzeit auch leer sollte sich um Eingaben (Tastatur, Maus) kümmern

//---

//```csharp
//var app = AppLauncher.Launch("MyApp.exe");
//var window = ElementFinder.FindWindowByTitle("MainWindow");
//var loginButton = ElementFinder.FindElementByAutomationId(window, "LoginButton");
//new ElementWrapper(loginButton).Click();
//```

//---

//Jetzt möchte ich konkrete strukturelle und funktionale **nächste Schritte**, damit sich daraus eine flexible, saubere Library ergibt. Bitte den bisherigen Stand dabei beibehalten und nur schrittweise verbessern.

//**Die nächsten Schritte sollen beinhalten:**

//1. * *AutomationHelper soll direkt `ElementWrapper` statt `AutomationElement` zurückgeben**, damit der Aufrufer gleich testbare Methoden zur Verfügung hat.
//   - Ziel: weniger wiederholter Wrapper-Aufbau im Aufrufercode.
//   - Optional: intern `TryFind`/`FindOrThrow` o. ä. für gutes Fehlerhandling.

//2. **ElementWrapper**:
//   -Unterstützt `.Click()`, `.GetText()`
//   -Später auch `.SetText()`, `.IsEnabled()`, `.Highlight()` etc.
//   - Kapselt intern den Zugriff auf `AutomationElement` und Patterns
//   - Sollte ggf. Factory-Pattern nutzen (z. B. `ElementWrapper.From(...)`)

//3. Einführung einer einfachen **Fluent-DSL-Syntax**, z. B.:

//```csharp
//TestApp("MyApp.exe")
//   .Window("MainWindow")
//   .Button("LoginButton").Click()
//   .Text("WelcomeMessage").Should().Contain("Willkommen");
//```

// Die ueberpruefung koennte mit FluentAssertions erfolgen.

//   - Ziel: lesbarer, deklarativer Testcode
//   - Muss nicht sofort vollständig sein – ein MVP reicht erstmal

//4. **Fehlerbehandlung**:
//   -Unterschied zwischen „nicht gefunden“ und „mehrfach gefunden“
//   - Exceptions mit Elementdetails
//   - Optionale Logging-Ausgabe, evtl. mit `ILogger`-Support oder einfachem Logger

//5. Aufbau der separaten WPF-Inspektor-App (`SharpE2E.Inspector`):
//   -Erkennt UI-Elemente unter dem Mauszeiger (z. B. per HitTest)
//   - Zeigt deren Properties (AutomationId, Name, ControlType)
//   - Kopiert fertigen Testcode (z. B. `Button("LoginButton").Click();`) ins Clipboard
//   - Nutzt intern die gleiche Core-Library (`SharpE2E.Core`)

//6. Später: Hinweise zur Vorbereitung für NuGet-Veröffentlichung:
//   -Paketstruktur: `SharpE2E.Core`, `SharpE2E.Inspector`, `SharpE2E.Fluent` etc.
//   - Namenskonventionen, Abhängigkeiten minimieren
//   - Nutzung in eigenen Testprojekten

//---

//Bitte diesen Kontext vollständig merken und danach fortsetzen – beginnend mit Schritt 1: 
//**AutomationHelper gibt künftig `ElementWrapper` zurück**, und das Ganze wird testbar, robust und lesbar aufgebaut.

