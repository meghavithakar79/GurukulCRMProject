using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
        }
        public static List<string> GenerateAllPermissions()
        {
           var allpermissions=new List<string>();
            var modules=Enum.GetValues(typeof(Modules));
            foreach (var module in modules)
            {
                allpermissions.AddRange(GeneratePermissionsList(module.ToString()));
            }
            return allpermissions;
        }
        public static class Contact
        {
            public const string View = "Permissions.Contact.View";
            public const string Create = "Permissions.Contact.Create";
            public const string Edit = "Permissions.Contact.Edit";
            public const string Delete = "Permissions.Contact.Delete";
        }
        public static class Donation
        {
            public const string View = "Permissions.Donation.View";
            public const string Create = "Permissions.Donation.Create";
            public const string Edit = "Permissions.Donation.Edit";
            public const string Delete = "Permissions.Donation.Delete";
        }
        public static class Event
        {
            public const string View = "Permissions.Event.View";
            public const string Create = "Permissions.Event.Create";
            public const string Edit = "Permissions.Event.Edit";
            public const string Delete = "Permissions.Event.Delete";
        }
        public static class Magazine
        {
            public const string View = "Permissions.Magazine.View";
            public const string Create = "Permissions.Magazine.Create";
            public const string Edit = "Permissions.Magazine.Edit";
            public const string Delete = "Permissions.Magazine.Delete";
        }
        public static class Mail
        {
            public const string View = "Permissions.Mail.View";
            public const string Create = "Permissions.Mail.Create";
            public const string Edit = "Permissions.Mail.Edit";
            public const string Delete = "Permissions.Mail.Delete";
        }
        /*public static class Student
        {
            public const string View = "Permissions.Student.View";
            public const string Create = "Permissions.Student.Create";
            public const string Edit = "Permissions.Student.Edit";
            public const string Delete = "Permissions.Student.Delete";
        }*/
    }
}
