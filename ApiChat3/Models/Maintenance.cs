//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiChat3.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Maintenance
    {
        public int IdMaintenance { get; set; }
        public string DescriptionMaintenance { get; set; }
        public int IdUtilisateur { get; set; }
        [JsonIgnore]
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
