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
using HackAtHome.SAL;
using HackAtHome.Entities;
using HackAtHome.CustomAdapters;

namespace HackAtHomeClient
{
    [Activity(Label = "@string/ApplicationName", Icon = "@drawable/icono", Theme = "@android:style/Theme.Holo")]
    public class ListaEvidenciasActivity : Activity
    {
        public ResultInfo InfoUsuario { get; set; }
        ListaEvidenciasFragment ListaEvidenciasFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListaEvidencias);


            InfoUsuario = HelperSAL.Deserializar<ResultInfo>(Intent.GetStringExtra("infoUsuario"));
            FindViewById<TextView>(Resource.Id.lblNombreCompleto).Text = InfoUsuario.FullName;


            MostrarEvidencias();

        }
        private async void MostrarEvidencias()
        {
            ListaEvidenciasFragment = (ListaEvidenciasFragment)this.FragmentManager.FindFragmentByTag("ListaEvidenciasFragment");
            if (ListaEvidenciasFragment == null)
            {
                //No ha sido almacenado, agregar el fragmento a la Activity
                ListaEvidenciasFragment = new ListaEvidenciasFragment();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(ListaEvidenciasFragment, "ListaEvidenciasFragment");
                FragmentTransaction.Commit();

                ServiceClient serviceClient = new ServiceClient();
                ListaEvidenciasFragment.listaEvidencias = await serviceClient.GetEvidencesAsync(InfoUsuario.Token);
            }
            var ListaEvidencias = FindViewById<ListView>(Resource.Id.listView1);

            ListaEvidencias.Adapter = new EvidencesAdapter(
                this, ListaEvidenciasFragment.listaEvidencias,
                Resource.Layout.ItemEvidencia, Resource.Id.lblTituloEvidencia,
                Resource.Id.lblEstadoEvidencia);

            ListaEvidencias.ItemClick += ListaEvidencias_ItemClick;
        }

        private void ListaEvidencias_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (e.Id > 0)
            {
                Intent button_login = new Intent(this, typeof(DetalleItemActivity));
                button_login.PutExtra("infoUsuario", HelperSAL.Serializar(InfoUsuario));
                var itemEvidencia = ListaEvidenciasFragment.listaEvidencias.Find(x => x.EvidenceID == e.Id);
                button_login.PutExtra("ObjetoEvidencia", HelperSAL.Serializar(itemEvidencia));
                StartActivity(button_login);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnResume()
        {
            base.OnResume();
        }
        protected override void OnPause()
        {
            base.OnPause();
        }

        //onDestroy, OnRestart
        protected override void OnStop()
        {
            base.OnStop();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            //outState.PutInt("CounterValue", Counter);
            base.OnSaveInstanceState(outState);
        }
    }
}