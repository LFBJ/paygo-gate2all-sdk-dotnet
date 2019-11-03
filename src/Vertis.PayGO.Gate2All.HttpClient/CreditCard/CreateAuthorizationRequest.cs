using System.Runtime.Serialization;
using Vertis.PayGO.Gate2All.HttpClient.Customer;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    [DataContract]
    public class CreateAuthorizationRequest
    {
        /// <summary>
        /// Identificador da transação no ambiente GATE2all. Texto, máx 150 caracteres, opcional.
        /// </summary>
        [DataMember(Name = "transactionId", EmitDefaultValue = false, IsRequired = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Identificador da transação no ambiente da loja. Texto, máx 100 caracteres, obrigatório.
        /// </summary>
        [DataMember(Name = "referenceId", EmitDefaultValue = true, IsRequired = true)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Valor da transação sem pontuação. Os dois últimos dígitos são os centavos (Ex: amount: 100 = R$ 1,00).
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = true, IsRequired = true)]
        public int TotalAmount { get; set; }

        /// <summary>
        /// Descrição da transação. Opcional, máximo de 300 caracteres (Ex: description: "Mouse sem fio").
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// URL onde o GATE2all enviará eventuais atualizações de status sobre a transação para o lojista. Opcional, sem limite de tamanho.
        /// </summary>
        [DataMember(Name="postBackUrl", EmitDefaultValue = false, IsRequired = false)]
        public string PostBackUrl { get; set; }

        /// <summary>
        /// Detalhes do cliente (portador do cartão). Obrigatório.
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = true, IsRequired = true)]
        public CustomerDetails CustomerDetails { get; set; }

        /// <summary>
        /// Detalhes de pagamento da transação. Obrigatório.
        /// </summary>
        [DataMember(Name = "payment", EmitDefaultValue = true, IsRequired = true)]
        public PaymentDetails PaymentDetails { get; set; }
    }
}
