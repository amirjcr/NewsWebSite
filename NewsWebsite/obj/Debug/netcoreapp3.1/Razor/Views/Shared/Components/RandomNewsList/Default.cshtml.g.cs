#pragma checksum "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cdcadf34766d1be931186e1ada90ed2cca20de3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RandomNewsList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RandomNewsList/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cdcadf34766d1be931186e1ada90ed2cca20de3", @"/Views/Shared/Components/RandomNewsList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RandomNewsList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NewsWebsite.ViewModels.News.NewsViewModel>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-12 col-sm-6 col-xl-3\">\r\n    <div class=\"footer-widget mb-70\">\r\n        <h6 class=\"widget-title\"> اخبار تصادفی </h6>\r\n");
#nullable restore
#line 6 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"single-blog-post d-flex\">\r\n                <div class=\"post-thumbnail\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7cdcadf34766d1be931186e1ada90ed2cca20de33460", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 367, "~/newsImage/", 367, 12, true);
#nullable restore
#line 10 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 379, item.ImageName, 379, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
AddHtmlAttributeValue("", 401, item.ImageName, 401, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"post-content\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 510, "\"", 547, 4);
            WriteAttributeValue("", 517, "/News/", 517, 6, true);
#nullable restore
#line 13 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 523, item.NewsId, 523, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 535, "/", 535, 1, true);
#nullable restore
#line 13 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
WriteAttributeValue("", 536, item.Title, 536, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"post-title\">");
#nullable restore
#line 13 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
                                                                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 16 "C:\Users\AmirHosseinMoradi\Desktop\NewsWebsite\NewsWebsite\Views\Shared\Components\RandomNewsList\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NewsWebsite.ViewModels.News.NewsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
