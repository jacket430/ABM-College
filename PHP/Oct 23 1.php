<?php
class ListNode {
    public $value;
    public $next;
    
    public function __construct($value) {
        $this->value = $value;
        $this->next = null;
    }
}

class LinkedList {
    private $head;
    
    public function __construct() {
        $this->head = null;
    }
    
    public function add($value) {
        $newNode = new ListNode($value);
        if ($this->head === null) {
            $this->head = $newNode;
        } else {
            $current = $this->head;
            while ($current->next !== null) {
                $current = $current->next;
            }
            $current->next = $newNode;
        }
    }
    
    public function display() {
        $current = $this->head;
        while ($current !== null) {
            echo $current->value . " -> ";
            $current = $current->next;
        }
        echo "Completed\n";
    }
    
    public function remove($value) {
        if ($this->head === null) {
            return;
        }
        if ($this->head->value === $value) {
            $this->head = $this->head->next;
            return;
        }
        $current = $this->head;
        while ($current->next !== null && $current->next->value !== $value) {
            $current = $current->next;
        }
        if ($current->next !== null) {
            $current->next = $current->next->next;
        }
    }
    
    public function update($oldValue, $newValue) {
        $current = $this->head;
        while ($current !== null) {
            if ($current->value === $oldValue) {
                $current->value = $newValue;
                return;
            }
            $current = $current->next;
        }
    }
    
    public function moveToHead($value) {
        $prev = null;
        $current = $this->head;
        
        while ($current !== null && $current->value !== $value) {
            $prev = $current;
            $current = $current->next;
        }
        
        if ($current !== null) {
            if ($prev !== null) {
                $prev->next = $current->next;
                $current->next = $this->head;
                $this->head = $current;
            }
        }
    }
}

$linkedList = new LinkedList();
$linkedList->add(1);
$linkedList->add(2);
$linkedList->add(3);
$linkedList->add(4);

echo "Before removal:\n";
$linkedList->display();

$linkedList->remove(3);

echo "After removal:\n";
$linkedList->display();

$linkedList->update(4, 5);

echo "After update:\n";
$linkedList->display();

$linkedList->moveToHead(5);

echo "After moving 5 to head:\n";
$linkedList->display();
