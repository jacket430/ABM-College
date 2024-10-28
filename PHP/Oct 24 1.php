<?php

class DirectedGraph {
    private $adjacencyList = [];

    public function addNode($node) {
        if (!array_key_exists($node, $this->adjacencyList)) {
            $this->adjacencyList[$node] = [];
        }
    }

    public function addEdge($fromNode, $toNode) {
        if (!array_key_exists($fromNode, $this->adjacencyList)) {
            $this->addNode($fromNode);
        }
        if (!array_key_exists($toNode, $this->adjacencyList)) {
            $this->addNode($toNode);
        }
        $this->adjacencyList[$fromNode][] = $toNode;
    }

    public function printAdjacencyList() {
        foreach ($this->adjacencyList as $node => $edges) {
            echo $node . " ---> " . implode(", ", $edges) . PHP_EOL;
        }
    }
}

$graph = new DirectedGraph();

$graph->addEdge('A', 'B');
$graph->addEdge('A', 'C');
$graph->addEdge('B', 'D');
$graph->addEdge('C', 'D');

$graph->printAdjacencyList();

