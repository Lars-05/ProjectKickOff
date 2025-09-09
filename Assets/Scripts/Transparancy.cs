using System;
using System.Runtime.InteropServices;
using UnityEngine;

using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    [DllImport("user32.dll")] 
    static extern IntPtr GetActiveWindow();
    
    [DllImport("user32.dll")] 
    static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    
    [DllImport("user32.dll")] 
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    
    [DllImport("Dwmapi.dll")] 
    static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);
    
    [DllImport("user32.dll")] 
    static extern uint SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x80000;
    const uint WS_EX_TRANSPARENT = 0x20;
    
    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    private IntPtr hwnd;
    void Start()
    {
        
        hwnd = GetActiveWindow();
        MARGINS margins = new MARGINS{cxLeftWidth = -1 };
        DwmExtendFrameIntoClientArea(hwnd, ref margins);
        
        SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, 0);
    }

    private void Update()
    {
        SetClickThrough(Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == null);
    }

    private void SetClickThrough(bool clickThrough)
    {
        if (clickThrough)
        {
            SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }
        else
        {
            SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED);
        }
    }
}
