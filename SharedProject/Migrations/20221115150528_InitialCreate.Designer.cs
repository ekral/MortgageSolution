// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedProject;

#nullable disable

namespace SharedProject.Migrations
{
    [DbContext(typeof(MortgagesContext))]
    [Migration("20221115150528_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("SharedProject.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("InterestRate")
                        .HasColumnType("REAL");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("REAL");

                    b.Property<int>("LoanTerm")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Mortgages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestRate = 6.0,
                            LoanAmount = 8000000.0,
                            LoanTerm = 30
                        },
                        new
                        {
                            Id = 2,
                            InterestRate = 5.0,
                            LoanAmount = 4000000.0,
                            LoanTerm = 20
                        },
                        new
                        {
                            Id = 3,
                            InterestRate = 4.0,
                            LoanAmount = 5000000.0,
                            LoanTerm = 15
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
