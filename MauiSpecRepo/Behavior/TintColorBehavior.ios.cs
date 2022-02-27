using Microsoft.Maui.Platform;
using UIKit;

namespace MauiSpecRepo;
internal partial class TintColorBehavior : BasePlatformBehavior<Image, UIImageView>
{
    protected override void OnPlatformAttachedBehavior(Image view)
    {
        if (NativeView is null || NativeView.Image is null)
            return;

        ImageEx.ApplyColor(NativeView, TintColor);
    }

    protected override void OnPlatformDeattachedBehavior(Image view)
    {
        if (NativeView is null)
            return;
        ImageEx.ClearColor(NativeView);
    }
}


internal static class ImageEx
{

    public static void ApplyColor(UIImageView imageView, Color color)
    {
        imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
        imageView.TintColor = color.ToNative();
    }

    public static void ClearColor(UIImageView imageView)
    {
        imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
    }
}
