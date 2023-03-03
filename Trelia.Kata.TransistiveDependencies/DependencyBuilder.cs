using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trelica.Kata.TransistiveDependencies
{
    public class DependencyBuilder : IDependencyBuilder
    {
        public Dictionary<string, List<string>> BuildDependencies(List<string> dependencies)
        {

            Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
            foreach (var line in dependencies)
            {
                var parts = line.Split(' ');
                var name = parts[0];
                var deps = parts.Skip(1).ToList();
                adjList[name] = deps;
            }

            return adjList;
        }
    }

    public interface IDependencyBuilder
    {
        Dictionary<string, List<string>> BuildDependencies(List<string> dependencies);
    }
}
