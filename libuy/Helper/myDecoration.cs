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
using Android.Views;
using Android.Widget;

namespace libuy
{
    public class myDecoration : RecyclerView.ItemDecoration
    {

        private Drawable mDivider;
        public myDecoration(Context context)
        {
            mDivider = context.GetDrawable(Resource.Drawable.divider);
        }


        public override void OnDraw(Canvas c, RecyclerView parent, RecyclerView.State state)
        {
            base.OnDraw(c, parent, state);
            int left = parent.PaddingLeft;
            int right = parent.Width - parent.PaddingRight;

            int childCount = parent.ChildCount;
            for (int i = 0; i < childCount -1; i++)
            {
                View child = parent.GetChildAt(i);
                RecyclerView.LayoutParams @params = (RecyclerView.LayoutParams)child.LayoutParameters;

                int top = child.Bottom + @params.BottomMargin;
                int bottom = top + mDivider.IntrinsicHeight;

                mDivider.SetBounds(left, top, right, bottom);
                mDivider.Draw(c);
            }
        }


        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            base.GetItemOffsets(outRect, view, parent, state);
            outRect.Set(0, 0, 0, 5);
        }
    }
}