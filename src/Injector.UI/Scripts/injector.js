(function (window, document, injectorId) {

    var settings = {
        scriptPath: 'scripts/injector.js',
        apiPath: 'api/injectionForUrl',
    };

    var getScriptUrl = function (scriptPath) {
        var scripts = document.getElementsByTagName('script');

        for (var i = scripts.length - 1; i >= 0; --i) {
            var src = scripts[i].src;
            if (src.indexOf(scriptPath, src.length - scriptPath.length) !== -1) {
                return src;
            }
        }
        return '';
    };

    var getApiUrl = function () {
        return getScriptUrl(settings.scriptPath).replace(settings.scriptPath, settings.apiPath) + '?injectorId=' + injectorId + '&url=' + escape(document.location.href);
    };

    function parse(text) {
        if (JSON) {
            return JSON.parse(text);
        } else {
            return eval('[' + text + '][0]');
        }
    };

    function get(url, success) {

        var invocation;

        if (window.XDomainRequest) {
            invocation = new window.XDomainRequest();
            invocation.onload = function () {
                var text = invocation.responseText;
                var data = parse(text);

                success(data);
            };
        } else {
            if (window.XMLHttpRequest) {
                invocation = new window.XMLHttpRequest();
            } else {
                invocation = new ActiveXObject("Microsoft.XMLHTTP");
            }

            invocation.onreadystatechange = function () {
                if (invocation.readyState == 4 && invocation.status == 200) {
                    var text = invocation.responseText;
                    var data = parse(text);
                    
                    success(data);
                }
            };
        };

        invocation.open("GET", url, true);
        invocation.send();
    }

    function load() {
        get(getApiUrl(), function (data) {
            for (var i = 0; i < data.length; i++) {
                var injection = data[i];

                var elements = document.querySelectorAll(injection.querySelector);

                for (var j = 0; j < elements.length; j++)
                {
                    elements[j].innerHTML = injection.html;
                }
            }
        });
    }

    if (window.addEventListener) {
        // W3C standard
        window.addEventListener('load', load, false);
    } else if (window.attachEvent) {
        // Microsoft
        window.attachEvent('onload', load);
    }

})(window, document, injectorId = injectorId);