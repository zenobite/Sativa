using System.Runtime.Serialization;

namespace Sativa.Libs
{
    [Serializable]
    internal class DirectoryServicesCOMException : Exception
    {
        public DirectoryServicesCOMException()
        {
        }

        public DirectoryServicesCOMException(string message) : base(message)
        {
        }

        public DirectoryServicesCOMException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DirectoryServicesCOMException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}