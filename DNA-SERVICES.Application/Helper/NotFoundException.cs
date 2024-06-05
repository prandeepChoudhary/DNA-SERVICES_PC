using System;
using System.Runtime.Serialization;

namespace DNA_SERVICES.Application.Helper
{
	[Serializable]
	public class NotFoundException : AppException
	{
		public NotFoundException()
		{
		}

		public NotFoundException(List<string> messages) : base(messages)
		{

		}
        public NotFoundException(string messages) : base(messages)
        {

        }
		public NotFoundException(string message, Exception inner) : base(message, inner)
		{

		}
		protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{

		}
    }

}

