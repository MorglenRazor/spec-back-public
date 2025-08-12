using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Specification.Core.Models.Auth
{
    public class User
    {
        /// <summary>
        /// Один из вариатов входи по логину и паролю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private User(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Один из вариантов входа по отделу, фио и паролю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="depId"></param>
        /// <param name="password"></param>
        private User(Guid id, string fullName, Guid depId, string password)
        {
            Id = id;
            FullName = fullName;
            DepartmentId = depId;
            Password = password;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="depId"></param>
        /// <param name="password"></param>
        private User(
            Guid id,
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            bool isAdmin,
            bool isActual,
            Guid depId
        )
        {
            Id = id;
            UserName = userName;
            Password = password;
            FullName = fullName;
            ShortName = shortName;
            PhoneNumber = phoneNumber;
            PositionName = positionName;
            IsAdmin = isAdmin;
            IsActual = isActual;
            DepartmentId = depId;
        }

        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <param name="shortName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="positionName"></param>
        /// <param name="depName"></param>
        private User(
            Guid id,
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            string depName,
            Guid depId,
            List<string> roleName
        )
        {
            Id = id;
            UserName = userName;
            Password = password;
            FullName = fullName;
            ShortName = shortName;
            PhoneNumber = phoneNumber;
            PositionName = positionName;
            DepName = depName;
            DepartmentId = depId;
            RolesName = roleName;
        }

        private User(
            Guid id,
            string userName,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            Guid depId
        )
        {
            Id = id;
            UserName = userName;
            FullName = fullName;
            ShortName = shortName;
            PhoneNumber = phoneNumber;
            PositionName = positionName;
            DepartmentId = depId;
        }

        private User(
            string userName,
            string fullName,
            string phoneNumber,
            string depName,
            string posName
        )
        {
            UserName = userName;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            PositionName = posName;
            DepName = depName;
        }

        private User(
            string userName,
            string fullName,
            string shortName,
            string phoneNumber,
            string depName,
            string posName,
            Guid depId
        )
        {
            UserName = userName;
            FullName = fullName;
            ShortName = shortName;
            PhoneNumber = phoneNumber;
            PositionName = posName;
            DepName = depName;
            DepartmentId = depId;
        }



        public static User Create(
            Guid id,
            string userName,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            Guid depId
        )
        {
            User users = new User(
                id,
                userName,
                fullName,
                shortName,
                phoneNumber,
                positionName,
                depId
            );
            return users;
        }

        /// <summary>
        /// Вход по логину и паролю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Create(Guid id, string userName, string password)
        {
            User users = new User(id, userName, password);
            return users;
        }

        /// <summary>
        /// Вход по отделу, фио и паролю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="depId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Create(Guid id, string fullName, Guid depId, string password)
        {
            User user = new User(id, fullName, depId, password);
            return user;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="shortName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="positionName"></param>
        /// <param name="depId"></param>
        /// <returns></returns>
        public static User Create(
            Guid id,
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            bool isAdmin,
            bool isActual,
            Guid depId
        )
        {
            User user = new User(
                id,
                userName,
                password,
                fullName,
                shortName,
                phoneNumber,
                positionName,
                isAdmin,
                isActual,
                depId
            );
            return user;
        }

        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <param name="shortName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="positionName"></param>
        /// <param name="depName"></param>
        /// <returns></returns>
        public static User Create(
            Guid id,
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            string depName,
            Guid depId,
            List<string> roleName
        )
        {
            User user = new User(
                id,
                userName,
                password,
                fullName,
                shortName,
                phoneNumber,
                positionName,
                depName,
                depId,
                roleName
            );
            return user;
        }

        public static User CreateWtPassword(
            string userName,
            string fullName,
            string shortName,
            string phoneNumber,
            string depName,
            string posName,
            Guid depId
        )
        {
            User user = new User(userName, fullName, shortName, phoneNumber, depName, posName, depId: depId);
            return user;
        }

        public Guid Id { get; }
        public string UserName { get; }
        public string Password { get; }
        public string FullName { get; }
        public string ShortName { get; }
        public string PhoneNumber { get; }
        public string PositionName { get; }
        public Guid DepartmentId { get; }
        public string DepName { get; }
        public string ShortDepName { get; }

        public bool IsAdmin { get; set; }
        public bool IsActual { get; set; }

        public List<string> RolesName { get; }
    }
}
