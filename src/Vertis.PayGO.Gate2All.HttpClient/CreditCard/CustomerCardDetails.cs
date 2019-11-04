using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Detalhes do Cartão do Cliente.
    /// </summary>
    [DataContract]
    public class CustomerCardDetails
    {
        /// <summary>
        /// Número do cartão, em formato de texto. Máximo de 19 caracteres, somente números, sem espaços ou pontuação. Obrigatório.
        /// </summary>
        [DataMember(Name = "number", EmitDefaultValue = true, IsRequired = false)]
        public string Number { get; set; }

        /// <summary>
        /// Mês da validade do cartão. Formato MM. Obrigatório.
        /// </summary>
        [DataMember(Name = "expirationMonth", EmitDefaultValue = true, IsRequired = false)]
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// Ano da validade do cartão. Formato YYYY. Obrigatório.
        /// </summary>
        [DataMember(Name = "expirationYear", EmitDefaultValue = true, IsRequired = false)]
        public string ExpirationYear { get; set; }

        /// <summary>
        /// Código de segurança do cartão, com até quatro dígitos. Obrigatório.
        /// </summary>
        [DataMember(Name = "cvv", EmitDefaultValue = true, IsRequired = false)]
        public string SecurityCode { get; set; }

        /// <summary>
        /// Nome identificador da bandeira do cartão, obrigatório, conforme lista:
        /// <remarks>
        /// Visa, Mastercard, Diners Club, American Express, Elo, Hipercard, Hiper, Aura, Discover, JCB, Visa Electron, Mastercard Maestro.
        /// </remarks>
        /// Obrigatório.
        /// </summary>
        [DataMember(Name = "brand", EmitDefaultValue = true, IsRequired = false)]
        public string BrandName { get; set; }

        /// <summary>
        /// Nome do portador como impresso no cartão, com até 25 caracteres. Obrigatório.
        /// </summary>
        [DataMember(Name = "holderName", EmitDefaultValue = true, IsRequired = false)]
        public string HolderName { get; set; }
    }
}
