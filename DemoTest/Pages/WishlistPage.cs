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

        IWebElement CartOptions => _parallelConfig.Driver.FindElementByCssSelector("a[title='Cart'] > i");


        public void VerifyPageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("Wishlist – TESTSCRIPTDEMO"));

        }

        public bool VerifyProductExistInWIshlist(IList<String> Name)
        {
            IList<IWebElement> ProductsName = new List<IWebElement>();
            ProductsName.Add(FirstProduct_InWishlist);
            ProductsName.Add(SecondProduct_InWishlist);
            ProductsName.Add(ThirdProduct_InWishlist);
            ProductsName.Add(FourthProduct_InWishlist);
            int Counter = 0;

            foreach (IWebElement ProdName in ProductsName)
            {
                String ProductName = ProdName.FindElement(By.ClassName("product-name")).GetLinkText();
                if (Name.Contains(ProductName))
                {
                    Counter++;
                }

            }
            if (Counter == ProductsName.Count) return true;
            else return false;
        }

        public void VerifyProductsInWishlist(IList<String> Name)
        {
            VerifyPageTitle();
            VerifyProductExistInWIshlist(Name);
        }

        public void CheckForLowestPriceProduct()
        {
            IList<IWebElement> ProdcutPrice = new List<IWebElement>();

            //foreach (IWebElement Price in ProdcurPrice)
            //{
            //    String ProductName = ProdName.FindElement(By.ClassName("product-name")).GetLinkText();
            //    if (Name.Contains(ProductName))
            //    {
            //        Count++;
            //    }

            //}
            String Price1 = FirstProduct_InWishlist.FindElement(By.CssSelector("td.product-price")).GetAttribute("innerText");
            String Price2 = SecondProduct_InWishlist.FindElement(By.CssSelector("td.product-price")).GetAttribute("innerText");
            String Price3= ThirdProduct_InWishlist.FindElement(By.CssSelector("td.product-price")).GetAttribute("innerText");
            String Price4 = FourthProduct_InWishlist.FindElement(By.CssSelector("td.product-price")).GetAttribute("innerText");

            AddLowestPriceProductBasket();

        }

        public void AddLowestPriceProductBasket()
        {

            ThirdProduct_InWishlist.FindElement(By.CssSelector("td.product-add-to-cart > a")).Click();

        }

        public CustomerCartPage goToCartPage()
        {
            if (CartOptions.IsElementPresent()) { CartOptions.Click(); }

            return new CustomerCartPage(_parallelConfig);
        }

    }
}
