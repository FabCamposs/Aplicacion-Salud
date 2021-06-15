using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace AplicacionTienda
{
    [Activity(Label = "Principal")]
    class Principal : Activity
    {
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VistaPrincipal);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnbuscar); 
            var txtNombre = FindViewById<EditText>(Resource.Id.txtnombre);
            var txtDomicilio = FindViewById<EditText>(Resource.Id.txtdomicilio);
            var txtCorreo = FindViewById<EditText>(Resource.Id.txtcorreo);
            var txtFecha = FindViewById<EditText>(Resource.Id.txtdia);
            var txtHora = FindViewById<EditText>(Resource.Id.txthora);
            var imagen = FindViewById<ImageView>(Resource.Id.image);
            imagen.SetImageResource(Resource.Drawable.logo);


            btnBuscar.Click += delegate
            {
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new ServicioWebSalud.ServicioWebSalud();
                    Conjunto = WS.Busqueda((txtNombre.Text));
                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    txtDomicilio.Text = Renglon["Domicilio"].ToString();
                    txtCorreo.Text = Renglon["Correo"].ToString();
                    txtFecha.Text = Renglon["Fecha"].ToString();
                    txtHora.Text = Renglon["Hora"].ToString();

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }

            }; 

        }
    }
}