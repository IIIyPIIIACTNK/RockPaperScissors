using BuisnessLogic.Contracts.GameTransactions;
using BuisnessLogic.Contracts.Transaction;
using BuisnessLogic.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Abstractions
{
    public interface IGameTransactionService
    {
        /// <summary>
        /// Получить транзакции игры.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО транзакций игры. </returns>
        Task<GameTransactionsDto> GetByIdAsync(string id);

        /// <summary>
        /// Создать транзакций игры.
        /// </summary>
        /// <param name="userDto"> ДТО транзакций игры. </param>
        Task<string> CreateAsync(GameTransactionsDto gameTransactionsDto);

        /// <summary>
        /// Изменить транзакций игры.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="userDto"> ДТО транзакций игры. </param>
        Task UpdateAsync(string id, GameTransactionsDto gameTransactionsDto);

        /// <summary>
        /// Удалить транзакций игры.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(string id);
        Task AddTransaction(TransactionDto dto, string id);
    }
}
