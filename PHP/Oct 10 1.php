<?php
function bankAccount($accountNumber) {
    $accounts = [
        123456 => 100,
        98765 => 200,
        101010 => 300
    ];

    if ($accountNumber == 123456) {
        echo "Account $accountNumber balance: $" . $accounts[123456] . "\n";
    } else if ($accountNumber == 98765) {
        echo "Account $accountNumber balance: $" . $accounts[98765] . "\n";
    } else if ($accountNumber == 101010) {
        echo "Account $accountNumber balance: $" . $accounts[101010] . "\n";
    } else {
        echo "Account $accountNumber not found.";
    }
}

bankAccount(123456);
bankAccount(98765);
bankAccount(101010);
?>
