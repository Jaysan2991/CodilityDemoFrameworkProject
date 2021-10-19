using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using DemoFramework.Base;
using DemoFramework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoTest.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement CookieButton => _parallelConfig.Driver.FindByLinkText("Accept all");

        IWebElement ProductAddedPopUp => _parallelConfig.Driver.FindByLinkText("#yith-wcwl-popup-message > #yith-wcwl-message");

        IWebElement FirstProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='17']");

        IWebElement SecondProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='14']");

        IWebElement ThirdProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='20']");

        IWebElement FourthProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='23']");

        IWebElement WishlistMenu => _parallelConfig.Driver.FindElementByCssSelector("a[title='Wishlist']");

        IList<IWebElement> ProductsName => _parallelConfig.Driver.FindElementsByCssSelector("h2.woocommerce-loop-product__title");



        public void VerifyHomePageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("TESTSCRIPTDEMO – Automation Practice"));
        }

        public void AcceptCookieButton()
        {
            VerifyHomePageTitle();
            CookieButton.Click();
        }

        public bool VerifyProductExist(IList<String> Name)
        {
            foreach(IWebElement ProdName in ProductsName)
            {
                String ProductName = ProdName.GetAttribute("innerText");
                if (Name.Contains(ProductName))
                {
                    return true;
                }
               
            }
            return false;
        }

        public void AddFirstProductTowishlist(IList<String> Name)
        {
            Actions actions = new Actions(_parallelConfig.Driver);
            actions.MoveToElement(FirstProduct);
            actions.Perform();
            VerifyProductExist(Name);
            FirstProduct.AssertElementPresent();
            FirstProduct.Click();
        }

        public void AddSecondProductTowishlist(IList<String> Name)
        {
            Actions actions = new Actions(_parallelConfig.Driver);
            actions.MoveToElement(SecondProduct);
            actions.Perform();
            VerifyProductExist(Name);
            SecondProduct.AssertElementPresent();
            SecondProduct.Click();
        }

        public void AddThirdProductTowishlist(IList<String> Name)
        {
            VerifyProductExist(Name);
            ThirdProduct.AssertElementPresent();
            ThirdProduct.Click();
        }

        public void AddFourthProductTowishlist(IList<String> Name)
        {
            VerifyProductExist(Name);
            FourthProduct.AssertElementPresent();
            FourthProduct.Click();
        }

        public WishListPage goToWishlistPage()
        {
            if (WishlistMenu.IsElementPresent()) { WishlistMenu.Click(); }

            return new WishListPage(_parallelConfig);
        }
                
    }
}
