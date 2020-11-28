using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;

namespace libuy.Helper
{
    class SwipeToDelete_v2 : ItemTouchHelper.Callback
    {

        private MyAdapter mAdapter;
        private Context mContext;
        private int position;


        public SwipeToDelete_v2(RecyclerView.Adapter adapter, Context context)
        {
            mAdapter = (MyAdapter)adapter;
            mContext = context;
            
        }

        public override int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1)
        {
            int swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
            return MakeMovementFlags(0, swipeFlags);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            position = viewHolder.AdapterPosition;
            mAdapter.deleteItem(position);
            RecyclerView vista = ((MainActivity)mContext).Window.DecorView.FindViewById<RecyclerView>(Resource.Id.recycler_view_main);
            vista.ScrollToPosition(position);
            vista.SetAdapter(mAdapter);
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
        }
    }
}