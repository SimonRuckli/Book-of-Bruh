namespace BookOfBruh.Core.Test.Helper
{
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using Ninject.Modules;

    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDiagonalPatternMatcher>().To<DiagonalPatternMatcher>().InSingletonScope();
            this.Bind<IFlashPatternMatcher>().To<FlashPatternMatcher>().InSingletonScope();
            this.Bind<ILinePatternMatcher>().To<LinePatternMatcher>().InSingletonScope();
            this.Bind<ITrianglePatternMatcher>().To<TrianglePatternMatcher>().InSingletonScope();
            this.Bind<IUPatternMatcher>().To<UPatternMatcher>().InSingletonScope();

            this.Bind<IPatternMatcher>().To<PatternMatcher>().InSingletonScope();
        }
    }
}
