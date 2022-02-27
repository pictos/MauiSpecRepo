namespace MauiSpecRepo;
public class ImageTintColor : Image
{
    public static readonly BindableProperty TintColorProperty =
        BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintColorBehavior), propertyChanged: OnTintColorChanged);

    public Color? TintColor
    {
        get => (Color?)GetValue(TintColorProperty);
        set => SetValue(TintColorProperty, value);
    }

    static void OnTintColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ImageTintColor)bindable;
        var tintColor = control.TintColor;

        if (control.Handler is null || control.Handler.NativeView is null)
        {
            // Hack: When this executes the Handler and NativeView is null
            control.HandlerChanged += (_, __) =>
            {
                OnTintColorChanged(control, oldValue, newValue);
            };
            return;
        }

        if (tintColor is not null)
        {
#if ANDROID
            ImageEx.ApplyColor((Android.Widget.ImageView)control.Handler.NativeView, tintColor);
#elif IOS
            ImageEx.ApplyColor((UIKit.UIImageView)control.Handler.NativeView, tintColor);
#endif
        }
        else
        {
#if ANDROID
            ImageEx.ClearColor((Android.Widget.ImageView)control.Handler.NativeView);
#elif IOS
            ImageEx.ClearColor((UIKit.UIImageView)control.Handler.NativeView);
#endif
        }
    }
}
