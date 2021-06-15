using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using Android.Content;

namespace AplicacionTienda
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            
           
            var btnGuardar = FindViewById<Button>(Resource.Id.btnguardar);
            var btnConsult = FindViewById<Button>(Resource.Id.btnconsultar);
            var txtNombre = FindViewById<EditText>(Resource.Id.txtnombre);
            var txtDomicilio = FindViewById<EditText>(Resource.Id.txtdomicilio);
            var txtCorreo = FindViewById<EditText>(Resource.Id.txtcorreo);
            var txtFecha = FindViewById<EditText>(Resource.Id.txtdia);
            var txtHora = FindViewById<EditText>(Resource.Id.txthora);
            var imagen = FindViewById<ImageView>(Resource.Id.image);
            imagen.SetImageResource(Resource.Drawable.logo);


            btnConsult.Click += delegate
            {
                try
                {
                    Cargar();
                }
               
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };

            btnGuardar.Click += delegate
            {
                try
                {
                    var WS = new ServicioWebSalud.ServicioWebSalud();
                    if (WS.Guardar(txtNombre.Text, txtDomicilio.Text, txtCorreo.Text, txtFecha.Text, int.Parse(txtHora.Text)))
                        Toast.MakeText(this, "Guardado correctamente en SQL Server", ToastLength.Long).Show();
                    else
                    {
                        Toast.MakeText(this, "No guardado", ToastLength.Long).Show();
                    }
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };

        }
   

        public void Cargar()
        {
            var VistaPrincipal = new Intent(this, typeof(Principal));
            StartActivity(VistaPrincipal);
        }
        public class Datos
        {
            public string Nombre;
            public string Domicilio;
            public string Correo;
            public string Fecha;
            public string Hora;


        }




    }
}