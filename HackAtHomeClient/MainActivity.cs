using Android.App;
using Android.Widget;
using Android.OS;
using HackAtHome.Entities;
using HackAtHome.SAL;
using Android.Content;

namespace HackAtHomeClient
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icono", Theme = "@android:style/Theme.Holo")]
    public class MainActivity : Activity
    {
        Button btnValidate;
        EditText txtEmail;
        EditText txtContrasena;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnValidate = FindViewById<Button>(Resource.Id.button1);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtContrasena = FindViewById<EditText>(Resource.Id.txtContrasena);
            txtEmail.Text = "danny_2405@hotmail.com";
            txtContrasena.Text = "";
            btnValidate.Click += BtnValidate_Click;

        }

        private void BtnValidate_Click(object sender, System.EventArgs e)
        {
            validate(txtEmail.Text, txtContrasena.Text);
        }
        
        private async void validate(string usuario, string clave)
        {
            ResultInfo resultInfo;
            resultInfo = await new ServiceClient().AutenticateAsync(usuario, clave);

            var MicrosoftEvidence = new LabItem()
            {
                Email = usuario,
                Lab = "Hack@Home",
                DeviceId = Android.Provider.Settings.Secure.GetString(
                    ContentResolver, Android.Provider.Settings.Secure.AndroidId
                    )
            };
            var MicrosoftClient = new MicrosoftServiceClient();
            await MicrosoftClient.SendEvidence(MicrosoftEvidence);

            if (resultInfo.Status == Status.Success)
            {
                Intent button_login = new Intent(this, typeof(ListaEvidenciasActivity));
                button_login.PutExtra("infoUsuario", HelperSAL.Serializar(resultInfo));
                StartActivity(button_login);
            }
        }
    }
}

