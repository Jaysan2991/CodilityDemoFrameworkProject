using DemoFramework.Base;
using DemoTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using DemoFramework.Config;

namespace DemoTest.Steps
{
    [Binding]
    public class AddProductToWishlist : BaseStep
    { 
        
        private readonly ParallelConfig _parallelConfig;

        public AddProductToWishlist(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void NavigateToSite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);

        }

        [Given(@"I have navigated to test demo website")]
        public void GivenIhaveNavigatedToTestDemoWebsite()
        {
            NavigateToSite();
        }

        [Given(@"I add four different products to my wishlist")]
        public void GivenIAddFourDifferentProductsToMyWishlist()
        {
        }

        [When(@"I veiw my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {

        }

        [Then(@"I find total four selected items in my wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {

        }

        [When(@"I search for lowest price product")]
        public void WhenISearchForLowestPriceProduct()
        {

        }

        [Then(@"I am able to add the lowest price item to my cart")]
        public void ThenIAmAbleToAddTheLowestPriceItemtoMyCart()
        {

        }

        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {

        }


    }
}
