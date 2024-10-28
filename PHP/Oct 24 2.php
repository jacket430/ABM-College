<?php

class DirectedGraph {
    private $adjacencyList = [];

    public function addNode($node) {
        if (!array_key_exists($node, $this->adjacencyList)) {
            $this->adjacencyList[$node] = [];
        }
    }

    public function addEdge($node1, $node2) {
        if (!array_key_exists($node1, $this->adjacencyList)) {
            $this->addNode($node1);
        }
        if (!array_key_exists($node2, $this->adjacencyList)) {
            $this->addNode($node2);
        }
        $this->adjacencyList[$node1][] = $node2;
    }

    public function printAdjacencyList() {
        foreach ($this->adjacencyList as $node => $edges) {
            echo $node . " ---> " . implode(", ", $edges) . "\n";
        }
    }
}

$graph = new DirectedGraph();

$graph->addEdge('A', 'B');
$graph->addEdge('B', 'C');

$graph->printAdjacencyList();
