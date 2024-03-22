using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

public partial class MainWindow : Window
{
    private const uint WDA_MONITOR = 1;

    [DllImport("user32.dll")]
    private static extern bool SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var windowInteropHelper = new WindowInteropHelper(this);
        SetWindowDisplayAffinity(windowInteropHelper.Handle, WDA_MONITOR);
    }
}