// ==UserScript== 
// @name          Edora Managed Module Injector
// @include     *://*/* 
// @grant       none
// ==/UserScript== 
(function() {  
    var script = document.createElement("script");
    script.src = "//modular.localhost/injector.js";

    document.body.appendChild(script);
})(); 