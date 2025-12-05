using EfCore.Data;
using EfCore.Pages.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Service
{
    public class UserInteresrtsServicecs
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public void Add(UserInterestGroup courceStudent)
        {
            var _courceStundent = new UserInterestGroup
            {
                InterestGroupId=courceStudent.InterestGroupId,
                InterestGroup=courceStudent.InterestGroup,
                UserId=courceStudent.UserId,
                User=courceStudent.User,
                JoinedAt=courceStudent.JoinedAt,
                IsModerator=courceStudent.IsModerator,
            };
            _db.Add<UserInterestGroup>(_courceStundent);
            _db.SaveChanges();
        }
    }
}
