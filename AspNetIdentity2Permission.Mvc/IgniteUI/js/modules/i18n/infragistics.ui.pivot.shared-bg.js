/*!@license
* Infragistics.Web.ClientUI Pivot Shared localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotShared) {
        $.ig.PivotShared = {};

        $.extend($.ig.PivotShared, {
            locale: {
                invalidDataSource: "Подаденият източник на данни е или нулев, или не се поддържа.",
                measureList: "Мерки",
                ok: "ОК",
                cancel: "Отказ",
                addToMeasures: "Добави към мерките",
                addToFilters: "Добави към филтрите",
                addToColumns: "Добави към колоните",
                addToRows: "Добави към редовете"
            }
        });
    }
})(jQuery);