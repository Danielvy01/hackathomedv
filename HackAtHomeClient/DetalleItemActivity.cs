using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HackAtHome.Entities;
using HackAtHome.SAL;
using Android.Webkit;

namespace HackAtHomeClient
{
    [Activity(Label = "@string/ApplicationName", Icon = "@drawable/icono", Theme = "@android:style/Theme.Holo")]
    public class DetalleItemActivity : Activity
    {
        public ResultInfo InfoUsuario { get; set; }
        public Evidence ObjetoEvidencia { get; set; }
        ListaDetalleEvidenciaFragment ListaDetalleEvidenciaFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            InfoUsuario = HelperSAL.Deserializar<ResultInfo>(Intent.GetStringExtra("infoUsuario"));
            ObjetoEvidencia = HelperSAL.Deserializar<Evidence>(Intent.GetStringExtra("ObjetoEvidencia"));
            SetContentView(Resource.Layout.DetalleItem);
            // Create your application here

            MostrarDetalleEvidencia();
        }
        private async void MostrarDetalleEvidencia()
        {
            ListaDetalleEvidenciaFragment = (ListaDetalleEvidenciaFragment)this.FragmentManager.FindFragmentByTag("ListaDetalleEvidenciaFragment");
            if (ListaDetalleEvidenciaFragment == null)
            {
                //No ha sido almacenado, agregar el fragmento a la Activity
                ListaDetalleEvidenciaFragment = new ListaDetalleEvidenciaFragment();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(ListaDetalleEvidenciaFragment, "ListaDetalleEvidenciaFragment");
                FragmentTransaction.Commit();

                ServiceClient serviceClient = new ServiceClient();
                ListaDetalleEvidenciaFragment.Evidencia = await serviceClient.GetEvidenceByIDAsync(InfoUsuario.Token, ObjetoEvidencia.EvidenceID);
            }
            FindViewById<TextView>(Resource.Id.lblTituloEvidencia).Text = ObjetoEvidencia.Title;
            FindViewById<TextView>(Resource.Id.lblEstadoEvidencia).Text = ObjetoEvidencia.Status;
            FindViewById<TextView>(Resource.Id.lblNombreCompleto).Text = InfoUsuario.FullName;
            var wvDescripcionEvidencia = FindViewById<WebView>(Resource.Id.wvDescripcionEvidencia);
            ListaDetalleEvidenciaFragment.Evidencia.Description = "<html><head><style>body{color:white}</style></head><body>" + ListaDetalleEvidenciaFragment.Evidencia.Description + "</body></html>";
            wvDescripcionEvidencia.LoadDataWithBaseURL(null, ListaDetalleEvidenciaFragment.Evidencia.Description, "text/html", "utf-8", null);
            //wvDescripcionEvidencia.LoadData(ListaDetalleEvidenciaFragment.Evidencia.Description, "text/html", "utf-8");
            wvDescripcionEvidencia.SetBackgroundColor(Android.Graphics.Color.Transparent);


            var ivEvidencia = FindViewById<ImageView>(Resource.Id.ivEvidencia);
            Koush.UrlImageViewHelper.SetUrlDrawable(ivEvidencia, ListaDetalleEvidenciaFragment.Evidencia.Url);
        }
    }
}