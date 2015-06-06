using System;
using Xunit;

namespace Test02
{
    public class NameTest
    {
        [Theory, InlineData(null), InlineData("")]
        public void Constructor_ThrowsArgumentException_WhenFirstNameIsEmpty(string testPart)
        {
            Assert.Throws<ArgumentException>(() => new Name(testPart, "Doe"));
        }

        [Fact]
        public void Constructor_SetsFirstAndLastNames_WhenNamesAreValid()
        {
            Name name = new Name("John", "Doe");
            Assert.Equal(name.First, "John");
            Assert.Equal(name.Last, "Doe");
        }

        [Fact]
        public void FullName_ReturnsFirstAndLastNameWithSpace_WhenFirstAndLastNameAreSet()
        {
            Name customer = new Name("John", "Doe");

            Assert.Equal(customer.Full, "John Doe");
        }

        [Fact]
        public void FullName_ReturnsFirstNameWithNoSpace_WhenLastNameIsEmpty()
        {
            Name customer = Name.None.ChangeFirst("John");

            Assert.Equal(customer.Full, "John");
        }

        [Fact]
        public void FullName_ReturnsLastNameWithNoSpace_WhenFirstNameIsEmpty()
        {
            Name customer = Name.None.ChangeLast("Doe");

            Assert.Equal(customer.Full, "Doe");
        }

        [Fact]
        public void FullName_ReturnsEmptyString_WhenFirstAndLastNamesAreEmpty()
        {
            Assert.Empty(Name.None.Full);
        }

        [Fact]
        public void Equals_ReturnsTrue_WhenFirstAndLastNameMatch()
        {
            Name name = new Name("John", "Doe");
            bool result = name.Equals(new Name("John", "Doe"));
            Assert.True(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_WhenFirstNamesMatchButLastNamesDont()
        {
            Name name = new Name("John", "Doe");
            bool result = name.Equals(new Name("John", "Foo"));
            Assert.False(result);
        }

        [Fact]
        public void Equals_ReturnsFalse_WhenLastNamesMatchButFirstNamesDont()
        {
            Name name = new Name("John", "Doe");
            bool result = name.Equals(new Name("Foo", "Doe"));
            Assert.False(result);
        }

        [Fact]
        public void ChangeFirstName_ReturnsNewName_WithUpdatedFirstName()
        {
            Name name = new Name("John", "Doe");
            Name changed = name.ChangeFirst("Foo");

            Assert.Equal(changed.First, "Foo");
            Assert.Equal(changed.Last, "Doe");
        }

        [Theory, InlineData(null), InlineData("")]
        public void ChangeFirstName_ThrowsArgumentException_WhenUpdatedFirstNameIsEmpty(string namePart)
        {
            Name name = new Name("John", "Doe");
            Assert.Throws<ArgumentException>(() => name.ChangeFirst(namePart));
        }

        [Fact]
        public void ChangeLastName_ReturnsNewName_WithUpdatedLastName()
        {
            Name name = new Name("John", "Doe");
            Name changed = name.ChangeLast("Foo");

            Assert.Equal(changed.First, "John");
            Assert.Equal(changed.Last, "Foo");
        }

        [Theory, InlineData(null), InlineData("")]
        public void ChangeLastName_ThrowsArgumentException_WhenUpdatedLastNameIsEmpty(string namePart)
        {
            Name name = new Name("John", "Doe");
            Assert.Throws<ArgumentException>(() => name.ChangeLast(namePart));
        }
    }
}
