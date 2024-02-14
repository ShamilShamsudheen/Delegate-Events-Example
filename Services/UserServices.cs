using DelegateEventSample.Model;
using DelegateEventSample.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventSample.Services
{
    public class UserServices
    {
        private UserRepository _userRepository;

        public UserServices(UserRepository userServices)
        {
            _userRepository = userServices;
            _userRepository.UserActionOccured += HandledUserAction;
        }

        public void HandledUserAction(object sender ,string message)
        {
            NotifyServices(message);
        }
        public void NotifyServices(string message)
        {
            var smsService = new SMSService();
            var emailService = new EmailService();
            var pushNotifcationService = new PushNotificationService();

            smsService.Notify(message);
            emailService.Notify(message);
            pushNotifcationService.Notify(message);
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(int userId, Action<User> updateAction)
        {
            _userRepository.UpdateUser(userId, updateAction);
        }

        public void RemoveUser(int userId)
        {
            _userRepository.RemoveUser(userId);
        }

    }
}
