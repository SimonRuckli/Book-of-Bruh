namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Ninject.Modules;
    using View.Control;

    public class BookOfBruhTestModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ControlViewModel>().ToSelf().InSingletonScope();
        }
    }
}