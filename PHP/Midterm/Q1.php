<?php

class Person {
    public $name;
    public $age;
    public $dob;
    public $birthplace;
    public $location;
    public $favcolor;
    public $favgenre;

    public function __construct($name, $age, DateTime $dob, $birthplace, $location, $favcolor, $favgenre) {
        $this->name = $name;
        $this->age = $age;
        $this->dob = $dob;
        $this->birthplace = $birthplace;
        $this->location = $location;
        $this->favcolor = $favcolor;
        $this->favgenre = $favgenre;
    }

    public function greet() {
        echo "Hello! My name is " . $this->name . "!" . "\n" ;
        echo "I am " . $this->age . " years old." . "\n";
        echo "My birthday is " . $this->dob->format('F d, Y') . ".\n";
        echo "I was born in " . $this->birthplace . ".\n";
        echo "I am currently living in " . $this->location . ".\n";
        echo "My favorite color is " . $this->favcolor . ".\n";
        echo "My favorite genre of music is " . $this->favgenre . ".";
    }
}

$person = new Person("Avery", 27, new DateTime('1997-02-01'), "Calgary", "Calgary", "Blue", "Punk Rock");

echo $person->greet();

?>
