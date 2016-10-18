using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;

namespace GlfwSharp
{
	static partial class Glfwint
	{
		[DllImport ("glfw.dll", EntryPoint="glfwCreateWindow")]
		public static extern IntPtr createWindow (int width, int height, IntPtr title, IntPtr monitor, IntPtr share);
		[DllImport ("glfw.dll", EntryPoint="glfwDestroyWindow")]
		public static extern void destroyWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwDefaultWindowHints")]
		public static extern void defaultWindowHints ();
		[DllImport ("glfw.dll", EntryPoint="glfwFocusWindow")]
		public static extern void focusWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwGetFramebufferSize")]
		public static extern void getFramebufferSize (IntPtr window, ref int width, ref int height);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWidnowAttrib")]
		public static extern int getWindowAttrib (IntPtr window, int attrib);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWindowFrameSize")]
		public static extern void getWindowFrameSize (IntPtr window, ref int left, ref int top, ref int right, ref int bottom);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWindowMonitor")]
		public static extern IntPtr getWindowMonitor (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWindowPos")]
		public static extern void getWindowPos (IntPtr window, ref int x, ref int y);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWindowSize")]
		public static extern void getWindowSize (IntPtr window, ref int width, ref int height);
		[DllImport ("glfw.dll", EntryPoint="glfwGetWindowUserPointer")]
		public static extern IntPtr getWindowUserPointer (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwHideWindow")]
		public static extern void hideWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwIconifyWindow")]
		public static extern void iconifyWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwMaximizeWindow")]
		public static extern void maximizeWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwPollEvents")]
		public static extern void pollEvents ();
		[DllImport ("glfw.dll", EntryPoint="glfwPostEmptyEvent")]
		public static extern void postEmptyEvent ();
		[DllImport ("glfw.dll", EntryPoint="glfwRestoreWindow")]
		public static extern void restoreWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwSetFramebufferSizeCallback")]
		public static extern GLFWframebuffersizefun setFramebufferSizeCallback (IntPtr window, GLFWframebuffersizefun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowAs[ectRatio")]
		public static extern void setWindowAspectRatio (IntPtr window, int numer, int denom);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowCloseCallback")]
		public static extern GLFWwindowclosefun setWindowCloseCallback (IntPtr window, GLFWwindowclosefun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowFocusCallback")]
		public static extern GLFWwindowfocusfun setWindowFocusCallback (IntPtr window, GLFWwindowfocusfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowIcon")]
		public static extern void setWindowIcon (IntPtr window, int count, IntPtr images);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowIconifyCallback")]
		public static extern GLFWwindowiconifyfun setWindowIconifyCallback (IntPtr window, GLFWwindowiconifyfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowMonitor")]
		public static extern void setWindowMonitor (IntPtr window, IntPtr monitor, int x, int y, int width, int height, int refreshRate);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowPos")]
		public static extern void setWindowPos (IntPtr window, int x, int y);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowPosCallback")]
		public static extern GLFWwindowposfun setWindowPosCallback (IntPtr window, GLFWwindowposfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwsetWindowRefreshCallback")]
		public static extern GLFWwindowrefreshfun setWindowRefreshCallback (IntPtr window, GLFWwindowrefreshfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowShouldClose")]
		public static extern void setWindowShouldClose (IntPtr window, int val);
		[DllImport ("glfw.dll", EntryPoint="glfwsetWindowSize")]
		public static extern void setWindowSize (IntPtr window, int width, int height);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowSizeCallback")]
		public static extern GLFWwindowsizefun setWindowSizeCallback (IntPtr window, GLFWwindowsizefun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowSizeLimits")]
		public static extern void setWindowSizeLimits (IntPtr window, int minWidth, int minHeight, int maxWidth, int maxHeight);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowTitle")]
		public static extern void setWindowTitle (IntPtr window, IntPtr title);
		[DllImport ("glfw.dll", EntryPoint="glfwSetWindowUserPointer")]
		public static extern void setWindowUserPointer (IntPtr window, IntPtr pointer);
		[DllImport ("glfw.dll", EntryPoint="glfwShowWindow")]
		public static extern void showWindow (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwSwapBuffers")]
		public static extern void swapBuffers (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwWaitEvents")]
		public static extern void waitEvents ();
		[DllImport ("glfw.dll", EntryPoint="glfwWaitEventsTimeout")]
		public static extern void waitEventsTimeout (double timeout);
		[DllImport ("glfw.dll", EntryPoint="glfwWindowHint")]
		public static extern void windowHint (int hint, int value);
		[DllImport ("glfw.dll", EntryPoint="glfwWindowShouldClose")]
		public static extern int windowShouldClose (IntPtr window);
	}

	public static partial class GLFW
	{
		public static GLFWwindow createWindow (int width, int height, string title)
		{
			GLFWwindow win = new GLFWwindow ();
			IntPtr tmp = Glfwint.createWindow (width, height, Marshal.StringToHGlobalAuto (title), IntPtr.Zero, IntPtr.Zero);
			win.handle = tmp;
			return win;
		}

		public static GLFWwindow createWindow (int width, int height, string title, GLFWmonitor monitor, GLFWwindow share)
		{
			GLFWwindow win = new GLFWwindow ();
			IntPtr tmp = Glfwint.createWindow (width, height, Marshal.StringToHGlobalAuto (title), monitor.handle, share.handle);
			win.handle = tmp;
			return win;
		}

		public static void destroyWindow (GLFWwindow window)
		{
			Glfwint.destroyWindow (window.handle);
		}

		public static void defaultWindowHints ()
		{
			Glfwint.defaultWindowHints ();
		}

		public static void focusWindow (GLFWwindow window)
		{
			Glfwint.focusWindow (window.handle);
		}

		public static void getFramebufferSize (GLFWwindow window, ref int width, ref int height)
		{
			width = 0;
			height = 0;
			Glfwint.getFramebufferSize (window.handle, ref width, ref height);
		}

		public static int getWindowAttrib (GLFWwindow window, GLFWAttribute attrib)
		{
			return Glfwint.getWindowAttrib (window.handle, (int)attrib);
		}

		public static void getWindowFrameSize (GLFWwindow window, ref int left, ref int top, ref int right, ref int bottom)
		{
			left = 0;
			top = 0;
			right = 0;
			bottom = 0;
			Glfwint.getWindowFrameSize (window.handle, ref left, ref top, ref right, ref bottom);
		}

		public static GLFWmonitor getWindowMonitor (GLFWwindow window)
		{
			GLFWmonitor mon = new GLFWmonitor ();
			mon.handle = Glfwint.getWindowMonitor (window.handle);
			return mon;
		}

		public static void getWindow (GLFWwindow window, ref int x, ref int y)
		{
			x = 0;
			y = 0;
			Glfwint.getWindowPos (window.handle, ref x, ref y);
		}

		public static void getWindowSize (GLFWwindow window, ref int width, ref int height)
		{
			width = 0;
			height = 0;
			Glfwint.getWindowSize (window.handle, ref width, ref height);
		}

		public static IntPtr getWindowUserPointer (GLFWwindow window)
		{
			return Glfwint.getWindowUserPointer (window.handle);
		}

		public static void hideWindow (GLFWwindow window)
		{
			Glfwint.hideWindow (window.handle);
		}

		public static void iconifyWindow (GLFWwindow window)
		{
			Glfwint.iconifyWindow (window.handle);
		}

		public static void maximizeWindow (GLFWwindow window)
		{
			Glfwint.maximizeWindow (window.handle);
		}

		public static void pollEvents ()
		{
			Glfwint.pollEvents ();
		}

		public static void postEmptyEvent ()
		{
			Glfwint.postEmptyEvent ();
		}

		public static void restoreWindow (GLFWwindow window)
		{
			Glfwint.restoreWindow (window.handle);
		}

		public static GLFWframebuffersizefun setFramebufferSizeCallback (GLFWwindow window, GLFWframebuffersizefun cbfun)
		{
			return Glfwint.setFramebufferSizeCallback (window.handle, cbfun);
		}

		public static void setWindowAspectRatio (GLFWwindow window, int numer, int denom)
		{
			Glfwint.setWindowAspectRatio (window.handle, numer, denom);
		}

		public static GLFWwindowclosefun setWindowCloseCallback (GLFWwindow window, GLFWwindowclosefun cbfun)
		{
			return Glfwint.setWindowCloseCallback (window.handle, cbfun);
		}

		public static GLFWwindowfocusfun setWindowFocusCallback (GLFWwindow window, GLFWwindowfocusfun cbfun)
		{
			return Glfwint.setWindowFocusCallback (window.handle, cbfun);
		}

		public static void setWindowIcon (GLFWwindow window, List<GLFWimage> images)
		{
			GLFWimage[] arr = images.ToArray ();
			IntPtr addr = new IntPtr ();
			Marshal.StructureToPtr (arr, addr, false);
			Glfwint.setWindowIcon (window.handle, images.Count, addr);
		}

		public static void setWindowMonitor (GLFWwindow window, GLFWmonitor monitor, int x, int y, int width, int height, int refreshRate)
		{
			Glfwint.setWindowMonitor (window.handle, monitor.handle, x, y, width, height, refreshRate);
		}

		public static void setWindowPos (GLFWwindow window, int x, int y)
		{
			Glfwint.setWindowPos (window.handle, x, y);
		}

		public static GLFWwindowposfun setWindowPosCallback (GLFWwindow window, GLFWwindowposfun cbfun)
		{
			return Glfwint.setWindowPosCallback (window.handle, cbfun);
		}

		public static GLFWwindowrefreshfun setWindowRefreshCallback (GLFWwindow window, GLFWwindowrefreshfun cbfun)
		{
			return Glfwint.setWindowRefreshCallback (window.handle, cbfun);
		}

		public static void setWindowShouldClose (GLFWwindow window, bool value)
		{
			Glfwint.setWindowShouldClose (window.handle, Convert.ToInt32 (value));
		}

		public static void setWindowSize (GLFWwindow window, int width, int height)
		{
			Glfwint.setWindowSize (window.handle, width, height);
		}

		public static GLFWwindowsizefun setWindowSizeCallback (GLFWwindow window, GLFWwindowsizefun cbfun)
		{
			return Glfwint.setWindowSizeCallback (window.handle, cbfun);
		}

		public static void setWindowSizeLimits (GLFWwindow window, int minWidth, int minHeight, int maxWidth, int maxHeight)
		{
			Glfwint.setWindowSizeLimits (window.handle, minWidth, minHeight, maxWidth, maxHeight);
		}

		public static void setWindowTitle (GLFWwindow window, string title)
		{
			Glfwint.setWindowTitle (window.handle, Marshal.StringToHGlobalAuto (title));
		}

		public static void setWindowUserPointer (GLFWwindow window, IntPtr pointer)
		{
			Glfwint.setWindowUserPointer (window.handle, pointer);
		}

		public static void showWindow (GLFWwindow window)
		{
			Glfwint.showWindow (window.handle);
		}

		public static void swapBuffers (GLFWwindow window)
		{
			Glfwint.swapBuffers (window.handle);
		}

		public static void waitEvents ()
		{
			Glfwint.waitEvents ();
		}

		public static void waitEventsTimeout (double timeout)
		{
			Glfwint.waitEventsTimeout (timeout);
		}

		public static void windowHint (GLFWAttribute hint, int value)
		{
			Glfwint.windowHint ((int)hint, value);
		}

		public static bool windowShouldClose (GLFWwindow window)
		{
			int val = Glfwint.windowShouldClose (window.handle);
			if (Convert.ToBoolean (val))
				return true;
			else
				return false;
		}
	}

	public enum GLFWAttribute
	{
		focused = 0x00020001,
		iconified = 0x00020002,
		visible = 0x00020004,
		resizable = 0x00020003,
		decorated = 0x00020005,
		floating = 0x00020007,
		redBits            =  0x00021001,
		greenBits          =  0x00021002,
		blueBits           =  0x00021003,
		alphaBits          =  0x00021004,
		depthBits          =  0x00021005,
		stencilBits        =  0x00021006,
		accumRedBits      =  0x00021007,
		accumGreenBits    =  0x00021008,
		accumBlueBits     =  0x00021009,
		accumAlphaBits    =  0x0002100a,
		auxBuffers         =  0x0002100b,
		stereo              =  0x0002100c,
		samples             =  0x0002100d,
		srgbCapable        =  0x0002100e,
		refreshRate        =  0x0002100f,
		doubleBuffer        =  0x00021010,
		clientApi                = 0x00022001,
		contextVersionMajor     = 0x00022002,
		contextVersionMinor     = 0x00022003,
		contextRevision          = 0x00022004,
		contextRobustness        = 0x00022005,
		openglForwardCompat     = 0x00022006,
		openglDebugContext      = 0x00022007,
		openglProfile            = 0x00022008,
		contextReleaseBehavior  = 0x000220,
		openglApi                = 0x00030001,
		openglEsApi             = 0x00030002,
		noRobustness             = 0,
		noResetNotification     = 0x00031001,
		loseContextOnReset     = 0x00031002,
		openglAnyProfile        = 0,
		openglCoreProfile       = 0x00032001,
		openglCompatProfile     = 0x00032002,
		cursor                    = 0x00033001,
		stickyKeys               = 0x00033002,
		stickyMouseButtons      = 0x00033003,
		cursorNormal             = 0x00034001,
		cursorHidden             = 0x00034002,
		cursorDisabled           = 0x00034003,
		anyReleaseBehavior      = 0,
		releaseBehaviorFlush    = 0x00035001,
		releaseBehaviorNone     = 0x00035002,
		arrowCursor=           0x00036001,
		ibeamCursor = 0x00036002,
		crossHairCursor = 0x00036003,
		handCursor = 0x00036004,
		hResizeCursor=0x00036005,
		vResizeCursor=0x00036006,
		connected=0x00040001,
		disconnected=0x00040002,
		dontCare=-1
	}

	public class GLFWwindow
	{
		public IntPtr handle;

		public GLFWwindow ()
		{

		}
	}

	public delegate void GLFWframebuffersizefun (IntPtr window, int width, int height);
	public delegate void GLFWwindowclosefun (IntPtr window);
	public delegate void GLFWwindowfocusfun (IntPtr window, int focused);
	public delegate void GLFWwindowiconifyfun (IntPtr window, int iconified);
	public delegate void GLFWwindowposfun (IntPtr window, int x, int y);
	public delegate void GLFWwindowrefreshfun (IntPtr window);
	public delegate void GLFWwindowsizefun (IntPtr window, int width, int height);
}

