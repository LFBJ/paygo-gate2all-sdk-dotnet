using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Retorno Detalhado da Transação de Cartão
    /// </summary>
    [DataContract]
    public class CardTransactionResponse
    {
        /// <summary>
        /// Nome do Fornecedor (Adquirente) que processou a transação. Valores válidos: Cielo, Rede, GetNet, Stone; Valor padrão: Cielo
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = false, IsRequired = false)]
        public string Provider { get; set; } = "Cielo";

        /// <summary>
        /// Versão da Integração do Fornecedor (Adquirente) que processou a transação. Valores válidos variam por fornecedor.
        /// <remarks>
        /// Cielo: 1.5 ou 3.0;
        /// Rede: Komerci ou Adquirencia;
        /// GetNet e Stone: (não disponível / não enviar);
        /// </remarks>
        /// Valor padrão: 3.0.
        /// </summary>
        [DataMember(Name = "providerVersion", EmitDefaultValue = false, IsRequired = false)]
        public string ProviderVersion { get; set; } = "3.0";

        /// <summary>
        /// Mensagem de retorno do Fornecedor (Adquirente) que processou a transação.
        /// </summary>
        [DataMember(Name = "providerMessage", EmitDefaultValue = false, IsRequired = false)]
        public string ProviderMessage { get; set; }

        /// <summary>
        /// Codigo de resposta do Fornecedor (Adquirente) que processou a transação.
        /// </summary>
        [DataMember(Name = "providerCode", EmitDefaultValue = false, IsRequired = false)]
        public string ProviderCode { get; set; }

        /// <summary>
        /// Codigo de autorização do Fornecedor (Adquirente) que processou a transação.
        /// </summary>
        [DataMember(Name = "codAuthorization", EmitDefaultValue = false, IsRequired = false)]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Indicador de autenticação da transação.
        /// Ver a documentação da Gate2All para mais detalhes: https://ntksolutions.github.io/API-GATE2all/#status-eci
        /// </summary>
        [DataMember(Name = "saveCard", EmitDefaultValue = false, IsRequired = false)]
        public string AuthenticationEci { get; set; }
    }
}
