// Blazor interop for OverlayScrollbars
// The library exposes OverlayScrollbarsGlobal.OverlayScrollbars when loaded via script tag

// Stores instances by element ID for later destruction
const instances = new Map();

function getOverlayScrollbars() {
    // Check for the global from the browser bundle
    if (typeof OverlayScrollbarsGlobal !== 'undefined' && OverlayScrollbarsGlobal.OverlayScrollbars) {
        return OverlayScrollbarsGlobal.OverlayScrollbars;
    }
    // Fallback to direct global (in case of different bundle)
    if (typeof OverlayScrollbars !== 'undefined') {
        return OverlayScrollbars;
    }
    return null;
}

export function initialize(elementId, options) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.warn(`OverlayScrollbars: Element with id '${elementId}' not found`);
        return false;
    }

    const OS = getOverlayScrollbars();
    if (!OS) {
        console.error('OverlayScrollbars: Library not loaded. Make sure overlayscrollbars.min.js is included before this script.');
        return false;
    }

    // Destroy existing instance if any
    if (instances.has(elementId)) {
        instances.get(elementId).destroy();
        instances.delete(elementId);
    }

    // The component renders its own viewport so OverlayScrollbars never moves the nodes Blazor manages.
    const viewport = element.querySelector(':scope > .overlay-scrollbar-viewport');
    const target = viewport ? { target: element, elements: { viewport } } : element;

    try {
        const instance = OS(target, options || {});
        instances.set(elementId, instance);
        return true;
    } catch (error) {
        console.error(`OverlayScrollbars: Failed to initialize on '${elementId}'`, error);
        return false;
    }
}

export function destroy(elementId) {
    if (instances.has(elementId)) {
        try {
            instances.get(elementId).destroy();
            instances.delete(elementId);
            return true;
        } catch (error) {
            console.error(`OverlayScrollbars: Failed to destroy '${elementId}'`, error);
            return false;
        }
    }
    return false;
}

export function destroyAll() {
    for (const [id, instance] of instances) {
        try {
            instance.destroy();
        } catch (error) {
            console.error(`OverlayScrollbars: Failed to destroy '${id}'`, error);
        }
    }
    instances.clear();
}
