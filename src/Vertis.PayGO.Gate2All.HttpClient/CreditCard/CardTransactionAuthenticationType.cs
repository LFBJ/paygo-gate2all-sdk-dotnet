namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Tipos de Autenticação da Transação
    /// </summary>
    public enum CardTransactionAuthenticationType
    {
        /// <summary>
        /// Indefinido
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Autorizar somente as transações autenticadas
        /// </summary>
        AuthenticatedRequestsOnly = 1,

        /// <summary>
        /// Autorizar as transações autenticadas ou não autenticadas
        /// </summary>
        AnyRequests = 2,

        /// <summary>
        /// Autorizar as transações sem necessidade de autenticação
        /// </summary>
        SkipAuthentication = 3
    }
}