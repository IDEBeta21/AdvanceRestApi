﻿using AdvanceRestApi.DTO_s;
using AdvanceRestApi.Interfaces;
using AdvanceRestApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AdvanceRestApi.Services
{
    public class UserService : IUser
    {
        //private UserDbContext _dbContext;
        private IMongoCollection<User> usersCollection;
        private IMapper _mapper;    
        public UserService(IMapper mapper, IConfiguration config)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
            var mongoClient = new MongoClient(config.GetConnectionString("UserConnection"));
            var mongoDatabase = mongoClient.GetDatabase("UsersDb");
            usersCollection = mongoDatabase.GetCollection<User>("Users");
        }
        public async Task<(bool IsSuccess, string ErrorMessage)> AddUser(AddUserDtoRequest userdto)
        {
            if(userdto!=null)
            {
                var user = _mapper.Map<User>(userdto);
                await usersCollection.InsertOneAsync(user);
                return (true, null);
            }
            return (false, "Please provide the user data");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeleteUser(Guid id)
        {

            var user = await usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                await usersCollection.DeleteOneAsync(u => u.Id == id);
                return (true, null);
            }
            return (false, "No user found");
        }

        public async Task<(bool IsSuccess, List<UserDTO> User, string ErrorMessage)> GetAllUsers()
        {
            var users = await usersCollection.Find(u => true).ToListAsync();
            if(users!=null)
            {
                var result = _mapper.Map<List<UserDTO>>(users);
                return (true, result, null);
            }
            return (false,null,"No users found");
        }

        public async Task<(bool IsSuccess, UserDTO User, string ErrorMessage)> GetUserById(Guid id)
        {
            var user = await usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                var result = _mapper.Map<UserDTO>(user);
                return (true, result, null);
            }
            return (false, null, "No user found");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateUser(Guid id, UpdateUserRequest userdto)
        {
            var userObj = await usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (userObj != null)
            {
                var user = _mapper.Map<User>(userdto);
                userObj.Name = user.Name;
                userObj.Address = user.Address;
                userObj.Phone = user.Phone;
                userObj.BloodGroup = user.BloodGroup;
                await usersCollection.ReplaceOneAsync(u => u.Id == id, userObj);
                return (true, null);
            }
            return (false, "User not found");
        }
    }
}
