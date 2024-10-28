<?php
$stack = [];

array_push($stack, "apple");
array_push($stack, "banana");
array_push($stack, "orange");

echo("Starting array:\n");
var_dump($stack);

echo "\nPopping two items\n\n";
array_pop($stack);
array_pop($stack);

print_r($stack);
