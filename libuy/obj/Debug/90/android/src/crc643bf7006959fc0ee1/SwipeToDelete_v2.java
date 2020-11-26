package crc643bf7006959fc0ee1;


public class SwipeToDelete_v2
	extends android.support.v7.widget.helper.ItemTouchHelper.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getMovementFlags:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;)I:GetGetMovementFlags_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onMove:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z:GetOnMove_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onSwiped:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnSwiped_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("libuy.Helper.SwipeToDelete_v2, libuy", SwipeToDelete_v2.class, __md_methods);
	}


	public SwipeToDelete_v2 ()
	{
		super ();
		if (getClass () == SwipeToDelete_v2.class)
			mono.android.TypeManager.Activate ("libuy.Helper.SwipeToDelete_v2, libuy", "", this, new java.lang.Object[] {  });
	}

	public SwipeToDelete_v2 (android.support.v7.widget.RecyclerView.Adapter p0, android.content.Context p1)
	{
		super ();
		if (getClass () == SwipeToDelete_v2.class)
			mono.android.TypeManager.Activate ("libuy.Helper.SwipeToDelete_v2, libuy", "Android.Support.V7.Widget.RecyclerView+Adapter, Xamarin.Android.Support.v7.RecyclerView:Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public int getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1)
	{
		return n_getMovementFlags (p0, p1);
	}

	private native int n_getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1);


	public boolean onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2)
	{
		return n_onMove (p0, p1, p2);
	}

	private native boolean n_onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2);


	public void onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSwiped (p0, p1);
	}

	private native void n_onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);

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
