using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trelica.Kata.TransistiveDependencies
{
    public class DepthFirstSearchTraversor : IDependencyTraverser
    {

        public List<string> TraverseDependencies(Dictionary<string, List<string>> adjList)
        {
            List<string> dependencies = new List<string>();

            foreach (var item in adjList)
            {
                string s = ApplyDepthFirstSearch(adjList, item.Key);
                dependencies.Add(s);
            }

            return dependencies;
        }

        private string ApplyDepthFirstSearch(Dictionary<string, List<string>> adjList, string vertex)
        {
            Stack<string> s = new Stack<string>();
            HashSet<string> visited = new HashSet<string>();

            visited.Add(vertex);
            s.Push(vertex);
            Dictionary<string, List<char>> result = new Dictionary<string, List<char>>();
            result[vertex] = new List<char>();
            while (s.Count > 0)
            {
                var currVertex = s.Pop();


                if (adjList.ContainsKey(currVertex))
                {
                    foreach (var item in adjList[currVertex])
                    {
                        if (item == vertex) throw new Exception("Circular dependency detected!");
                        if (!visited.Contains(item))
                        {
                            visited.Add(item);
                            result[vertex].Add(Convert.ToChar(item));
                            s.Push(item);
                        }

                    }
                }
            }

            var finalString = string.Concat(vertex, "  ");

            finalString += string.Join(' ', result[vertex].OrderBy(x => x));
            return finalString;

        }
    }

    public interface IDependencyTraverser
    {
        List<string> TraverseDependencies(Dictionary<string, List<string>> adjList);
    }
}
