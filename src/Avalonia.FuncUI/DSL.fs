namespace Avalonia.FuncUI.DSL
open System.Windows.Input
open Avalonia
open Avalonia.Controls
open Avalonia.FuncUI.Core.Domain
open Avalonia.FuncUI.Core.Domain
open Avalonia.Layout
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling

[<AutoOpen>]
module Extensions =
    open Avalonia.FuncUI
    open Avalonia.FuncUI
    
    open Avalonia    
    open Avalonia.Controls.Primitives
    open Avalonia.Controls.Templates
    open Avalonia.Animation
    open Avalonia.Layout
    open Avalonia.Input

    type Animatable with
        static member transitions<'t when 't :> Animatable>(transitions: Transitions) : IAttr<'t> =
            let accessor = Accessor.Avalonia Animatable.TransitionsProperty
            let property = Property.createDirect(accessor, transitions)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member clock<'t when 't :> Animatable>(clock: IClock) : IAttr<'t> =
            let accessor = Accessor.Avalonia Animatable.ClockProperty
            let property = Property.createDirect(accessor, clock)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
    type StyledElement with
        static member dataContext<'t when 't :> StyledElement>(dataContext: obj) : IAttr<'t> =
            let accessor = Accessor.Avalonia StyledElement.DataContextProperty
            let property = Property.createDirect(accessor, dataContext)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member name<'t when 't :> StyledElement>(name: string) : IAttr<'t> =
            let accessor = Accessor.Avalonia StyledElement.NameProperty
            let property = Property.createDirect(accessor, name)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member templatedParent<'t when 't :> StyledElement>(template: #ITemplatedControl) : IAttr<'t> =
            let accessor = Accessor.Avalonia StyledElement.TemplatedParentProperty
            let property = Property.createDirect(accessor, template)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
    type Visual with
        static member clipToBounds<'t when 't :> Visual>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.ClipToBoundsProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member clip<'t when 't :> Visual>(mask: Geometry) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.ClipProperty
            let property = Property.createDirect(accessor, mask)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member isVisible<'t when 't :> Visual>(visible: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.IsVisibleProperty
            let property = Property.createDirect(accessor, visible)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
    
        static member opacity<'t when 't :> Visual>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.OpacityProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
        static member opacityMask<'t when 't :> Visual>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.OpacityMaskProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member renderTransform<'t when 't :> Visual>(transform: Transform) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.RenderTransformProperty
            let property = Property.createDirect(accessor, transform)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
    
        static member renderTransformOrigin<'t when 't :> Visual>(origin: RelativePoint) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.RenderTransformProperty
            let property = Property.createDirect(accessor, origin)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member zIndex<'t when 't :> Visual>(index: int) : IAttr<'t> =
            let accessor = Accessor.Avalonia Visual.ZIndexProperty
            let property = Property.createDirect(accessor, index)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
    type Layoutable with
        static member width<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.WidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member height<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.HeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member minWidth<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MinWidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member minHeight<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MinHeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
        static member maxWidth<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MaxWidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member maxHeight<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MaxHeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member margin<'t when 't :> Layoutable>(margin: Thickness) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MarginProperty
            let property = Property.createDirect(accessor, margin)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
    
        static member horizontalAlignment<'t when 't :> Layoutable>(value: HorizontalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.HorizontalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
   
        static member verticalAlignment<'t when 't :> Layoutable>(value: VerticalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.VerticalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
           
        static member useLayoutRounding<'t when 't :> Layoutable>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.UseLayoutRoundingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
  
    type InputElement with
        static member focusable<'t when 't :> InputElement>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia InputElement.FocusableProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member isEnabled<'t when 't :> InputElement>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia InputElement.IsEnabledProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member cursor<'t when 't :> InputElement>(cursor: Cursor) : IAttr<'t> =
            let accessor = Accessor.Avalonia InputElement.CursorProperty
            let property = Property.createDirect(accessor, cursor)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
        static member isHitTestVisible<'t when 't :> InputElement>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia InputElement.IsHitTestVisibleProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
    type Control with
        static member focusAdorner<'t when 't :> Control>(value: #ITemplate<IControl>) : IAttr<'t> =
            let accessor = Accessor.Avalonia Control.FocusAdornerProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member tag<'t when 't :> Control>(value: obj) : IAttr<'t> =
            let accessor = Accessor.Avalonia Control.TagProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member contextMenu<'t when 't :> Control>(menu: ContextMenu) : IAttr<'t> =
            let accessor = Accessor.Avalonia Control.ContextMenuProperty
            let property = Property.createDirect(accessor, menu)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
    type TemplatedControl with
        static member background<'t when 't :> TemplatedControl>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.BackgroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member borderBrush<'t when 't :> TemplatedControl>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.BorderBrushProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member fontFamily<'t when 't :> TemplatedControl>(value: FontFamily) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.FontFamilyProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontSize<'t when 't :> TemplatedControl>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.FontSizeProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontWeight<'t when 't :> TemplatedControl>(value: FontWeight) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.FontWeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member foreground<'t when 't :> TemplatedControl>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.ForegroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member padding<'t when 't :> TemplatedControl>(value: Thickness) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.PaddingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member template<'t when 't :> TemplatedControl>(value: #IControlTemplate) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.TemplateProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>        
        
        static member isTemplateFocusTarget<'t when 't :> TemplatedControl>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia TemplatedControl.IsTemplateFocusTargetProperty
            let property = Property.createAttached(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

    type ContentControl with
        static member content<'t when 't :> ContentControl>(text: string) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.ContentProperty
            let property = Property.createDirect(accessor, text)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member content<'t when 't :> ContentControl>(value: IView) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.ContentProperty
            let content = Content.createSingle(accessor, Some value)
            let attr = Attr.createContent<'t> content
            attr :> IAttr<'t>
            
        static member content<'t when 't :> ContentControl>(value: IView option) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.ContentProperty
            let content = Content.createSingle(accessor, value)
            let attr = Attr.createContent<'t> content
            attr :> IAttr<'t>
            
        static member content<'t when 't :> ContentControl>(value: obj) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.BorderBrushProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member contentTemplate<'t when 't :> ContentControl>(value: #IDataTemplate) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.ContentTemplateProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

        static member horizontalAlignment<'t when 't :> ContentControl>(value: HorizontalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.HorizontalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member verticalAlignment<'t when 't :> ContentControl>(value: VerticalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia ContentControl.VerticalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

    type Panel with
            
        static member children<'t when 't :> Panel>(value: IView list) : IAttr<'t> =
            let accessor = Accessor.Instance "Children"
            let content = Content.createMultiple(accessor, value)
            let attr = Attr.createContent<'t> content
            attr :> IAttr<'t>
            
        static member children<'t when 't :> Panel>(value: obj) : IAttr<'t> =
            let accessor = Accessor.Instance "Children"
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member background<'t when 't :> Panel>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia Panel.BackgroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>    
    
    type Button with
       static member create (attrs: IAttr<Button> list): IView<Button> =
            View.create<Button>(attrs)

       static member clickMode<'t when 't :> Button>(value: ClickMode) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.ClickModeProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
       static member command<'t when 't :> Button>(value: ICommand) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.CommandProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
       static member hotKey<'t when 't :> Button>(value: KeyGesture) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.HotKeyProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
       static member commandParameter<'t when 't :> Button>(value: #obj) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.CommandParameterProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
       static member isDefault<'t when 't :> Button>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.IsDefaultProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
    type StackPanel with
        static member create (attrs: IAttr<StackPanel> list): IView<StackPanel> =
            View.create<StackPanel>(attrs)
            
        static member spacing<'t when 't :> StackPanel>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia StackPanel.SpacingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member orientation<'t when 't :> StackPanel>(orientation: Orientation) : IAttr<'t> =
            let accessor = Accessor.Avalonia StackPanel.OrientationProperty
            let property = Property.createDirect(accessor, orientation)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
               
    type DockPanel with
       static member create (attrs: IAttr<DockPanel> list): IView<DockPanel> =
            View.create<DockPanel>(attrs)
        
       static member lastChildFill<'t when 't :> DockPanel>(fill: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia DockPanel.LastChildFillProperty
            let property = Property.createDirect(accessor, fill)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
                 
       static member dock<'t when 't :> DockPanel>(dock: Dock) : IAttr<'t> =
            let accessor = Accessor.Avalonia DockPanel.DockProperty
            let property = Property.createAttached(accessor, dock)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
    
    type TextBlock with
        static member create (attrs: IAttr<TextBlock> list): IView<TextBlock> =
            View.create<TextBlock>(attrs)
            
        static member background<'t when 't :> TextBlock>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.BackgroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>    
        
        static member fontFamily<'t when 't :> TextBlock>(value: FontFamily) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.FontFamilyProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontSize<'t when 't :> TextBlock>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.FontSizeProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontStyle<'t when 't :> TextBlock>(value: FontStyle) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.FontStyleProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontWeight<'t when 't :> TextBlock>(value: FontWeight) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.FontWeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member foreground<'t when 't :> TextBlock>(value: #IBrush) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.ForegroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member textAlignment<'t when 't :> TextBlock>(alignment: TextAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.TextAlignmentProperty
            let property = Property.createDirect(accessor, alignment)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member textWrapping<'t when 't :> TextBlock>(value: TextWrapping) : IAttr<'t> =
            let accessor = Accessor.Avalonia TextBlock.TextWrappingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

            
module Playground =
     let view =
          StackPanel.create [
               StackPanel.orientation Orientation.Horizontal
               StackPanel.children [
                    Button.create [
                         Button.content "click me"
                    ]
               ]
          ]