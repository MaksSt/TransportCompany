using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TransportCompany.Entities;

public partial class TransportdbContext : DbContext
{
    public TransportdbContext()
    {
    }

    public TransportdbContext(DbContextOptions<TransportdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Contractemployee> Contractemployees { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<Scheme> Schemes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Сarrier> Сarriers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=transportdb;username=root;password=1222");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.HasIndex(e => e.CategoryIid, "fk_Cargo_Category1_idx");

            entity.HasIndex(e => e.ContractId, "fk_Cargo_Contract1_idx");

            entity.HasIndex(e => e.StockId, "fk_Cargo_Stock1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryIid).HasColumnName("category_Iid");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Quanyity)
                .HasMaxLength(45)
                .HasColumnName("quanyity");
            entity.Property(e => e.StockId).HasColumnName("stock_id");

            entity.HasOne(d => d.CategoryI).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CategoryIid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cargo_Category1");

            entity.HasOne(d => d.Contract).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cargo_Contract1");

            entity.HasOne(d => d.Stock).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cargo_Stock1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasMaxLength(45)
                .HasColumnName("category");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("checks");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.NodeId, "fk_Check_Node1_idx");

            entity.Property(e => e.Id)
                .HasMaxLength(45)
                .HasColumnName("id");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.PaymentAmount).HasColumnName("payment_amount");

            entity.HasOne(d => d.Node).WithMany(p => p.Checks)
                .HasForeignKey(d => d.NodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Check_Node1");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contracts");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CustomerId, "fk_Contract_Customer1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DateOfConclusionOfTheContract)
                .HasMaxLength(45)
                .HasColumnName("date_of_conclusion_of_the_contract");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShipmentDate)
                .HasMaxLength(45)
                .HasColumnName("shipment_date");
            entity.Property(e => e.ЗlaceOfDelivery)
                .HasMaxLength(45)
                .HasColumnName("зlace_of_delivery");

            entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contract_Customer1");
        });

        modelBuilder.Entity<Contractemployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("contractemployee");

            entity.HasIndex(e => e.ContractId, "Contract_idx");

            entity.HasIndex(e => e.EmployeeId, "fk_Contract-Employee_Employee1_idx");

            entity.Property(e => e.ContractId).HasColumnName("Contract_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.HasOne(d => d.Contract).WithMany()
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Contract");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contract-Employee_Employee1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Middlename)
                .HasMaxLength(45)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Post)
                .HasMaxLength(45)
                .HasColumnName("post");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoices");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ContractId, "fk_Invoice_Contract1_idx");

            entity.HasIndex(e => e.NodeId, "fk_Invoice_Node1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.Price)
                .HasMaxLength(45)
                .HasColumnName("price");
            entity.Property(e => e.PriceCustomClearance)
                .HasMaxLength(45)
                .HasColumnName("price_custom_clearance");

            entity.HasOne(d => d.Contract).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Invoice_Contract1");

            entity.HasOne(d => d.Node).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.NodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Invoice_Node1");
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nodes");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "fk_Node_Employee1_idx");

            entity.HasIndex(e => e.CarrierId, "fk_Node_Сarrier1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(45)
                .HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryPoint)
                .HasMaxLength(45)
                .HasColumnName("delivery_point");
            entity.Property(e => e.DoINeedCustomsClearance)
                .HasMaxLength(45)
                .HasColumnName("do_I_need_customs_clearance");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ReceptionPoint)
                .HasMaxLength(45)
                .HasColumnName("reception_point");
            entity.Property(e => e.Transport)
                .HasMaxLength(45)
                .HasColumnName("transport");
            entity.Property(e => e.TypeOfTransportation)
                .HasMaxLength(45)
                .HasColumnName("type_of_transportation");

            entity.HasOne(d => d.Carrier).WithMany(p => p.Nodes)
                .HasForeignKey(d => d.CarrierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Node_Сarrier1");

            entity.HasOne(d => d.Employee).WithMany(p => p.Nodes)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Node_Employee1");
        });

        modelBuilder.Entity<Scheme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("schemes");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.NodeId, "fk_Scheme_Node1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NodeId).HasColumnName("node_id");

            entity.HasOne(d => d.Node).WithMany(p => p.Schemes)
                .HasForeignKey(d => d.NodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Scheme_Node1");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("stocks");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
        });

        modelBuilder.Entity<Сarrier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("сarriers");

            entity.HasIndex(e => e.Id, "ID_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(45)
                .HasColumnName("company");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
