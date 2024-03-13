using BuisnessLogic.Contracts.MatchHistory;
using BuisnessLogic.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Abstractions
{
    public interface IMatchHistoryService
    { /// <summary>
      /// Получить историю игры.
      /// </summary>
      /// <param name="id"> Идентификатор. </param>
      /// <returns> ДТО истории игры. </returns>
        Task<MatchHistoryDto> GetByIdAsync(string id);

        /// <summary>
        /// Создать историю игры.
        /// </summary>
        /// <param name="MatchHistoryDto"> ДТО истории игры. </param>
        Task<string> CreateAsync(MatchHistoryDto MatchHistoryDto);

        /// <summary>
        /// Изменить историю игры.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="MatchHistoryDto"> ДТО истории игры. </param>
        Task UpdateAsync(string id, MatchHistoryDto MatchHistoryDto);

        /// <summary>
        /// Удалить историю игры.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(string id);
    }
}
