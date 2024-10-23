<?php

function fibonacci($a) {
    $firstNum = 0;
    $secondNum = 1;

    echo "Fibonacci Sequence:\n";
    for ($i = 0; $i < $a; $i++) {
        echo $firstNum;
        if ($i < $a - 1) {
            echo ",\n";
        } else {
            echo ".";
        }
        $nextNum = $firstNum + $secondNum;
        $firstNum = $secondNum;
        $secondNum = $nextNum;
    }
    echo "\n";
}

fibonacci(10);