using System;
using System.Linq;

namespace Algorithms.lab3;
class Student(string lastName, string firstName, string group, string city, string region) {
    public string LastName { get; set; } = lastName;
    public string FirstName { get; set; } = firstName;
    public string Group { get; set; } = group;
    public string City { get; set; } = city;
    public string Region { get; set; } = region;
}