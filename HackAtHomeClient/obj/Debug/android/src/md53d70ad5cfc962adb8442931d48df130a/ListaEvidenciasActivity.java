package md53d70ad5cfc962adb8442931d48df130a;


public class ListaEvidenciasActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onRestart:()V:GetOnRestartHandler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HackAtHomeClient.ListaEvidenciasActivity, HackAtHomeAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListaEvidenciasActivity.class, __md_methods);
	}


	public ListaEvidenciasActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ListaEvidenciasActivity.class)
			mono.android.TypeManager.Activate ("HackAtHomeClient.ListaEvidenciasActivity, HackAtHomeAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onRestart ()
	{
		n_onRestart ();
	}

	private native void n_onRestart ();


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
