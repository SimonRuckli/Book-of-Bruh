namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Core;
    using Core.CodeValidation;
    using Core.Reels;
    using Core.SlotAnalysation;
    using Core.SlotAnalysation.PatternMatchers;
    using Core.SlotGeneration;
    using Main;
    using Ninject.Modules;
    using View.Control;
    using View.Stake;
    using ViewService;
    using Win;

    public class BookOfBruhTestModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ControlViewModel>().ToSelf().InSingletonScope();
            this.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            this.Bind<StakeViewModel>().ToSelf().InSingletonScope();
            this.Bind<WinViewModel>().ToSelf().InSingletonScope();
            this.Bind<IStakeViewService>().To<StakeViewService>().InSingletonScope();
            this.Bind<WalletViewService>().ToSelf().InSingletonScope();
            this.Bind<IWalletViewService>().To<WalletViewService>().InSingletonScope();
            this.Bind<ISlotConverter>().To<FakeSlotConverter>().InSingletonScope();
            this.Bind<IReelsGenerator>().To<ReelsGenerator>().InSingletonScope();
            this.Bind<ISymbolListGenerator>().To<SymbolListGenerator>().InSingletonScope();


            this.Bind<ISlotMachine>().To<Game>().InSingletonScope();
            this.Bind<ISpeedCalculator>().To<SpeedCalculator>().InSingletonScope();
            this.Bind<GameState>().To<ReadyToSpinState>().InSingletonScope();

            this.Bind<ICodeValidator>().To<CodeValidator>().InSingletonScope();
            this.Bind<IAcceptedCodes>().To<AcceptedCodes>().InSingletonScope();
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