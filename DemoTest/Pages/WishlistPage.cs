using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DemoFramework.Base;
using DemoFramework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoTest.Pages
{
    internal class WishListPage : BasePage
    {
        public WishListPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement FirstProduct_InWishlist => _parallelConfig.Driver.FindElementByCssSelector("#yith-wcwl-row-17");

        IWebElement SecondProduct_InWishlist => _parallelConfig.Driver.FindElementByCssSelector("#yith-wcwl-row-14");

        IWebElement ThirdProduct_InWishlist => _parallelConfig.Driver.FindElementByCssSelector("#yith-wcwl-row-20");

        IWebElement FourthProduct_InWishlist => _parallelConfig.Driver.FindElementByCssSelector("#yith-wcwl-row-23");


        public void VerifyPageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("Wishlist – TESTSCRIPTDEMO"));

        }

        public WishListPage VerifyProductsInWishlist()
        {
            VerifyPageTitle();
            String FirstProductName = FirstProduct_InWishlist.FindElement(By.ClassName("product-name")).GetLinkText();
            String SecondProductName = SecondProduct_InWishlist.FindElement(By.ClassName("product-name")).GetLinkText();
            String ThirdProductName = ThirdProduct_InWishlist.FindElement(By.ClassName("product-name")).GetLinkText();
            String FourthProductName = FourthProduct_InWishlist.FindElement(By.ClassName("product-name")).GetLinkText();

            return new WishListPage(_parallelConfig);
        }

    }
}
