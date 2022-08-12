using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class OnlineRadiosView : UserControl
{
    public OnlineRadiosView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}