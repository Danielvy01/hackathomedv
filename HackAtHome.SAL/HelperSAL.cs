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
using Newtonsoft.Json;

namespace HackAtHome.SAL
{
    public class HelperSAL
    {
        public static T Deserializar<T>(string cadena)
        {
            return JsonConvert.DeserializeObject<T>(cadena);
        }
        public static string Serializar<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
        bool IsLandScape(Activity activity)
        {
            var Orientation = activity.WindowManager.DefaultDisplay.Rotation;
            return Orientation == Android.Views.SurfaceOrientation.Rotation90 || Orientation == Android.Views.SurfaceOrientation.Rotation270;
        }
    }
}