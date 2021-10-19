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
    internal class CustomerCartPage : BasePage
    {
        public CustomerCartPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IList<IWebElement> ProductsName => _parallelConfig.Driver.FindElementsByCssSelector(".woocommerce-cart-form__cart-item.cart_item");

        public void VerifyPageTitle()
        {
            String pageTitle = _parallelConfig.Driver.Title.ToString();
            Assert.That(pageTitle, Is.EqualTo("Cart – TESTSCRIPTDEMO"));

        }

        public bool VerifyProductAddedToCart(IList<String> Name)
        {
            foreach (IWebElement ProdName in ProductsName)
            {
                String ProductName = ProdName.FindElement(By.CssSelector("td.product-name")).GetAttribute("innerText");
                if (Name.Contains(ProductName))
                {
                    return true;
                }

            }
            return false;

        }

        public void VerifyItemInCart(IList<String> Name)
        {
            VerifyPageTitle();
            VerifyProductAddedToCart(Name);
        }



    }
}
