using System;
using System.Runtime.InteropServices;

namespace GlfwSharp
{
	static partial class Glfwint
	{
		[DllImport ("glfw.dll", EntryPoint="glfwInit")]
		public static extern bool glfwInit ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetVersion")]
		public static extern void getVersion (ref int major, ref int minor, ref int rev);
		[DllImport ("glfw.dll", EntryPoint="glfwGetVersionString")]
		public static extern IntPtr getVersionString ();
		[DllImport ("glfw.dll", EntryPoint="glfwSetErrorCallback")]
		public static extern GLFWerrorfun setErrorCallback (GLFWerrorfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwTerminate")]
		public static extern void terminate ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetTime")]
		public static extern double getTime ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetTimerFrequency")]
		public static extern UInt64 getTimerFrequency ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetTimerValue")]
		public static extern UInt64 getTimerValue ();
		[DllImport ("glfw.dll", EntryPoint="glfwSetTime")]
		public static extern void setTime (double time);
	}
}

