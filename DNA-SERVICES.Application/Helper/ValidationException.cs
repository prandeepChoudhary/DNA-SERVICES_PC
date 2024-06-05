using System;
using System.Runtime.Serialization;

namespace DNA_SERVICES.Application.Helper
{
	[Serializable]
	public class ValidationException : AppException
	{
		public ValidationException()
		{
		}

        public ValidationException(List<string> messages) : base(messages)
        {

        }
        public ValidationException(string messages) : base(messages)
        {

        }
        public ValidationException(string message, Exception inner) : base(message, inner)
        {

        }
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

