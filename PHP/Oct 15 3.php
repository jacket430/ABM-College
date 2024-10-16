<?php
function promptUser($message) {
    echo $message;
    return trim(fgets(STDIN));
}

while (true) {
    $restaurant = promptUser("Enter restaurant: ");
    $location = promptUser("Enter location: ");
    $cost = promptUser("Enter price: ");
    $tip = promptUser("Enter tip: ");
    $status = promptUser("Enter status: ");

    if (strcasecmp($status, "pending") === 0) {
        echo "Delivery\n";
        sleep(10);
        $status = "done";
    }

    if (strcasecmp($status, "done") === 0) {
        echo "Restaurant: $restaurant\n";
        echo "Location: $location\n";
        echo "Cost: $cost\n";
        echo "Tip: $tip\n";
        echo "Status: $status\n";
        echo "-----------------------\n";
    }
}
?>
