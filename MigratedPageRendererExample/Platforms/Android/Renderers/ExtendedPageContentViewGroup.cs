using System;
using Android.Content;
using Microsoft.Maui.Platform;

namespace MigratedPageRendererExample.Renderers
{
	public class ExtendedPageContentViewGroup : ContentViewGroup
	{
        public ExtendedPageContentViewGroup(Context context) : base(context)
        {
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);

            System.Diagnostics.Debug.WriteLine($"ExtendedPageRenderer.OnLayout() called!");
        }
    }
}

