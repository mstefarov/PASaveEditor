using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PASaveEditor {
    static class TextBoxWatermarkExtensionMethod {
        const uint ECM_FIRST = 0x1500;
        const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam,
                                         [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetWatermark(this TextBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

    }
}