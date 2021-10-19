using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DemoFramework.Base;
using DemoFramework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoTest.Pages
{
    internal class WishListPage : BasePage
    {
        public WishListPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement CartOptions => _parallelConfig.Driver.FindElementByCssSelector("a[title='Cart'] > i");

        IList<IWebElement> ProductsInWIshList => _parallelConfig.Driver.FindElementsByCssSelector("tbody.wishlist-items-wrapper > tr");

        IWebElement AddedToCartAlert => _parallelConfig.Driver.FindElementByCssSelector("div.woocommerce-message");


        static String productName;


        public void VerifyPageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("Wishlist – TESTSCRIPTDEMO"));

        }

        public bool VerifyProductExistInWIshlist(IList<String> Name)
        {
            int Counter = 0;

            foreach (IWebElement ProdName in ProductsInWIshList)
            {
                String ProductName = ProdName.FindElement(By.CssSelector("td.product-name")).GetLinkText();
                if (Name.Contains(ProductName))
                {
                    Counter++;
                }

            }
            if (Counter == ProductsInWIshList.Count) return true;
            else return false;
        }

        public void VerifyProductsInWishlist(IList<String> Name)
        {
            VerifyPageTitle();
            Assert.That(VerifyProductExistInWIshlist(Name), Is.True);
        }

        public void CheckForLowestPriceProduct(IList<String> Name)
        {
            IDictionary<String, String> ProductPrice = new Dictionary<String, String>();

            foreach (IWebElement ProdName in ProductsInWIshList)
            {
                String ProductName = ProdName.FindElement(By.CssSelector("td.product-name")).GetLinkText();
                if (Name.Contains(ProductName))
                {
                    String Price = ProdName.FindElement(By.CssSelector("td.product-price")).GetAttribute("innerText");
                    ProductPrice.Add(ProductName, Price);
                }

            }

            IDictionary<String, float> PPrice = CheckPrice(ProductPrice);

            FindLowestPriceOfProduct(PPrice);


        }


        public IDictionary<String, float> CheckPrice(IDictionary<String, String> ProdPrice) 
        {
            IDictionary<String, float> ProductPriceForCompare = new Dictionary<String, float>();
            foreach (KeyValuePair<String, String> price in ProdPrice)
            {
                String[] pp = price.Value.Split();

                if(pp.Length > 1)
                {
                    if (pp.Length == 3)
                    {
                        float costOfItem = float.Parse(pp[0].Trim('£'));
                        ProductPriceForCompare.Add(price.Key, costOfItem);
                    }
                    else
                    {
                        float costOfItem = float.Parse(pp[1].Trim('£'));
                        ProductPriceForCompare.Add(price.Key, costOfItem);
                    }

                }

                else
                {
                    float costOfItem = float.Parse(pp[0].Trim('£'));
                    ProductPriceForCompare.Add(price.Key, costOfItem);
                }

            }

            return ProductPriceForCompare;


        }

        public void FindLowestPriceOfProduct(IDictionary<String, float> PPrice)
        {
            float price = float.MaxValue;
            foreach(KeyValuePair<String, float> IndividualPrice in PPrice)
            {
                if(IndividualPrice.Value < price)
                {
                    price = IndividualPrice.Value;
                    productName = IndividualPrice.Key;
                }

            }
        }

        public void AddLowestPriceProductBasket()
        {

            foreach (IWebElement ProdName in ProductsInWIshList)
            {
                String ProductName = ProdName.FindElement(By.CssSelector("td.product-name")).GetLinkText();
                if (ProductName.Equals(productName))
                {
                    IWebElement AddTocCart_product = ProdName.FindElement(By.CssSelector("td.product-add-to-cart > a"));
                    AddTocCart_product.IsElementPresent();
                    AddTocCart_product.Click();

                }

            }

        }

        public CustomerCartPage goToCartPage()
        {
            
            Actions actions = new Actions(_parallelConfig.Driver);
            actions.MoveToElement(CartOptions);
            actions.Perform();
            if (CartOptions.IsElementPresent()) { CartOptions.Click(); }

            return new CustomerCartPage(_parallelConfig);
        }

    }
}
