namespace ShopifyAPI
{
    using Newtonsoft.Json;
    using System;
    using System.Text.Json.Serialization;


    public class ShopifyWebhookData
    {
        public EventData? Event { get; set; }
    }

    public class EventData
    {
        public string? Method { get; set; }

        public string? Path { get; set; }

        public string? Url { get; set; }

        public string? Client_ip { get; set; }
        public HeadersData? Headers { get; set; }
        public BodyData? Body { get; set; }

        public Query? Query { get; set; }
    }
    public class Query
    {

    }
    public class HeadersData
    {

        [JsonProperty("x-shopify-hmac-sha256")]
        public string? ShopifyHmacSha256 { get; set; }

        public string? Accept { get; set; }

        [JsonProperty("accept-encoding")]
        public string? AcceptEncoding { get; set; }

        [JsonProperty("content-length")]
        public string? ContentLength { get; set; }

        [JsonProperty("content-type")]
        public string? ContentType { get; set; }


        public string? Host { get; set; }

        [JsonProperty("user-agent")]
        public string? UserAgent { get; set; }

        [JsonProperty("x-shopify-api-version")]
        public string? ShopifyApiVersion { get; set; }

        [JsonProperty("x-shopify-order-id")]
        public string? ShopifyOrderId { get; set; }

        [JsonProperty("x-shopify-shop-domain")]
        public string? ShopifyShopDomain { get; set; }

        [JsonProperty("x-shopify-test")]
        public string? ShopifyTest { get; set; }

        [JsonProperty("x-shopify-topic")]
        public string? ShopifyTopic { get; set; }

        [JsonProperty("x-shopify-triggered-at")]
        public string? ShopifyTriggeredAt { get; set; }

        [JsonProperty("x-shopify-webhook-id")]
        public string? ShopifyWebhookId { get; set; }

    }

    public class BodyData
    {

        public long? Id { get; set; }

        [JsonProperty("admin_graphql_api_id")]
        public string? AdminGraphqlApiId { get; set; }


        [JsonProperty("app_id")]
        public int AppId { get; set; }

