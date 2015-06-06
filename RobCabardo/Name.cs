using System;
using Xunit.Sdk;

namespace Test02
{
    /// <summary>
    /// Represents a first and last name
    /// </summary>
    public class Name : IEquatable<Name>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        /// <summary>
        /// First name
        /// </summary>
        public string First { get; protected set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string Last { get; protected set; }

        /// <summary>
        /// Returns the full name
        /// </summary>
        public string Full
        {
            get { return First + Last; }
        }

        /// <summary>
        /// Create a new name with a different first name
        /// </summary>
        public Name ChangeFirst(string first)
        {
            if (first == "" || String.IsNullOrEmpty(first))
                throw new ArgumentException("Not valid.");

            return new Name(first,Last);
        }

        /// <summary>
        /// Create a new name with a different last name
        /// </summary>
        public Name ChangeLast(string last)
        {
            if (last == "" || String.IsNullOrEmpty(last))
                throw new ArgumentException("Not valid.");

            return new Name(First,last);
        }

        /// <summary>
        /// Checks for equality
        /// </summary>
        public bool Equals(Name other)
        {
            if (ChangeFirst(First) == other)
                return true;
            else
                return false;
        }

        #region "Pre-built code"
        private static readonly Name none = new Name { First = string.Empty, Last = string.Empty };

        /// <summary>
        /// Constructor
        /// </summary>
        private Name()
        {

        }

        /// <summary>
        /// Represents an empty name
        /// </summary>
        /// <remarks>You should not need to touch this.  It represents an empty name</remarks>
        public static Name None
        {
            get
            {
                return none;
            }
        }

        /// <summary>
        /// Gets the hash code of the name
        /// </summary>
        /// <remarks>You should not need to touch this.  Feel free to look up what it's for</remarks>
        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Last.GetHashCode();
        }

        /// <summary>
        /// Checks for equality
        /// </summary>
        /// <remarks>You should not need to touch this.  Feel free to look up what it's for</remarks>
        public override bool Equals(object obj)
        {
            return Equals(obj as Name);
        }
        #endregion
    }
}
