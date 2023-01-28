namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module TabItem =
    open Avalonia.Controls
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder

    let create (attrs: Attr<TabItem> list): View<TabItem> =
        ViewBuilder.Create<TabItem>(attrs)

    type TabItem with

        static member tabStripPlacement<'t when 't :> TabItem>(placement: Dock) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<Dock>(TabItem.TabStripPlacementProperty, placement, ValueNone)

        static member isSelected<'t when 't :> TabItem>(value: bool) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(TabItem.IsSelectedProperty, value, ValueNone)

        static member onIsSelectedChanged<'t when 't :> TabItem>(func: bool -> unit, ?subPatchOptions) =
            AttrBuilder<'t>.CreateSubscription<bool>(TabItem.IsSelectedProperty, func, ?subPatchOptions = subPatchOptions)