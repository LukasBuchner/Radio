using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radio.Views;

public partial class EditFmRadioView : UserControl
{
    public EditFmRadioView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}