using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Detalhes da Transação de Cartão
    /// </summary>
    [DataContract]
    public class CardTransactionDetails
    {
        /// <summary>
        /// 2019-10-07 :: Não Alterar! Documentação da Gate2All incompleta, manter esta propriedade com o valor padrão = 1.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false, IsRequired = false)]
        public int Type { get; set; } = 1;

        /// <summary>
        /// Texto a ser exibido na fatura do portador do cartão. Opcional. Caso seja enviado mais que o suportado pela operadora, o texto excedente será ignorado. Cielo e Rede = 13 / GetNet e Stone = 22
        /// </summary>
        [DataMember(Name = "softDescriptor", EmitDefaultValue = false, IsRequired = false)]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// Booleano que indica se haverá captura automática ou se a captura será realizada posteriormente, em uma requisição subsequente. Padrão: true (captura automaticamente a transação).
        /// </summary>
        [DataMember(Name = "capture", EmitDefaultValue = true, IsRequired = true)]
        public bool AutoCapture { get; set; } = true;

        /// <summary>
        /// Quantidade de parcelas desejadas na transação. Obrigatório. O valor enviado deve estar entre 1 e 99.
        /// </summary>
        [DataMember(Name = "installments", EmitDefaultValue = true, IsRequired = true)]
        public int Installments { get; set; }

        /// <summary>
        /// Inteiro representando o tipo de parcelamento da transação. Ver <see cref="CardTransactionInterestType"/>. Padrão: 3 (Parcelado Loja)
        /// </summary>
        [DataMember(Name = "interestType", EmitDefaultValue = false, IsRequired = false)]
        public int InterestType { get; set; } = (int) CardTransactionInterestType.Store;

        /// <summary>
        /// Inteiro representando o modelo de autenticação da transação. Ver <see cref="CardTransactionAuthenticationType"/>. Padrão: 3 (Autorizar sem autenticar)
        /// </summary>
        [DataMember(Name = "authenticate", EmitDefaultValue = false, IsRequired = false)]
        public int Authenticate { get; set; } = (int) CardTransactionAuthenticationType.SkipAuthentication;

        /// <summary>
        /// Nome do Fornecedor (Adquirente) pela qual a transação será processada. Valores válidos: Cielo, Rede, GetNet, Stone
        /// </summary>
        [DataMember(Name = "provider", EmitDefaultValue = false, IsRequired = false)]
        public string Provider { get; set; }

        /// <summary>
        /// Versão da Integração do Fornecedor (Adquirente) pela qual a transação será processada. Valores válidos variam por fornecedor.
        /// <remarks>
        /// Cielo: 1.5 ou 3.0;
        /// Rede: Komerci ou Adquirencia;
        /// GetNet e Stone: (não disponível / não enviar);
        /// </remarks>
        /// </summary>
        [DataMember(Name = "providerVersion", EmitDefaultValue = false, IsRequired = false)]
        public string ProviderVersion { get; set; }

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
        /// Código de referência retornado pelo Fornecedor (Adquirente) que processou a transação.
        /// </summary>
        [DataMember(Name = "providerReference", EmitDefaultValue = false, IsRequired = false)]
        public string ProviderReference { get; set; }

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

        /// <summary>
        /// Booleano que indica se os dados do cartão deverão ser salvos no ambiente Gate2All (tokenização). Opcional. Valor padrão: false (não salvar).
        /// </summary>
        [DataMember(Name = "saveCard", EmitDefaultValue = false, IsRequired = false)]
        public bool SaveCard { get; set; }

        /// <summary>
        /// Booleano que indica se a transação é uma transação recorrente. Opcional. Valor padrão: false (não recorrente).
        /// </summary>
        [DataMember(Name = "recurrent", EmitDefaultValue = false, IsRequired = false)]
        public bool Recurrent { get; set; }

        /// <summary>
        /// Detalhes do cartão do cliente. Obrigatório.
        /// </summary>
        [DataMember(Name = "cardInfo", EmitDefaultValue = true, IsRequired = true)]
        public CustomerCardDetails CustomerCardDetails { get; set; }
    }
}
