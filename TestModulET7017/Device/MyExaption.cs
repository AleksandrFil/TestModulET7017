using System;
using System.Runtime.Serialization;

namespace TestModulET7017
{
    [Serializable]
    internal class MyExaption : Exception
    {
        public MyExaption()
        {
        }

        public MyExaption(string message) : base(message)
        {
        }

        public MyExaption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyExaption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}