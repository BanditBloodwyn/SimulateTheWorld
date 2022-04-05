using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using SimulateTheWorld.Graphics.Data;
using SimulateTheWorld.Graphics.Rendering.Utilities;
using SimulateTheWorld.Graphics.Shapes;

namespace SimulateTheWorld.Graphics.Rendering.Rendering;

public class OpenGLRenderer
{
    private readonly STWShape[] _shapes = ShapeHandler.CreateShapes();

    private Shader? _shader;
    private int _vertexBufferObject;
    
    public CircularCamera Camera { get; }

    public OpenGLRenderer()
    {
        Camera = new CircularCamera(Vector3.UnitZ * 10);
    }

    public void OnLoaded()
    {
        GL.ClearColor(new Color4(0, 0, 70, 0));

        OpenGLPreparer.PrepareOpenGL(_shapes, out _vertexBufferObject, out _shader);
    }

    public void OnRender()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        TestRendering();
    }

    private void TestRendering()
    {
        foreach (STWShape shape in _shapes)
        {
            foreach (var texture in shape.Material.Textures)
            {
                texture.Key.Use(texture.Value);
            }

            Matrix4 model = ApplyModelTransforms(shape);
            
            if (_shader == null)
                return;

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", Camera.GetViewMatrix());
            _shader.SetMatrix4("projection", Camera.GetProjectionMatrix());
            _shader.Use();

            if (shape.Indices == null)
                return;

            GL.DrawElements(PrimitiveType.Triangles, shape.Indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);
        }
    }

    private static Matrix4 ApplyModelTransforms(STWShape shape)
    {
        Matrix4 model = Matrix4.Identity;
        model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(shape.Transform.AngleX));
        model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(shape.Transform.AngleY));
        model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(shape.Transform.AngleZ));
        model *= Matrix4.CreateTranslation(shape.Transform.PositionX, shape.Transform.PositionY, shape.Transform.PositionZ);

        return model;
    }

    public void OnUnLoaded()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_vertexBufferObject);

        _shader?.Dispose();
    }

    public void UpdateViewPort(double width, double height)
    {
        Camera.AspectRatio = (float)(width / height);
        GL.Viewport(0, 0, (int)width, (int)height);
    }
}