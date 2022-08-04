using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class RadiosView : UserControl
{
    public RadiosView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}