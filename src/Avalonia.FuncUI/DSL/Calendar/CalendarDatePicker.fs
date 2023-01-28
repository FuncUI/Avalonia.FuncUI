﻿namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module CalendarDatePicker =
    open System
    open Avalonia.Controls
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder

    let create (attrs: Attr<CalendarDatePicker> list): View<CalendarDatePicker> =
        ViewBuilder.Create<CalendarDatePicker>(attrs)

    type CalendarDatePicker with

        static member displayDate<'t when 't :> CalendarDatePicker>(value: DateTime) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime>(CalendarDatePicker.DisplayDateProperty, value, ValueNone)

        static member displayDateStart<'t when 't :> CalendarDatePicker>(value: DateTime Nullable) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateStartProperty, value, ValueNone)

        static member displayDateStart<'t when 't :> CalendarDatePicker>(value: DateTime) : Attr<'t> =
            value |> Nullable |> CalendarDatePicker.displayDateStart

        static member displayDateStart<'t when 't :> CalendarDatePicker>(value: DateTime option) : Attr<'t> =
            value |> Option.toNullable |> CalendarDatePicker.displayDateStart

        static member displayDateEnd<'t when 't :> CalendarDatePicker>(value: DateTime Nullable) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.DisplayDateEndProperty, value, ValueNone)

        static member displayDateEnd<'t when 't :> CalendarDatePicker>(value: DateTime) : Attr<'t> =
            value |> Nullable |> CalendarDatePicker.displayDateEnd

        static member displayDateEnd<'t when 't :> CalendarDatePicker>(value: DateTime option) : Attr<'t> =
            value |> Option.toNullable |> CalendarDatePicker.displayDateEnd

        static member firstDayOfWeek<'t when 't :> CalendarDatePicker>(value: DayOfWeek) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<DayOfWeek>(CalendarDatePicker.FirstDayOfWeekProperty, value, ValueNone)

        static member isDropDownOpen<'t when 't :> CalendarDatePicker>(value: bool) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.IsDropDownOpenProperty, value, ValueNone)

        static member onDropDownOpenChanged<'t when 't :> CalendarDatePicker>(func: bool -> unit, ?subPatchOptions) : Attr<'t> =
            AttrBuilder<'t>.CreateSubscription(CalendarDatePicker.IsDropDownOpenProperty, func, ?subPatchOptions = subPatchOptions)

        static member isTodayHighlighted<'t when 't :> CalendarDatePicker>(value: bool) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.IsTodayHighlightedProperty , value, ValueNone)

        static member selectedDate<'t when 't :> CalendarDatePicker>(value: DateTime Nullable) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, value, ValueNone)

        static member selectedDate<'t when 't :> CalendarDatePicker>(value: DateTime) : Attr<'t> =
            value |> Nullable |> CalendarDatePicker.selectedDate

        static member selectedDate<'t when 't :> CalendarDatePicker>(value: DateTime option) : Attr<'t> =
            value |> Option.toNullable |> CalendarDatePicker.selectedDate

        static member onSelectedDateChanged<'t when 't :> CalendarDatePicker>(func: Nullable<DateTime> -> unit, ?subPatchOptions) : Attr<'t> =
            AttrBuilder<'t>.CreateSubscription<DateTime Nullable>(CalendarDatePicker.SelectedDateProperty, func, ?subPatchOptions = subPatchOptions)

        static member selectedDateFormat<'t when 't :> CalendarDatePicker>(value: CalendarDatePickerFormat) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<CalendarDatePickerFormat>(CalendarDatePicker.SelectedDateFormatProperty, value, ValueNone)

        static member customDateFormatString<'t when 't :> CalendarDatePicker>(value: string) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.CustomDateFormatStringProperty, value, ValueNone)

        static member text<'t when 't :> CalendarDatePicker>(value: string) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.TextProperty, value, ValueNone)

        static member watermark<'t when 't :> CalendarDatePicker>(value: string) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(CalendarDatePicker.WatermarkProperty, value, ValueNone)

        static member useFloatingWatermark<'t when 't :> CalendarDatePicker>(value: bool) : Attr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(CalendarDatePicker.UseFloatingWatermarkProperty, value, ValueNone)

