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
                filtersHeader: "Placer les champs de filtre ici",
                measuresHeader: "Placer les éléments de données ici",
                rowsHeader: "Placer les champs de ligne ici",
                columnsHeader: "Placer les champs de colonne ici",
                disabledFiltersHeader: "Champs de filtre",
                disabledMeasuresHeader: "Éléments de données",
                disabledRowsHeader: "Champs de ligne",
                disabledColumnsHeader: "Champs de colonne",
                noSuchAxis: "Aucun axe de ce type"
            }
        });
    }
})(jQuery);