using EfCore.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EfCore.Data.UserInterestGroup;

namespace EfCore.Data
{
    public class UserInterestGroup: ObservableObject
    {
        private int _interestgroupId;
        public int InterestGroupId
        {
            get => _interestgroupId;
            set => SetProperty(ref _interestgroupId, value);
        }
        private InterestGroup _interestgroup;
        public InterestGroup InterestGroup
        {
            get => _interestgroup;
            set => SetProperty(ref _interestgroup, value);
        }

        private int _userid;
        public int UserId
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }
        private User _user;
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        private DateTime _joinedat;
        public DateTime JoinedAt
        {
            get => _joinedat;
            set => SetProperty(ref _joinedat, value);
        }
        private bool _ismoderator;
        public bool IsModerator
        {
            get => _ismoderator;
            set => SetProperty(ref _ismoderator, value);
        }
         
    }
}
