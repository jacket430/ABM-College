<?php

class Book {
    private $title;
    private $author;
    private $yearPublished;

    public function __construct($title, $author, $yearPublished){
        $this->title = $title;
        $this->author = $author;
        $this->yearPublished = $yearPublished;
    }

    public function getInfo(){
        return "\"{$this->title}\" by {$this->author} ({$this->yearPublished})";
    }

    public function getTitle(){
        return $this->title;
    }
}

class Library {
    private $name;
    private $location;
    private $books = [];

    public function __construct($name, $location){
        $this->name = $name;
        $this->location = $location;
    }

    public function addBook(Book $book) {
        $this->books[] = $book;
    }

    public function addBooks(array $books) {
        foreach ($books as $book) {
            if ($book instanceof Book) {
                $this->books[] = $book;
            }
        }
    }

    public function listBooks(){
        if (empty($this->books)){
            return "There are no books in the library, or there was an error.";
        }

        $bookInfos = array_map(function($book) {
            return $book->getInfo();
        }, $this->books);

        return "Books in " .$this->name.", ".$this->location. ":\n" . implode("\n", $bookInfos);
    }
}

$book1 = new Book("The Bingus Book", "Bingus B. Bingus", 2022);
$book2 = new Book("Earl's List", "Earl Hickey", 2006);
$book3 = new Book("Guitar Heroes: A Tale of Rock", "Neversoft Productions", 2007);

$library = new Library("Coventry Hills Public Library", "Calgary");

$library->addBooks([$book1, $book2, $book3]);

echo $library->listBooks();

?>
