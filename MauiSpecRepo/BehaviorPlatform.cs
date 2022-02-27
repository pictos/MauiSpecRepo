#if __IOS__
using NativeView = UIKit.UIView;
#elif __MACOS__
using NativeView = AppKit.NSView;
#elif ANDROID
using NativeView = Android.Views.View;
#elif WINDOWS
using NativeView = Microsoft.UI.Xaml.FrameworkElement;
#endif

namespace MauiSpecRepo;
/// <summary>
/// 
/// </summary>
public abstract partial class BasePlatformBehavior<TView, TNativeView> : Behavior<TView>
    where TView : VisualElement
#if !NET6_0 || IOS || ANDROID || WINDOWS
        where TNativeView : NativeView
#else
		where TNativeView : class
#endif
{
    /// <summary>
    /// 
    /// </summary>
    protected TNativeView? NativeView => View?.Handler?.NativeView as TNativeView;
    protected TView? View { get; private set; }

    /// <inheritdoc />
    protected override void OnAttachedTo(BindableObject bindable)
    {
        base.OnAttachedTo(bindable);
    }

    /// <inheritdoc />
    protected override void OnDetachingFrom(BindableObject bindable)
    {
        base.OnDetachingFrom(bindable);
    }

    /// <inheritdoc />
    protected override async void OnAttachedTo(TView bindable)
    {
        base.OnAttachedTo(bindable);
        View = bindable;
        //hack for MAUI bug
        View.HandlerChanged += View_HandlerChanged;
        await System.Threading.Tasks.Task.Delay(5000);
    }

    private void View_HandlerChanged(object? sender, EventArgs e)
    {
        if (View?.Handler is null)
            return;

        OnPlatformAttachedBehavior(View);
    }

    /// <inheritdoc />
    protected override void OnDetachingFrom(TView bindable)
    {
        base.OnDetachingFrom(bindable);
        OnPlatformDeattachedBehavior(bindable);
        if (View is not null)
            View.HandlerChanged -= View_HandlerChanged;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="view"></param>
    protected abstract void OnPlatformAttachedBehavior(TView view);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="view"></param>
    protected abstract void OnPlatformDeattachedBehavior(TView view);
}