using System;

namespace SystemEntities {
    public interface IUser {
        string Username { get; set; }
        string Password { get; set; }
        string UserType { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ContactNo { get; set; }
    }
}