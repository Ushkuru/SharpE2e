using System.Runtime.InteropServices;
using SharpE2e.Core.Enum;

namespace SharpE2e.Core.Input
{
    internal static class Mouse
    {
        // P/Invoke for setting the cursor position
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        // P/Invoke for simulating mouse events
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        public static void MouseEvent(MouseEvent mouseEvent)
        {
            var mEvent = (uint)mouseEvent;
            mouse_event(mEvent, 0, 0, 0, UIntPtr.Zero);
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }
    }
}
