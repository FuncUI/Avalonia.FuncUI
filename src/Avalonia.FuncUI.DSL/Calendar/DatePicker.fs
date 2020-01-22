﻿namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module DatePicker =
    open System
    open Avalonia.Controls
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder
    
    let create (attrs: IAttr<DatePicker> list): IView<DatePicker> =
        ViewBuilder.Create<DatePicker>(attrs)
     
    type DatePicker with
  
        static member displayDate<'t when 't :> DatePicker>(value: DateTime) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime>(DatePicker.DisplayDateProperty, value, ValueNone)

        static member displayDateStart<'t when 't :> DatePicker>(value: DateTime option) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime option>(DatePicker.DisplayDateStartProperty, value, ValueNone)

        static member displayDateEnd<'t when 't :> DatePicker>(value: DateTime option) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime option>(DatePicker.DisplayDateEndProperty, value, ValueNone)

        static member firstDayOfWeek<'t when 't :> DatePicker>(value: DayOfWeek) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DayOfWeek>(DatePicker.FirstDayOfWeekProperty, value, ValueNone)

        static member isDropdownOpen<'t when 't :> DatePicker>(value: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(DatePicker.IsDropDownOpenProperty, value, ValueNone)
        
        static member isTodayHighlightedProperty<'t when 't :> DatePicker>(value: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(DatePicker.IsTodayHighlightedProperty , value, ValueNone)

        static member selectedDate<'t when 't :> DatePicker>(value: DateTime option) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime option>(DatePicker.SelectedDateProperty, value, ValueNone)

        static member selectedDateFormat<'t when 't :> DatePicker>(value: DatePickerFormat) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<DatePickerFormat>(DatePicker.SelectedDateFormatProperty, value, ValueNone)

        static member customDateFormatString<'t when 't :> DatePicker>(value: string) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(DatePicker.CustomDateFormatStringProperty, value, ValueNone)

        static member text<'t when 't :> DatePicker>(value: string) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(DatePicker.TextProperty, value, ValueNone)

        static member watermark<'t when 't :> DatePicker>(value: string) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(DatePicker.WatermarkProperty, value, ValueNone)

        static member useFloatingWatermark<'t when 't :> DatePicker>(value: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(DatePicker.UseFloatingWatermarkProperty, value, ValueNone)

