using BuisnessLogic.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Получить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО пользователя. </returns>
        Task<UserDto> GetByIdAsync(string id);

        /// <summary>
        /// Создать пользователя.
        /// </summary>
        /// <param name="userDto"> ДТО пользователя. </param>
        Task<string> CreateAsync(UserDto userDto);

        /// <summary>
        /// Изменить пользователя.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="userDto"> ДТО пользователя. </param>
        Task UpdateAsync(string id, UserDto userDto);

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(string id);

        Task<UserDto> GetByName(string name);
    }
}
