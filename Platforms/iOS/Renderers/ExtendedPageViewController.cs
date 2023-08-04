using System;
using Microsoft.Maui.Platform;

namespace MigratedPageRendererExample.Renderers
{
	public class ExtendedPageViewController : PageViewController
    {
        public ExtendedPageViewController(IView page, IMauiContext mauiContext) : base(page, mauiContext)
        {
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
}

