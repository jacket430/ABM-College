<?php

class University {
    private $name;
    private $gpaRequirement;
    private $programs;

    public function __construct($name, $gpaRequirement, $programs) {
        $this->name = $name;
        $this->gpaRequirement = $gpaRequirement;
        $this->programs = $programs;
    }

    public function getDetails() {
        return "University: {$this->name}, GPA Requirement: {$this->gpaRequirement}, Programs: " . implode(', ', $this->programs);
    }

    public function getName() {
        return $this->name;
    }

    public function getGpaRequirement() {
        return $this->gpaRequirement;
    }
}

class Graph {
    private $universities = [];
    private $edges = [];

    public function addUniversity(University $university) {
        $this->universities[] = $university;
        $this->edges[$university->getName()] = [];
    }

    public function addEdge($university1, $university2) {
        if (isset($this->edges[$university1->getName()])) {
            $this->edges[$university1->getName()][] = $university2->getName();
        }
        if (isset($this->edges[$university2->getName()])) {
            $this->edges[$university2->getName()][] = $university1->getName();
        }
    }

    public function getUniversitiesForGPA($gpa) {
        $eligibleUniversities = [];
        foreach ($this->universities as $university) {
            if ($university->getGpaRequirement() <= $gpa) {
                $eligibleUniversities[] = $university;
            }
        }
        return $eligibleUniversities;
    }

    public function getRecommendations($gpa) {
        return $this->getUniversitiesForGPA($gpa);
    }
}

class Student {
    private $name;
    private $gpa;
    private $selectedUniversities = [];

    public function __construct($name, $gpa) {
        $this->name = $name;
        $this->gpa = $gpa;
    }

    public function applyToUniversities(Graph $graph) {
        $this->selectedUniversities = $graph->getUniversitiesForGPA($this->gpa);
    }

    public function getSelectedUniversities() {
        return $this->selectedUniversities;
    }

    public function getName() {
        return $this->name;
    }

    public function getGpa() {
        return $this->gpa;
    }
}

$university1 = new University("University A", 3.5, ["Engineering", "Arts"]);
$university2 = new University("University B", 3.0, ["Science", "Business"]);

$graph = new Graph();
$graph->addUniversity($university1);
$graph->addUniversity($university2);
$graph->addEdge($university1, $university2);

$students = [
    new Student("John Doe", 3.4),
    new Student("Jane Smith", 3.6),
    new Student("Alice Johnson", 2.9)
];

foreach ($students as $student) {
    $student->applyToUniversities($graph);
    echo "Results for {$student->getName()}:\n";
    $selectedUniversities = $student->getSelectedUniversities();
    if (empty($selectedUniversities)) {
        echo "Unfortunately, your GPA of {$student->getGpa()} does not meet the requirements for any universities.\n";
    } else {
        foreach ($selectedUniversities as $university) {
            echo $university->getDetails() . "\n";
        }
    }
    echo "\n";
}
