using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace project4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [HttpGet]
        public ActionResult ColorChooser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ColorChooser(string priColor, string secColor)
        {
            if (priColor != null  && secColor != null && priColor != "" && secColor != "")
            {
                Color leftColor = ColorTranslator.FromHtml(priColor);
                Color rightColor = ColorTranslator.FromHtml(secColor);

                // initializing combo values
                int aCombo = leftColor.A + rightColor.A;
                int rCombo = leftColor.R + rightColor.R;
                int gCombo = leftColor.G + rightColor.G;
                int bCombo = leftColor.B + rightColor.B;

                // Do checking for Alpha overflow
                if (aCombo > 1)
                    aCombo = 1;

                // Do checking for Red overflow
                if (rCombo > 255)
                    rCombo = 255;

                // Do checking for Green overflow
                if (gCombo > 255)
                    gCombo = 255;

                // Do checking for Blue overflow
                if (bCombo > 255)
                    bCombo = 255;

                Color mixedColor = Color.FromArgb(aCombo, rCombo, gCombo, bCombo);

                // Assign values for viewbag for use in html
                ViewBag.colorLeft = "width: 100px; height: 100px; border: 1px solid; background: " + ColorTranslator.ToHtml(leftColor) + "; ";
                ViewBag.colorRight = "width: 100px; height: 100px; border: 1px solid; background: " + ColorTranslator.ToHtml(rightColor) + "; ";
                ViewBag.colorMixed = "width: 100px; height: 100px; border: 1px solid; background: " + ColorTranslator.ToHtml(mixedColor) + "; ";
                ViewBag.plus = "+";
                ViewBag.equal = "=";
            }


            return View();
        }
    }
}