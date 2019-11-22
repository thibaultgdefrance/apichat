using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiChat3.Models;

namespace ApiChat3.Controllers
{
    public class MessagesController : ApiController
    {
        private Chat2Entities db = new Chat2Entities();

        // GET: api/Messages
        public IQueryable<Message> GetMessage()
        {
            return db.Message;
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            Message message = await db.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.IdMessage)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Message.Add(message);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = message.IdMessage }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            Message message = await db.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Message.Remove(message);
            await db.SaveChangesAsync();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Message.Count(e => e.IdMessage == id) > 0;
        }

        public List<MessageUtilisateur> getMessagesDiscussion(int IdDiscussion)
        {
            List<MessageUtilisateur> messagesUtilisateur = new List<MessageUtilisateur>();
            List<Message> messages = (from m in db.Message where m.IdDiscussion == IdDiscussion select m).ToList();
            foreach (var item in messages)
            {
                Utilisateur utilisateur = (from u in db.Utilisateur where u.IdUtilisateur == item.IdUtilisateur select u).First();
                MessageUtilisateur messageUtilisateur = new MessageUtilisateur();
                messageUtilisateur.PseudoUtilisateur = utilisateur.PseudoUtilisateur;
                messageUtilisateur.IdMessage = item.IdMessage;
                messageUtilisateur.IdTon = item.IdTon;
                messageUtilisateur.IdUtilisateur = item.IdUtilisateur;
                messageUtilisateur.DateEnvoi = item.DateEnvoi;
                messageUtilisateur.TexteMessage = item.TexteMessage;
                messageUtilisateur.IdDiscussion = item.IdDiscussion;
                
                messageUtilisateur.StatutMessage = item.StatutMessage;
                messagesUtilisateur.Add(messageUtilisateur);
            }
            return messagesUtilisateur;
        }
    }
}