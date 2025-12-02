using EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Pages.Service
{
    public class UserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<User> Users { get; set; } = new();
        public UserService()
        {
            GetAll();
        }
        public void Add(User user)
        {
            var _user = new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UserProfile=user.UserProfile,
                RoleId = user.RoleId,
                Role=user.Role,
            };
            _db.Add<User>(_user);
            Commit();
            Users.Add(user);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Users.Include(s => s.UserProfile)
.Include(s => s.Role)
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        public void Remove(User student)
        {
            _db.Remove<User>(student);
            if (Commit() > 0)
                if (Users.Contains(student))
                    Users.Remove(student);
        }
        public void LoadRelation(int role)
        {
            var users = _db.Users.Include(s => s.UserProfile)
.Include(s => s.Role).Where(s => s.RoleId == role)
.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
    

