using System;

using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;

namespace GlfwSharp
{
	static partial class Glfwint
	{
		[DllImport ("glfw.dll", EntryPoint="glfwGetGammaRamp")]
		public static extern IntPtr getGammaRamp (IntPtr monitor);
		[DllImport ("glfw.dll", EntryPoint="glfwGetMonitorName")]
		public static extern IntPtr getMonitorName (IntPtr monitor);
		[DllImport ("glfw.dll", EntryPoint="glfwGetMonitorPhysicalSize")]
		public static extern void getMonitorPhysicalSize (IntPtr monitor, ref int width, ref int height);
		[DllImport ("glfw.dll", EntryPoint="glfwGetMonitorPos")]
		public static extern void getMonitorPos (IntPtr monitor, ref int x, ref int y);
		[DllImport ("glfw.dll", EntryPoint="glfwGetMonitors")]
		public static extern IntPtr getMonitors (ref int count);
		[DllImport ("glfw.dll", EntryPoint="glfwGetGammaRamp")]
		public static extern IntPtr getPrimaryMonitor ();
		[DllImport ("glfw.dll", EntryPoint="glfwGetVideoMode")]
		public static extern IntPtr getVideoMode (IntPtr monitor);
		[DllImport ("glfw.dll", EntryPoint="glfwGetVideoModes")]
		public static extern IntPtr getVideoModes (IntPtr monitor, ref int count);
		[DllImport ("glfw.dll", EntryPoint="glfwSetGamma")]
		public static extern void setGamma (IntPtr monitor, float gamma);
		[DllImport ("glfw.dll", EntryPoint="glfwSetGammaRamp")]
		public static extern void setGammaRamp (IntPtr monitor, IntPtr ramp);
		[DllImport ("glfw.dll", EntryPoint="glfwSetMonitorCallback")]
		public static extern GLFWmonitorfun setMonitorCallback (GLFWmonitorfun cbfun);
	}

	public static partial class GLFW
	{
		public static GLFWgammaramp getGammaRamp (GLFWmonitor monitor)
		{
			IntPtr a = Glfwint.getGammaRamp (monitor.handle);
			GLFWgammaramp ramp = (GLFWgammaramp)Marshal.PtrToStructure (a, typeof (GLFWgammaramp));
			return ramp;
		}

		public static string getMonitorName (GLFWmonitor monitor)
		{
			IntPtr name = Glfwint.getMonitorName (monitor.handle);
			return Marshal.PtrToStringAuto (name);
		}

		// I don't know, I want to name it getPhysicalMonitorSize, but I'll keep it getMonitorPhysicalSize for the sake of compatibility
		public static void getMonitorPhysicalSize (GLFWmonitor monitor, ref int width, ref int height)
		{
			width = 0;
			height = 0;
			Glfwint.getMonitorPhysicalSize (monitor.handle, ref width, ref height);
		}

		public static void getMonitorPos (GLFWmonitor monitor, ref int x, ref int y)
		{
			x = 0;
			y = 0;
			Glfwint.getMonitorPos (monitor.handle, ref x, ref y);
		}

		public static List<GLFWmonitor> getMonitors ()
		{
			int count = 0;
			IntPtr monitorList = Glfwint.getMonitors (ref count);

			List<GLFWmonitor> monitors = new List<GLFWmonitor> ();
			for (int i = 0; i < count; i++)
			{
				GLFWmonitor newMonitor = new GLFWmonitor ();

				newMonitor.handle = (IntPtr)Marshal.PtrToStructure (monitorList, typeof(IntPtr));
				monitorList += Marshal.SizeOf (typeof(IntPtr));
				monitors.Add (newMonitor);
			}

			return monitors;
		}

		public static GLFWmonitor getPrimaryMonitor ()
		{
			GLFWmonitor newMonitor = new GLFWmonitor ();
			newMonitor.handle = Glfwint.getPrimaryMonitor ();
			return newMonitor;
		}

		public static GLFWvidmode getVideoMode (GLFWmonitor monitor)
		{
			return (GLFWvidmode)Marshal.PtrToStructure (Glfwint.getVideoMode (monitor.handle), typeof (GLFWvidmode));
		}

		public static List<GLFWvidmode> getVideoModes (GLFWmonitor monitor)
		{
			int count = 0;
			IntPtr modeList = Glfwint.getVideoModes (monitor.handle, ref count);

			List<GLFWvidmode> modes = new List<GLFWvidmode> ();
			for (int i = 0; i < count; i++)
			{
				GLFWvidmode newMode = new GLFWvidmode ();

				newMode = (GLFWvidmode)Marshal.PtrToStructure (modeList, typeof(GLFWvidmode));
				modeList += Marshal.SizeOf (typeof(GLFWvidmode));
				modes.Add (newMode);
			}

			return modes;
		}

		public static void setGamma (GLFWmonitor monitor, float gamma)
		{
			Glfwint.setGamma (monitor.handle, gamma);
		}

		public static void setGammaRamp (GLFWmonitor monitor, GLFWgammaramp ramp)
		{
			IntPtr ptr= new IntPtr ();
			Marshal.StructureToPtr (ramp, ptr, false);
			Glfwint.setGammaRamp (monitor.handle, ptr);
		}

		public static GLFWmonitorfun setMonitorCallback (GLFWmonitorfun cbfun)
		{
			return Glfwint.setMonitorCallback (cbfun);
		}
	}

	public class GLFWmonitor
	{
		public IntPtr handle;

		public GLFWmonitor ()
		{
		}
	}

	public delegate void GLFWmonitorfun (GLFWmonitor monitor, int ev);

	public class GLFWvidmode
	{
		public int width;
		public int height;
		public int redBits;
		public int greenBits;
		public int blueBits;
		public int refreshRate;
	}

	public class GLFWgammaramp
	{
		List<ushort> red;
		List<ushort> green;
		List<ushort> blue;
		uint size;
	}
}

