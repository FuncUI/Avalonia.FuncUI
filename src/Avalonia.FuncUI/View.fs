namespace Avalonia.FuncUI.DSL

open Avalonia.FuncUI.Types

[<AbstractClass; Sealed>]
type View () =

    static member createWithKey (key: string) (createView: IAttr<'view> list -> IView<'view>) (attrs: IAttr<'view> list) =
        let view = createView(attrs)

        { View.ViewType = typeof<'view>
          View.ViewKey = ValueSome key
          View.Attrs = view.Attrs
          View.ConstructorArgs = view.ConstructorArgs
          View.Outlet = ValueNone }
        :> IView<'view>

    static member createWithOutlet (outlet: 'view -> unit) (createView: IAttr<'view> list -> IView<'view>) (attrs: IAttr<'view> list) =
        let view = createView(attrs)

        { View.ViewType = typeof<'view>
          View.ViewKey = ValueNone
          View.Attrs = view.Attrs
          View.ConstructorArgs = view.ConstructorArgs
          View.Outlet = ValueSome (fun control -> outlet (control :?> 'view)) }
        :> IView<'view>

    static member withKey (key: string) (view: IView<'view>) : IView<'view> =
        { View.ViewType = view.ViewType
          View.ViewKey = ValueSome key
          View.Attrs = view.Attrs
          View.ConstructorArgs = view.ConstructorArgs
          View.Outlet = view.Outlet }

    static member withOutlet (outlet: 'view -> unit) (view: IView<'view>) : IView<'view> =
        { View.ViewType = view.ViewType
          View.ViewKey = ValueNone
          View.Attrs = view.Attrs
          View.ConstructorArgs = view.ConstructorArgs
          View.Outlet = ValueSome (fun control -> outlet (control :?> 'view)) }