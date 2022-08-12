using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class FmRadiosView : UserControl
{
    public FmRadiosView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}