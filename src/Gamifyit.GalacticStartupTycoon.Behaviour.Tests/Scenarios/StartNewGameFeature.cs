namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using Xbehave;

    public class StartNewGameFeature : WebsiteTest
    {
        [Scenario]
        public void StartNewGame()
        {
            "And a new Personal Account has opened called Wallet"
                .x(() => this.ANewPersonalAccountHasOpened());

            "And I am notified of funds into my account"
                .x(() => this.IAmNotifiedOfFundsIntoMyAccount());

            "And I am notified of Assets attained"
                .x(() => this.IAmNotifiedOfAssetsAttained());

            "And I am notified my current Net Worth has increased to 200C"
                .x(() => this.IAmNotifiedMyCurrentNetWorthHasIncreasedTo(200, "C"));

            "And I can view my account"
                .x(() => this.ICanViewMyAccount());

            "And I can view my Assets"
                .x(() => this.ICanViewMyAssets());
        }



        private void ICanViewMyAssets()
        {
            throw new System.NotImplementedException();
        }

        private void ICanViewMyAccount()
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedMyCurrentNetWorthHasIncreasedTo(int i, string s)
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedOfAssetsAttained()
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedOfFundsIntoMyAccount()
        {
            throw new System.NotImplementedException();
        }

        private void ANewPersonalAccountHasOpened()
        {
            throw new System.NotImplementedException();
        }

    }
}