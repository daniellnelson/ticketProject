#pragma checksum "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12e780d3fe571b8b8757042e1da44792113cf43e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_tickets_userClosedTickets), @"mvc.1.0.view", @"/Views/tickets/userClosedTickets.cshtml")]
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
#line 1 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\_ViewImports.cshtml"
using ticketsDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\_ViewImports.cshtml"
using ticketsDemo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12e780d3fe571b8b8757042e1da44792113cf43e", @"/Views/tickets/userClosedTickets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c36ee31e86a41e8f2292e2113d63dd527b5e1e04", @"/Views/_ViewImports.cshtml")]
    public class Views_tickets_userClosedTickets : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ticketsDemo.Models.tickets>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "userView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
  
    ViewData["Title"] = "Closed Tickets";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Closed Tickets</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12e780d3fe571b8b8757042e1da44792113cf43e3770", async() => {
                WriteLiteral("Back to Open List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            <th>
                Submission Date
            </th>
            <th>
               Closed On
            </th>
            <th>
                Severity
            </th>
            <th>
                Priority
            </th>
            <th>
               Assignee
            </th>
            <th>
                Submitter
            </th>
            <th>
               Description
            </th>
            <th>
               Status
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 47 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
             if (item.status.id == 3)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SubmittedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ClosedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.severity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.assignee.fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.submitter.fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 77 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
                   Write(Html.DisplayFor(modelItem => item.status.statusName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 80 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\dnelson\source\repos\ticketsDemo\ticketsDemo\Views\tickets\userClosedTickets.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ticketsDemo.Models.tickets>> Html { get; private set; }
    }
}
#pragma warning restore 1591
