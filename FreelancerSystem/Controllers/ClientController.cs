using FreelancerSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreelancerSystem.Controllers
{
    public class ClientController : Controller
    {
        //here i create instance of database that name is ApplicationDbContext
        ApplicationDbContext db;
        public ClientController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        //here i get the client information 
        public ActionResult ClientInformation()
        {
            //here i get the cureent user id 
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            //here i find the data of user by using id
            return View(currentUser);
        }
        public FileContentResult UserPhoto()
        {
            string userId = User.Identity.GetUserId();
            var dbUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var userImage = dbUsers.Users.Where(x => x.Id == userId).FirstOrDefault();
            return new FileContentResult(userImage.UserPhoto, "image/jpeg");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
           
         // GET: Client/CreatePost
        public ActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Creation_Date = DateTime.Now;
                post.ClientId = User.Identity.GetUserId();
                post.ClientName = User.Identity.GetUserName();
                post.postId = Guid.NewGuid().ToString();
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("GetAllPost");
            }

            return View(post);
        }
        //here history posts that create by client
        //here it is delete post [Get] request
        public ActionResult DeletePost(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPost(string id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("GetAllPost");
        }

        public ActionResult EditPost(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public ActionResult GetAllPost()
        {
            string currentId = User.Identity.GetUserId();
            var result = db.Posts.Where(x => x.ClientId == currentId);
            var userPosts = result.ToList();
            return View(userPosts);
        }
        //here i edit the post
      
        // POST: Client/Create


        // GET: Client/Edit/5
        public ActionResult EditInfo(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string currentUser = User.Identity.GetUserId();
            ApplicationUser applicationUser = db.Users.Find(currentUser);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult EditInfo( ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientInformation");
            }
            
            return View(applicationUser);
            
        }
        //here i delete the post
        // GET: Client/Delete/5
        
        // POST: Client/Delete/5
        
        
    }
}
