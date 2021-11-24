namespace BookOfBruh.View.Infrastructure
{
    using Control;
    using Core;
    using Main;
    using Ninject.Modules;
    using Slot;

    internal class BookOfBruhModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Game>().ToSelf().InSingletonScope();
            this.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            this.Bind<ControlViewModel>().ToSelf().InSingletonScope();
            this.Bind<SlotViewModel>().ToSelf().InSingletonScope();
        }
    }
}
