using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMDataLayer.Models;

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

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DailySale> DailySales { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<ReviewsRating> ReviewsRatings { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<ShopifyOrder> ShopifyOrders { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SoftwaholicApp", "ClothingStore.db"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Categories_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.DisplayInPos).HasColumnName("DisplayInPOS");

            entity.HasOne(d => d.Branch).WithMany(p => p.Categories).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Customers_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Customers).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<DailySale>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_DailySales_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.DailySales).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.HasIndex(e => e.BranchId, "IX_Inventory_BranchID");

            entity.HasIndex(e => e.ProductId, "IX_Inventory_ProductId");

            entity.HasIndex(e => e.SupplierId, "IX_Inventory_SupplierId");


            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");


            entity.HasOne(d => d.Branch).WithMany(p => p.Inventories).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Inventories).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Notifications_BranchID");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Notifications).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.OptionName).HasColumnName("option_name");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.ItemId, "IX_OrderItem_ItemId");

            entity.HasIndex(e => e.OrderId, "IX_OrderItem_OrderId");

            entity.Property(e => e.IsPaid).HasDefaultValueSql("1");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrderSummary");

            entity.HasIndex(e => e.BranchId, "IX_OrderSummary_BranchID");

            entity.HasIndex(e => e.BuyerId, "IX_OrderSummary_BuyerId");

            entity.HasIndex(e => e.SellerId, "IX_OrderSummary_SellerId");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.GainInLbp).HasColumnName("GainInLBP");
            entity.Property(e => e.GainInUsd).HasColumnName("GainInUSD");
            entity.Property(e => e.IsPaid)
                .HasDefaultValueSql("1")
                .HasColumnName("isPaid");
            entity.Property(e => e.TotalAfterDiscountInUsd).HasColumnName("TotalAfterDiscountInUSD");
            entity.Property(e => e.TotalInLbp).HasColumnName("TotalInLBP");
            entity.Property(e => e.TotalInUsd).HasColumnName("TotalInUSD");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrderSummaries).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Buyer).WithMany(p => p.OrderSummaries).HasForeignKey(d => d.BuyerId);

            entity.HasOne(d => d.Seller).WithMany(p => p.OrderSummaries).HasForeignKey(d => d.SellerId);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_PaymentMethods_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.PaymentMethods).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BarcodeId, "IX_Products_BarcodeId").IsUnique();

            entity.HasIndex(e => e.BranchId, "IX_Products_BranchID");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Products).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Promotions_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Promotions).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Purchases_BranchID");

            entity.HasIndex(e => e.CurrencyId, "IX_Purchases_CurrencyID");

            entity.HasIndex(e => e.ProductId, "IX_Purchases_ProductID");

            entity.HasIndex(e => e.SupplierId, "IX_Purchases_SupplierID");

            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.InitialPayment).HasDefaultValueSql("0.00");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValueSql("1");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.TotalPaid).HasDefaultValueSql("0.00");

            entity.HasOne(d => d.Branch).WithMany(p => p.Purchases).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Currency).WithMany(p => p.Purchases).HasForeignKey(d => d.CurrencyId);

            entity.HasOne(d => d.Product).WithMany(p => p.Purchases).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Returns_BranchID");

            entity.HasIndex(e => e.CustomerId, "IX_Returns_CustomerId");

            entity.HasIndex(e => e.NewProductId, "IX_Returns_NewProductID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.NewProductId).HasColumnName("NewProductID");
            entity.Property(e => e.ReturnedProductId).HasColumnName("ReturnedProductID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Returns).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Returns).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.NewProduct).WithMany(p => p.Returns).HasForeignKey(d => d.NewProductId);
        });

        modelBuilder.Entity<ReviewsRating>(entity =>
        {
            entity.HasKey(e => e.ReviewRatingId);

            entity.HasIndex(e => e.BranchId, "IX_ReviewsRatings_BranchID");

            entity.HasIndex(e => e.CustomerId, "IX_ReviewsRatings_CustomerID");

            entity.HasIndex(e => e.ProductId, "IX_ReviewsRatings_ProductID");

            entity.Property(e => e.ReviewRatingId).HasColumnName("ReviewRatingID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Branch).WithMany(p => p.ReviewsRatings).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Customer).WithMany(p => p.ReviewsRatings).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Product).WithMany(p => p.ReviewsRatings).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Services_BranchID");

            entity.HasIndex(e => e.CustomerId, "IX_Services_CustomerID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Services).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Services).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingKey);
        });

        modelBuilder.Entity<ShopifyOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.HasIndex(e => e.BranchId, "IX_ShopifyOrders_BranchID");

            entity.HasIndex(e => e.CustomerId, "IX_ShopifyOrders_CustomerID");

            entity.HasIndex(e => e.ProductId, "IX_ShopifyOrders_ProductID");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Branch).WithMany(p => p.ShopifyOrders).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Customer).WithMany(p => p.ShopifyOrders).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Product).WithMany(p => p.ShopifyOrders).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("Subscription");

            entity.HasIndex(e => e.PaidDate, "IX_Subscription_PaidDate ").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id ");
            entity.Property(e => e.Amount).HasColumnName("Amount ");
            entity.Property(e => e.PaidDate).HasColumnName("PaidDate ");
            entity.Property(e => e.PaymentMethod).HasColumnName("PaymentMethod ");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Suppliers_BranchID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Suppliers).HasForeignKey(d => d.BranchId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(e => e.BranchId, "IX_Transactions_BranchID");

            entity.HasIndex(e => e.EmployeeId, "IX_Transactions_EmployeeId");

            entity.HasIndex(e => e.OrderId, "IX_Transactions_OrderId");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Transactions).HasForeignKey(d => d.BranchId);

            entity.HasOne(d => d.Employee).WithMany(p => p.Transactions).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasIndex(e => e.GrpByVariantId, "IX_Variants_GrpByVariantId");

            entity.HasIndex(e => e.ProductId, "IX_Variants_ProductId");

            entity.HasIndex(e => e.OptionId, "IX_Variants_option_id");

            entity.Property(e => e.OptionId).HasColumnName("option_id");

            entity.HasOne(d => d.GrpByVariant).WithMany(p => p.InverseGrpByVariant).HasForeignKey(d => d.GrpByVariantId);

            entity.HasOne(d => d.Option).WithMany(p => p.Variants).HasForeignKey(d => d.OptionId);

            entity.HasOne(d => d.Product).WithMany(p => p.Variants).HasForeignKey(d => d.ProductId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
