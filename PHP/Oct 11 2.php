<?php

class Dog{
    public $name;

    public function __construct($name){
        $this->name = $name;
    }

    public function message(){
        return $this->name . " the dog is barking!";
    }
}

$myDog = new Dog("Clifford");
echo $myDog->message();

?>