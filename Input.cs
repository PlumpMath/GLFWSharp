using System;
using System.Runtime.InteropServices;

namespace GlfwSharp
{
	static partial class Glfwint
	{
		[DllImport ("glfw.dll", EntryPoint="glfwGetClipboardString")]
		public static extern IntPtr getClipboardString (IntPtr window);
		[DllImport ("glfw.dll", EntryPoint="glfwGetInputMode")]
		public static extern int getInputMode (IntPtr window, int mode);
		[DllImport ("glfw.dll", EntryPoint="glfwCreateCursor")]
		public static extern IntPtr createCursor (IntPtr iamge, int x, int y);
		[DllImport ("glfw.dll", EntryPoint="glfwCreateStandardCursor")]
		public static extern IntPtr createStandardCursor (int shape);
		[DllImport ("glfw.dll", EntryPoint="glfwDestroyCursor")]
		public static extern void destroyCursor (IntPtr cursor);
		[DllImport ("glfw.dll", EntryPoint="glfwGetCursorPos")]
		public static extern void getCursorPos (IntPtr image, ref double x, ref double y);
		[DllImport ("glfw.dll", EntryPoint="glfwGetJoystickAxes")]
		public static extern IntPtr getJoystickAxes (int joy, ref int count);
		[DllImport ("glfw.dll", EntryPoint="glfwGetJoystickButtons")]
		public static extern IntPtr getJoystickButtons (int joy, ref int count);
		[DllImport ("glfw.dll", EntryPoint="glfwGetJoystickName")]
		public static extern IntPtr getJoystickName (int joy);
		[DllImport ("glfw.dll", EntryPoint="glfwGetKey")]
		public static extern int getKey (IntPtr window, int key);
		[DllImport ("glfw.dll", EntryPoint="glfwGetKeyName")]
		public static extern IntPtr getKeyName (int key, int code);
		[DllImport ("glfw.dll", EntryPoint="glfwGetMouseButton")]
		public static extern int getMouseButton (IntPtr window, int button);
		[DllImport ("glfw.dll", EntryPoint="glfwJoystickPresent")]
		public static extern int joystickPresent (int joy);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCharCallback")]
		public static extern GLFWcharfun setErrorCallback (IntPtr win, GLFWcharfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCharModsCallback")]
		public static extern GLFWcharmodsfun setCharModsCallback (IntPtr win, GLFWcharmodsfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetClipboardString")]
		public static extern void setClipboardString (IntPtr win, IntPtr content);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCursor")]
		public static extern void setCursor (IntPtr win, IntPtr cursor);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCursorEnterCallback")]
		public static extern GLFWcursorenterfun setCursorEnterCallback (IntPtr win, GLFWcursorenterfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCursorPos")]
		public static extern void setCursorPos (IntPtr win, double x, double y);
		[DllImport ("glfw.dll", EntryPoint="glfwSetCursorPosCallback")]
		public static extern GLFWcursorposfun setCursorPosCallback (IntPtr win, GLFWcursorposfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetDropCallback")]
		public static extern GLFWdropfun setDropCallback (IntPtr window, GLFWdropfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetInputMode")]
		public static extern void setInputMode (IntPtr window, int mode, int value);
		[DllImport ("glfw.dll", EntryPoint="glfwSetJoystickCallback")]
		public static extern GLFWjoystickfun setJoystickCallback (GLFWjoystickfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetKeyCallback")]
		public static extern GLFWkeyfun setKeyCallback (IntPtr window, GLFWkeyfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetMouseButtonCallback")]
		public static extern GLFWmousebuttonfun setMouseButtonCallback (IntPtr window, GLFWmousebuttonfun cbfun);
		[DllImport ("glfw.dll", EntryPoint="glfwSetScrollCallback")]
		public static extern GLFWscrollfun setScrollCallback (IntPtr window, GLFWscrollfun cbfun);
	}

	public static partial class GLFW
	{
		public static bool init ()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;
			System.IO.Directory.SetCurrentDirectory (path);
			return Glfwint.glfwInit ();
		}

		public static GlfwVersion getVersion ()
		{
			GlfwVersion version = new GlfwVersion ();
			Glfwint.getVersion (ref version.Major, ref version.Minor, ref version.Revision);
			return version;
		}

		public static string getVersionString ()
		{
			return Marshal.PtrToStringAuto (Glfwint.getVersionString ());
		}

		public static GLFWerrorfun setErrorCallback (GLFWerrorfun cbfun)
		{
			return Glfwint.setErrorCallback (cbfun);
		}

		public static void terminate ()
		{
			Glfwint.terminate ();
		}

		public static GLFWcursor createCursor (GLFWimage image, int x, int y)
		{
			GLFWcursor cursor = new GLFWcursor ();
			cursor.handle = Glfwint.createCursor (image.handle, x, y);
			return cursor;
		}

		public static GLFWcursor createStandardCursor (int shape)
		{
			GLFWcursor cursor = new GLFWcursor ();
			cursor.handle = Glfwint.createStandardCursor (shape);
			return cursor;
		}

		public static void destroyCursor (GLFWcursor cursor)
		{
			Glfwint.destroyCursor (cursor.handle);
		}

		public static string getClipboardString (GLFWwindow window)
		{
			IntPtr p = Glfwint.getClipboardString (window.handle);
			return Marshal.PtrToStringAuto (p);
		}

		public static void getCursorPos (GLFWwindow window, out double x, out double y)
		{
			x = 0;
			y = 0;
			Glfwint.getCursorPos (window.handle, ref x, ref y);
		}

		public static GLFWmode getInputMode (GLFWwindow window, GLFWmode mode)
		{
			int a = Glfwint.getInputMode (window.handle, (int)mode);
			if (a == 0)
				return GLFWmode.cursor;
			else if (a == 1)
				return GLFWmode.stickyKeys;
			else if (a == 2)
				return GLFWmode.stickyMouseButtons;
			else
				throw new Exception ("Unknown code recieved from 'getInputMode', '" + a.ToString () + "'");
		}

		public static float[] getJoystickAxes (int joy)
		{
			int count = 0;
			IntPtr a = Glfwint.getJoystickAxes (joy, ref count);
			if (count != 0)
			{
				float[] o = new float[count];
				Marshal.Copy (a, o, 0, count);
				return o;
			}

			return new float[0];
		}

		public static GLFWbuttonState[] getJoystickButtons (int joy)
		{
			int count = 0;
			IntPtr a = Glfwint.getJoystickButtons (joy, ref count);
			if (count != 0)
			{
				char[] o = new char[count];
				Marshal.Copy (a, o, 0, count);
				GLFWbuttonState[] t = new GLFWbuttonState[count];
				for (int i = 0; i < o.Length; i++)
					if (o [i] == (int)GLFWbuttonState.press)
						t [i] = GLFWbuttonState.press;
					else
						t [i] = GLFWbuttonState.release;
				return t;
			}

			return new GLFWbuttonState[0];
		}

		public static string getJoystickName (int joy)
		{
			IntPtr a = Glfwint.getJoystickName (joy);
			return Marshal.PtrToStringAuto (a);
		}

		public static GLFWbuttonState getKey (GLFWwindow window, int key)
		{
			int a = Glfwint.getKey (window.handle, key);
			if (a == (int)GLFWbuttonState.press)
				return GLFWbuttonState.press;
			else
				return GLFWbuttonState.release;
		}

		public static string getKeyName (GLFWkey key)
		{
			return getKeyName (key, 0);
		}

		public static string getKeyName (GLFWkey key, int scancode)
		{
			IntPtr name = Glfwint.getKeyName ((int)key, scancode);
			return Marshal.PtrToStringAuto (name);
		}

		public static GLFWbuttonState getMouseButton (GLFWwindow window, GLFWkey key)
		{
			int a = Glfwint.getMouseButton (window.handle, (int)key);
			return (GLFWbuttonState)a;
		}

		public static double getTime ()
		{
			return Glfwint.getTime ();
		}

		public static UInt64 getTimerFrequency ()
		{
			return Glfwint.getTimerFrequency ();
		}

		public static UInt64 getTimerValue ()
		{
			return Glfwint.getTimerValue ();
		}

		public static bool joystickPresent (int joy)
		{
			if (Glfwint.joystickPresent (joy) == 1)
				return true;
			return false;
		}

		public static GLFWcharfun setErrorCallback (GLFWwindow window, GLFWcharfun cbfun)
		{
			return Glfwint.setErrorCallback (window.handle, cbfun);
		}

		public static GLFWcharmodsfun setCharModsCallback (GLFWwindow window, GLFWcharmodsfun cbfun)
		{
			return Glfwint.setCharModsCallback (window.handle, cbfun);
		}

		public static void setClipboardString (GLFWwindow window, string content)
		{
			IntPtr msg = Marshal.StringToHGlobalAuto (content);
			Glfwint.setClipboardString (window.handle, msg);
		}

		public static void setCursor (GLFWwindow window, GLFWcursor cursor)
		{
			Glfwint.setCursor (window.handle, cursor.handle);
		}

		public static GLFWcursorenterfun setCursorEnterCallback (GLFWwindow window, GLFWcursorenterfun cbfun)
		{
			return Glfwint.setCursorEnterCallback (window.handle, cbfun);
		}

		public static void setCursorPos (GLFWwindow window, double x, double y)
		{
			Glfwint.setCursorPos (window.handle, x, y);
		}

		public static GLFWcursorposfun setCursorPosCallback (GLFWwindow window, GLFWcursorposfun cbfun)
		{
			return Glfwint.setCursorPosCallback (window.handle, cbfun);
		}

		public static GLFWdropfun setDropCallback (GLFWwindow window, GLFWdropfun cbfun)
		{
			return Glfwint.setDropCallback (window.handle, cbfun);
		}

		public static void setInputModes (GLFWwindow window, int mode, int value)
		{
			Glfwint.setInputMode (window.handle, mode, value);
		}

		public static GLFWjoystickfun setJoystickCallback (GLFWjoystickfun cbfun)
		{
			return Glfwint.setJoystickCallback (cbfun);
		}

		public static GLFWkeyfun setKeyCallback (GLFWwindow window, GLFWkeyfun cbfun)
		{
			return Glfwint.setKeyCallback (window.handle, cbfun);
		}

		public static GLFWmousebuttonfun setMouseButtonCallback (GLFWwindow window, GLFWmousebuttonfun cbfun)
		{
			return Glfwint.setMouseButtonCallback (window.handle, cbfun);
		}

		public static GLFWscrollfun setScrollCallback (GLFWwindow window, GLFWscrollfun cbfun)
		{
			return Glfwint.setScrollCallback (window.handle, cbfun);
		}

		public static void setTime (double time)
		{
			Glfwint.setTime (time);
		}
	}

	public enum GLFWbuttonState
	{
		press=1,
		release=0,
		repeat=2
	}

	public enum GLFWkey
	{
		unknown=-1,

		space=32,
		apostrophe=39,
		comma=44,
		minus=45,
		period=46,
		slash=47,
		zero=48,
		one=49,
		two=50,
		three=51,
		four=52,
		five=53,
		six=54,
		seven=55,
		eight=56,
		nine=57,
		semicolon=59,
		equal=61,
		A=65,
		B=66,
		C=67,
		D=68,
		E=69,
		F=70,
		G=71,
		H=72,
		I=73,
		J=74,
		K=75,
		L=76,
		M=77,
		N=78,
		O=79,
		P=80,
		Q=81,
		R=82,
		S=83,
		T=84,
		U=85,
		V=86,
		W=87,
		X=88,
		Y=89,
		Z=90,

		leftBracket=91,
		rightBracket=93,
		backslash=92,
		accent=96,
		world1=161,
		world2=162,
		escape         =    256,
		enter          =    257,
		tab            =    258,
		backspace      =    259,
		insert         =    260,
		delete         =    261,
		right          =    262,
		left           =    263,
		down           =    264,
		up             =    265,
		pageUp        =    266,
		pageDown      =    267,
		home           =    268,
		end            =    269,
		capsLock      =    280,
		scrollLock    =    281,
		numLock       =    282,
		printScreen   =    283,
		pause          =    284,

		F1=290,
		F2=291,
		F3=292,
		F4=293,
		F5=294,
		F6=295,
		F7=296,
		F8=297,
		F9=298,
		F10=299,
		F11=300,
		F12=301,
		F13=302,
		F14=303,
		F15=304,
		F16=305,
		F17=306,
		F18=307,
		F19=308,
		F20=309,
		F21=310,
		F22=311,
		F23=312,
		F24=313,
		F25=314,

		keypad0=320,
		keypad1=321,
		keypad2=322,
		keypad3=323,
		keypad4=324,
		keypad5=325,
		keypad6=326,
		keypad7=327,
		keypad8=328,
		keypad9=329,

		keypadDecimal=330,
		keypadDivide=321,
		keypadMultiply=332,
		keypadSubtract=333,
		keypadAdd=334,
		keypadEnter=335,
		keypadEqual=336,
		leftShift=340,
		leftControl=341,
		leftAlt=342,
		leftSuper=343,
		rightShift=344,
		rightControl=345,
		rightAlt=346,
		rightSuper=347,
		menu=348,
		last=348,

		mouseButton1=0,
		mouseButton2=1,
		mouseButton3=2,
		mouseButton4=3,
		mouseButton5=4,
		mouseButton6=5,
		mouseButton7=6,
		mouseButton8=7,
		mouseButtonLast=7,
		mouseButtonLeft=0,
		mouseButtonRight=1,
		mouseButtonMiddle=2,
		
		joystickButton1=0,
		joystickButton2=1,
		joystickButton3=2,
		joystickButton4=3,
		joystickButton5=4,
		joystickButton6=5,
		joystickButton7=6,
		joystickButton8=7,
		joystickButton9=8,
		joystickButton10=9,
		joystickButton11=10,
		joystickButton12=11,
		joystickButton13=12,
		joystickButton14=13,
		joystickButton15=14,
		joystickButton16=15,
		joystickButtonLast=15
	}

	public enum GLFWmode
	{
		cursor=0,
		stickyKeys=1,
		stickyMouseButtons=2
	}

	public delegate void GLFWerrorfun (int errorCode, IntPtr desc);
	public delegate void GLFWcharfun (IntPtr window, uint codePoint);
	public delegate void GLFWcharmodsfun (IntPtr window, uint codePoint, int mods);
	public delegate void GLFWcursorfun (IntPtr window, int codePoint);
	public delegate void GLFWcursorenterfun (IntPtr window, int codePoint);
	public delegate void GLFWcursorposfun (IntPtr window, double x, double y);
	public delegate void GLFWdropfun (IntPtr window, int count, IntPtr paths);
	public delegate void GLFWjoystickfun (int joy, int ev);
	public delegate void GLFWkeyfun (IntPtr window, int key, int scancode, int action, int mods);
	public delegate void GLFWmousebuttonfun (IntPtr window, int button, int action, int mods);
	public delegate void GLFWscrollfun (IntPtr window, double x, double y);

	public class GlfwVersion
	{
		public Int32 Major;
		public Int32 Minor;
		public Int32 Revision;

		public GlfwVersion ()
		{

		}

		public override string ToString ()
		{
			return Major.ToString () + "." + Minor.ToString () + "." + Revision.ToString ();
		}
	}

	public class GLFWcursor
	{
		public IntPtr handle;

		public GLFWcursor ()
		{

		}
	}

	public class GLFWimage
	{
		public IntPtr handle;

		public GLFWimage ()
		{

		}
	}

	public class GLFWjoystick
	{
		public float x;
		public float y;
		public float z;
	}
}

