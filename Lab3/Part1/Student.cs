using System;

namespace Algorithms.lab3;

enum Gender {
    Male,
    Female
}

enum Residence {
    Dormitory,
    Apartment,
    Home
}

class Student : IComparable<Student> {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentId { get; set; }
    public Gender Gender { get; set; }
    public Residence Residence { get; set; }
    public byte Course { get; private set; }

    public void SetCourse(byte course) {
        if (course < 1 || course > 6) throw new ArgumentOutOfRangeException(nameof(course));
        this.Course = course;
    }

    public int CompareTo(Student? other) {
        if (other is null) return 1; // У C# null вважається меншим за будь-який об'єкт
        return this.StudentId.CompareTo(other.StudentId);
    }

    public override string ToString() {
        return $"{this.FirstName,-12} {this.LastName,-12} {this.StudentId,-12} {this.Gender,-8} {this.Residence,-12} {this.Course,-6}";
    }

    public Student(string first, string last, int studentId, Gender gender, Residence residence, byte course = 1) {
        this.FirstName = first;
        this.LastName = last;
        this.StudentId = studentId;
        this.Gender = gender;
        this.Residence = residence;
        this.SetCourse(course);
    }
}