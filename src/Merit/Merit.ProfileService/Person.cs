using System;
using System.Collections.Generic;
using System.Text;

namespace Merit.ProfileService
{
    public record Person (int Id, string FirstName, string LastName, DateTime DateOfBirth, string Email, string Street, string City, string ZipCode, string Phone);
}
