using System;

namespace GlfwSharp
{
	public class GLFWNotInitializedException : Exception
	{
		public GLFWNotInitializedException ()
		{

		}


		public GLFWNotInitializedException (string message)
			: base(message)
		{
		}

		public GLFWNotInitializedException (string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}

