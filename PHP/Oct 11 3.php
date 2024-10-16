<?php
class Book {
    public $name;
    public $author;
    public $pages;

    public function __construct($name, $author, $pages) {
        $this->name = $name;
        $this->author = $author;
        $this->pages = $pages;
    }

    function bookInfo() {
        $output = "Book Title: " . $this->name . ",\n" .
                  "Author: " . $this->author . ",\n" . 
                  "Pages: " . $this->pages . "." . "\n \n";
        return $output;
    }
}

function addBook(&$books, $name, $author, $pages) {
    $books[] = new Book($name, $author, $pages);
}

function displayBooks($books) {
    foreach ($books as $book) {
        echo $book->bookInfo();
    }
}

function removeBook(&$books, $name) {
    foreach ($books as $index => $book) {
        if ($book->name === $name) {
            unset($books[$index]);
            $books = array_values($books);
            return true;
        }
    }
    return false;
}

function modifyBook(&$books, $oldName, $newName) {
    foreach ($books as $book) {
        if ($book->name === $oldName) {
            $book->name = $newName;
            return true;
        }
    }
    return false;
}

$books = [];

addBook($books, "Test Book", "Test Author", 100);
addBook($books, "Other Book", "New Author", 300);
addBook($books, "Books Books Books!", "Cool Author", 10000);
addBook($books, "Silly Book", "Silly Guy", 4500);

echo "--- DEBUG: Before modifying a book:\n \n";
displayBooks($books);

$bookModified = modifyBook($books, "Books Books Books!", "Modified Book Title");

if ($bookModified) {
    echo "--- DEBUG: Modified 'Books Books Books!' to 'Modified Book Title':" . "\n \n";
} else {
    echo "\n--- DEBUG: Error modifying book. Are you sure you entered the title correctly?.\n";
}

displayBooks($books);

?>
