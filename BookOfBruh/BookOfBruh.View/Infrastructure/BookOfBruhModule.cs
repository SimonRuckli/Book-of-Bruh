namespace BookOfBruh.View.Infrastructure
{
    using Control;
    using Core;
    using Core.CodeValidation;
    using Core.GameData;
    using Core.SlotAnalysation;
    using Core.SlotAnalysation.PatternMatchers;
    using Core.SlotGeneration;
    using Main;
    using Ninject.Modules;
    using Slot;
    using ViewService;
    using Win;

    internal class BookOfBruhModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            this.Bind<ControlViewModel>().ToSelf().InSingletonScope();
            this.Bind<SlotViewModel>().ToSelf().InSingletonScope();
            this.Bind<WinViewModel>().ToSelf().InSingletonScope();
            this.Bind<IStakeViewService>().To<StakeViewService>().InSingletonScope();
            this.Bind<WalletViewService>().ToSelf().InSingletonScope();
            this.Bind<IWalletViewService>().To<WalletViewService>().InSingletonScope();

            this.Bind<ControlState>().To<NotEnoughBruhCoinState>();
            this.Bind<ISlotSpinner>().To<SlotSpinner>();
            
            this.Bind<Game>().ToSelf().InSingletonScope();

            this.Bind<IPlayer>().To<Player>().InSingletonScope();
            this.Bind<IWallet>().To<Wallet>().InSingletonScope();
            this.Bind<ISlotGenerator>().To<SlotGenerator>().InSingletonScope();
            this.Bind<ISymbolGenerator>().To<SymbolGenerator>().InSingletonScope();
            this.Bind<ISymbolListGenerator>().To<SymbolListGenerator>().InSingletonScope();
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
