namespace Blazor.OverlayScrollbars;

/// <summary>
/// Options for configuring OverlayScrollbars behavior.
/// See https://kingsora.github.io/OverlayScrollbars/ for full documentation.
/// </summary>
public class OverlayScrollbarOptions
{
    /// <summary>
    /// Whether padding should be relative to the content or viewport.
    /// Default: "content"
    /// </summary>
    public string? PaddingAbsolute { get; set; }

    /// <summary>
    /// Whether to show the native scrollbars.
    /// Valid values: "scroll", "move", "leave", "never"
    /// Default: "never"
    /// </summary>
    public string? ShowNativeOverlaidScrollbars { get; set; }

    /// <summary>
    /// Scroll behavior configuration.
    /// </summary>
    public ScrollBehaviorOptions? ScrollBehavior { get; set; }

    /// <summary>
    /// Scrollbar configuration.
    /// </summary>
    public ScrollbarOptions? Scrollbars { get; set; }

    /// <summary>
    /// Converts to the options object for JS interop, holding only the options that are set.
    /// </summary>
    /// <remarks>
    /// OverlayScrollbars takes a null option as the value to use rather than as unset, so sending one replaces
    /// the library's default: a null visibility never shows the scrollbars, and a null dragScroll stops the
    /// handle from dragging. Leaving unset options out keeps those defaults.
    /// </remarks>
    internal object ToJsOptions()
    {
        var options = new Dictionary<string, object>();
        AddIfSet(options, "paddingAbsolute", PaddingAbsolute);
        AddIfSet(options, "showNativeOverlaidScrollbars", ShowNativeOverlaidScrollbars);

        if (ScrollBehavior != null)
        {
            var overflow = new Dictionary<string, object>();
            AddIfSet(overflow, "x", ScrollBehavior.X);
            AddIfSet(overflow, "y", ScrollBehavior.Y);
            options["overflow"] = overflow;
        }

        if (Scrollbars != null)
        {
            var scrollbars = new Dictionary<string, object>();
            AddIfSet(scrollbars, "theme", Scrollbars.Theme);
            AddIfSet(scrollbars, "visibility", Scrollbars.Visibility);
            AddIfSet(scrollbars, "autoHide", Scrollbars.AutoHide);
            AddIfSet(scrollbars, "autoHideDelay", Scrollbars.AutoHideDelay);
            AddIfSet(scrollbars, "autoHideSuspend", Scrollbars.AutoHideSuspend);
            AddIfSet(scrollbars, "dragScroll", Scrollbars.DragScroll);
            AddIfSet(scrollbars, "clickScroll", Scrollbars.ClickScroll);
            AddIfSet(scrollbars, "pointers", Scrollbars.Pointers);
            options["scrollbars"] = scrollbars;
        }

        return options;
    }

    private static void AddIfSet(Dictionary<string, object> target, string name, object? value)
    {
        if (value != null)
            target[name] = value;
    }
}

/// <summary>
/// Scroll behavior options.
/// </summary>
public class ScrollBehaviorOptions
{
    /// <summary>
    /// X-axis scroll behavior.
    /// Valid values: "scroll", "hidden", "visible", "visible-hidden"
    /// </summary>
    public string? X { get; set; }

    /// <summary>
    /// Y-axis scroll behavior.
    /// Valid values: "scroll", "hidden", "visible", "visible-hidden"
    /// </summary>
    public string? Y { get; set; }
}

/// <summary>
/// Scrollbar appearance and behavior options.
/// </summary>
public class ScrollbarOptions
{
    /// <summary>
    /// Theme class name. Default: "os-theme-dark"
    /// Use "os-theme-light" for light backgrounds.
    /// </summary>
    public string? Theme { get; set; }

    /// <summary>
    /// Scrollbar visibility.
    /// Valid values: "visible", "hidden", "auto"
    /// Default: "auto"
    /// </summary>
    public string? Visibility { get; set; }

    /// <summary>
    /// Auto-hide behavior.
    /// Valid values: "never", "scroll", "leave", "move"
    /// Default: "never"
    /// </summary>
    public string? AutoHide { get; set; }

    /// <summary>
    /// Delay in ms before auto-hide activates.
    /// Default: 1300
    /// </summary>
    public int? AutoHideDelay { get; set; }

    /// <summary>
    /// Whether auto-hide should be suspended on pointer enter.
    /// </summary>
    public bool? AutoHideSuspend { get; set; }

    /// <summary>
    /// Whether drag scrolling is enabled.
    /// Default: true
    /// </summary>
    public bool? DragScroll { get; set; }

    /// <summary>
    /// Whether click scrolling on the track is enabled.
    /// Default: false
    /// </summary>
    public bool? ClickScroll { get; set; }

    /// <summary>
    /// Pointer types that can interact with scrollbars.
    /// Default: ["mouse", "touch", "pen"]
    /// </summary>
    public string[]? Pointers { get; set; }
}
