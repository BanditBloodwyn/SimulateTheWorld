using System;
using System.Windows;
using System.Windows.Input;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;
using MouseWheelEventArgs = System.Windows.Input.MouseWheelEventArgs;

namespace SimulateTheWorld.Graphics.Rendering.Control;

/// <summary>
/// Interaktionslogik für RenderingControl.xaml
/// </summary>
public sealed partial class RenderingControl
{
    private readonly RenderingControlViewModel _viewModel;

    public RenderingControl()
    {
        InitializeComponent();

        _viewModel = DataContext as RenderingControlViewModel 
                     ?? new RenderingControlViewModel();

        GLWpfControlSettings mainSettings = new GLWpfControlSettings
        {
            MajorVersion = 4, MinorVersion = 5, GraphicsProfile = ContextProfile.Core,
            GraphicsContextFlags = ContextFlags.Default, RenderContinuously = true
        };
        GlControl.Start(mainSettings);
    }

    public void Load()
    {
        _viewModel.OnLoad();
    }

    private void GlControl_OnRender(TimeSpan elapsedTimeSpan)
    {
        _viewModel.OnRender(elapsedTimeSpan, GlControl.ActualWidth, GlControl.ActualHeight);
    }

    private void GlControl_OnUnloaded(object sender, RoutedEventArgs e)
    {
        _viewModel.OnUnload();
    }

    private void GlControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        _viewModel.OnSizeChanged(GlControl.ActualWidth, GlControl.ActualHeight);
    }

    private void GlControl_OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        RenderingControlViewModel.OnMouseWheel(e.Delta);
    }

    private void GlControl_OnMouseMove(object sender, MouseEventArgs e)
    {
        _viewModel.OnMouseMove(e, this);
    }

    private void GlControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        _viewModel.OnMouseUp(e, PointToScreen(Mouse.GetPosition(this)));
    }
}