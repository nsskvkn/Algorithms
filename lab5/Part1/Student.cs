using System;
using System.Collections.Generic;
namespace Algorithms.lab5;
public class Student(string firstName, string lastName, string middleName, int id, bool militaryTraining) : IComparable<Student> {
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string MiddleName { get; set; } = middleName;
    public int Id { get; set; } = id; 
    public bool HasMilitaryTraining { get; set; } = militaryTraining;

    public int CompareTo(Student? other) {
        if (other is null) return -1;
        return this.Id.CompareTo(other.Id);
    }

    public override string ToString() => 
        $"{this.FirstName,-10} {this.LastName,-12} {this.Id,-5} Військ. підготовка: {(this.HasMilitaryTraining ? "Так" : "Ні")}";
}