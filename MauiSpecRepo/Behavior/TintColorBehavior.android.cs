using Android.Graphics;
using Android.Widget;
using Microsoft.Maui.Platform;
using Color = Microsoft.Maui.Graphics.Color;

namespace MauiSpecRepo;
partial class TintColorBehavior : BasePlatformBehavior<Image, ImageView>
{
    protected override void OnPlatformAttachedBehavior(Image view)
    {
        if (NativeView is null) return;
        if (TintColor is null)
            ImageEx.ClearColor(NativeView);
        else
            ImageEx.ApplyColor(NativeView, TintColor);
    }

    protected override void OnPlatformDeattachedBehavior(Image view)
    {
        if (NativeView is null)
            return;

        ImageEx.ClearColor(NativeView);
    }
}


static class ImageEx
{
    public static void ApplyColor(ImageView imageView, Color color)
    {
        imageView.SetColorFilter(new PorterDuffColorFilter(color.ToNative(), PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
    }

    public static void ClearColor(ImageView imageView)
    {
        imageView.ClearColorFilter();
    }
}