using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trelica.Kata.TransistiveDependencies
{
    public class DependencyResolver
    {
        private readonly IDependencyBuilder _builder;
        private readonly IDependencyTraverser _traverser;


        public DependencyResolver()
        {
            _builder = new DependencyBuilder();
            _traverser = new DepthFirstSearchTraversor();
        }
        public DependencyResolver(IDependencyBuilder builder, IDependencyTraverser traverser)
        {
            _builder = builder;
            _traverser = traverser;
        }

        public List<string> ResolveDependencies(List<string> dependencies)
        {
            var adjList = _builder.BuildDependencies(dependencies);
            var resolvedDependencies = _traverser.TraverseDependencies(adjList);
            return resolvedDependencies;
        }
    }
}
