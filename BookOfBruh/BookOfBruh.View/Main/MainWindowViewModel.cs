namespace BookOfBruh.View.Main
{
    using Control;
    using Infrastructure;
    using Slot;

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        public MainWindowViewModel(SlotViewModel slotViewModel, ControlViewModel controlViewModel)
        {
            SlotViewModel = slotViewModel;
            ControlViewModel = controlViewModel;
        }

        public SlotViewModel SlotViewModel { get; }

        public ControlViewModel ControlViewModel { get; }

    }
}
