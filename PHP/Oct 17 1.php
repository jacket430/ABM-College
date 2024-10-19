<?php

while (true) {
    echo "Waiting for input: ";
    $input = trim(fgets(STDIN));

    if (is_numeric($input)) {
        echo "True\n";
    } else {
        echo "False\n";
    }
    if (strtolower($input) === 'exit') {
        break;
    }
}

?>


<?php

while (true) {
    echo "Waiting for input: ";
    $input = trim(fgets(STDIN));

    if (is_numeric($input)) {
        echo "True\n";
    } else {
        echo "False\n";
    }
    if (strtolower($input) === 'exit') {
        break;
    }
}

?>

<?php

$var1 = "Avery";
$var2 = 430;
$var3 = "Basant";
$var4 = 3.14;
$var5 = "Tommy";
$var6 = 62000;

function checkVariableType($var) {
    if (is_string($var)) {
        echo "The variable '" . $var . "' is a string.\n";
    } elseif (is_int($var)) {
        echo "The variable '" . $var . "' is an integer.\n";
    } else {
        echo "The variable '" . $var . "' is not a string or integer.\n";
    }
}

checkVariableType($var1);
checkVariableType($var2);
checkVariableType($var3);
checkVariableType($var4);
checkVariableType($var5);
checkVariableType($var6);

?>

<?php

$string = "Avery has a cat named Tina. They are best friends!";
$keyWord = "best";

if (str_contains($string, $keyWord)) {
    echo "True";
} else {
    echo "False";
}

?>

<?php

$ogString = "123 456 789";
$newString = replaceSubstringAtPosition($ogString);

function replaceSubstringAtPosition($inputString) {
    $position = strpos($inputString, "123");
    if ($position !== false) {
        $result = substr_replace($inputString, "000", $position, 3);
    } else {
        $result = $inputString;
    }
    return $result;
}

echo $newString;

?>
