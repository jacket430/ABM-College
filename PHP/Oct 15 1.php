<?php
$boolVar = true;
$intVar = 42;
$decimalVar = 19.99;
$stringVar = "123";
$nullVar = null;

// Convert to string
$boolToString = (string)$boolVar;
$intToString = (string)$intVar;
$decimalToString = (string)$decimalVar;
$stringToString = $stringVar;
$nullToString = (string)$nullVar;

echo "boolToString: $boolToString\n";
echo "intToString: $intToString\n";
echo "decimalToString: $decimalToString\n";
echo "stringToString: $stringToString\n";
echo "nullToString: $nullToString\n";
echo "\n";

// Convert to int
$boolToInt = (int)$boolVar;
$stringToInt = (int)$stringVar;
$decimalToInt = (int)$decimalVar;
$nullToInt = (int)$nullVar;

echo "boolToInt: $boolToInt\n";
echo "intToInt: $intVar\n";
echo "decimalToInt: $decimalToInt\n";
echo "stringToInt: $stringToInt\n";
echo "nullToInt: $nullToInt\n";
echo "\n";

// Convert to array
$boolToArray = (array)$boolVar;
$intToArray = (array)$intVar;
$decimalToArray = (array)$decimalVar;
$stringToArray = (array)$stringVar;
$nullToArray = (array)$nullVar;

echo "boolToArray: ";
print_r($boolToArray);
echo "intToArray: ";
print_r($intToArray);
echo "decimalToArray: ";
print_r($decimalToArray);
echo "stringToArray: ";
print_r($stringToArray);
echo "nullToArray: ";
print_r($nullToArray);
?>
