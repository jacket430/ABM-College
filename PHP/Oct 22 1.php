<?php
$people = [
    [
        'id' => 1,
        'firstname' => 'Basant',
        'lastname' => 'Gera',
        'age' => 32,
        'gender' => 'male',
        'emailid' => 'basantgera29@gmail.com'
    ],
    [
        'id' => 2,
        'firstname' => 'Avery',
        'lastname' => 'Hogan',
        'age' => 27,
        'gender' => 'male',
        'emailid' => 'avemitchell@gmail.com'
    ]
];

foreach ($people as $person) {
    echo "ID: " . $person['id'] . "\n";
    echo "First Name: " . $person['firstname'] . "\n";
    echo "Last Name: " . $person['lastname'] . "\n";
    echo "Age: " . $person['age'] . "\n";
    echo "Gender: " . $person['gender'] . "\n";
    echo "Email ID: " . $person['emailid'] . "\n\n";
}
