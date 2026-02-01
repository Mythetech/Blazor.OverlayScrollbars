namespace Blazor.OverlayScrollbars;

/// <summary>
/// Default configurations for OverlayScrollbars.
/// </summary>
public static class OverlayScrollbarDefaults
{
    /// <summary>
    /// Configuration for always-visible scrollbars.
    /// </summary>
    public static OverlayScrollbarOptions AlwaysVisible => new()
    {
        Scrollbars = new ScrollbarOptions
        {
            Theme = "os-theme-dark",
            AutoHide = "never"
        }
    };

    /// <summary>
    /// Configuration for scrollbars that hide on scroll completion.
    /// </summary>
    public static OverlayScrollbarOptions HideOnScroll => new()
    {
        Scrollbars = new ScrollbarOptions
        {
            Theme = "os-theme-dark",
            AutoHide = "scroll",
            AutoHideDelay = 800
        }
    };

    /// <summary>
    /// Configuration for horizontal-only scrolling (e.g., tab bars).
    /// Uses auto-hide on mouse leave.
    /// </summary>
    public static OverlayScrollbarOptions HorizontalOnly => new()
    {
        ScrollBehavior = new ScrollBehaviorOptions
        {
            X = "scroll",
            Y = "hidden"
        },
        Scrollbars = new ScrollbarOptions
        {
            Theme = "os-theme-dark",
            AutoHide = "leave",
            AutoHideDelay = 400
        }
    };

    /// <summary>
    /// Configuration for vertical-only scrolling.
    /// Uses auto-hide on mouse leave.
    /// </summary>
    public static OverlayScrollbarOptions VerticalOnly => new()
    {
        ScrollBehavior = new ScrollBehaviorOptions
        {
            X = "hidden",
            Y = "scroll"
        },
        Scrollbars = new ScrollbarOptions
        {
            Theme = "os-theme-dark",
            AutoHide = "leave",
            AutoHideDelay = 400
        }
    };
}
