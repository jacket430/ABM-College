<?php

function evaluateRPN($tokens) {
    $stack = [];

    foreach ($tokens as $token) {
        if (is_numeric($token)) {
            array_push($stack, (int)$token);
        } else {
            $b = array_pop($stack);
            $a = array_pop($stack);
            switch ($token) {
                case '+':
                    array_push($stack, $a + $b);
                    break;
                case '-':
                    array_push($stack, $a - $b);
                    break;
                case '*':
                    array_push($stack, $a * $b);
                    break;
                case '/':
                    array_push($stack, intdiv($a, $b));
                    break;
                default:
                    throw new InvalidArgumentException("Invalid operator: $token");
            }
        }
    }
    return array_pop($stack);
}


$expression = ["3", "4", "+"];
$result = evaluateRPN($expression);
echo "Result: " . $result;
