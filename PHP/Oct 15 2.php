<?php
// Finding lowest number in an array
echo "- Find Lowest Number\n";
$numbersLow = [1, 20, 30, 15.6];
echo "-- Provided Numbers: \n";
var_dump($numbersLow);
$lowest = min($numbersLow);
echo "-- Lowest number: " . $lowest;

echo "\n\n";

// Finding highest number in an array
echo "- Find highest Number\n";
$numbersHigh = [20, 67, 89, 19];
echo "-- Provided Numbers: \n";
var_dump($numbersHigh);
$highest = max($numbersHigh);
echo "-- Highest number: " . $highest;

echo "\n\n";

// Displaying Pi
$pi = pi();
echo "- Value of Pi: " . $pi;

echo "\n\n";

// Negative -> Positive + as percentage
$negativeNumber = -91.7;
echo "- Negative number: " . $negativeNumber;
echo "\n";
$positiveNumber = abs($negativeNumber);
echo "-- Converted to positive: " . $positiveNumber;
echo "\n";
$negativeNumber = -91.7;
$positiveNumber = abs($negativeNumber);
echo "-- Positive as percentage: " . $positiveNumber . "%";
?>