namespace Avalonia.FuncUI.DSL
open Avalonia.Controls
open Avalonia.Controls.Primitives

[<AutoOpen>]
module StyledElement =  
    open Avalonia
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder
    open Avalonia.Styling

    module private Internals =
        open System.Linq

        /// pseudoclasse is classe beginning with a ':' character.
        let isPseudoClass (s: string) = s.StartsWith(":")

        /// Update `Classes`'s standard classes with new values. 
        let patchStandardClasses (classes: Classes) (newValues: string seq) =

            let (|PseudoClass|_|) (s: string) =
                if isPseudoClass s then
                    Some PseudoClass
                else
                    None
            
            let newValues = newValues |> Seq.toList

            if List.isEmpty newValues then
                classes.Clear()
            else
                classes
                |> Seq.filter (isPseudoClass >> not)
                |> Seq.except newValues
                |> classes.RemoveAll

                if classes.Count = 0 then
                    classes.AddRange newValues
                else
                    /// Update Classes to minimize event triggers while taking pseudoclasse into account.
                    let rec loop insertIndex newValues =
                        let current = Seq.tryItem insertIndex classes

                        match current, newValues with
                        | _, [] ->
                            // If there are no more values, update finished.
                            ()
                        | None, _ ->
                            // If there are no more classes in the current classes, add the new values.
                            classes.AddRange(newValues)
                        | Some PseudoClass, _ ->
                            // If the current class is a pseudo class, skip it.
                            loop (insertIndex + 1) newValues
                        | Some current, newClass :: rest when current = newClass ->
                            // If the current class is the same as the new class, skip it.
                            loop (insertIndex + 1) rest
                        | Some _, newClass :: rest ->
                            // Search for the new class in the current classes.
                            let oldIndex = classes |> Seq.tryFindIndex ((=) newClass)

                            match oldIndex with
                            
                            | Some oldIndex when oldIndex = insertIndex ->
                                // If oldIndex is the same as insertIndex, do nothing.
                                ()
                            | Some oldIndex ->
                                // If oldIndex is different from insertIndex, move the class to the right position.
                                classes.Move(oldIndex, insertIndex)
                            | None ->
                                // If the class is not in the current classes, insert it.
                                classes.Insert(insertIndex, newClass)

                            // Continue with the next class.
                            loop (insertIndex + 1) rest

                    loop 0 newValues

        /// Compare two sequences of standard classes.
        let compareClasses<'e when 'e :> seq<string> > (a: obj, b: obj) : bool =
            let setup (o: obj) =
                o :?> 'e |> Seq.filter (isPseudoClass >> not)

            let a = setup a
            let b = setup b

            Enumerable.SequenceEqual(a, b)

    type StyledElement with
        static member dataContext<'t when 't :> StyledElement>(dataContext: obj) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<obj>(StyledElement.DataContextProperty, dataContext, ValueNone)
            
        static member name<'t when 't :> StyledElement>(name: string) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<string>(StyledElement.NameProperty, name, ValueNone)
            
        static member templatedParent<'t when 't :> StyledElement>(template: TemplatedControl) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<AvaloniaObject>(StyledElement.TemplatedParentProperty, template, ValueNone)
        
        static member theme<'t when 't :> StyledElement>(theme: ControlTheme) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<ControlTheme>(StyledElement.ThemeProperty, theme, ValueNone)

        static member classes<'t when 't :> StyledElement>(value: Classes) : IAttr<'t> =
            let getter: ('t -> Classes) = (fun control -> control.Classes)

            let setter: ('t * Classes -> unit) =
                (fun (control, value) ->
                    Internals.patchStandardClasses control.Classes value)

            let compare = Internals.compareClasses<Classes>

            let factory = (fun () -> Classes())

            AttrBuilder<'t>.CreateProperty<Classes>("Classes", value, ValueSome getter, ValueSome setter, ValueSome compare, factory)

        static member classes<'t when 't :> StyledElement>(classes: string list) : IAttr<'t> =
            let getter: ('t -> (string list)) =(fun control -> Seq.toList control.Classes)

            let setter: ('t * string list -> unit) =
                (fun (control, values) -> Internals.patchStandardClasses control.Classes values)

            let compare = Internals.compareClasses<string list>

            let factory = fun () -> []

            AttrBuilder<'t>.CreateProperty<string list>("Classes", classes, ValueSome getter, ValueSome setter, ValueSome compare, factory)

        static member resources<'t when 't :> StyledElement>(value: IResourceDictionary) : IAttr<'t> =
            let getter : ('t -> IResourceDictionary) = (fun control -> control.Resources)
            let setter : ('t * IResourceDictionary -> unit) = (fun (control, value) -> control.Resources <- value)
            let factory = fun () -> ResourceDictionary() :> IResourceDictionary
            
            AttrBuilder<'t>.CreateProperty<IResourceDictionary>("Resources", value, ValueSome getter, ValueSome setter, ValueNone, factory)
            
        // Attached properties related to text input
        
        static member contentType<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.ContentTypeProperty, value, ValueNone)
            
        static member returnKeyType<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.ReturnKeyTypeProperty, value, ValueNone)
            
        static member multiline<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.MultilineProperty, value, ValueNone)
            
        static member autoCapitalization<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.AutoCapitalizationProperty, value, ValueNone)
            
        static member isSensitive<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.IsSensitiveProperty, value, ValueNone)
            
        static member uppercase<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.UppercaseProperty, value, ValueNone)
            
        static member lowercase<'t when 't :> StyledElement>(value) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<_>(Avalonia.Input.TextInput.TextInputOptions.LowercaseProperty, value, ValueNone)
