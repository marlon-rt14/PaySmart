using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using libuy.Helper;
using System;
using System.Collections.Generic;

namespace libuy
{

    class MyViewHolder : RecyclerView.ViewHolder //PERMITE OBTENER REFERENCIAS DE LOS COMPONENTES VISUALES(VISTAS) DE CADA ELEMENTO DE LA LISTA
    {
        public TextView txt_titulo;
        public TextView txt_descripcion;
        public TextView txt_numeration;

        public MyViewHolder(View itemView) : base(itemView)
        {
            txt_titulo = itemView.FindViewById<TextView>(Resource.Id.txtTitulo);
            txt_descripcion = itemView.FindViewById<TextView>(Resource.Id.txtDescripcion);
            txt_numeration = itemView.FindViewById<TextView>(Resource.Id.txtNumeracion);
        }
    }

    public class MyAdapter : RecyclerView.Adapter
    {
        private List<Data> lstData;
        private Context mContexto;
        private Data mRecentlyDeletedItem;
        private int mRecentlyDeletedItemPosition;

        public MyAdapter(List<Data> lstData, Context contexto) //añadir, editar o eliminar elementos
        {
            this.lstData = lstData;
            mContexto = contexto;
        }


        public override int ItemCount => lstData.Count; //DEVUELVE UN ENTERO INDICANDO LA CANTIDAD DE ELEMENTOS A MOSTRAR EN EL RECYCLERVIEW

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)//ENLAZA NUESTROS DATOS CON EL VIEWHOLDER(LA VISTA TITULAR)
        {
            //Data newItemData = lstData.FindIndex(position);
            MyViewHolder newDataView = holder as MyViewHolder;
            newDataView.txt_titulo.Text = lstData[position].data_title;
            newDataView.txt_descripcion.Text = lstData[position].data_description;
            newDataView.txt_numeration.Text = lstData[position].data_numeration.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)//INFLA NUESTRO LAYOUT(ARCHIVO XAML) QUER REPRESENTA NUESTROS ELEMENTOS,
                                                                                                  //Y DEVUELVE UNA INSTRANCIA DE LA CLASE VIEWHOLDER QUE ANTES DEFINIMOS
        {

            //CREAR UNA NUEVAS VISTAS
            //TextView newTextView = (TextView)LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item, parent, false);
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item, parent, false);
            //return new MyViewHolder(newTextView);


            //MyViewHolder vista = new MyViewHolder(itemView);

            //LAYOUT, DISPOSICION
            // LayoutInflater inflater = LayoutInflater.From(parent.Context);
            //VIEW, VISTA
            // View itemView = inflater.Inflate(Resource.Layout.item, parent, false);
            //REGRESAR LA NUEVA VISTA
            return new MyViewHolder(itemView);
        }

        //SEGUNDA VERSION
        public void deleteItem(int position)
        {
            mRecentlyDeletedItem = lstData[position];
            mRecentlyDeletedItemPosition = position;
            lstData.RemoveAt(position);
            NotifyItemRemoved(position);
            //RecyclerView recycler = ((MainActivity)mContexto).Window.DecorView.FindViewById<RecyclerView>(Resource.Id.recycler_view_main);
            //recycler.ScrollToPosition(position);
            showUndoSnackBar();
        }

        public void showUndoSnackBar()
        {
            View vista = ((MainActivity)mContexto).Window.DecorView.FindViewById(Resource.Id.container);
            Snackbar sbMessage = Snackbar.Make(vista, "Eliminado", Snackbar.LengthLong);
            sbMessage.SetAction("Deshacer", (View view) => {
                lstData.Insert(mRecentlyDeletedItemPosition, mRecentlyDeletedItem);
                NotifyItemInserted(mRecentlyDeletedItemPosition);
            });
            sbMessage.Show();
        }

        //PRIMERA VERSION
        //public Data getData(int position)
        //{
        //    return lstData[position];
        //}

        //public void removeItem(int position)
        //{
        //    lstData.RemoveAt(position);
        //    NotifyItemRemoved(position);
        //}

        //public void restoreItem(Data item, int position)
        //{
        //    lstData.Add(item);
        //    NotifyItemInserted(position);
        //}

    }
}