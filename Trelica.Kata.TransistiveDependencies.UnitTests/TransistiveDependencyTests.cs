namespace Trelica.Kata.TransistiveDependencies.UnitTests
{
    public class TransistiveDependencyTests
    {
        private DependencyResolver _dependencyResolver;

        [SetUp]
        public void Setup()
        {
            _dependencyResolver = new DependencyResolver();
        }


        [Test]
        public void ShouldReturnCorrectDependencies_WhenInputIsGiven()
        {
            var dependencies = new List<string> {
            "A B C",
            "B C E",
            "C G",
            "D A F",
            "E F",
            "F H"
            };

            var result = _dependencyResolver.ResolveDependencies(dependencies);

            List<string> expected = new List<string>() { "A  B C E F G H", "B  C E F G H", "C  G", "D  A B C E F G H", "E  F H", "F  H" };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void ShouldThrowError_WhenCircularDependenciesIsDectected()
        {
            var dependencies = new List<string> {
                                            "A B C",
                                            "B C E",
                                            "C G",
                                            "D A F",
                                            "E F",
                                            "F H",
                                            "H A"
                                        };


            Assert.Throws<Exception>(
            () => _dependencyResolver.ResolveDependencies(dependencies));
        }
    }
}
