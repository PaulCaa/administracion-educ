﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EscuelaDBEntities : DbContext
    {
        public EscuelaDBEntities()
            : base("name=EscuelaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catedras> Catedras { get; set; }
        public virtual DbSet<Cursadas> Cursadas { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<CursadasAlumno> Cursadas_Alumno { get; set; }
        public virtual DbSet<ListadoCatedras> Listado_Catedras { get; set; }
    }
}