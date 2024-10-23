<?php
$people = [
    "Avery" => 27,
    "Tony" => 50,
    "Peter" => 35
];

arsort($people);

foreach ($people as $name => $age) {
    echo "$name = $age\n";
}
