﻿using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
         
        }

        public async Task<User?> GetAsync(
            Expression<Func<User, bool>> predicate
           

        )
        {
            User? user = await _userRepository.GetAsync(predicate);
            return user;
        }

        //public async Task<IPaginate<User>?> GetListAsync(
        //    Expression<Func<User, bool>>? predicate = null,
        //    Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        //    Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        //    int index = 0,
        //    int size = 10,
        //    bool withDeleted = false,
        //    bool enableTracking = true,
        //    CancellationToken cancellationToken = default
        //)
        //{
        //    IPaginate<User> userList = await _userRepository.GetListAsync(
        //        predicate,
        //        orderBy,
        //        include,
        //        index,
        //        size,
        //        withDeleted,
        //        enableTracking,
        //        cancellationToken
        //    );
        //    return userList;
        //}

        //public async Task<User> AddAsync(User user)
        //{
        //    await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        //    User addedUser = await _userRepository.AddAsync(user);

        //    return addedUser;
        //}

        //public async Task<User> UpdateAsync(User user)
        //{
        //    await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        //    User updatedUser = await _userRepository.UpdateAsync(user);

        //    return updatedUser;
        //}

        //public async Task<User> DeleteAsync(User user, bool permanent = false)
        //{
        //    User deletedUser = await _userRepository.DeleteAsync(user);

        //    return deletedUser;
        //}
    }
}
