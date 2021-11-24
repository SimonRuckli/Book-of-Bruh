namespace BookOfBruh.View.Infrastructure
{
    using Core;
    using Ninject.Modules;

    internal class BookOfBruhModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Game>().ToSelf().InSingletonScope();
        }
    }
}
