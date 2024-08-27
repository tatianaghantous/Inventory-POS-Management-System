using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopifyAPI.Models;

public partial class ClothingStoreContext : DbContext
{
    public ClothingStoreContext()
    {
    }

    public ClothingStoreContext(DbContextOptions<ClothingStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DailySale> DailySales { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<ReviewsRating> ReviewsRatings { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ShopifyOrder> ShopifyOrders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Clothing Store;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK_Account");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.HashedPassword).HasMaxLength(50);
            entity.Property(e => e.LastConnection).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branches__A1682FA5AE6396A0");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BranchName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Categories)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Categories_Branches");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Customers)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Customers_Branches");
        });

        modelBuilder.Entity<DailySale>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.EndBalance).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.Profit).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.StartingBalance).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.TotalSales).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.DailySales)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_DailySales_Branches");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.LastRestockedDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReorderThreshold).HasColumnType("date");

            entity.HasOne(d => d.Branch).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Inventory_Branches");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Inventory_Products");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Inventory_Suppliers");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK_Table_1");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.NotificationText).HasMaxLength(255);

            entity.HasOne(d => d.Branch).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Table_1_Table_1");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.InitialCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceAfterDiscount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceUsd).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Products");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_OrderSummary");
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrderSummary");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.GainInLbp)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("GainInLBP");
            entity.Property(e => e.GainInUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("GainInUSD");
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderDateTime).HasColumnType("datetime");
            entity.Property(e => e.TotalInLbp)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TotalInLBP");
            entity.Property(e => e.TotalInUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TotalInUSD");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrderSummaries)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrderSummary_Branches");

            entity.HasOne(d => d.Buyer).WithMany(p => p.OrderSummaries)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_OrderSummary_Customers");

            entity.HasOne(d => d.Seller).WithMany(p => p.OrderSummaries)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderSummary_Accounts");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.PaymentMethodName).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_PaymentMethods_Branches");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BarcodeId, "BarcodeUnique").IsUnique();

            entity.Property(e => e.BarcodeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.InitialPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.Products)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Products_Branches");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Discount).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Branch).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Promotions_Branches");
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NewProductId).HasColumnName("NewProductID");
            entity.Property(e => e.PaidDifference).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Refund).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnReason)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedProductId).HasColumnName("ReturnedProductID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Returns)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Returns_Branches");

            entity.HasOne(d => d.NewProduct).WithMany(p => p.Returns)
                .HasForeignKey(d => d.NewProductId)
                .HasConstraintName("FK_Returns_Products");
        });

        modelBuilder.Entity<ReviewsRating>(entity =>
        {
            entity.HasKey(e => e.ReviewRatingId);

            entity.Property(e => e.ReviewRatingId).HasColumnName("ReviewRatingID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ReviewDate).HasColumnType("date");
            entity.Property(e => e.ReviewText).HasColumnType("text");

            entity.HasOne(d => d.Branch).WithMany(p => p.ReviewsRatings)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_ReviewsRatings_Branches");

            entity.HasOne(d => d.Customer).WithMany(p => p.ReviewsRatings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ReviewsRatings_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.ReviewsRatings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ReviewsRatings_Products");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.IsPaid)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ServiceCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceDate).HasColumnType("date");
            entity.Property(e => e.ServiceDuration).HasMaxLength(50);
            entity.Property(e => e.ServiceProfit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceSellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceType).HasMaxLength(90);

            entity.HasOne(d => d.Branch).WithMany(p => p.Services)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Services_Branches");
        });

        modelBuilder.Entity<ShopifyOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ShopifyO__C3905BAF4755CD70");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FinancialStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FulfillmentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.ShopifyOrders)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__ShopifyOr__Branc__7AF13DF7");

            entity.HasOne(d => d.Customer).WithMany(p => p.ShopifyOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ShopifyOr__Custo__7908F585");

            entity.HasOne(d => d.Product).WithMany(p => p.ShopifyOrders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ShopifyOr__Produ__79FD19BE");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.ContactInformation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Suppliers_Branches");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Transactions_Branches");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Transactions_Accounts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
