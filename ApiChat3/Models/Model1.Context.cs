﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiChat3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Chat2Entities : DbContext
    {
        public Chat2Entities()
            : base("name=Chat2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acces> Acces { get; set; }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<Discussion> Discussion { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<StatutDiscussion> StatutDiscussion { get; set; }
        public virtual DbSet<StatutUtilisateur> StatutUtilisateur { get; set; }
        public virtual DbSet<Ton> Ton { get; set; }
        public virtual DbSet<TypeDiscussion> TypeDiscussion { get; set; }
        public virtual DbSet<TypeNotification> TypeNotification { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurDiscussion> UtilisateurDiscussion { get; set; }
    }
}
