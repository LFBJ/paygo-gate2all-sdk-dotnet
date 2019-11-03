using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Detalhes da Transação de Pagamento
    /// </summary>
    [DataContract]
    public class PaymentDetails
    {
        /// <summary>
        /// Detalhes da transação de cartão. Obrigatório.
        /// </summary>
        [DataMember(Name = "card", EmitDefaultValue = true, IsRequired = true)]
        public CardTransactionDetails CardTransactionDetails { get; set; }
    }
}
