using System.Text.Json;
using Bunit;
using Shouldly;

namespace Blazor.OverlayScrollbars.Test;

public class OverlayScrollbarTests : TestContext
{
    private const string InteropModule = "./_content/Mythetech.BlazorOverlayScrollbars/js/overlay-scrollbars-interop.js";

    private readonly BunitJSModuleInterop _module;

    public OverlayScrollbarTests()
    {
        _module = JSInterop.SetupModule(InteropModule);
        _module.Setup<bool>("initialize", _ => true).SetResult(true);
    }

    [Fact]
    public void ChildContent_RendersInsideTheViewportTheComponentOwns()
    {
        var cut = RenderComponent<OverlayScrollbar>(p => p
            .AddChildContent("<span class=\"item\">Item</span>"));

        cut.Find(".overlay-scrollbar > .overlay-scrollbar-viewport > .item").TextContent.ShouldBe("Item");
    }

    [Fact]
    public void Initialize_LeavesOutOptionsThatAreNotSet()
    {
        RenderComponent<OverlayScrollbar>(p => p
            .Add(x => x.Options, new OverlayScrollbarOptions
            {
                Scrollbars = new ScrollbarOptions { AutoHide = "leave" }
            }));

        SentOptions().ShouldBe("""{"scrollbars":{"autoHide":"leave"}}""");
    }

    [Fact]
    public void Initialize_SendsEveryOptionThatIsSet()
    {
        RenderComponent<OverlayScrollbar>(p => p
            .Add(x => x.Options, new OverlayScrollbarOptions
            {
                ScrollBehavior = new ScrollBehaviorOptions { X = "scroll", Y = "hidden" },
                Scrollbars = new ScrollbarOptions
                {
                    Theme = "os-theme-dark",
                    Visibility = "auto",
                    AutoHide = "leave",
                    AutoHideDelay = 400,
                    AutoHideSuspend = false,
                    DragScroll = true,
                    ClickScroll = false,
                    Pointers = ["mouse"]
                }
            }));

        SentOptions().ShouldBe(
            """{"overflow":{"x":"scroll","y":"hidden"},"scrollbars":{"theme":"os-theme-dark","visibility":"auto","autoHide":"leave","autoHideDelay":400,"autoHideSuspend":false,"dragScroll":true,"clickScroll":false,"pointers":["mouse"]}}""");
    }

    [Fact]
    public void Initialize_SendsNoOptionsWithoutAny()
    {
        RenderComponent<OverlayScrollbar>();

        SentOptions().ShouldBe("{}");
    }

    private string SentOptions()
    {
        var invocation = _module.Invocations["initialize"].ShouldHaveSingleItem();
        return JsonSerializer.Serialize(invocation.Arguments[1], new JsonSerializerOptions(JsonSerializerDefaults.Web));
    }
}
