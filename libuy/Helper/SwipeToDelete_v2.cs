using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
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
        private Drawable deleteDrawable;
        private ColorDrawable background;
        private int intrinsicWidth;
        private int intrinsicHeight;

        public SwipeToDelete_v2(RecyclerView.Adapter adapter, Context context)
        {
            mAdapter = (MyAdapter)adapter;
            mContext = context;
            background = new ColorDrawable();
            deleteDrawable = context.GetDrawable(Resource.Drawable.ic_delete);
            intrinsicWidth = deleteDrawable.IntrinsicWidth;
            intrinsicHeight = deleteDrawable.IntrinsicHeight;
        }

        public override int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1)
        {
            int swipeFlags = ItemTouchHelper.Start;
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

            View itemView = viewHolder.ItemView;
            int itemHeight = itemView.Height;

            background.SetColorFilter(Color.Red, PorterDuff.Mode.Add);
            background.SetBounds(itemView.Right + (int)dX, itemView.Top, itemView.Right, itemView.Bottom);
            background.Draw(c);

            int deleteIconTop = itemView.Top + (itemHeight - intrinsicHeight) / 2;
            int deleteIconMargin = (itemHeight - intrinsicHeight) / 2;
            int deleteIconLeft = itemView.Right - deleteIconMargin - intrinsicWidth;
            int deleteIconRight = itemView.Right - deleteIconMargin;
            int deleteIconBottom = deleteIconTop + intrinsicHeight;

            deleteDrawable.SetBounds(deleteIconLeft, deleteIconTop, deleteIconRight, deleteIconBottom);
            deleteDrawable.Draw(c);
        }
    }
}