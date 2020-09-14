﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
//using DbModel = WebApi.Models.DbModel;

namespace WebApi.Controllers
{
    public class authorsController : ApiController
    {
        private Models.DbModel db = new Models.DbModel();
        
        // GET: api/authors
        public IQueryable<author> Getauthors()
        {
            return db.authors;
        }

        // GET: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Getauthor(int id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthor(int id, author author)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != author.Id)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!authorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/authors
        [ResponseType(typeof(author))]
        public IHttpActionResult Postauthor(author author)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.authors.Add(author);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Deleteauthor(int id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            db.authors.Remove(author);
            db.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authorExists(int id)
        {
            return db.authors.Count(e => e.Id == id) > 0;
        }
    }
}