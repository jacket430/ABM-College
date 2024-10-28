<?php

class Pizza {
    private $size;
    private $toppings;

    public function __construct($size) {
        $this->size = $size;
        $this->toppings = [];
    }

    public function addTopping($topping) {
        $this->toppings[] = $topping;
    }

    public function removeTopping($topping) {
        $key = array_search($topping, $this->toppings);
        if ($key !== false) {
            unset($this->toppings[$key]);
            $this->toppings = array_values($this->toppings);
        } else {
            return "Topping not found.";
        }
    }

    public function getToppings() {
        return $this->toppings;
    }

    public function getDescription() {
        $toppingsList = implode(", ", $this->toppings);
        return "Size: {$this->size}\nToppings: {$toppingsList}";
    }

    public function getSize() {
        return $this->size;
    }

    public function setSize($size) {
        $this->size = $size;
    }
}

class Order {
    private $pizza;
    private $status;

    public function __construct($pizza) {
        $this->pizza = $pizza;
        $this->status = "Pending";
    }

    public function finalizeOrder() {
        $this->status = "Completed";
        return "----------\nOrder completed:\n" . $this->pizza->getDescription();
    }

    public function getPizza() {
        return $this->pizza;
    }

    public function getStatus() {
        return $this->status;
    }
}

class Customer {
    private $name;
    private $order;

    public function __construct($name) {
        $this->name = $name;
    }

    public function createOrder($size) {
        $pizza = new Pizza($size);
        $this->order = new Order($pizza);
    }

    public function addTopping($topping) {
        if ($this->order) {
            $this->order->getPizza()->addTopping($topping);
        }
    }

    public function removeTopping($topping) {
        if ($this->order) {
            return $this->order->getPizza()->removeTopping($topping);
        }
    }

    public function placeOrder() {
        if ($this->order) {
            return $this->order->finalizeOrder();
        }
    }

    public function getName() {
        return $this->name;
    }

    public function setName($name) {
        $this->name = $name;
    }

    public function getOrder() {
        return $this->order;
    }
}

echo "Creating new customer 'Tommy'\n";
$customer = new Customer("Tommy Hogan");

echo "Selecting 'Large' pizza size\n";
$customer->createOrder("Large");

echo "Adding topping 'Pepperoni'\n";
$customer->addTopping("Pepperoni");

echo "Adding topping 'Mushrooms'\n";
$customer->addTopping("Mushrooms");

echo "Adding topping 'Olives'\n";
$customer->addTopping("Olives");

echo "Removing topping 'Pepperoni'\n";
$customer->removeTopping("Pepperoni");

echo "Completing order\n";
echo $customer->placeOrder();
