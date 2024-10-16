<?php
class Car{
    public $color;
    public $model;

    public function __construct($color, $model){
        $this->color = $color;
        $this->model = $model;
    }

    public function message(){
        return "This car is a " . $this->color ." ". $this->model ."!";
    }
}

$myCar = new Car("Red","Ford");
var_dump( $myCar->message() );

?>