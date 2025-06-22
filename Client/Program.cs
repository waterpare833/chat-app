﻿namespace CHAT_APP.CLIENT;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args) => Program.BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args)
;
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}