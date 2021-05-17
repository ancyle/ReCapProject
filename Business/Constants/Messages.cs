using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedCar = "Car added.";
        public static string ListedCar = "Cars are Listed";
        public static string Failed = "Failed check fields.";
        public static string MaintenanceTime = "System is under Maintenance";
        public static string RentalFailures = "Fails";
        public static string Success = "Succeed";
        public static string AuthorizationDenied="Access denied.";

        public static string UserRegistered ="User registered.";
        public static string UserNotFound = "User matching failure.";
        public static string AccessTokenCreated = "Token creation success";
        public static string UserAlreadyExists = "User already exists";
        public static string SuccessfulLogin = "Access provided.";
        public static string PasswordError = "Password failure";
    }
}
