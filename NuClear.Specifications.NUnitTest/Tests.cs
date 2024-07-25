namespace NuClear.Specifications.NUnitTest
{
    public class Tests
    {
        protected TestObject testObject;

        [SetUp]
        public void Setup()
        {
            testObject = new TestObject()
            {
                Id = 1,
                Name = "TestObject",
                CreateTime = new DateTime(2024, 7, 1, 12, 0, 0),
            };
        }

        [Test]
        public void AndSpecificationTest1()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.And(Specification<TestObject>.Create(t => t.CreateTime < DateTime.Now));

            spec = spec.And(Specification<TestObject>.Create(t => t.Name.Contains("Test")));

            Assert.IsTrue(spec.IsSatisfiedBy(testObject));
        }

        [Test]
        public void AndSpecificationTest2()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.And(Specification<TestObject>.Create(t => t.CreateTime > DateTime.Now));

            Assert.IsFalse(spec.IsSatisfiedBy(testObject));
        }

        [Test]
        public void OrSpecificationTest1()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.Or(Specification<TestObject>.Create(t => t.CreateTime > DateTime.Now));

            Assert.IsTrue(spec.IsSatisfiedBy(testObject));
        }

        [Test]
        public void OrSpecificationTest2()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 2);

            spec = spec.Or(Specification<TestObject>.Create(t => t.CreateTime > DateTime.Now));

            Assert.IsFalse(spec.IsSatisfiedBy(testObject));
        }


        [Test]
        public void AndNotSpecificationTest1()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.AndNot(Specification<TestObject>.Create(t => t.CreateTime > DateTime.Now));

            Assert.IsTrue(spec.IsSatisfiedBy(testObject));
        }

        [Test]
        public void AndNotSpecificationTest2()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.AndNot(Specification<TestObject>.Create(t => t.CreateTime < DateTime.Now));

            Assert.IsFalse(spec.IsSatisfiedBy(testObject));
        }

        [Test]
        public void NotSpecificationTest2()
        {
            var spec = Specification<TestObject>.Create(t => t.Id == 1);

            spec = spec.Not();

            Assert.IsFalse(spec.IsSatisfiedBy(testObject));
        }

    }
}