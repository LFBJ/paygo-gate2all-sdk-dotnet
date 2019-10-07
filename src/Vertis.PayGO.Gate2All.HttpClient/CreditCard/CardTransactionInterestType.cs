namespace Vertis.PayGO.Gate2All.HttpClient.CreditCard
{
    /// <summary>
    /// Tipos de Parcelamento da Transação
    /// </summary>
    public enum CardTransactionInterestType
    {
        /// <summary>
        /// Indefinido
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Parcelado Loja
        /// </summary>
        Store = 3,

        /// <summary>
        /// Parcelado Administrador
        /// </summary>
        Acquirer = 4
    }
}