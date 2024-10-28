<?php

class Student {
    private $name;
    private $id;

    public function __construct($name, $id) {
        $this->name = $name;
        $this->id = $id;
    }

    public function getDetails() {
        return "Student Name: $this->name, ID: $this->id";
    }

    public function getId() {
        return $this->id;
    }
}

class Classroom {
    private $className;
    private $teacher;
    private $enrollmentQueue = [];

    public function __construct($className, $teacher) {
        $this->className = $className;
        $this->teacher = $teacher;
    }

    public function enrollStudent(Student $student) {
        if ($this->isEnrolled($student->getId())) {
            return "Student with ID {$student->getId()} is already enrolled.";
        }
        $this->enrollmentQueue[] = $student;
        return "Student with ID {$student->getId()} has been enrolled.";
    }

    public function dropStudent($studentId) {
        foreach ($this->enrollmentQueue as $key => $student) {
            if ($student->getId() === $studentId) {
                unset($this->enrollmentQueue[$key]);
                $this->enrollmentQueue = array_values($this->enrollmentQueue);
                return "Student with ID $studentId has been dropped from the class.";
            }
        }
        return "Student with ID $studentId is not enrolled in the class.";
    }

    public function getEnrollmentList() {
        $list = [];
        foreach ($this->enrollmentQueue as $student) {
            $list[] = $student->getDetails();
        }
        return $list;
    }

    public function isEnrolled($studentId) {
        foreach ($this->enrollmentQueue as $student) {
            if ($student->getId() === $studentId) {
                return true;
            }
        }
        return false;
    }
}

$student1 = new Student("Avery", "S001");
$student2 = new Student("Tommy", "S002");
$student3 = new Student("Tina", "S003");
$student4 = new Student("Misty", "S004");

$classroom = new Classroom("Math 101", "Mr. Hogan");

echo "Enrolling students... \n";
echo $classroom->enrollStudent($student1) . "\n";
echo $classroom->enrollStudent($student2) . "\n";
echo $classroom->enrollStudent(student: $student3) . "\n";
echo $classroom->enrollStudent(student: $student4) . "\n\n";

echo "Attempting to enroll a duplicate student... \n";
echo $classroom->enrollStudent($student1) . "\n\n";

echo "Dropping two students...\n";
echo $classroom->dropStudent("S001") . "\n";
echo $classroom->dropStudent("S002") . "\n\n";

echo "Running 'isEnrolled' function...\n";
print_r($classroom->getEnrollmentList());
