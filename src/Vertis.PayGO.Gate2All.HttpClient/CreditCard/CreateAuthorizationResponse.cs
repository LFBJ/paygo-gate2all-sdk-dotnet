using System;
using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    [DataContract]
    public class CreateAuthorizationResponse
    {
        /// <summary>
        /// Identificador da transação no ambiente GATE2all.
        /// </summary>
        [DataMember(Name = "transactionId", EmitDefaultValue = false, IsRequired = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Identificador da transação no ambiente da loja.
        /// </summary>
        [DataMember(Name = "referenceId", EmitDefaultValue = false, IsRequired = false)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Data e hora da transação no ambiente GATE2all.
        /// </summary>
        [DataMember(Name = "dtTransaction", EmitDefaultValue = false, IsRequired = false)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Retorno Detalhado da Transação de Cartão.
        /// </summary>
        [DataMember(Name = "card", EmitDefaultValue = false, IsRequired = false)]
        public CardTransactionResponse TransactionResponse { get; set; }

        /// <summary>
        /// Status da transação retornado pelo ambiente GATE2all.
        /// Ver a documentação da GATE2all para mais detalhes: https://ntksolutions.github.io/API-GATE2all/#status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public int Status { get; set; }

        [IgnoreDataMember]
        public IGate2AllHttpError HttpError { get; set; }

        [IgnoreDataMember]
        public bool IsSuccess => HttpError == null;
    }
}
