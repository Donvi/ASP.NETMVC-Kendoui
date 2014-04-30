﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fzrain.Core;
using Fzrain.Core.Data;
using Fzrain.Core.Domain;

namespace Fzrain.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user);
        }

        public IPagedList<User> GetAllUsers(int pageSize,int pageIndex)
        {
          var query=  userRepository.Table;
          query =  query.OrderBy(u => u.Id);
           var users= new PagedList<User>(query,pageIndex,pageSize);
           return users;
        }
    }
}
