using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class AddFmRadioView : UserControl
{
    public AddFmRadioView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}