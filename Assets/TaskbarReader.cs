using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class TaskbarInfo
{
    [StructLayout(LayoutKind.Sequential)]
    private struct APPBARDATA
    {
        public uint cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public uint uEdge;
        public RECT rc;
        public int lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left, top, right, bottom;
    }

    private const int ABM_GETTASKBARPOS = 5;

    [DllImport("shell32.dll")]
    private static extern uint SHAppBarMessage(uint dwMessage, ref APPBARDATA pData);

    public static Rect GetTaskbarRect()
    {
        APPBARDATA data = new APPBARDATA();
        data.cbSize = (uint)Marshal.SizeOf(data);

        SHAppBarMessage(ABM_GETTASKBARPOS, ref data);

        return new Rect(data.rc.left, data.rc.top,
            data.rc.right - data.rc.left,
            data.rc.bottom - data.rc.top);
    }
}