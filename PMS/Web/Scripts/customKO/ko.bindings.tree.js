(function ($, ko) {
    "use strict";

    ko.bindingHandlers.tree = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            if(!ko.isObservable(valueAccessor()))
                throw new Error("tree binding should be used only for observables");

            var $el = $(element);
            var options = allBindings.get('treeOptions') || {};

            $el.tree($.extend(options, {data: valueAccessor()()}));
            
        },
        update: function(element, valueAccessor){
            
        }
    };

})(jQuery, ko);