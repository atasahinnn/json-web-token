using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories;
using Jwt.Api.Domain.Responses;
using Jwt.Api.Domain.Services;
using Jwt.Api.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public UserResponse AddUser(User user)
        {
            try
            {
                userRepository.AddUser(user);
                unitOfWork.Complete();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public UserResponse GetByEmailAndPassword(string email, string password)
        {
            try
            {
                User user = userRepository.GetByEmailAndPassword(email, password);

                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı.");
                }

                return new UserResponse(user);
            }
            catch (Exception ex)
            {

                return new UserResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public UserResponse GetUserById(int id)
        {
            try
            {
                User user = userRepository.GetUserById(id);

                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı.");
                }

                return new UserResponse("Kullanıcı Bulunamadı.");
            }
            catch (Exception ex)
            {

                return new UserResponse($"Hata Kodu: {ex.Message}");
            }

        }

        public UserResponse GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = userRepository.GetUserWithRefreshToken(refreshToken);

                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı.");
                }

                return new UserResponse("Kullanıcı Bulunamadı.");
            }
            catch (Exception ex)
            {

                return new UserResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);
                unitOfWork.Complete();
            }
            catch (Exception)
            {
                // LOGLAMA YAPILABİLİR
            }
        }

        public void SaveRefreshToken(int id, string refreshToken)
        {
            try
            {
                userRepository.SaveRefreshToken(id, refreshToken);
                unitOfWork.Complete();
            }
            catch (Exception)
            {

                // LOG
            }
        }
    }
}
