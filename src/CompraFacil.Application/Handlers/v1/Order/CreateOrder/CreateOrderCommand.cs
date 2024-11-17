using CompraFacil.Application.Models.Requests.CreateOrder;
using MediatR;
using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Order.CreateOrder;

public sealed class CreateOrderCommand : IRequest<CreateOrderResult>
{
    [JsonPropertyName("customer")]
    public CustomerRequest? Customer { get; set; }

    [JsonPropertyName("orderItems")]
    public List<OrderItemRequest>? Items { get; set; }

    [JsonPropertyName("deliveryAddress")]
    public DeliveryAddressRequest? DeliveryAddress { get; set; }

    [JsonPropertyName("paymentAddress")]
    public PaymentAddressRequest? PaymentAddress { get; set; }

    [JsonPropertyName("paymentInfo")]
    public PaymentInfoRequest? PaymentInfo { get; set; }
} 
