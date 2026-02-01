# Mythetech.BlazorOverlayScrollbars

A Blazor wrapper component for [OverlayScrollbars](https://kingsora.github.io/OverlayScrollbars/) - beautiful, customizable scrollbars for your Blazor applications.

## Features

- Simple Blazor component wrapper for OverlayScrollbars
- Includes MudBlazor theme integration (dark/light mode support)
- Configurable scrollbar behavior and appearance
- Preset configurations for common use cases
- Cross-platform support (Blazor Server, WebAssembly, and Desktop via Photino/Hermes)

## Installation

```bash
dotnet add package Mythetech.BlazorOverlayScrollbars
```

## Setup

1. Add the CSS references to your `index.html` or `_Host.cshtml`:

```html
<link href="_content/Mythetech.BlazorOverlayScrollbars/css/overlayscrollbars.min.css" rel="stylesheet" />
<!-- Optional: MudBlazor theme integration -->
<link href="_content/Mythetech.BlazorOverlayScrollbars/css/overlayscrollbars-mudblazor-theme.css" rel="stylesheet" />
```

2. Add the JavaScript reference (before `</body>`):

```html
<script src="_content/Mythetech.BlazorOverlayScrollbars/js/overlayscrollbars.min.js"></script>
```

## Usage

### Basic Usage

```razor
@using Blazor.OverlayScrollbars

<OverlayScrollbar Style="height: 300px;">
    <div>
        <!-- Your scrollable content here -->
    </div>
</OverlayScrollbar>
```

### With Preset Options

```razor
<OverlayScrollbar Options="@OverlayScrollbarDefaults.HideOnScroll">
    <!-- Content -->
</OverlayScrollbar>
```

### Available Presets

| Preset | Description |
|--------|-------------|
| `OverlayScrollbarDefaults.AlwaysVisible` | Scrollbars always visible |
| `OverlayScrollbarDefaults.HideOnScroll` | Hide after scrolling stops (800ms delay) |
| `OverlayScrollbarDefaults.HorizontalOnly` | Horizontal-only scrolling with auto-hide |
| `OverlayScrollbarDefaults.VerticalOnly` | Vertical-only scrolling with auto-hide |

### Custom Options

```razor
<OverlayScrollbar Options="@_customOptions">
    <!-- Content -->
</OverlayScrollbar>

@code {
    private OverlayScrollbarOptions _customOptions = new()
    {
        Scrollbars = new ScrollbarOptions
        {
            Theme = "os-theme-dark",
            AutoHide = "scroll",
            AutoHideDelay = 1000,
            ClickScroll = true
        },
        ScrollBehavior = new ScrollBehaviorOptions
        {
            X = "hidden",
            Y = "scroll"
        }
    };
}
```

## Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `ChildContent` | `RenderFragment` | The content to wrap with scrollbars |
| `Class` | `string` | Additional CSS classes |
| `Style` | `string` | Inline styles |
| `Options` | `OverlayScrollbarOptions` | Scrollbar configuration |

## MudBlazor Integration

The included `overlayscrollbars-mudblazor-theme.css` provides automatic theming using MudBlazor CSS variables. Scrollbars will automatically adapt to your MudBlazor theme's colors and respond to dark/light mode changes.

## License

MIT License - Copyright (c) 2026 Mythetech

OverlayScrollbars is licensed under the MIT License by KingSora.
