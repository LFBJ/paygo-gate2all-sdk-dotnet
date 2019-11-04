using System;
using System.Runtime.Serialization;

namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    [DataContract]
    public class CreateAuthorizationResponse : CreateAuthorizationRequest
    {
        /// <summary>
        /// Data e hora da transação no ambiente GATE2all.
        /// </summary>
        [DataMember(Name = "dtTransaction", EmitDefaultValue = false, IsRequired = false)]
        public DateTime Timestamp { get; set; }

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
