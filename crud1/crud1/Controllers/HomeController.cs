using crud1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace crud1.Controllers
{
    public class HomeController : Controller
    {
        private readonly  Cs cs = new Cs();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()

        {
            

            return View();
        }

        public ActionResult Listof(int pagenumber=1) 

        {
            
            int a = cs.catagory.ToList().Count;
            if (a > 0)
            {
                int b = cs.Products.ToList().Count;
                if (b > 0)
                {
                    ViewBag.ab = cs.catagory.ToList();
                    //ViewBag.bc = cs.Products.ToList();

                    ViewBag.totalpages = Math.Ceiling(cs.Products.ToList().Count / 5.0);
                    // ViewBag.bc = cs.Products.OrderBy(x => x.ProductId).Skip(2).Take(5).ToList();
                    ViewBag.bc = cs.Products.OrderBy(x => x.ProductId).Skip((pagenumber - 1) * 5).Take(5).ToList();
                    List<Product> products = cs.Products.OrderBy(x => x.ProductId).ToList();
                    //ViewBag.bc=products.Skip(4).Take(5).ToList();    
                    ViewBag.bbb = pagenumber;
                    return View();
                }
                else
                {
                    //ViewBag.ab = cs.catagory.ToList();
                    ViewBag.totalpages = Math.Ceiling(cs.catagory.ToList().Count / 5.0);
                    ViewBag.ab = cs.catagory.Skip((pagenumber-1)*5).Take(5).ToList();  

                    return View("Listof1");
                }

            }
            else
            {
                return View("Listof2");
            }



            
        }
        [HttpPost]
        public ActionResult AddCatpo(String cname)
        {
            string tr=cname.Trim().ToUpper();   
            Catagory a = new Catagory();
            List<Catagory> ab = cs.catagory.ToList();
            foreach (Catagory catagory in ab)
            { 
                if(catagory.CatgoryName.Trim().ToUpper()==tr)
                {
                    return View("cat1");
                }
            
          }
            a.CatgoryName = tr;
            cs.catagory.Add(a);
            cs.SaveChanges();

            return RedirectToAction("Addnpro");
            
        }
        
        public ActionResult AddCat()
        {
            ViewBag.ab = cs.catagory.ToList();
            return View();
        }




        [HttpPost]
        public ActionResult Addpro(String pname,string ha)
        {
            Product p= new Product();
            p.ProductName = pname;
            p.Catgory_Id = int.Parse(ha);
            
            cs.Products.Add(p);
            cs.SaveChanges();


            return RedirectToAction("Listof");
        }



        public ActionResult Addnpro()
        {
            
            
                int a=cs.catagory.ToList().Count;
            if(a > 0)
            {
                ViewBag.ab = cs.catagory.ToList();
                return View();
            }
            
            else { return View("list3"); }
                 
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Updatet(int idc)
        {
            Product p = cs.Products.Find(idc);
            ViewBag.ida= p;
            ViewBag.ab = cs.catagory.ToList();

            return View();
        }
        public ActionResult Delete(int id)
        {
           Product p= cs.Products.Find(id);
            Product product = cs.Products.Remove(p);
            cs.SaveChanges(); ;

            return RedirectToAction("Listof");
        }
        [HttpPost]
        public ActionResult Updatea(string pname,string id,string ha)
        {
            Product d = cs.Products.Find(int.Parse(id));
            Product product = cs.Products.Remove(d);
            cs.SaveChanges();

            Product p = new Product();
            p.ProductName = pname;
            p.Catgory_Id = int.Parse(ha);
            int a = int.Parse(id);
            p.ProductId = --a;

            cs.Products.Add(p);
            cs.SaveChanges();
            return RedirectToAction("Listof");
        }

        public ActionResult Delcat(int id)
        {
          Catagory cat=cs.catagory.Find(id);
            Catagory catagory = cs.catagory.Remove(cat);
            cs.SaveChanges();   

            return RedirectToAction("Listof");
        }

        public ActionResult Upcat(int idc)
        {
            Catagory p = cs.catagory.Find(idc);
            ViewBag.ida = p;
            ViewBag.ab = cs.catagory.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Upcac(string cat, string id)
        {
            Catagory d = cs.catagory.Find(int.Parse(id));
            Catagory product = cs.catagory.Remove(d);
            cs.SaveChanges();

            Catagory p = new Catagory();
            p.CatgoryName = cat;
            p.Catgory_Id = int.Parse(id);
            

            cs.catagory.Add(p);
            cs.SaveChanges();
            return RedirectToAction("Listof");
        }
        public ActionResult D(int id)
        {
            var p = cs.Products.Where(pa=>pa.Catgory_Id==id).ToList();
            if (p != null)
            {
                cs.Products.RemoveRange(p);
                cs.SaveChanges();
            }
            Catagory c = cs.catagory.Find(id);
            Catagory ca = cs.catagory.Remove(c);
            cs.SaveChanges();   
            return RedirectToAction("Listof");
        }

    }
}