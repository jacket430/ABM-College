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
            foreach ($edges as $edge) {
                echo $node . " ---> " . $edge . "\n";
            }
        }
    }
}

$graph = new DirectedGraph();

$graph->addEdge('City A', 'City B');
$graph->addEdge('City A', 'City C');
$graph->addEdge('City B', 'City D');
$graph->addEdge('City C', 'City D');

$graph->printAdjacencyList();