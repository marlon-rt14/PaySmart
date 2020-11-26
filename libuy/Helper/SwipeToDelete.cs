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
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;

namespace libuy.Helper
{
    public class SwipeToDelete : ItemTouchHelper.Callback
    {

        MyAdapter myAdapter;
        Context mContext;
        RecyclerView newRecylcer;
        private Paint mClearPaint;
        private ColorDrawable mBackground;
        private Drawable deleteDrawable;
        private int intrinsicWidth;
        private int intrinsicHeight;

        public SwipeToDelete(Context context, RecyclerView.Adapter adapter, RecyclerView mRecycler)
        {
            myAdapter = (MyAdapter)adapter;
            mContext = context;
            newRecylcer = mRecycler;
            mBackground = new ColorDrawable();
            mClearPaint = new Paint();
            mClearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
            deleteDrawable = context.GetDrawable(Resource.Drawable.ic_delete);
            intrinsicWidth = deleteDrawable.IntrinsicWidth;
            intrinsicHeight = deleteDrawable.IntrinsicHeight;
        }

        public override int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1)
        {
            //int dragFlags = ItemTouchHelper.Down | ItemTouchHelper.Up;
            int swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
            //return MakeMovementFlags(dragFlags, swipeFlags);
            return MakeMovementFlags(0, swipeFlags);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            //int position = viewHolder.AdapterPosition;
            //Data item = myAdapter.getData(position);

            //myAdapter.removeItem(position);

            //View container = ((MainActivity)mContext).Window.DecorView.FindViewById(Resource.Id.container);
            //Snackbar snackbar = Snackbar.Make(container, "El producto ha sido removido de la lista", Snackbar.LengthLong);
            //snackbar.SetAction("UNDO", (View view) =>
            //{
            //    myAdapter.restoreItem(item, position);
            //    newRecylcer.ScrollToPosition(position);
            //});
            //snackbar.SetActionTextColor(Color.LightGreen);
            //snackbar.Show();
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);

            View itemView = viewHolder.ItemView;
            int itemHeight = itemView.Height;

            Boolean isCancelled = dX == 0 && !isCurrentlyActive;

            if (isCancelled)
            {
                clearCanvas(c, itemView.Right + dX, (float)itemView.Top, (float)itemView.Right, (float)itemView.Bottom);
                base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
                return;
            }

            mBackground.SetColorFilter(Color.Red, PorterDuff.Mode.Add);
            mBackground.SetBounds(itemView.Right + (int)dX, itemView.Top, itemView.Right, itemView.Bottom);
            mBackground.Draw(c);

            int deleteIconTop = itemView.Top + (itemHeight - intrinsicHeight) / 2;
            int deleteIconMargin = (itemHeight - intrinsicHeight) / 2;
            int deleteIconLeft = itemView.Right - deleteIconMargin - intrinsicWidth;
            int deleteIconRight = itemView.Right - deleteIconMargin;
            int deleteIconBottom = deleteIconTop + intrinsicHeight;

            deleteDrawable.SetBounds(deleteIconLeft, deleteIconTop, deleteIconRight, deleteIconBottom);
            deleteDrawable.Draw(c);

            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
        }

        private void clearCanvas(Canvas c, float left, float top, float right, float bottom)
        {
            c.DrawRect(left, top, right, bottom, mClearPaint);
        }

        public override float GetSwipeThreshold(RecyclerView.ViewHolder viewHolder)
        {
            return 0.7f;
        }

    }
}