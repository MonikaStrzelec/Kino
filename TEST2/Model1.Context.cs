﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kino
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dim> Dim { get; set; }
        public virtual DbSet<DimsMovie> DimsMovie { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieState> MovieState { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonType> PersonType { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleStatus> ScheduleStatus { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<MoviePerson> MoviePerson { get; set; }
    }
}