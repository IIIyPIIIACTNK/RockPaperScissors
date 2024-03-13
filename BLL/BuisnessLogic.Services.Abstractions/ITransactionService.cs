using BuisnessLogic.Contracts.Transaction;
using BuisnessLogic.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Abstractions
{
    public interface ITransactionService
    {
        /// <summary>
        /// Получить транзакцию.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО транзакцию. </returns>
        Task<TransactionDto> GetByIdAsync(string id);

        /// <summary>
        /// Создать транзакцию.
        /// </summary>
        /// <param name="userDto"> ДТО транзакцию. </param>
        Task<string> CreateAsync(TransactionDto transactionDto);

        /// <summary>
        /// Изменить транзакцию.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="userDto"> ДТО транзакцию. </param>
        Task UpdateAsync(string id, TransactionDto transactionDto);

        /// <summary>
        /// Удалить транзакцию.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(string id);
    }
}
