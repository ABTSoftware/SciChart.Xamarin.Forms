using System;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [InjectAndroidContext]
    [AbstractClassDefinition]
    [ClassDeclaration("AnnotationBase", typeof(View))]
    [XamarinFormsWrapperDefinition("AnnotationBase")]
    public interface IAnnotation : INativeSciChartObjectWrapper
    {        
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration(nativeProperty: "X1Value")]
        IComparable X1 { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration(nativeProperty: "X2Value")]
        IComparable X2 { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration(nativeProperty: "Y1Value")]
        IComparable Y1 { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration(nativeProperty: "Y2Value")]
        IComparable Y2 { get; set; }

        [BindablePropertyDefinition()]
        string XAxisId { get; set; }

        [BindablePropertyDefinition()]
        string YAxisId { get; set; }

        [BindablePropertyDefinition()]
        bool IsEditable { get; set; }

        [BindablePropertyDefinition()]
        bool IsHidden { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("Direction2D")]
        Direction2D DragDirections { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("Direction2D")]
        Direction2D ResizeDirections { get; set; }

        [BindablePropertyDefinition()]
        int ZIndex { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("AnnotationSurface")]
        AnnotationSurface AnnotationSurface { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("AnnotationCoordinateMode")]
        AnnotationCoordinateMode CoordinateMode { get; set; }

        [MethodDeclaration]
        void Show();

        [MethodDeclaration]
        void Hide();

        [MethodDeclaration]
        void MoveBasePointTo(float xCoord, float yCoord, int index);

        [MethodDeclaration]
        void MoveAnnotation(float horizontalOffset, float verticalOffset);
    }
}