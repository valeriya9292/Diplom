(function ($, ko) {
    "use strict";

    ko.bindingHandlers.datepicker = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            if(!ko.isObservable(valueAccessor()))
                throw new Error("tree binding should be used only for observables");

            var $el = $(element);
           // var options = allBindings.get('treeOptions') || {};

            $el.datepicker({ "setDate": valueAccessor()() });
            
        },
        update: function(element, valueAccessor){
            $(element).datepicker('setDate', valueAccessor()());
        }
    };

})(jQuery, ko);