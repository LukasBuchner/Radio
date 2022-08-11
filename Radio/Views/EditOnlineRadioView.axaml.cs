using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class EditOnlineRadioView : UserControl
{
    public EditOnlineRadioView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}