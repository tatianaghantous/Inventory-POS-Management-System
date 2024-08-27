using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    LoginId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: true),
                    HasPermission = table.Column<long>(type: "INTEGER", nullable: true),
                    LastConnection = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    BackupNumber = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInfo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyCode = table.Column<string>(type: "TEXT", nullable: false),
                    CurrencyName = table.Column<string>(type: "TEXT", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    option_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    option_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.option_id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingKey = table.Column<string>(type: "TEXT", nullable: false),
                    SettingValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingKey);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<long>(name: "Id ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(name: "Amount ", type: "REAL", nullable: false),
                    PaidDate = table.Column<string>(name: "PaidDate ", type: "TEXT", nullable: false),
                    PaymentMethod = table.Column<string>(name: "PaymentMethod ", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    DisplayInPOS = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentWorker = table.Column<long>(type: "INTEGER", nullable: false),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "DailySales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    StartingBalance = table.Column<double>(type: "REAL", nullable: true),
                    EndBalance = table.Column<double>(type: "REAL", nullable: true),
                    Profit = table.Column<double>(type: "REAL", nullable: true),
                    TotalSales = table.Column<double>(type: "REAL", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySales_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NotificationText = table.Column<string>(type: "TEXT", nullable: true),
                    NotificationSeen = table.Column<long>(type: "INTEGER", nullable: false),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentMethodName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PromotionName = table.Column<string>(type: "TEXT", nullable: true),
                    Discount = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<string>(type: "TEXT", nullable: true),
                    EndDate = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotions_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInformation = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarcodeId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<long>(type: "INTEGER", nullable: true),
                    SellingPrice = table.Column<double>(type: "REAL", nullable: true),
                    InitialPrice = table.Column<double>(type: "REAL", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "OrderSummary",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerId = table.Column<long>(type: "INTEGER", nullable: true),
                    BuyerId = table.Column<long>(type: "INTEGER", nullable: true),
                    isPaid = table.Column<long>(type: "INTEGER", nullable: false, defaultValueSql: "1"),
                    OrderDate = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDateTime = table.Column<string>(type: "TEXT", nullable: true),
                    TotalInLBP = table.Column<double>(type: "REAL", nullable: true),
                    GainInLBP = table.Column<double>(type: "REAL", nullable: true),
                    TotalInUSD = table.Column<double>(type: "REAL", nullable: true),
                    GainInUSD = table.Column<double>(type: "REAL", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    TotalAfterDiscountInUSD = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSummary", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderSummary_Accounts_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Accounts",
                        principalColumn: "LoginId");
                    table.ForeignKey(
                        name: "FK_OrderSummary_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_OrderSummary_Customers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceCost = table.Column<double>(type: "REAL", nullable: false),
                    ServiceSellingPrice = table.Column<double>(type: "REAL", nullable: false),
                    ServiceType = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceDate = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceProfit = table.Column<double>(type: "REAL", nullable: true),
                    IsPaid = table.Column<long>(type: "INTEGER", nullable: false),
                    ServiceDuration = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Services_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    SupplierId = table.Column<long>(type: "INTEGER", nullable: true),
                    QuantityInStock = table.Column<long>(type: "INTEGER", nullable: true),
                    LastRestockedDate = table.Column<string>(type: "TEXT", nullable: true),
                    ReorderThreshold = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Inventory_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierID = table.Column<long>(type: "INTEGER", nullable: true),
                    ProductID = table.Column<long>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "1"),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    CurrencyID = table.Column<long>(type: "INTEGER", nullable: true),
                    PurchaseOrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    ExpectedDeliveryDate = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAmount = table.Column<double>(type: "REAL", nullable: false),
                    InitialPayment = table.Column<double>(type: "REAL", nullable: true, defaultValueSql: "0.00"),
                    TotalPaid = table.Column<double>(type: "REAL", nullable: true, defaultValueSql: "0.00"),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentStatus = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_Purchases_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Purchases_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyID");
                    table.ForeignKey(
                        name: "FK_Purchases_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    ReturnId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReturnDate = table.Column<string>(type: "TEXT", nullable: true),
                    ReturnedProductID = table.Column<long>(type: "INTEGER", nullable: true),
                    NewProductID = table.Column<long>(type: "INTEGER", nullable: true),
                    QuantityReturned = table.Column<long>(type: "INTEGER", nullable: true),
                    ReturnReason = table.Column<string>(type: "TEXT", nullable: true),
                    Refund = table.Column<double>(type: "REAL", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PaidDifference = table.Column<double>(type: "REAL", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.ReturnId);
                    table.ForeignKey(
                        name: "FK_Returns_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Returns_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Returns_Products_NewProductID",
                        column: x => x.NewProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ReviewsRatings",
                columns: table => new
                {
                    ReviewRatingID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductID = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomerID = table.Column<long>(type: "INTEGER", nullable: true),
                    Rating = table.Column<long>(type: "INTEGER", nullable: true),
                    ReviewText = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewDate = table.Column<string>(type: "TEXT", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsRatings", x => x.ReviewRatingID);
                    table.ForeignKey(
                        name: "FK_ReviewsRatings_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_ReviewsRatings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_ReviewsRatings_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ShopifyOrders",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ProductID = table.Column<long>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomerID = table.Column<long>(type: "INTEGER", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderDate = table.Column<string>(type: "TEXT", nullable: true),
                    FulfillmentStatus = table.Column<string>(type: "TEXT", nullable: true),
                    FinancialStatus = table.Column<string>(type: "TEXT", nullable: true),
                    ShippingAddress = table.Column<string>(type: "TEXT", nullable: true),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopifyOrders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_ShopifyOrders_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_ShopifyOrders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_ShopifyOrders_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    option_id = table.Column<long>(type: "INTEGER", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    InitialPrice = table.Column<double>(type: "REAL", nullable: true),
                    SellingPrice = table.Column<double>(type: "REAL", nullable: true),
                    Barcode = table.Column<string>(type: "TEXT", nullable: true),
                    Sku = table.Column<string>(type: "TEXT", nullable: true),
                    GrpByVariantId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_Variants_Options_option_id",
                        column: x => x.option_id,
                        principalTable: "Options",
                        principalColumn: "option_id");
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Variants_Variants_GrpByVariantId",
                        column: x => x.GrpByVariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<long>(type: "INTEGER", nullable: true),
                    PriceUsd = table.Column<double>(type: "REAL", nullable: true),
                    InitialCost = table.Column<double>(type: "REAL", nullable: true),
                    SalePrice = table.Column<double>(type: "REAL", nullable: true),
                    IsPaid = table.Column<long>(type: "INTEGER", nullable: false, defaultValueSql: "1"),
                    UnitPriceAfterDiscount = table.Column<double>(type: "REAL", nullable: true),
                    DiscountedFromShopify = table.Column<long>(type: "INTEGER", nullable: true),
                    TotalPriceAfterDiscount = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderSummary_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderSummary",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionDate = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<long>(type: "INTEGER", nullable: true),
                    PaymentMethodID = table.Column<long>(type: "INTEGER", nullable: true),
                    BranchID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Accounts",
                        principalColumn: "LoginId");
                    table.ForeignKey(
                        name: "FK_Transactions_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_Transactions_OrderSummary_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderSummary",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BranchID",
                table: "Categories",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchID",
                table: "Customers",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_BranchID",
                table: "DailySales",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BranchID",
                table: "Inventory",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SupplierId",
                table: "Inventory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BranchID",
                table: "Notifications",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummary_BranchID",
                table: "OrderSummary",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummary_BuyerId",
                table: "OrderSummary",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummary_SellerId",
                table: "OrderSummary",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BranchID",
                table: "PaymentMethods",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BarcodeId",
                table: "Products",
                column: "BarcodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BranchID",
                table: "Products",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BranchID",
                table: "Promotions",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BranchID",
                table: "Purchases",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CurrencyID",
                table: "Purchases",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductID",
                table: "Purchases",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierID",
                table: "Purchases",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_BranchID",
                table: "Returns",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_CustomerId",
                table: "Returns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_NewProductID",
                table: "Returns",
                column: "NewProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsRatings_BranchID",
                table: "ReviewsRatings",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsRatings_CustomerID",
                table: "ReviewsRatings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsRatings_ProductID",
                table: "ReviewsRatings",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BranchID",
                table: "Services",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CustomerID",
                table: "Services",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopifyOrders_BranchID",
                table: "ShopifyOrders",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopifyOrders_CustomerID",
                table: "ShopifyOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopifyOrders_ProductID",
                table: "ShopifyOrders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PaidDate ",
                table: "Subscription",
                column: "PaidDate ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BranchID",
                table: "Suppliers",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchID",
                table: "Transactions",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_GrpByVariantId",
                table: "Variants",
                column: "GrpByVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_option_id",
                table: "Variants",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySales");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "ReviewsRatings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "ShopifyOrders");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "OrderSummary");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
