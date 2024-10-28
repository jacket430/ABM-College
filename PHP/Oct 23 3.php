<?php

$queue = new SplQueue();

$queue->enqueue("apple");
$queue->enqueue("banana");
$queue->enqueue("orange");

echo "Enqueue:\n\n";
print_r($queue);

$queue->dequeue();
$queue->dequeue();

echo "\nDequeue:\n\n";
print_r($queue);
