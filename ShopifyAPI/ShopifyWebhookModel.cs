using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace ShopifyAPI
{
    using System;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    public class ShopifyWebhookData
    {
        public EventData? Event { get; set; }
    }

    public class EventData
    {
        [Newtonsoft.Json.JsonIgnore]
        public string? Method { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string? Path { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string? Url { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string? Client_ip { get; set; }
        public HeadersData? Headers { get; set; }
        public BodyData? Body { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Query? Query { get; set; }
    }
    public class Query
    {

    }
    public class HeadersData
    {

        [JsonProperty("x-shopify-hmac-sha256")]
        public string? ShopifyHmacSha256 { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string? Accept { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("accept-encoding")]
        public string? AcceptEncoding { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("content-length")]
        public string? ContentLength { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("content-type")]
        public string? ContentType { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string? Host { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("user-agent")]
        public string? UserAgent { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("x-shopify-api-version")]
        public string? ShopifyApiVersion { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [JsonProperty("x-shopify-order-id")]
        public string? ShopifyOrderId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
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

        [JsonProperty("email")]
        public string? Email { get; set; }


        [JsonProperty("estimated_taxes")]
        public bool? EstimatedTaxes { get; set; }


        [JsonProperty("financial_status")]
        public string? FinancialStatus { get; set; }


        [JsonProperty("fulfillment_status")]
        public string? FulfillmentStatus { get; set; }

        [JsonProperty("line_items")]
        public LineItem[] LineItems { get; set; }
    }

        public class LineItem
        {
            public string? Sku { get; set; }


        }

    }

