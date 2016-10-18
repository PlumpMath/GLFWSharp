using System;
using System.Runtime.InteropServices;

namespace GlfwSharp
{
	static partial class Glfwint
	{
		[DllImport ("glfw.dll", EntryPoint="glfwExtensionSupported")]
		public static extern int extensionSupported (IntPtr extension);
		[DllImport ("glfw.dll", EntryPoint="glfwGetCurrentContext")]
		public static extern IntPtr getCurrentContext ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetProcAddress")]
		public static extern GLFWglproc getProcAddress (IntPtr procname);
		[DllImport ("glfw.dll", EntryPoint="glfwMakeContextCurrent")]
		public static extern void makeContextCurrent (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwSwapInterval")]
		public static extern void swapInterval (int interval);
	}

	public static partial class GLFW
	{
		public static bool extensionSupported (string extension)
		{
			IntPtr ext = Marshal.StringToHGlobalAuto (extension);
			int val = Glfwint.extensionSupported (ext);
			return (val == 1);
		}

		public static GLFWwindow getCurrentContext ()
		{
			GLFWwindow win = new GLFWwindow ();
			win.handle = Glfwint.getCurrentContext ();
			return win;
		}

		public static GLFWglproc getProcAddress (string procname)
		{
			return Glfwint.getProcAddress (Marshal.StringToHGlobalAuto (procname));
		}

		public static void makeContextCurrent (GLFWwindow window)
		{
			Glfwint.makeContextCurrent (window.handle);
		}

		public static void swapInterval (int interval)
		{
			Glfwint.swapInterval (interval);
		}
	}

	public delegate void GLFWglproc ();
}

