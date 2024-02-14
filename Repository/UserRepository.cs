using DelegateEventSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventSample.Repository
{
    public class UserRepository
    {
        private List<User> users = new List<User>();
        public event EventHandler<string> UserActionOccured;

        public void AddUser(User user)
        {
            users.Add(user);
            OnUserActionOccured($"User Added - {user.Id}: {user.Name} ");
        }
        public void UpdateUser(int userId, Action<User> updateAction)
        {
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                updateAction(user);
                OnUserActionOccured($"User Updated - {user.Id}: {user.Name}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        public void RemoveUser(int userId)
        {
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
                OnUserActionOccured($"User Removed - {user.Id}: {user.Name} : {user.Email} : {user.Contact}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        protected virtual void OnUserActionOccured(string message)
        {
            UserActionOccured?.Invoke(this, message);
        }
    }
}
