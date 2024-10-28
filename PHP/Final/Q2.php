<?php

function isBalanced($expression) {
    $stack = [];
    $pairs = [
        ')' => '(',
        '}' => '{',
        ']' => '['
    ];

    for ($i = 0; $i < strlen($expression); $i++) {
        $char = $expression[$i];

        if (in_array($char, $pairs)) {
            array_push($stack, $char);
        } elseif (isset($pairs[$char])) {
            if (empty($stack)) {
                return "Not Balanced: Found closing '$char' without matching opening.";
            }
            $top = array_pop($stack);
            if ($top !== $pairs[$char]) {
                return "Not Balanced: Opening bracket bracket '$char' does not match opening bracket '$top'.";
            }
        }
    }

    if (empty($stack)) {
        return "Balanced: All parentheses are matched.";
    } else {
        return "Not Balanced: Unmatched opening parentheses remain.";
    }
}

$expression1 = "{[()]}";
$expression2 = "{[(])}";
$expression3 = "{{[[(())]]}}";

echo "Input expression: " . $expression1 . "\n";
echo isBalanced($expression1) . "\n\n";

echo "Input expression: " . $expression2 . "\n";
echo isBalanced($expression2) . "\n\n";

echo "Input expression: " . $expression3 . "\n";
echo isBalanced($expression3) . "\n";
