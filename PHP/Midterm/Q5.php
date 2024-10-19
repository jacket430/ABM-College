<?php

class School {
    private $name;
    private $location;
    private $students = [];
    private $courses = [];

    public function __construct($name, $location) {
        $this->name = $name;
        $this->location = $location;
    }

    public function addStudent(Student $student) {
        $this->students[] = $student;
    }

    public function removeStudent($studentName) {
        foreach ($this->students as $key => $student) {
            if ($student->getName() === $studentName) {
                unset($this->students[$key]);
                return "Student '$studentName' removed.";
            }
        }
        return "Student '$studentName' not found.";
    }

    public function listStudents() {
        if (empty($this->students)) {
            return "No students enrolled.";
        }

        $studentNames = array_map(function($student) {
            return $student->getName();
        }, $this->students);

        return "Students: " . implode(", ", $studentNames);
    }

    public function addCourse(Course $course) {
        $this->courses[] = $course;
    }

    public function removeCourse($courseName) {
        foreach ($this->courses as $key => $course) {
            if ($course->getName() === $courseName) {
                unset($this->courses[$key]);
                return "Course '$courseName' removed.";
            }
        }
        return "Course '$courseName' not found.";
    }

    public function listCourses() {
        if (empty($this->courses)) {
            return "No courses available.";
        }

        $courseNames = array_map(function($course) {
            return $course->getName();
        }, $this->courses);

        return "Courses: " . implode(", ", $courseNames);
    }
}

class Student {
    private $name;
    private $age;
    private $grades = [];

    public function __construct($name, $age) {
        $this->name = $name;
        $this->age = $age;
    }

    public function getName() {
        return $this->name;
    }

    public function addGrade($courseName, $grade) {
        $this->grades[$courseName] = $grade;
    }

    public function removeGrade($courseName) {
        if (isset($this->grades[$courseName])) {
            unset($this->grades[$courseName]);
            return "Grade for '$courseName' removed.";
        }
        return "Grade for '$courseName' not found.";
    }

    public function calculateGPA() {
        if (empty($this->grades)) {
            return 0.0;
        }
        return array_sum($this->grades) / count($this->grades);
    }

    public function getInfo() {
        return sprintf(
            "Name: %s, Age: %d, GPA: %.2f",
            $this->name,
            $this->age,
            $this->calculateGPA()
        );
    }
}

class Course {
    private $name;
    private $credits;
    private $instructor;

    public function __construct($name, $credits, $instructor) {
        $this->name = $name;
        $this->credits = $credits;
        $this->instructor = $instructor;
    }

    public function getName() {
        return $this->name;
    }

    public function getInfo() {
        return sprintf(
            "Course: %s, Credits: %d, Instructor: %s",
            $this->name,
            $this->credits,
            $this->instructor
        );
    }
}

$school = new School("Greenwood High", "New York");

$course1 = new Course("Mathematics", 3, "Dr. Smith");
$course2 = new Course("Science", 4, "Dr. Johnson");
$course3 = new Course("History", 2, "Dr. Brown");
$course4 = new Course("Art", 1, "Ms. Green");
$course5 = new Course("Physical Education", 2, "Mr. White");

$school->addCourse($course1);
$school->addCourse($course2);
$school->addCourse($course3);
$school->addCourse($course4);
$school->addCourse($course5);

$student1 = new Student("Bingus", 20);
$student2 = new Student("Floppa", 22);
$student3 = new Student("Sogga", 19);
$student4 = new Student("Plinka", 21);
$student5 = new Student("El Gatito", 23);

$school->addStudent($student1);
$school->addStudent($student2);
$school->addStudent($student3);
$school->addStudent($student4);
$school->addStudent($student5);

$student1->addGrade("Mathematics", 85);
$student1->addGrade("Science", 90);
$student2->addGrade("Mathematics", 78);
$student2->addGrade("Science", 88);
$student3->addGrade("History", 92);
$student3->addGrade("Art", 95);
$student4->addGrade("Physical Education", 80);
$student4->addGrade("Science", 85);
$student5->addGrade("Mathematics", 88);
$student5->addGrade("History", 90);

echo $student1->getInfo() . "\n";
echo $student2->getInfo() . "\n";
echo $student3->getInfo() . "\n";
echo $student4->getInfo() . "\n";
echo $student5->getInfo() . "\n\n";

echo $school->listStudents() . "\n";
echo $school->listCourses() . "\n\n";

echo $school->removeStudent("Bingus") . "\n";
echo $school->removeCourse("Science") . "\n\n";

echo $school->listStudents() . "\n";
echo $school->listCourses() . "\n";

?>
