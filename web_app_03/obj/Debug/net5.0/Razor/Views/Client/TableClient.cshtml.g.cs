#pragma checksum "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "feb3432d4ccecb9fcdad72a78e5355a58fb8ca29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_TableClient), @"mvc.1.0.view", @"/Views/Client/TableClient.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\_ViewImports.cshtml"
using web_app_03;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
using web_app_03.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feb3432d4ccecb9fcdad72a78e5355a58fb8ca29", @"/Views/Client/TableClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f8add651bdef7f5a32d6f7d20c366f32a32b4f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_TableClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ClientModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
  
    ViewData["Title"] = "IndexClient";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>TableClient</h1>\r\n<div class=\"card col-md-12\">\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <td>PKey</td>\r\n            <td></td>\r\n            <td>Login</td>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 19 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td></td>\r\n                <td>");
#nullable restore
#line 24 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
               Write(item.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 26 "F:\files_zhilin\2.CODIDE\3.C#\VS2019\6.WEB_APP\web_app_06_i\web_app_03\Views\Client\TableClient.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ClientModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
