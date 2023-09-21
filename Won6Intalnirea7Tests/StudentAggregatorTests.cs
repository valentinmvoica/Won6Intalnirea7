using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class StudentAggregatorTests
    {
        [TestMethod()]
        public void GetAverageTest()
        {
            var students = new List<IStudent>();

            Mock<IStudent> s1 = new Mock<IStudent>();
            s1.Setup(s => s.Marks).Returns(new List<int> { 10, 5, 4, 9 });

            students.Add(s1.Object);

            Mock<IStudent> s2 = new Mock<IStudent>();
            s2.Setup(s => s.Marks).Returns(new List<int> { 9, 9, 9, 9 });

            students.Add(s2.Object);
           

            var actualResult = StudentAggregator.GetAverage(students);

            Assert.AreEqual(9, actualResult);
        }
    }

    class StudentMock : IStudent
    {
        public StudentMock(List<int> marks)
        {
            this.Marks = marks;
        }
        public List<int> Marks { get; private set; }


        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}