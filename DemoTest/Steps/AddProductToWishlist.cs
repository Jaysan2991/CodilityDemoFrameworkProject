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
            _parallelConfig.Driver.Manage().Window.Maximize();
            _parallelConfig.Driver.Manage().Cookies.DeleteAllCookies();
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            

        }

        [Given(@"I have navigated to test demo website")]
        public void GivenIhaveNavigatedToTestDemoWebsite()
        {
            NavigateToSite();
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<HomePage>().AcceptCookieButton();
        }

        [Given(@"I add four different products to my wishlist")]
        public void GivenIAddFourDifferentProductsToMyWishlist()
        {
            _parallelConfig.CurrentPage.As<HomePage>().AddFirstProductTowishlist();
            _parallelConfig.CurrentPage.As<HomePage>().AddSecondProductTowishlist();
            _parallelConfig.CurrentPage.As<HomePage>().AddThirdProductTowishlist();
            _parallelConfig.CurrentPage.As<HomePage>().AddFourthProductTowishlist();
        }

        [When(@"I veiw my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
            _parallelConfig.CurrentPage.As<HomePage>().goToWishlistPage();
        }

        [Then(@"I find total four selected items in my wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {
            _parallelConfig.CurrentPage = new WishListPage(_parallelConfig);
            _parallelConfig.CurrentPage.As<WishListPage>().VerifyProductsInWishlist();
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
