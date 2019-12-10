﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    /// !!!!!!!!!!!!!该案例为了上课方便使用，违反编程规范，编程时不要使用此种实现方式
    /// 
    /// 购物车定义
    public class ShoppingCart : List<ShoppingCartItem> { }
    /// <summary>
    /// 购物车商品类
    /// </summary>

    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }//商品名称
        public int Quantity { get; set; }//商品数量
    }

    public class ExampleJavaScriptResultApplicationController : Controller
    {
        private static Dictionary<Guid, int> stock = new Dictionary<Guid, int>();//stock：库存字典
        private static Guid stockA = Guid.NewGuid(), stockB = Guid.NewGuid(), stockC = Guid.NewGuid();//对库存商品ID进行Guid编号生成的工作
        /// <summary>
        /// 库存控制器构造函数
        /// </summary>
        static ExampleJavaScriptResultApplicationController()
        {
            stock.Add(stockA, 10);
            stock.Add(stockB, 1000);
            stock.Add(stockC, 10);
        }
        /// <summary>
        /// 库存检查
        /// </summary>
        private bool CheckStock(Guid id, int quantity)
        {
            return stock[id] >= quantity;
        }
        // GET: ExampleJavaScriptResultApplication
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.Add(new ShoppingCartItem { Id = stockA, Quantity = 2, Name = "Air Jordan篮球鞋" });
            cart.Add(new ShoppingCartItem { Id = stockB, Quantity = 1, Name = "Fashion衣服" });
            cart.Add(new ShoppingCartItem { Id = stockC, Quantity = 3, Name = "空军一号鞋子" });

            return View(cart);
        }
        public ActionResult processOrder(ShoppingCart cart)
        {
            StringBuilder sbd = new StringBuilder();//定义可变字符串
            ///库存检查并返回字符串结果
            foreach (var cartItem in cart)
            {
                ///判断cart的商品数量是否小于库存Id的数量,是就返回商品名字和Id的字符串
                if (!CheckStock(cartItem.Id , cartItem.Quantity ))
                {
                    sbd.Append(string.Format("{0}:{1}", cartItem.Name, stock[cartItem.Id]));
                }
            }
            if (string.IsNullOrEmpty(sbd.ToString()))
            {
                return Content("alert('您的订单已成功处理!')", "text/javascript");
            }
            string scriptString = string.Format("alert('库存不足！({0})')", sbd.ToString().TrimEnd(':'));
            return JavaScript(scriptString);
        }
    }
}