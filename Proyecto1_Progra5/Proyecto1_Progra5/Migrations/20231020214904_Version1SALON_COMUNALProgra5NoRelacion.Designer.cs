﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto1_Progra5.Data;

#nullable disable

namespace Proyecto1_Progra5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231020214904_Version1SALON_COMUNALProgra5NoRelacion")]
    partial class Version1SALON_COMUNALProgra5NoRelacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
#pragma warning restore 612, 618
        }
    }
}
