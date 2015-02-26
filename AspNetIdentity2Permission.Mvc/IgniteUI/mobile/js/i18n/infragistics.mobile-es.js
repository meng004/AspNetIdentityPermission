/*!@license
* Infragistics.Web.ClientUI ListView localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
$.ig = $.ig || {};

if (!$.ig.mobileListView) {
	$.ig.mobileListView = {};
	$.ig.mobileListViewFiltering = {};
	$.ig.mobileListViewLoadOnDemand = {};
	$.ig.mobileListViewSorting = {};

	$.ig.mobileListView.locale = {
		noSuchWidget: "No se ha cargado ese widget: ",
		optionChangeNotSupported: "No se admite el cambio de la siguiente opción después de crear igListView.",
		emptyListText: "¡No hay elementos de lista!",
		goBackLabel: "Volver",
		detailsLabel: "Detalles",
		searchTrayExpandLabel: "Ordenar/Filtrar",
		searchTrayCollapseLabel: "Contraer"
	};
	$.ig.mobileListViewFiltering.locale = {
		keywordSearchLabel: "",
		keywordAllStateText: "Todos los campos",
		filterPresetsLabel: "Filtrar preestablecidos:",
		searchBarPlaceHolder: "Filtrar elementos...",
		filterAllStateText: "Todos",
		showLabel: "Mostrar ",
		cancelButtonLabel: "Cancelar",
		clearSearchButtonText: "Borrar texto"
	};
	$.ig.mobileListViewLoadOnDemand.locale = {
		loadMoreItemsLabel: "Cargar más elementos",
		noMoreItemsLabel: "No quedan elementos para cargar"
	};
	$.ig.mobileListViewSorting.locale = {
		sortPresetsLabel: "Ordenar preestablecidos:",
		sortDefaultStateText: "Predeterminado",
		sortByLabel: "Ordenar por ",
		expandedCueText: "Haga clic para contraer {0}",
		collapsedCueText: "Haga clic para expandir {0}"
	};

}

/*!@license
* Infragistics.Web.ClientUI data source localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {

    $.ig = $.ig || {};

    if (!$.ig.DataSourceLocale) {
	    $.ig.DataSourceLocale = {};

	    $.extend($.ig.DataSourceLocale, {

		    locale: {
			    invalidDataSource: "El origen de datos proporcionado no es válido. Es de tipo escalar.",
			    unknownDataSource: "No se puede determinar el tipo de origen de datos. Especifique si son datos JSON o XML.",
			    errorParsingArrays: "Se ha producido un error al analizar los datos de matriz y aplicar el esquema de datos definido: ",
			    errorParsingJson: "Se ha producido un error al analizar los datos JSON y aplicar el esquema de datos definido: ",
			    errorParsingXml: "Se ha producido un error al analizar los datos XML y aplicar el esquema de datos definido: ",
			    errorParsingHtmlTable: "Se ha producido un error al extraer datos de la tabla HTML y aplicar el esquema: ",
			    errorExpectedTbodyParameter: "Se esperaba un tbody o una tabla como parámetro.",
			    errorTableWithIdNotFound: "No se ha encontrado la tabla HTML con el siguiente Id.: ",
			    errorParsingHtmlTableNoSchema: "Se ha producido un error al analizar el DOM de la tabla: ",
			    errorParsingJsonNoSchema: "Se ha producido un error al analizar/evaluar la cadena JSON: ",
			    errorParsingXmlNoSchema: "Se ha producido un error al analizar la cadena XML: ",
			    errorXmlSourceWithoutSchema: "El origen de datos proporcionado es un documento xml, pero no hay un esquema de datos definido ($.IgDataSchema) ",
			    errorUnrecognizedFilterCondition: " La condición de filtro especificada no ha sido reconocida: ",
			    errorRemoteRequest: "Error en la solicitud remota de recuperación de datos: ",
			    errorSchemaMismatch: "Los datos de entrada no coinciden con el esquema, no se ha podido asignar el siguiente campo: ",
			    errorSchemaFieldCountMismatch: "Los datos de entrada no coinciden con el esquema en términos de número de campos. ",
			    errorUnrecognizedResponseType: "El tipo de respuesta no se ha establecido correctamente o no ha sido posible detectarlo automáticamente. Establezca settings.responseDataType y/o settings.responseContentType.",
			    hierarchicalTablesNotSupported: "Tablas no admitidas para HierarchicalSchema",
			    cannotBuildTemplate: "No se ha podido generar la plantilla jQuery. No hay registros presentes en el origen de datos y no hay columnas definidas.",
			    unrecognizedCondition: "Condición de filtro no reconocida en la siguiente expresión: ",
			    fieldMismatch: "La siguiente expresión contiene un campo o una condición de filtro no válidos: ",
			    noSortingFields: "No se ha especificado ningún campo. Debe especificar al menos un campo de ordenación al llamar a sort().",
			    filteringNoSchema: "No se ha especificado ningún esquema / campo. Debe especificar un esquema con definiciones y tipos de campo para poder filtrar el origen de datos."
		    }
	    });

    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI common DV widget localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Chart) {
	    $.ig.Chart = {};

	    $.extend($.ig.Chart, {

		    locale: {
			    seriesName: "debe especificar la opción de nombre de la serie al establecer las opciones.",
			    axisName: "debe especificar la opción de nombre del eje al establecer las opciones.",
			    invalidLabelBinding: "No existe ningún valor para las etiquetas de enlace.",
			    close: "Cerrar",
			    overview: "Información general",
			    zoomOut: "Alejar",
			    zoomIn: "Acercar",
			    resetZoom: "Restablecer zoom"
		    }
	    });

    }
})(jQuery);

/*!@license
* Infragistics.Web.ClientUI templating localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Templating) {
	    $.ig.Templating = {};

	    $.extend($.ig.Templating, {
		    locale: {
			    undefinedArgument: 'Se ha producido un error al intentar recuperar las propiedades del origen de datos: '
		    }
	    });
    }
})(jQuery);

