#CSharp Project - Student Course Management Design Patterns

##Overview
This project is a **Console-Based Student Course Management System** developed in **C#** using **Object-Oriented Programming (OOP)** principles and **Design Patterns**.

The system manages student course enrollment for two different course types:

- 📘 Short Course
- 📗 Long Course

The main twist of this project is:

✅ **Short Courses require an admission fee**  
✅ **Long Courses do not require any admission fee**

This project demonstrates clean architecture, maintainable code structure, and practical implementation of design patterns in C#.

---

#Features

- Create Student Information
- Read Student Records
- Update Student Details
- Delete Student Information
- Student Course Enrollment
- Manage Course Types (Short Course & Long Course)
- Department Management
- Admission Fee Calculation
- Course Type & Department Handling
- Clean Layered Architecture
- Factory Pattern Implementation
- Repository Pattern Implementation
- Console-Based User Interaction

---

#Design Patterns Used

##Factory Pattern
Used to create course objects dynamically based on course type.

### Benefits:
- Reduces object creation complexity
- Improves scalability
- Follows Open/Closed Principle

---

##Repository Pattern
Used for handling data operations separately from business logic.

### Benefits:
- Cleaner code structure
- Better maintainability
- Easier future database integration

---

#Project Structure

```text
CSharpProjectStudentCourseManagementDesignPatterns/
│
├── Entities/        # Student, Course, Enums, Models
├── Factory/         # Course object creation
├── Repository/      # Data access layer
├── Manager/         # Business logic
├── Services/        # Service handling
├── Program.cs       # Entry point
└── README.md
