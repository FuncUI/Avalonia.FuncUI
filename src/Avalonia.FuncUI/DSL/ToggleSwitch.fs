﻿namespace Avalonia.FuncUI.DSL


[<AutoOpen>]
module ToggleSwitch =

    open Avalonia.Controls
    open Avalonia.Controls.Templates
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder

    let create (attrs: Attr<ToggleSwitch> list): View<ToggleSwitch> =
        ViewBuilder.Create<ToggleSwitch>(attrs)

    type ToggleSwitch with
        static member onContent<'t when 't :> ToggleSwitch>(value: obj) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<obj>(ToggleSwitch.OnContentProperty, value, ValueNone)

        static member onContentTemplate<'t when 't :> ToggleSwitch>(template: IDataTemplate) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<IDataTemplate>(ToggleSwitch.OnContentTemplateProperty, template, ValueNone)

        static member offContent<'t when 't :> ToggleSwitch>(value: obj) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<obj>(ToggleSwitch.OffContentProperty, value, ValueNone)

        static member offContentTemplate<'t when 't :> ToggleSwitch>(template: IDataTemplate) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<IDataTemplate>(ToggleSwitch.OffContentTemplateProperty, template, ValueNone)
