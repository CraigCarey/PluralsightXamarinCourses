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
using System.Reflection;

namespace CoursesAndroid
{
    public static class ResourceHelper
    {
        // used to cache images so reflection is only used once for each image
        static Dictionary<String, int> resourceDictionary = new Dictionary<String, int>();

        // get image using quick and dirty method. Doesn't scale well
        public static int TranslateDrawable(String drawableName)
        {
            int resourceValue = -1;

            switch(drawableName)
            {
                case "ps_top_card_01" :
                    resourceValue = Resource.Drawable.ps_top_card_01;
                    break;
                case "ps_top_card_02":
                    resourceValue = Resource.Drawable.ps_top_card_02;
                    break;
                case "ps_top_card_03":
                    resourceValue = Resource.Drawable.ps_top_card_03;
                    break;
                case "ps_top_card_04":
                    resourceValue = Resource.Drawable.ps_top_card_04;
                    break;
                default:
                    resourceValue = Resource.Drawable.ps_top_card_01;
                    break;
            }

            return resourceValue;
        }

        // get image using reflection. Reflection is expensive
        public static int TranslateDrawableWithReflection(String drawableName)
        {
            int resourceValue = -1;

            if (resourceDictionary.ContainsKey(drawableName))
            {
                resourceValue = resourceDictionary[drawableName];
            }
            else
            {
                // Drawable is a class
                Type drawableType = typeof(Resource.Drawable);

                // drawableName should match a field of the class drawable
                FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);

                // get the value of the drawableName field
                resourceValue = (int)resourceFieldInfo.GetValue(null);


                // going to the definition of ps_top_card_01 would get you to:
                //public partial class Drawable
                //{			
                //    // aapt resource value: 0x7f020001
                //    public const int ps_top_card_01 = 2130837505;

                // add the value to the dictionary to make future uses faster
                resourceDictionary.Add(drawableName, resourceValue);
            }

            return resourceValue;
        }
    }
}