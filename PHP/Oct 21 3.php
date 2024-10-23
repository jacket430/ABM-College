<?php

function uniqueNums($array1, $array2) {
    $unique1 = array_diff($array1, $array2);
    $unique2 = array_diff($array2, $array1);
    $unique = array_merge($unique1, $unique2);

    echo "Unique nums: " . implode(", ", $unique) . "\n";
}

$array1 = [1, 2, 3, 4, 5, 6];
$array2 = [2, 3, 4, 5, 6, 7];

uniqueNums($array1, $array2);
