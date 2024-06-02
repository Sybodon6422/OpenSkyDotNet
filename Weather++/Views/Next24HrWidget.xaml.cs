using Weather__.ViewModels;

namespace Weather__.Views;

public partial class Next24HrWidget
{
    public Next24HrWidget()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}
