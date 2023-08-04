using System;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace MigratedPageRendererExample.Renderers
{
    /// <summary>
    /// This is not longer used. See ExtendedPageViewController
    /// </summary>
    //public class ExtendedPageRenderer : PageRenderer // XF version
    public class ExtendedPageRenderer : PageHandler
    {
        class MyPageViewController : PageViewController
        {
            private readonly Page page;
            public MyPageViewController(IView page, IMauiContext mauiContext) : base(page, mauiContext)
            {
                page = this.page;
            }

            public override void ViewWillAppear(bool animated)
            {
                base.ViewWillAppear(animated);

                System.Diagnostics.Debug.WriteLine($"ExtendedPageRenderer.ViewWillAppear() called!");
            }

            public override void ViewDidAppear(bool animated)
            {
                base.ViewDidAppear(animated);

                System.Diagnostics.Debug.WriteLine($"ExtendedPageRenderer.ViewDidAppear() called!");
            }
        }

        protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
        {
            _ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
            _ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

            if (ViewController == null)
                ViewController = new MyPageViewController(VirtualView, MauiContext);

            if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
                return pv;

            if (ViewController.View is Microsoft.Maui.Platform.ContentView cv) // fall back to MAUI ContentView
                return cv;

            throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");

            //PageHandler.PlatformViewFactory = (handler) =>
            //{
            //    var vc = new MyPageViewController(handler.VirtualView, handler.MauiContext);
            //    handler.ViewController = vc;
            //    return (Microsoft.Maui.Platform.ContentView)vc.View;
            //};

            //throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");

            //return ViewController.View as Microsoft.Maui.Platform.ContentView;
        }
    }
}

