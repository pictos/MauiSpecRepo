using Microsoft.Maui.Handlers;

namespace MauiSpecRepo;
public static class TintColorMapper
{

    public static readonly BindableProperty TintColorProperty =
    BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(Image), null);

    public static Color GetTintColor(BindableObject view)
            => (Color)view.GetValue(TintColorProperty);

    public static void SetTintColor(BindableObject view, Color? value)
        => view.SetValue(TintColorProperty, value);

    public static void ApplyTintColor()
    {
        ImageHandler.Mapper.Add("TintColor", (handler, view) =>
        {
            if (handler.VirtualView is null || handler.NativeView is null)
                return;

            var tintColor = GetTintColor((Image)handler.VirtualView);

            if (tintColor is not null)
            {
#if ANDROID
                ImageEx.ApplyColor((Android.Widget.ImageView)handler.NativeView, tintColor);
#elif IOS
                ImageEx.ApplyColor((UIKit.UIImageView)handler.NativeView, tintColor);
#endif
            }
            else
            {
#if ANDROID
                ImageEx.ClearColor((Android.Widget.ImageView)handler.NativeView);
#elif IOS
                ImageEx.ClearColor((UIKit.UIImageView)handler.NativeView);
#endif
            }
        });
    }

    public static void RemoveTintColor()
    {
        // How to remove a key from the mapper?
    }
}
