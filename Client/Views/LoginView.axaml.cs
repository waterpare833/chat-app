﻿using Avalonia.Markup.Xaml;

namespace Client.Views;

public partial class LoginView: UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}