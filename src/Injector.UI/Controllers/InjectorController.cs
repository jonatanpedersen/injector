using System;
using System.Web.Mvc;

namespace Injector.UI.Controllers
{
    public class InjectorController : Controller
    {
        public ActionResult Manage(string id)
        {
            return View((object)id);
        }

        public JavaScriptResult Install(string id)
        {
            var url = string.Format("//{0}{1}", Request.Url.Host, Url.Content("~/scripts/injector.js"));

            var script = string.Format(
                "// ==UserScript=={0}" +
                "// @name          Injector ({1}) {0}" +
                "// @include     *://*/*{0}" +
                "// @grant       none{0}" +
                "// ==/UserScript=={0}" +
                "(function() {{{0}" +
                "var script1 = document.createElement('script');{0}" +
                "script1.innerHTML = \"var injectorId = '{1}'\";{0}" +
                "var script2 = document.createElement('script');{0}" +
                "    script2.src = \"{2}\"{0}" +
                "document.body.appendChild(script1);{0}" +
                "document.body.appendChild(script2);{0}" +
                "}})();{0}", Environment.NewLine, id, url);

            return JavaScript(script);
        }
    }
}
