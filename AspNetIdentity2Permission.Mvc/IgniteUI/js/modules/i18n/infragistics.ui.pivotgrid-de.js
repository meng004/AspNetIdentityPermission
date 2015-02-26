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
                filtersHeader: "Filterfelder hier ablegen",
                measuresHeader: "Datenfelder hierher ziehen",
                rowsHeader: "Zeilenfelder hierher ziehen",
                columnsHeader: "Spaltenfelder hierher ziehen",
                disabledFiltersHeader: "Filterfelder",
                disabledMeasuresHeader: "Datenelemente",
                disabledRowsHeader: "Zeilenfelder",
                disabledColumnsHeader: "Spaltenfelder",
                noSuchAxis: "Keine solche Achse"
            }
        });
    }
})(jQuery);