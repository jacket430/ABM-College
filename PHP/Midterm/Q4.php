<?php

class Item {
    private $name;
    private $quantity;
    private $price;

    public function __construct($name, $quantity, $price) {
        $this->name = $name;
        $this->quantity = $quantity;
        $this->price = $price;
    }

    public function getInfo() {
        return sprintf(
            "Name: %s, Quantity: %d, Price: %.2f",
            $this->name,
            $this->quantity,
            $this->price
        );
    }

    public function getName() {
        return $this->name;
    }

    public function getQuantity() {
        return $this->quantity;
    }

    public function getPrice() {
        return $this->price;
    }

    public function setQuantity($quantity) {
        $this->quantity = $quantity;
    }

    public function setPrice($price) {
        $this->price = $price;
    }
}

class Inventory {
    private $name;
    private $location;
    private $items = [];

    public function __construct($name, $location) {
        $this->name = $name;
        $this->location = $location;
    }

    public function addItem(Item $item) {
        $this->items[] = $item;
    }

    public function addItems(array $items) {
        foreach ($items as $item) {
            if ($item instanceof Item) {
                $this->addItem($item);
            }
        }
    }

    public function removeItem($itemName) {
        foreach ($this->items as $key => $item) {
            if ($item->getName() === $itemName) {
                unset($this->items[$key]);
                return "Item '$itemName' removed.";
            }
        }
        return "Item '$itemName' not found.";
    }

    public function updateItem(Item $newItem) {
        foreach ($this->items as $item) {
            if ($item->getName() === $newItem->getName()) {
                $item->setQuantity($newItem->getQuantity());
                $item->setPrice($newItem->getPrice());
                return "Item '{$newItem->getName()}' updated.";
            }
        }
        return "Item '{$newItem->getName()}' not found.";
    }

    public function listItems() {
        if (empty($this->items)) {
            return "No items in the inventory.";
        }

        $itemDetails = array_map(function($item) {
            return $item->getInfo();
        }, $this->items);

        return "Items in inventory:\n" . implode("\n", $itemDetails);
    }
}

$item1 = new Item("Pixel 7 128GB", 10, 799.99);
$item2 = new Item("Nvidia GTX 4080 16GB", 15, 1299.99);
$item3 = new Item("Compressed Air", 50, 11.99);

$inventory = new Inventory("Memory Express", "Beddington Hills");

$inventory->addItems([$item1, $item2, $item3]);

echo $inventory->listItems();
echo "\n\n";

echo "Updating item...\n";
$updatedItem = new Item("Compressed Air", 27, 10.99);
echo $inventory->updateItem($updatedItem) . "\n\n";

echo $inventory->listItems() . "\n\n";

echo "Removing item...\n";
echo $inventory->removeItem("Pixel 7 128GB") . "\n\n";
echo $inventory->listItems();

?>
