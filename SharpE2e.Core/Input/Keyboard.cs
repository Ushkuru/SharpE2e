using System.Runtime.InteropServices;
using SharpE2e.Core.Enum;

internal static class Keyboard
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    private const uint KEYEVENTF_KEYDOWN = 0x0000;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    private static void PressKey(KeyCode key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
    }

    public static void ClickKey(KeyCode key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    public static void SendText(string text)
    {
        foreach (char c in text)
        {
            // Prüfe, ob der Charakter ein Großbuchstabe ist
            var isUpperCase = char.IsUpper(c);

            // Prüfe, ob der Charakter ein Buchstabe oder Sonderzeichen ist
            if (char.IsLetter(c))
            {
                // Hole den KeyCode für den Buchstaben (immer Großbuchstaben verwenden)
                var key = (KeyCode)char.ToUpper(c);

                if (isUpperCase)
                {
                    // Drücke Shift für Großbuchstaben
                    PressKey(KeyCode.Shift);
                    ClickKey(key);
                    ReleaseKey(KeyCode.Shift);
                }
                else
                {
                    // Drücke nur den Buchstaben
                    ClickKey(key);
                }
            }
            else if (char.IsDigit(c))
            {
                // Zahlen direkt senden
                KeyCode key = (KeyCode)((int)KeyCode.D0 + (c - '0'));
                PressKey(key);
            }
            else
            {
                // Sonderzeichen behandeln
                HandleSpecialCharacter(c);
            }
        }
    }

    private static void HandleSpecialCharacter(char c)
    {
        switch (c)
        {
            case '!':
                PressKeyWithShift(KeyCode.D1);
                break;
            case '@':
                PressKeyWithShift(KeyCode.D2);
                break;
            case '#':
                PressKeyWithShift(KeyCode.D3);
                break;
            case '$':
                PressKeyWithShift(KeyCode.D4);
                break;
            case '%':
                PressKeyWithShift(KeyCode.D5);
                break;
            case '^':
                PressKeyWithShift(KeyCode.D6);
                break;
            case '&':
                PressKeyWithShift(KeyCode.D7);
                break;
            case '*':
                PressKeyWithShift(KeyCode.D8);
                break;
            case '(':
                PressKeyWithShift(KeyCode.D9);
                break;
            case ')':
                PressKeyWithShift(KeyCode.D0);
                break;
            case '_':
                PressKeyWithShift(KeyCode.Minus);
                break;
            case '-':
                ClickKey(KeyCode.Minus);
                break;
            case ' ':
                ClickKey(KeyCode.Space);
                break;
            default:
                throw new NotSupportedException($"Character '{c}' is not supported.");
        }
    }

    private static void PressKeyWithShift(KeyCode key)
    {
        PressKey(KeyCode.Shift);
        ClickKey(key);
        ReleaseKey(KeyCode.Shift);
    }

    private static void ReleaseKey(KeyCode key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }
}