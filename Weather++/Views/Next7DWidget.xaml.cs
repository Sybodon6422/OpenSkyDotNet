using Weather__.ViewModels;

namespace Weather__.Views;

public partial class Next7DWidget
{
    public Next7DWidget()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}
