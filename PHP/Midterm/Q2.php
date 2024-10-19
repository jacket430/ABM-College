<?php

class Student {
    public $name;
    public $age;
    public $grades;

    public function __construct($name, $age, array $grades) {
        $this->name = $name;
        $this->age = $age;
        $this->grades = $grades;
    }

    public function averageGrade() {
        if (count($this->grades) == 0) {
            return 0;
        }
        $total = array_sum($this->grades);
        return $total / count($this->grades);
    }

    public function introduce(){
        $average = $this->averageGrade();
        echo "Student '" .$this->name. "' is " .$this->age. " years old. They have an average grade of " .$average. ".";
    }
}

$student = new Student("Avery", 27, [87, 95, 98, 89, 96]);

echo $student->introduce();

?>