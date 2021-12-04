#pragma checksum "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f2f4dc6fce7e5ef7f272b062f30e9b5a1eea990"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Dashboard/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f2f4dc6fce7e5ef7f272b062f30e9b5a1eea990", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"263f5f7032912694fc818ebb6bd514c8d5a64492", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(95, 812, true);
            WriteLiteral(@"
<script src=""https://code.highcharts.com/highcharts.js""></script>
<script src=""https://code.highcharts.com/modules/data.js""></script>
<script src=""https://code.highcharts.com/modules/drilldown.js""></script>

<style>
    .highcharts-root {
      font-family: Vazir_Medium !important;
}
    .highcharts-credits {
      display: none !important;
}
</style>

<div id=""modal-placeholder""></div>
<nav class=""navbar navbar-top navbar-expand-md navbar-dark"" id=""navbar-main"">
    <div class=""container-fluid"">
        <!-- Brand -->
        <ul class=""nav nav-sitemap justify-content-center justify-content-xl-end"">
            <li>
                <a class=""h4 mb-0 text-white d-lg-inline-block"" href=""./index.html""> داشبورد </a>
            </li>
        </ul>

        <!-- User -->
        ");
            EndContext();
            BeginContext(908, 38, false);
#line 31 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
   Write(await Html.PartialAsync("_AdminLogin"));

#line default
#line hidden
            EndContext();
            BeginContext(946, 642, true);
            WriteLiteral(@"
    </div>
</nav>
<!-- Header -->
<div class=""header bg-gradient-primary pb-6 pt-5 pt-md-8"">
</div>

<div class=""container-fluid mt--7"">
    <div class=""header-body"">
        <!-- Card stats -->
        <div class=""row"">
            <div class=""col-xl-3 col-lg-6"">
                <div class=""card card-stats mb-4 mb-xl-0"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col"">
                                <h5 class=""card-title text-uppercase text-muted mb-0"">کل اخبار</h5>
                                <span class=""h2 mb-0 font_Vazir_FD"">");
            EndContext();
            BeginContext(1589, 12, false);
#line 48 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                               Write(ViewBag.News);

#line default
#line hidden
            EndContext();
            BeginContext(1601, 870, true);
            WriteLiteral(@"</span>
                            </div>
                            <div class=""col-auto"">
                                <div class=""icon icon-shape bg-success text-white rounded-circle shadow"">
                                    <i class=""fas fa-newspaper""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-lg-6"">
                <div class=""card card-stats mb-4 mb-xl-0"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col"">
                                <h5 class=""card-title text-uppercase text-muted mb-0"">اخبار منتشر شده</h5>
                                <span class=""h2 mb-0 font_Vazir_FD"">");
            EndContext();
            BeginContext(2472, 21, false);
#line 65 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                               Write(ViewBag.NewsPublished);

#line default
#line hidden
            EndContext();
            BeginContext(2493, 865, true);
            WriteLiteral(@"</span>
                            </div>
                            <div class=""col-auto"">
                                <div class=""icon icon-shape bg-warning text-white rounded-circle shadow"">
                                    <i class=""fas fa-check""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-lg-6"">
                <div class=""card card-stats mb-4 mb-xl-0"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col"">
                                <h5 class=""card-title text-uppercase text-muted mb-0"">اخبار پیش نویس</h5>
                                <span class=""h2 mb-0 font_Vazir_FD"">");
            EndContext();
            BeginContext(3359, 17, false);
#line 82 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                               Write(ViewBag.DraftNews);

#line default
#line hidden
            EndContext();
            BeginContext(3376, 873, true);
            WriteLiteral(@"</span>
                            </div>
                            <div class=""col-auto"">
                                <div class=""icon icon-shape bg-yellow text-white rounded-circle shadow"">
                                    <i class=""fas fa-edit""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-lg-6"">
                <div class=""card card-stats mb-4 mb-xl-0"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col"">
                                <h5 class=""card-title text-uppercase text-muted mb-0"">اخبار منتشر شده در آینده</h5>
                                <span class=""h2 mb-0 font_Vazir_FD"">");
            EndContext();
            BeginContext(4250, 27, false);
#line 99 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                               Write(ViewBag.FuturePublishedNews);

#line default
#line hidden
            EndContext();
            BeginContext(4277, 1849, true);
            WriteLiteral(@"</span>
                            </div>
                            <div class=""col-auto"">
                                <div class=""icon icon-shape bg-info text-white rounded-circle shadow"">
                                    <i class=""fas fa-paper-plane""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""row mt-5"">
        <div class=""card shadow w-100"">
            <div class=""card-header font_Vazir_Medium"">
                بازدیدهای اخبار منتشر شده در هر ماه
            </div>
            <div class=""card-body"">
                <div id=""container"" style=""min-width: 310px; height: 400px; margin: 0 auto""></div>
            </div>
        </div>
    </div>
</div>


<div id=""container"" style=""min-width: 310px; height: 400px; margin: 0 auto""></div>


<script>
    // Create the chart
Highcharts.chart('cont");
            WriteLiteral(@"ainer', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'نمودار بازدیدهای اخبار منتشر شده در هر ماه'
    },
    xAxis: {
        type: 'category'
    },
    yAxis: {
        title: {
            text: 'تعداد بازدید'
        }

    },
    legend: {
        enabled: false
    },
    plotOptions: {
        series: {
            borderWidth: 0,
            dataLabels: {
                enabled: true,
                format: '{point.y}'
            }
        }
    },

    tooltip: {
        headerFormat: '<span style=""font-size:12px"">{series.name}</span><br>',
        pointFormat: '<span style=""color:{point.color}"">{point.name}</span>: <b>{point.y}'
    },

    series: [
        {
            name: ""ماه ها"",
            colorByPoint: true,
            data: ");
            EndContext();
            BeginContext(6127, 52, false);
#line 169 "E:\ASP.NET Core Training\NewsWebsite - Copy\NewsWebsite\Areas\Admin\Views\Dashboard\Index.cshtml"
             Write(Html.Raw(Json.Serialize(ViewBag.NumberOfVisitChart)));

#line default
#line hidden
            EndContext();
            BeginContext(6179, 36, true);
            WriteLiteral(",\r\n        }\r\n    ],\r\n});\r\n</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
