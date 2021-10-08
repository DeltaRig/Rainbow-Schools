Author: Daniela Pereira Rigoli

# Rainbow-Schools
Phase 1 - OOPs in C Sharp

Create an OOP Based System for Storing School Data Using Design Patterns.

## DESCRIPTION

A program that will retrieve student data from a text file, display it sorted, and search by name the studants. The files already is created and the application will then fill the objects with dummy data to test its correctness. 

### This program: 

Have a simple menu. If the user choose the option 1,If the user choose the option 1, will appear studants data order by name. When the user choose the option 2, will ask what studant's name that he want search and after that user sent the name will show the student information of that this user didn't found. Option 3 is the same then two but to appear the teachers. Option 4 is to see students in a class, so the user send the class name. And option 5 is to see subjects taught by a teacher, in this program I use the teacher name like a unique to check what subjects this teacher taught. If the user write something different from a number between 0 an 5 will appear that is a invalid option. And if the user write ‘0’ will close the program. 

In the studants list could be the same studant in more then one class, and will appear in the search all studant's classes. In the sort is user Insertion Sort and in search is used Binary Search algorithm.

### Background of the problem statement:

As part of the prototyping process of developing software for Rainbow Schools, they need a simple system where students’ data can be stored in a text file and then be displayed on screen after being sorted by name. They should also be able to search a student and teacher by name. 

Rainbow School is developing a simple OOP based system for storing information about teachers, students, and subjects. This system is based on C#. It wants to follow the principles of design patterns while designing the classes. 

The objective is to build a Console .NET Project which will allow the creation of the use of the classes to test with sample data. 

### Environment:
Visual Studio Windows Console Project

.NETFramework,Version=v4.7.2

### Text file: 
Simple text file created externally using Notepad and pre-populated with data

### Data format:  

The text will be updated with data offline using a notepad or text editor. The following will be the format, adding as many rows as required.  

Student and Teacher file:

```
 Name, Class, Section  
 Name, Class, Section
```

Subject file:

```
 Name, SubjectCode, TeacherName  
 Name, SubjectCode, TeacherName 
```
