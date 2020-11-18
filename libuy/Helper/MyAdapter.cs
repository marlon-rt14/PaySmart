using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
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

        public MyViewHolder(View itemView) : base(itemView)
        {
            txt_titulo = itemView.FindViewById<TextView>(Resource.Id.txtTitulo);
            txt_descripcion = itemView.FindViewById<TextView>(Resource.Id.txtDescripcion);
        }
    }

    class MyAdapter : RecyclerView.Adapter
    {
        private List<Data> lstData;

        public MyAdapter(List<Data> lstData)
        {
            this.lstData = lstData;
        }

        public override int ItemCount => lstData.Count; //DEVUELVE UN ENTERO INDICANDO LA CANTIDAD DE ELEMENTOS A MOSTRAR EN EL RECYCLERVIEW

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)//ENLAZA NUESTROS DATOS CON EL VIEWHOLDER(LA VISTA TITULAR)
        {
            MyViewHolder newDataView = holder as MyViewHolder;
            newDataView.txt_titulo.Text = lstData[position].data_title;
            newDataView.txt_descripcion.Text = lstData[position].data_description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)//INFLA NUESTRO LAYOUT(ARCHIVO XAML) QUER REPRESENTA NUESTROS ELEMENTOS,
                                                                                                  //Y DEVUELVE UNA INSTRANCIA DE LA CLASE VIEWHOLDER QUE ANTES DEFINIMOS
        {
            //CREAR UNA NUEVAS VISTAS
            //TextView newTextView = (TextView)LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item, parent, false);
            //return new MyViewHolder(newTextView);

            //LAYOUT, DISPOSICION
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            //VIEW, VISTA
            View itemView = inflater.Inflate(Resource.Layout.item, parent, false);
            //REGRESAR LA NUEVA VISTA
            return new MyViewHolder(itemView);
        }
    }
}