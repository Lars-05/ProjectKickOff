using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Transparent : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.backgroundColor = new Color(0, 0, 0, 0); // (0,0,0,0)
    }

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

    public void Update()
    {
        var v3 = Input.mousePosition;
        v3.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z); 
        
        bool hit2D = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(v3)) != null;
        bool hit3D = Physics.Raycast(Camera.main.ScreenPointToRay(v3));
        bool hitUI = IsPointerOverUI();

        SetClickThrough(!(hit2D || hit3D || hitUI));
    }

    private bool IsPointerOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results.Count > 0;
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
