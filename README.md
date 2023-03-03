# Trelica.Kata.TransistiveDependencies

The problem at hand is to find the transitive dependencies between different items, given that each item is listed on a separate line. My initial thoughts on the problem come from mathematical principles where we know that if A=B and B=C, then A indirectly depends on C. To tackle this problem, I have come up with two solutions, out of which one seemed more intuitive and is based on core computer science foundations.


- To start, I considered every character in the input as a vertex of a directed graph, with each vertex having direct dependencies. For instance, vertex A has directed edges to its dependent vertices B and C.

- Graphs are generally represented in adjacency matrices or adjacency lists. In this case, we chose an adjacency list as the input is already formatted that way, and we do not need to add vertices and edges. 

- We can traverse the graph by applying depth-first search where we traverse each item on the adjacency list and apply DFS to traverse their direct and indirect descendants.

# Part II 

- In part two of the problem, we need to handle circular dependencies. By representing the problem in the graph data structure, we can conveniently solve the problem by checking if the root vertex has been visited again. If that is the case, we throw an exception.

The main class that solves the problem is the DepthFirstSearchTraversor, while other classes and interfaces are created to make the code production-ready. To test the code, we use unit tests.
