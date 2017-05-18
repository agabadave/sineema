using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UIFirstExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            #region Knowing when to use StringBuilder 

            //1. StringBuilder is faster mostly with big strings
            //2. if you just want to append something to a string a single time then a StringBuilder class is overkill
            //3. choosing correctly between StringBuilder objects and string types you can optimize your code

            #endregion

            #region Comparing Non-Case-Sensitive Strings

            //Bad code, However repetitively calling the function ToLower() is a bottleneck in performace
            string strl = "somestring";
            string str2 = "SomeString";
            var isequal = strl.ToLower() == str2.ToLower();

            //Better code, using the built-in string.Compare() function you can increase the speed of your applications

            isequal = string.Compare(strl, str2, true) == 0; //Ignoring cases

            #endregion

            #region string.Empty

            //This is simply a better programming practice
            if (strl == "") ; //Bad code

            if (strl == string.Empty) ; //Better code
            #endregion

            #region Replace ArrayList with List<>

            //Bad code
            ArrayList intArrayList = new ArrayList();
            intArrayList.Add(10);
            var result = (int)intArrayList[0] + 20;//Notice you have to type cast the result to intergers 

            //Better code
            List<int> intList = new List<int>();//Define the type one
            intList.Add(10);
            result = intList[0] + 20;// No need to type cast
                                     //The performance increase can be especially significant with primitive data types like integers.

            #endregion

            #region Use && and || operators

            object object1 = null;

            //if (object1 != null && object1.runMethod()) ;

            #endregion

            #region Try-Catch
            //Only use the try catch if you must; using if is better to check for null references

            #endregion

            #region Remove extra View Engines
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            #endregion

            #region HTTP compression and Static Cache

            //  < system.webServer >
            //      < urlCompression doDynamicCompression = "true" doStaticCompression = "true" dynamicCompressionBeforeCache = "true" />
            //  </ system.webServer >
            #endregion

            #region Other Checks

            //-profiler to discover memory leaks and performance problems
            //-Run your site in Release mode, not Debug mode, when in production
            //-Cache frequently used data (Data that hardly changes)
            //-Use Asynchronous Controllers to implement actions that depend on external resources processing.
            //-Optimize your client side, use a tool like YSlow for suggestions to improve performance
            //-Use AJAX to update components of your UI, avoid a whole page update when possible
            //-Move charting and graph generation logic to the client side if possible
            //-Use CDN's for scripts and media content to improve loading on the client side
            //-Minify -Compile- your JavaScript in order to improve your script size, Reduces the number of requests to the server-Bundling and Minification
            //-Keep cookie size small, since cookies are sent to the server on every request.
            //-Code review --Refactor and remove whatever you can do without. This can really lighten the load for your code. 
            //-Disposing objects (using statements )
            //-Using ‘foreach’ instead of ‘for’ for anything else than collections
            //-Retrieving or saving data to DB in more than 1 call
            //-Optimize Your Images


            #endregion


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





    }
}