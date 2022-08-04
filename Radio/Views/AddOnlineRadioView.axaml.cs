using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class AddOnlineRadioView : UserControl
{
    public AddOnlineRadioView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}