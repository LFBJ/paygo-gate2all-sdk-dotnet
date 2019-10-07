using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.Customer
{
    /// <summary>
    /// Detalhes do portador do cartão ou sacado/pagador do boleto.
    /// </summary>
    [DataContract]
    public class CustomerDetails
    {
        /// <summary>
        /// Nome do portador do cartão ou sacado/pagador do boleto. Texto, máx. 100 caracteres, obrigatório.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true, IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Documento (CPF/CNPJ) do portador do cartão ou sacado/pagador do boleto. Texto, máx. 18 caracteres, obrigatório.
        /// </summary>
        [DataMember(Name = "document", EmitDefaultValue = true, IsRequired = true)]
        public string Document { get; set; }

        /// <summary>
        /// E-mail do portador do cartão ou sacado/pagador do boleto. Texto, máx. 100 caracteres, obrigatório.
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = true, IsRequired = true)]
        public string Email { get; set; }
    }
}