        [JsonProperty("browser_ip")]
        public string? BrowserIp { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool? BuyerAcceptsMarketing { get; set; }

        [JsonProperty("cancel_reason")]
        public string? CancelReason { get; set; }

        [JsonProperty("cancelled_at")]
        public DateTime? CancelledAt { get; set; }

        [JsonProperty("cart_token")]
        public string? CartToken { get; set; }

        [JsonProperty("checkout_id")]
        public long? CheckoutId { get; set; }

        [JsonProperty("checkout_token")]
        // public BillingAddress BillingAddress { get; set; }
        public string? CheckoutToken { get; set; }

        // [JsonProperty("client_details")]
        // public ClientDetails? ClientDetails { get; set; }
        [JsonProperty("closed_at")]
        public object ClosedAt { get; set; }


        [JsonProperty("confirmation_number")]
        public string ConfirmationNumber { get; set; }


        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }


        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }


        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }


        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("current_subtotal_price")]
        public string CurrentSubtotalPrice { get; set; }

        //public CurrentSubtotalPriceSet CurrentSubtotalPriceSet { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        public decimal? CurrentTotalDiscounts { get; set; }

        //public CurrentTotalDiscountsSet CurrentTotalDiscountsSet { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        public object CurrentTotalDutiesSet { get; set; }

        public decimal? CurrentTotalPrice { get; set; }

        //public CurrentTotalPriceSet CurrentTotalPriceSet { get; set; }
        // [Newtonsoft.Json.JsonIgnore]
        public decimal? CurrentTotalTax { get; set; }
        // [Newtonsoft.Json.JsonIgnore]
        // public CurrentTotalTaxSet CurrentTotalTaxSet { get; set; }
        //  [Newtonsoft.Json.JsonIgnore]
        //public CustomerInShopify Customer { get; set; }

        [JsonProperty("customer_locale")]
        public string CustomerLocale { get; set; }


        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
        //[Newtonsoft.Json.JsonIgnore]

        // [JsonProperty("discount_applications")]
        // public DiscountApplication[] DiscountApplications { get; set; }
        // [Newtonsoft.Json.JsonIgnore]

        //[JsonProperty("discount_codes")]
        //public DiscountCode[] DiscountCodes { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("estimated_taxes")]
        public bool? EstimatedTaxes { get; set; }


        [JsonProperty("financial_status")]
        public string FinancialStatus { get; set; }


        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }
        //[Newtonsoft.Json.JsonIgnore]

        // [JsonProperty("fulfillments")]
        // public Fulfillment[] Fulfillments { get; set; }


        [JsonProperty("line_items")]
        public LineItem[] LineItems { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("location_id")]
        //  public string? LocationId { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("merchant_of_record_app_id")]
        //  public string? MerchantOfRecordAppId { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("name")]
        //  public string? Name { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("note")]
        //  public string? Note { get; set; }
        //    //  [Newtonsoft.Json.JsonIgnore]

        //    //  [JsonProperty("note_attributes")]
        ////  public NoteAttribute[]? NoteAttributes { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("number")]
        //  public string? Number { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("order_number")]
        //  public string? OrderNumber { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("order_status_url")]
        //  public string? OrderStatusUrl { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("original_total_additional_fees_set")]
        //  public string? OriginalTotalAdditionalFeesSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("original_total_duties_set")]
        //  public string? OriginalTotalDutiesSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("payment_gateway_names")]
        //  public string[]? PaymentGatewayNames { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("payment_terms")]
        //  public string? PaymentTerms { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("phone")]
        //  public string? Phone { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("po_number")]
        //  public string? PONumber { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("presentment_currency")]
        //  public string? PresentmentCurrency { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("processed_at")]
        //  public string? ProcessedAt { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("reference")]
        //  public string? Reference { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("referring_site")]
        //  public string? ReferringSite { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("refunds")]
        //  public Refund[]? Refunds { get; set; }
        //    //  [Newtonsoft.Json.JsonIgnore]

        //     // [JsonProperty("shipping_lines")]
        // // public ShippingLine[]? ShippingLines { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("tags")]
        //  public string? Tags { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("tax_exempt")]
        //  public bool? TaxExempt { get; set; }
        //      //[Newtonsoft.Json.JsonIgnore]
        //     // [JsonProperty("tax_lines")]
        //      //public TaxLine[]? TaxLines { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_discounts")]
        //      public string? TotalDiscounts { get; set; }
        //     // [Newtonsoft.Json.JsonIgnore]

        //    //  [JsonProperty("total_discounts_set")]
        //     // public MoneySet? TotalDiscountsSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_line_items_price")]
        //      public string? TotalLineItemsPrice { get; set; }
        //     // [Newtonsoft.Json.JsonIgnore]

        //     // [JsonProperty("total_line_items_price_set")]
        //      //public MoneySet? TotalLineItemsPriceSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_outstanding")]
        //      public string? TotalOutstanding { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_price")]
        //      public string? TotalPrice { get; set; }
        //     // [Newtonsoft.Json.JsonIgnore]

        //     // [JsonProperty("total_price_set")]
        //     // public MoneySet? TotalPriceSet { get; set; }
        //     // [Newtonsoft.Json.JsonIgnore]

        //     // [JsonProperty("total_shipping_price_set")]
        //     /// public MoneySet? TotalShippingPriceSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_tax")]
        //      public string? TotalTax { get; set; }
        //     // [Newtonsoft.Json.JsonIgnore]

        //    //  [JsonProperty("total_tax_set")]
        //      //public MoneySet? TotalTaxSet { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_tip_received")]
        //      public string? TotalTipReceived { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("total_weight")]
        //      public string? TotalWeight { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("updated_at")]
        //      public string? UpdatedAt { get; set; }
        //      [Newtonsoft.Json.JsonIgnore]

        //      [JsonProperty("user_id")]
        //      public string? UserId { get; set; }

        //  }

        //public class Refund
        //{
        //    [Newtonsoft.Json.JsonIgnore]
        //    [JsonProperty("id")]
        //    public string? Id { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("shipping_address")]
        //    //public ShippingAddress? ShippingAddress { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("shipping_lines")]
        //    //public ShippingLine[]? ShippingLines { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("discount_allocations")]
        //    //public DiscountAllocation[]? DiscountAllocations { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("requested_fulfillment_service_id")]
        //    public string? RequestedFulfillmentServiceId { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("source")]
        //    public string? Source { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("tax_lines")]
        //    //public TaxLine[]? TaxLines { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("subtotal_price")]
        //    //public decimal SubtotalPrice { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    //[JsonProperty("subtotal_price_set")]
        //    //public MoneySet? SubtotalPriceSet { get; set; }
        //    //[Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("tags")]
        //    public string? Tags { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("tax_exempt")]
        //    public bool TaxExempt { get; set; }
        //}

        //public class Fulfillment
        //{
        //    [Newtonsoft.Json.JsonIgnore]
        //    [JsonProperty("id")]
        //    public string? Id { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("landing_site")]
        //    public string? LandingSite { get; set; }
        //    [Newtonsoft.Json.JsonIgnore]

        //    [JsonProperty("landing_site_ref")]
        //    public string? LandingSiteRef { get; set; }
        //}

        public class LineItem
        {
    
            [JsonProperty("admin_graphql_api_id")]
            public string AdminGraphqlApiId { get; set; }
    

            [JsonProperty("attributed_staffs")]
            public string[] AttributedStaffs { get; set; }
    

            [JsonProperty("current_quantity")]
            public int? CurrentQuantity { get; set; }
            //    [Newtonsoft.Json.JsonIgnore]

            //    [JsonProperty("discount_allocations")]
            //public DiscountAllocation[] DiscountAllocations { get; set; }
            //    [Newtonsoft.Json.JsonIgnore]

            //    [JsonProperty("duties")]
            //public Duty[] Duties { get; set; }
    

            [JsonProperty("fulfillable_quantity")]
            public int? FulfillableQuantity { get; set; }
    

            [JsonProperty("fulfillment_service")]
            public string FulfillmentService { get; set; }
    

            [JsonProperty("fulfillment_status")]
            public string FulfillmentStatus { get; set; }
    

            [JsonProperty("gift_card")]
            public bool? GiftCard { get; set; }
    

            [JsonProperty("grams")]
            public int? Grams { get; set; }
    

            [JsonProperty("id")]
            public long? Id { get; set; }
    

            [JsonProperty("name")]
            public string Name { get; set; }
    

            [JsonProperty("price")]
            public decimal? Price { get; set; }
            //    [Newtonsoft.Json.JsonIgnore]

            //    [JsonProperty("price_set")]
            //public MoneySet PriceSet { get; set; }
    

            [JsonProperty("product_exists")]
            public bool? ProductExists { get; set; }
    

            [JsonProperty("product_id")]
            public long? ProductId { get; set; }
    

           // [JsonProperty("properties")]
            //public Property[] Properties { get; set; }
    

            [JsonProperty("quantity")]
            public int? Quantity { get; set; }
    

            [JsonProperty("requires_shipping")]
            public bool? RequiresShipping { get; set; }
    

            [JsonProperty("sku")]
            public string Sku { get; set; }
            //    [Newtonsoft.Json.JsonIgnore]

            //    [JsonProperty("tax_lines")]
            //public TaxLine[] TaxLines { get; set; }
    

            [JsonProperty("title")]
            public string Title { get; set; }
    

            [JsonProperty("total_discount")]
            public decimal? TotalDiscount { get; set; }
            //    [Newtonsoft.Json.JsonIgnore]

            //    [JsonProperty("total_discount_set")]
            //public MoneySet TotalDiscountSet { get; set; }
    

            [JsonProperty("variant_id")]
            public long? VariantId { get; set; }
    

            [JsonProperty("variant_inventory_management")]
            public string VariantInventoryManagement { get; set; }
    

            [JsonProperty("variant_title")]
            public string VariantTitle { get; set; }
    

            [JsonProperty("vendor")]
            public string Vendor { get; set; }
        }

        //public class ShippingAddress
        //    {
        //
        //        [JsonProperty("id")]
        //        public long? Id { get; set; }
        //

        //        [JsonProperty("customer_id")]
        //        public long? CustomerId { get; set; }
        //

        //        [JsonProperty("first_name")]
        //        public string? FirstName { get; set; }
        //

        //        [JsonProperty("last_name")]
        //        public string? LastName { get; set; }
        //

        //        [JsonProperty("address1")]
        //        public string? Address1 { get; set; }
        //

        //        [JsonProperty("address2")]
        //        public string? Address2 { get; set; }
        //

        //        [JsonProperty("city")]
        //        public string? City { get; set; }
        //

        //        [JsonProperty("province")]
        //        public string? Province { get; set; }
        //

        //        [JsonProperty("country")]
        //        public string? Country { get; set; }
        //

        //        [JsonProperty("zip")]
        //        public string? Zip { get; set; }
        //

        //        [JsonProperty("phone")]
        //        public string? Phone { get; set; }
        //

        //        [JsonProperty("name")]
        //        public string? Name { get; set; }
        //

        //        [JsonProperty("province_code")]
        //        public string? ProvinceCode { get; set; }
        //

        //        [JsonProperty("country_code")]
        //        public string? CountryCode { get; set; }
        //

        //        [JsonProperty("country_name")]
        //        public string? CountryName { get; set; }
        //

        //        [JsonProperty("default")]
        //        public bool? Default { get; set; }
        //

        //        [JsonProperty("latitude")]
        //        public double? Latitude { get; set; }
        //
        //        [JsonProperty("longitude")]
        //        public double? Longitude { get; set; }
        //    }

        //    public class ShippingLine
        //    {
        //
        //        [JsonProperty("id")]
        //        public long? Id { get; set; }
        //

        //        [JsonProperty("title")]
        //        public string? Title { get; set; }
        //

        //        [JsonProperty("price")]
        //        public string? Price { get; set; }
        //

        //        [JsonProperty("code")]
        //        public string? Code { get; set; }
        //

        //        [JsonProperty("source")]
        //        public string? Source { get; set; }
        //

        //        [JsonProperty("phone")]
        //        public string? Phone { get; set; }
        //

        //        [JsonProperty("requested_fulfillment_service_id")]
        //        public string? RequestedFulfillmentServiceId { get; set; }
        //

        //        [JsonProperty("delivery_category")]
        //        public string? DeliveryCategory { get; set; }
        //

        //        [JsonProperty("carrier_identifier")]
        //        public string? CarrierIdentifier { get; set; }
        //

        //        [JsonProperty("discounted_price")]
        //        public string? DiscountedPrice { get; set; }
        //

        //        [JsonProperty("discounted_price_set")]
        //        public MoneySet? DiscountedPriceSet { get; set; }
        //

        //        [JsonProperty("price_set")]
        //        public MoneySet? PriceSet { get; set; }
        //

        //        [JsonProperty("discount_allocations")]
        //        public DiscountAllocation[]? DiscountAllocations { get; set; }
        //

        //        [JsonProperty("tax_lines")]
        //        public TaxLine[]? TaxLines { get; set; }
        //    }

        //    public class DiscountApplication
        //    {
        //
        //        [JsonProperty("type")]
        //        public string? Type { get; set; }
        //

        //        [JsonProperty("value")]
        //        public string? Value { get; set; }
        //

        //        [JsonProperty("value_type")]
        //        public string? ValueType { get; set; }
        //

        //        [JsonProperty("allocation_method")]
        //        public string? AllocationMethod { get; set; }
        //

        //        [JsonProperty("target_selection")]
        //        public string? TargetSelection { get; set; }
        //    

        //            [JsonProperty("target_type")]
        //        public string? TargetType { get; set; }
        //

        //        [JsonProperty("description")]
        //        public string? Description { get; set; }
        //

        //        [JsonProperty("title")]
        //        public string? Title { get; set; }
        //

        //        [JsonProperty("code")]
        //        public string? Code { get; set; }
        //

        //        [JsonProperty("value_set")]
        //        public MoneySet? ValueSet { get; set; }

        //    }


        //public class DiscountAllocation
        //{
        //
        //        [JsonProperty("discounted_price")]
        //    public string? DiscountedPrice { get; set; }
        //

        //        [JsonProperty("discounted_price_set")]
        //    public MoneySet? DiscountedPriceSet { get; set; }
        //}
        //public class Duty
        //{
        //
        //        [JsonProperty("rate")]
        //    public string? Rate { get; set; }
        //

        //        [JsonProperty("title")]
        //    public string? Title { get; set; }
        //

        //        [JsonProperty("taxable")]
        //    public bool? Taxable { get; set; }
        //

        //        [JsonProperty("tax_lines")]
        //    public TaxLine[]? TaxLines { get; set; }
        //}

        //public class CustomerInShopify
        //    {
        //
        //        [JsonProperty("admin_graphql_api_id")]
        //    public string AdminGraphqlApiId { get; set; }
        //
        //        [JsonProperty("created_at")]
        //    public DateTime CreatedAt { get; set; }
        //

        //        public string Currency { get; set; }
        //
        //        [JsonProperty("default_address")]
        //    public DefaultAddress DefaultAddress { get; set; }
        //
        //        [JsonProperty("customer_id")]
        //    public string CustomerId { get; set; }
        //
        //        public bool Default { get; set; }
        //
        //        [JsonProperty("email")]
        //    public string Email { get; set; }
        //
        //        [JsonProperty("email_marketing_consent")]
        //    public EmailMarketingConsent EmailMarketingConsent { get; set; }
        //
        //        [JsonProperty("first_name")]
        //    public string FirstName { get; set; }
        //
        //        public string Id { get; set; }
        //
        //        [JsonProperty("last_name")]
        //    public string LastName { get; set; }
        //
        //        public string MultipassIdentifier { get; set; }
        //
        //        public string Note { get; set; }
        //
        //        public string Phone { get; set; }
        //
        //        [JsonProperty("sms_marketing_consent")]
        //    public string State { get; set; }
        //
        //        public string sms_marketing_consent { get; set; }
        //
        //        public string[] Tags { get; set; }
        //
        //        [JsonProperty("tax_exempt")]
        //    public bool TaxExempt { get; set; }
        //
        //        [JsonProperty("tax_exemptions")]
        //    public string[] TaxExemptions { get; set; }
        //
        //        [JsonProperty("updated_at")]
        //    public DateTime UpdatedAt { get; set; }
        //
        //        [JsonProperty("verified_email")]
        //    public bool VerifiedEmail { get; set; }
        //}
        //public class DefaultAddress
        //{

        //
        //        public string Address1 { get; set; }
        //
        //        public string Address2 { get; set; }
        //
        //        public string City { get; set; }
        //
        //        public string Company { get; set; }
        //
        //        public string Country { get; set; }

        //    [JsonProperty("country_code")]
        //    public string CountryCode { get; set; }
        //    [JsonProperty("country_name")]
        //    public string CountryName { get; set; }
        //    [JsonProperty("customer_id")]
        //    public string CustomerId { get; set; }
        //
        //        public bool Default { get; set; }
        //    [JsonProperty("first_name")]
        //    public string FirstName { get; set; }
        //    public string Id { get; set; }
        //    [JsonProperty("last_name")]
        //    public string LastName { get; set; }
        //
        //        public string Phone { get; set; }
        //
        //        public string Province { get; set; }
        //    [JsonProperty("province_code")]
        //    public string ProvinceCode { get; set; }
        //
        //        public string Zip { get; set; }
        //}

        //public class EmailMarketingConsent
        //{
        //
        //        [JsonProperty("consent_updated_at")]
        //    public object ConsentUpdatedAt { get; set; }
        //
        //        [JsonProperty("opt_in_level")]
        //    public string OptInLevel { get; set; }
        //
        //        public string State { get; set; }
        //
        //        [JsonProperty("first_name")]
        //    public string FirstName { get; set; }

        //
        //        public string Id { get; set; }
        //
        //        [JsonProperty("last_name")]
        //    public string LastName { get; set; }
        //}


        //public class CurrentSubtotalPriceSet
        //    {
        //
        //        public PresentmentMoney PresentmentMoney { get; set; }
        //
        //        public ShopMoney ShopMoney { get; set; }
        //    }

        //    public class PresentmentMoney
        //    {
        //
        //        public decimal? Amount { get; set; }
        //
        //        public string CurrencyCode { get; set; }
        //    }

        //    public class ShopMoney
        //    {
        //
        //        public decimal? Amount { get; set; }
        //
        //        public string CurrencyCode { get; set; }
        //    }

        //    public class CurrentTotalDiscountsSet
        //    {
        //
        //        public PresentmentMoney PresentmentMoney { get; set; }
        //
        //        public ShopMoney ShopMoney { get; set; }
        //    }

        //    public class CurrentTotalPriceSet
        //    {
        //
        //        public PresentmentMoney PresentmentMoney { get; set; }
        //
        //        public ShopMoney ShopMoney { get; set; }
        //    }

        //    public class CurrentTotalTaxSet
        //    {
        //
        //        public PresentmentMoney PresentmentMoney { get; set; }
        //
        //        public ShopMoney ShopMoney { get; set; }
        //    }
        //    public class BillingAddress
        //    {
        //
        //        public string Address1 { get; set; }
        //
        //        public string Address2 { get; set; }
        //
        //        public string City { get; set; }
        //
        //        public string Company { get; set; }
        //
        //        public string Country { get; set; }
        //
        //        public string CountryCode { get; set; }
        //
        //        public string FirstName { get; set; }
        //
        //        public string LastName { get; set; }
        //
        //        public string Latitude { get; set; }
        //
        //        public string Longitude { get; set; }
        //
        //        public string Name { get; set; }
        //
        //        public string Phone { get; set; }
        //
        //        public string Province { get; set; }
        //
        //        public string ProvinceCode { get; set; }
        //
        //        public string Zip { get; set; }
        //    }

        //    public class ClientDetails
        //    {
        //
        //        [JsonProperty("accept_language")]
        //        public string AcceptLanguage { get; set; }
        //

        //        [JsonProperty("browser_height")]
        //        public int? BrowserHeight { get; set; }
        //

        //        [JsonProperty("browser_ip")]
        //        public string BrowserIp { get; set; }
        //

        //        [JsonProperty("browser_width")]
        //        public int? BrowserWidth { get; set; }
        //

        //        [JsonProperty("session_hash")]
        //        public string SessionHash { get; set; }
        //

        //        [JsonProperty("user_agent")]
        //        public string UserAgent { get; set; }
        //    }

        //    public class DiscountCode
        //    {
        //
        //        public string? Code { get; set; }
        //
        //        public string? Amount { get; set; }
        //
        //        public string? Type { get; set; }
        //    }

        //    public class NoteAttribute
        //    {
        //
        //        public string? Name { get; set; }
        //
        //        public string? Value { get; set; }
        //    }

        //    public class PriceSetData
        //    {
        //        [JsonProperty("shop_money")]
        //        public Money? ShopMoney { get; set; }
        //        [JsonProperty("presentment_money")]
        //        public Money? PresentmentMoney { get; set; }
        //    }

        //    public class ContextData
        //    {
        //
        //        public string? Id { get; set; }
        //
        //        public string? Ts { get; set; }
        //
        //        [JsonProperty("workflow_id")]
        //        public string? WorkflowId { get; set; }
        //
        //        [JsonProperty("deployment_id")]
        //        public string? DeploymentId { get; set; }
        //
        //        [JsonProperty("source_type")]
        //        public string? SourceType { get; set; }
        //        // Add other context properties as needed
        //    }

        //    public class TaxLine
        //    {
        //
        //        [JsonProperty("taxes_included")]
        //        public bool? TaxesIncluded { get; set; }
        //

        //        [JsonProperty("test")]
        //        public bool? Test { get; set; }
        //

        //        [JsonProperty("token")]
        //        public string? Token { get; set; }
        //

        //        [JsonProperty("total_discounts")]
        //        public string? TotalDiscounts { get; set; }
        //

        //        [JsonProperty("total_discounts_set")]
        //        public MoneySet? TotalDiscountsSet { get; set; }
        //

        //        [JsonProperty("total_line_items_price")]
        //        public string? TotalLineItemsPrice { get; set; }
        //

        //        [JsonProperty("total_line_items_price_set")]
        //        public MoneySet? TotalLineItemsPriceSet { get; set; }
        //

        //        [JsonProperty("total_outstanding")]
        //        public string? TotalOutstanding { get; set; }
        //

        //        [JsonProperty("total_price")]
        //        public string? TotalPrice { get; set; }
        //

        //        [JsonProperty("total_price_set")]
        //        public MoneySet? TotalPriceSet { get; set; }
        //

        //        [JsonProperty("total_shipping_price_set")]
        //        public MoneySet? TotalShippingPriceSet { get; set; }
        //

        //        [JsonProperty("total_tax")]
        //        public string? TotalTax { get; set; }
        //

        //        [JsonProperty("total_tax_set")]
        //        public MoneySet? TotalTaxSet { get; set; }
        //

        //        [JsonProperty("total_tip_received")]
        //        public string? TotalTipReceived { get; set; }
        //

        //        [JsonProperty("total_weight")]
        //        public string? TotalWeight { get; set; }
        //

        //        [JsonProperty("updated_at")]
        //        public string? UpdatedAt { get; set; }
        //

        //        [JsonProperty("user_id")]
        //        public string? UserId { get; set; }
        //

        //        [JsonProperty("client_ip")]
        //        public string? ClientIp { get; set; }
        //    }

        //    public class MoneySet
        //    {
        //
        //        [JsonProperty("presentment_money")]
        //        public Money? PresentmentMoney { get; set; }
        //

        //        [JsonProperty("shop_money")]
        //        public Money? ShopMoney { get; set; }
        //    }

        //    public class Money
        //    {
        //
        //        [JsonProperty("amount")]
        //        public string? Amount { get; set; }
        //

        //        [JsonProperty("currency_code")]
        //        public string? CurrencyCode { get; set; }
        //    }

    }
}
