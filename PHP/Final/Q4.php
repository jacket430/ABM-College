<?php

class Restaurant {
    private $name;
    private $menu;

    public function __construct($name, $menu = []) {
        $this->name = $name;
        $this->menu = $menu;
        echo "Restaurant '{$this->name}' created.\n";
    }

    public function addMenuItem($item, $price) {
        $this->menu[$item] = $price;
        echo "Added menu item '{$item}' with price \${$price}.\n";
    }

    public function removeMenuItem($item) {
        if (isset($this->menu[$item])) {
            unset($this->menu[$item]);
            echo "Removed menu item '{$item}'.\n";
        }
    }

    public function getMenu() {
        return $this->menu;
    }
}

class Order {
    private $restaurant;
    private $items;
    private $status;

    public function __construct(Restaurant $restaurant) {
        $this->restaurant = $restaurant;
        $this->items = [];
        $this->status = "Pending";
        echo "Order created with status '{$this->status}'.\n";
    }

    public function addItem($item, $quantity) {
        if (isset($this->restaurant->getMenu()[$item])) {
            if (isset($this->items[$item])) {
                $this->items[$item] += $quantity;
            } else {
                $this->items[$item] = $quantity;
            }
            echo "Adding item '{$item}' with quantity {$quantity}.\n";
        } else {
            echo "Item '{$item}' not available in the menu.\n";
        }
    }

    public function removeItem($item) {
        if (isset($this->items[$item])) {
            unset($this->items[$item]);
            echo "Removed item '{$item}' from order.\n";
        }
    }

    public function getTotalCost() {
        $total = 0;
        foreach ($this->items as $item => $quantity) {
            $total += $this->restaurant->getMenu()[$item] * $quantity;
        }
        return $total;
    }

    public function updateStatus($status) {
        $this->status = $status;
        echo "Order status updated to '{$this->status}'.\n";
    }

    public function markAsDelivered() {
        $this->updateStatus("Delivered");
        echo "Order has been marked as delivered.\n";
    }
}

class Customer {
    private $name;
    private $order;

    public function __construct($name) {
        $this->name = $name;
        echo "Customer '{$this->name}' created.\n";
    }

    public function createOrder(Restaurant $restaurant) {
        $this->order = new Order($restaurant);
    }

    public function getOrder() {
        return $this->order;
    }

    public function placeOrder() {
        if ($this->order) {
            $totalCost = $this->order->getTotalCost();
            $this->order->updateStatus("In Progress");
            echo "----------------\nOrder placed successfully.\nTotal cost: \${$totalCost}\n";
        } else {
            echo "No order to place.\n";
        }
    }
}

$restaurant = new Restaurant("McDonald's", ["Big Mac" => 5.99, "Fries" => 2.99, "Coke" => 1.49]);

$restaurant->addMenuItem("McFlurry", 3.49);
$restaurant->removeMenuItem("Coke");

$customer = new Customer("Tina Hogan");
$customer->createOrder($restaurant);

$customer->getOrder()->addItem("Big Mac", 2);
$customer->getOrder()->addItem("Fries", 1);
$customer->getOrder()->addItem("McFlurry", 1);
$customer->getOrder()->removeItem("Fries");

$customer->placeOrder();

$customer->getOrder()->markAsDelivered();
