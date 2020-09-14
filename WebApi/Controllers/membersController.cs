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
using DbModel = WebApi.Models.DbModel;

namespace WebApi.Controllers
{
    public class membersController : ApiController
    {
        private DbModel db = new DbModel();

        // GET: api/members
        public IQueryable<member> Getmembers()
        {
            return db.members;
        }

        // GET: api/members/5
        [ResponseType(typeof(member))]
        public IHttpActionResult Getmember(int id)
        {
            member member = db.members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/members/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmember(int id, member member)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != member.Id)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!memberExists(id))
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

        // POST: api/members
        [ResponseType(typeof(member))]
        public IHttpActionResult Postmember(member member)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.members.Add(member);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = member.Id }, member);
        }

        // DELETE: api/members/5
        [ResponseType(typeof(member))]
        public IHttpActionResult Deletemember(int id)
        {
            member member = db.members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.members.Remove(member);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool memberExists(int id)
        {
            return db.members.Count(e => e.Id == id) > 0;
        }
    }
}