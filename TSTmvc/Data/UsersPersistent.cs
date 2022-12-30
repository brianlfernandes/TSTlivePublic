using System;
using TSTmvc.Models;

namespace TSTmvc.Data
{
    public class UsersPersistent
    {
        public static List<User> usersList { get; set; } = new List<User>()
        {
            new User()
            {
                Id=1001,
                Name="Brian Fernandes",
                Email="brianlfernandes@yahoo.com",
                Phone="9167177278",
                Sex='M'
            },
            new User()
            {
                Id=1002,
                Name="Nick Pereira",
                Email="pereiranick99@gmail.com",
                Phone="8082653092",
                Sex='M'
            },
            new User()
            {
                Id=1003,
                Name="Khalid Muloor",
                Email="khalid.muloor@yahoo.com",
                Phone="9167170005",
                Sex='M'
            }
        };

    }
}

