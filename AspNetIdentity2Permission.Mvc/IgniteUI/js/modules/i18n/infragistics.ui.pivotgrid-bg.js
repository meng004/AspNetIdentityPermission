/*!@license
* Infragistics.Web.ClientUI Pivot Grid localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotGrid) {
        $.ig.PivotGrid = {};

        $.extend($.ig.PivotGrid, {
            locale: {
                filtersHeader: "Пусни филтърните полета тук",
                measuresHeader: "Пусни данните тук",
                rowsHeader: "Пусни полетата за редове тук",
                columnsHeader: "Пусни полетата за колони тук",
                disabledFiltersHeader: "Полета за филтриране",
                disabledMeasuresHeader: "Данни",
                disabledRowsHeader: "Полета за редове",
                disabledColumnsHeader: "Полета за колони",
                noSuchAxis: "Няма такава ос"
            }
        });
    }
})(jQuery);