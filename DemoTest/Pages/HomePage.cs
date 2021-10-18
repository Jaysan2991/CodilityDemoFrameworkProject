using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using DemoFramework.Base;
using DemoFramework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTest.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement CookieButton => _parallelConfig.Driver.FindByLinkText("Accept all");

        IWebElement ProductAddedPopUp => _parallelConfig.Driver.FindByLinkText("Accept all");

        IWebElement FirstProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='17']");

        IWebElement SecondProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='14']");

        IWebElement ThirdProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='20']");

        IWebElement FourthProduct => _parallelConfig.Driver.FindElementByCssSelector("div > a[data-product-id='23']");

        IWebElement WishlistMenu => _parallelConfig.Driver.FindElementByCssSelector("a[title='Wishlist']");

        public void VerifyHomePageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("TESTSCRIPTDEMO – Automation Practice"));
        }

        public HomePage AcceptCookieButton()
        {
            VerifyHomePageTitle();
            CookieButton.Click();
            return new HomePage(_parallelConfig);
        }

        public HomePage AddFirstProductTowishlist()
        {
            
            FirstProduct.AssertElementPresent();
            FirstProduct.Click();
            return new HomePage(_parallelConfig);
        }

        public HomePage AddSecondProductTowishlist()
        {
            SecondProduct.AssertElementPresent();
            SecondProduct.Click();
            return new HomePage(_parallelConfig);
        }

        public HomePage AddThirdProductTowishlist()
        {
            ThirdProduct.AssertElementPresent();
            ThirdProduct.Click();
            return new HomePage(_parallelConfig);
        }

        public HomePage AddFourthProductTowishlist()
        {
            FourthProduct.AssertElementPresent();
            FourthProduct.Click();
            return new HomePage(_parallelConfig);
        }

        public HomePage goToWishlistPage()
        {
            if (WishlistMenu.IsElementPresent()) { WishlistMenu.Click(); }

            return new HomePage(_parallelConfig);
        }
                
    }
}
