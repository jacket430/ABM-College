<?php
$coordinates = [
    [1, 3],
    [2, 5],
    [5, 8],
    [5, 9]
];

$last = count($coordinates) - 1;

foreach ($coordinates as $index => $pair) {
    $sum = $pair[0] + $pair[1];
    if ($index === $last) {
        echo $sum . ".";
    } else {
        echo $sum . ", ";
    }
}
