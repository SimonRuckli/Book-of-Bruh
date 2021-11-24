namespace BookOfBruh.View.Control
{
    using Infrastructure;
    using Infrastructure.Commands;

    public class ControlViewModel : NotifyPropertyChangedBase
    {

        public ControlViewModel()
        {
            this.SpinClickCommand = new RelayCommand(this.SpinClick, this.SpinIsValid);
        }

        public RelayCommand SpinClickCommand { get; set; }  

        public string Guthaben { get; } = "Proof of Concept";

        private bool SpinIsValid()
        {
            return true;
        }

        private void SpinClick()
        {
            throw new System.NotImplementedException();
        }

    }
}
