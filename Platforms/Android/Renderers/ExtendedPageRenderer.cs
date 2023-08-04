using System;
using Android.Content;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace MigratedPageRendererExample.Renderers
{
    /// <summary>
    /// No longer using this. See ExtendedPageContentViewGroup
    /// </summary>
    public class ExtendedPageRenderer : PageHandler
    {
        class MyContentViewGroup : ContentViewGroup
        {
            //private readonly Page page;
            public MyContentViewGroup(Context context) : base(context)
            {
                //page = context.
            }

            protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
            {
                base.OnLayout(changed, left, top, right, bottom);

                System.Diagnostics.Debug.WriteLine($"ExtendedPageRenderer.OnLayout() called!");
            }
        }

        protected override ContentViewGroup CreatePlatformView()
        {
            PageHandler.PlatformViewFactory = (handler) =>
            {
                var vc = new MyContentViewGroup(handler.Context);
                return vc;
            };

            throw new InvalidOperationException($"MyContentViewGroup must be a {nameof(ContentViewGroup)}");
        }
    }
}

