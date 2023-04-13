using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;
using MVCMusicStore.Data;
using Microsoft.EntityFrameworkCore;
using MVCMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityModel;

namespace MVCMusicStore.Controllers
{

    public class AccountControllercs : Controller
    {
        //public const string CartSessionKey = "CartId";
        private readonly ApplicationDbContext _context;


        public AccountControllercs(ApplicationDbContext context)
        {
            _context = context;
        }
        //private void MigrateShoppingCart(string UserName)
        //{
        //    // Associate shopping cart items with logged-in user
        //    var cart = ShoppingCart.GetCart(this.HttpContext, _context);

        //    cart.MigrateCart(UserName);

        //    //Session[ShoppingCart.CartSessionKey] = UserName;

        //    this.HttpContext.Session.SetString(ShoppingCart.CartSessionKey, UserName);

        //}

        //
        // POST: /Account/LogOn
        //[HttpPost]
        //public ActionResult LogOn(LogOnModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Membership.ValidateUser(model.UserName, model.Password))
        //        {
        //            MigrateShoppingCart(model.UserName);

        //            FormsAuthentication.SetAuthCookie(model.UserName,
        //                model.RememberMe);
        //            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
        //                && returnUrl.StartsWith("/")
        //                && !returnUrl.StartsWith("//") &&
        //                !returnUrl.StartsWith("/\\"))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //        }
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}



    }
}
