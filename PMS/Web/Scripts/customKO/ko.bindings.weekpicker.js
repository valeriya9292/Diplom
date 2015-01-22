(function ($, ko) {
    "use strict";

    ko.bindingHandlers.weekpicker = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

            var $el = $(element);

                var startDate;
                var endDate;

                var selectCurrentWeek = function () {
                    window.setTimeout(function () {
                        $el.find('.ui-datepicker-current-day a').addClass('ui-state-active');
                    }, 1);
                }
                var startDateValue = allBindings.get('startDateValue');
                var endDateValue = allBindings.get('endDateValue');

                $el.datepicker({
                    showOtherMonths: true,
                    selectOtherMonths: true,
                    onSelect: function (dateText, inst) {
                        var date = $(this).datepicker('getDate');
                        startDate = new Date(date.getFullYear(), date.getMonth(), date.getDate() - date.getDay());
                        endDate = new Date(date.getFullYear(), date.getMonth(), date.getDate() - date.getDay() + 6);
                        var dateFormat = inst.settings.dateFormat || $.datepicker._defaults.dateFormat;
                        startDateValue($.datepicker.formatDate(dateFormat, startDate, inst.settings));
                        endDateValue($.datepicker.formatDate(dateFormat, endDate, inst.settings));
                        selectCurrentWeek();
                    },
                    beforeShowDay: function (date) {
                        var cssClass = '';
                        if (date >= startDate && date <= endDate)
                            cssClass = 'ui-datepicker-current-day';
                        return [true, cssClass];
                    },
                    onChangeMonthYear: function (year, month, inst) {
                        selectCurrentWeek();
                    }
                });
              
                $('.ui-datepicker-current-day').click();

                $('.ui-datepicker-calendar tr', $el).live('mousemove', function () { $(this).find('td a').addClass('ui-state-hover'); });
                $('.ui-datepicker-calendar tr', $el).live('mouseleave', function () { $(this).find('td a').removeClass('ui-state-hover'); });

        },
        update: function(element, valueAccessor){
            
        }
    };

})(jQuery, ko);