<?php

function isPrime($number) {
    if ($number <= 1) {
        return false;
    }
    for ($i = 2; $i <= sqrt($number); $i++) {
        if ($number % $i == 0) {
            return false;
        }
    }
    return true;
}

while (true) {
    echo "Enter a number: ";
    $input = trim(fgets(STDIN));
    if (!is_numeric($input)) {
        echo "Not a valid number.\n";
        continue;
    }

    $number = (int)$input;

    if (isPrime($number)) {
        echo "$number is a prime number.\n";
    } else {
        echo "$number is not a prime number.\n";
    }
}
