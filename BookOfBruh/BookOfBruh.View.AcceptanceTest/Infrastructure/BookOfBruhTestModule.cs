namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Core;
    using Core.CodeValidation;
    using Core.GameData;
    using Core.SlotAnalysation;
    using Core.SlotAnalysation.PatternMatchers;
    using Core.SlotGeneration;
    using Ninject.Modules;
    using View.Control;

    public class BookOfBruhTestModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ControlViewModel>().ToSelf().InSingletonScope();

            this.Bind<Game>().ToSelf().InSingletonScope();

            this.Bind<IPlayer>().To<FakeIPlayer>().InSingletonScope();
            this.Bind<ISlotGenerator>().To<FakeSlotGenerator>().InSingletonScope();

            this.Bind<ICodeValidator>().To<CodeValidator>().InSingletonScope();
            this.Bind<ISlotAnalyzer>().To<SlotAnalyzer>().InSingletonScope();
            this.Bind<IPatternMatcher>().To<PatternMatcher>().InSingletonScope();

            this.Bind<ILinePatternMatcher>().To<LinePatternMatcher>().InSingletonScope();
            this.Bind<IFlashPatternMatcher>().To<FlashPatternMatcher>().InSingletonScope();
            this.Bind<IDiagonalPatternMatcher>().To<DiagonalPatternMatcher>().InSingletonScope();
            this.Bind<ITrianglePatternMatcher>().To<TrianglePatternMatcher>().InSingletonScope();
            this.Bind<IUPatternMatcher>().To<UPatternMatcher>().InSingletonScope();
        }
    }
}