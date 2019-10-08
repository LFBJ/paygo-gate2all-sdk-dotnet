using System;
using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient
{
    [DataContract, Serializable]
    public class Gate2AllConnectionSettings
    {
        /// <summary>
        /// Não utilizado. Ignorar.
        /// </summary>
        [DataMember]
        public string TokenEndpointUri { get; set; }

        /// <summary>
        /// Valor que será enviado no cabeçalho HTTP "authenticationApi" das requisições de transação.
        /// </summary>
        [DataMember]
        public string ClientId { get; set; }

        /// <summary>
        /// Valor que será enviado no cabeçalho HTTP "authenticationKey" das requisições de transação.
        /// </summary>
        [DataMember]
        public string ClientSecret { get; set; }

        /// <summary>
        /// URL base para onde deverão ser encaminhadas as requisições de transação.
        /// </summary>
        [DataMember]
        public string BaseAddress { get; set; }
    }
}
