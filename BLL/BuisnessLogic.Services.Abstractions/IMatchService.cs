using BuisnessLogic.Contracts.Match;
using BuisnessLogic.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Abstractions
{
    public interface IMatchService
    {
        /// <summary>
        /// Получить матч.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО матча. </returns>
        Task<MatchDto> GetByIdAsync(string id);

        /// <summary>
        /// Создать матч.
        /// </summary>
        /// <param name="matchDto"> ДТО матч. </param>
        Task<string> CreateAsync(MatchDto matchDto);

        /// <summary>
        /// Изменить матч.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="matchDto"> ДТО матча. </param>
        Task UpdateAsync(string id, MatchDto matchDto);

        /// <summary>
        /// Удалить матч.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(string id);

        Task<List<MatchDto>> GetAllAsync();
    }
}
