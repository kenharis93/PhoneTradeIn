using PhoneTradeInFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhoneTradeInFinal.Controllers
{
    public class CartController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        // GET: Cart
        [Authorize]
        public ActionResult CartView()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> RequestEmail()
        {
            var cart = (List<Item>)Session["cart"];
            var user = User.Identity.Name;

            StringBuilder sb = new StringBuilder();
            sb.Append("Hello, " + user + "!");
            sb.Append("\r\nYour Requested Quotes for:");
            foreach (var item in cart)
            {
                sb.Append("\r\nProduct ID: " + item.Product.Id.ToString()+",");
                sb.Append("\r\nDevice Name: " + item.Product.Name.ToString() + ",");
                sb.Append("\r\nEstimated Trade In Value: " + "$" + item.Product.Price.ToString() + ",");
                sb.Append("\r\nQuantity: " + item.Quantity.ToString());
                sb.Append("\r\n________________________________________________");
            }
            sb.Append("\r\nA Representative will contact you to gather addition details such as IMEIs and pictures, to assess appropriate quotes and then provide further details.");
            sb.AppendLine();
            sb.Append("\r\nThank you for using SwingIt!");
            sb.Append("</body>");
            sb.Append("</html>");
            var message = new MailMessage();
            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(user));
            message.Bcc.Add(new MailAddress("swingittoronto@gmail.com"));
            message.From = new MailAddress("swingittoronto@gmail.com");
            message.Subject = "Swing It Quote Request " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.TimeOfDay.ToString();
            message.Body = sb.ToString();

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "swingittoronto@gmail.com",
                    Password = "Humber123!"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");
            }


            return View();
        }

        [Authorize]
        public ActionResult Sent()
        {
            var cart = (List<Item>)Session["cart"];
            cart.Clear();
            return View();
        }

        //Add a new item to the cart and check if item already exists to increase quantity
        [Authorize]
        public ActionResult Buy(string id)
        {
            Product product = db.Products.Find(id);
            List<Item> cart = new List<Item>();
            if (Session["cart"] == null)
            {
                //List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = product, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = product, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("CartView");
        }

        //remove item from the cart
        public ActionResult Remove(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("CartView");
        }

        //method to check if item is already in cart
        private int isExist(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i=0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                    return i;
            }
            return -1;
        }
    }
}