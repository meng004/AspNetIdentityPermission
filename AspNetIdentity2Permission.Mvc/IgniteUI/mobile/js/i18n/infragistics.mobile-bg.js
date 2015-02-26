/*!@license
* Infragistics.Web.MobileUI ListView localization resources 14.2.20142.1018
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
		noSuchWidget: "Следният widget не е зареден: ",
		optionChangeNotSupported: "Промяната на следната опция след инициялизация на igListView не се поддържа:",
		emptyListText: "Листът няма елементи!",
		goBackLabel: "Назад",
		detailsLabel: "Детайли",
		searchTrayExpandLabel: "Сортиране/Филтриране",
		searchTrayCollapseLabel: "Затвори"
	};
	$.ig.mobileListViewFiltering.locale = {
		keywordSearchLabel: "",
		keywordAllStateText: "Всички полета",
		filterPresetsLabel: "Предефинирани филтри:",
		searchBarPlaceHolder: "Филтриране на елементи...",
		filterAllStateText: "Всичко",
		showLabel: "Покажи ",
		cancelButtonLabel: "Отмени",
		clearSearchButtonText: "Изчисти текста"
	};
	$.ig.mobileListViewLoadOnDemand.locale = {
		loadMoreItemsLabel: "Зареди още елементи",
		noMoreItemsLabel: "Няма останали незаредени елементи"
	};
	$.ig.mobileListViewSorting.locale = {
		sortPresetsLabel: "Предефинирани сортитащи изрази:",
		sortDefaultStateText: "По подразбиране",
		sortByLabel: "Сортирай по ",
		expandedCueText: "Щракни, за да свиеш {0}",
		collapsedCueText: "Щракни, за да разшириш {0}"
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
			    invalidDataSource: "Подаденият източник на данни е невалиден.",
			    unknownDataSource: "Типът на източника на данни не може да бъде определен. Моля дефинирайте дали данните са в JSON или XML формат.",
			    errorParsingArrays: "Грешка при парсирането на масива от данни и при прилагането на дефинираната schema: ",
			    errorParsingJson: "Грешка при парсирането на JSON обекта от данни и при прилагането на дефинираната schema: ",
			    errorParsingXml: "Грешка при парсирането на XML обекта от данни и при прилагането на дефинираната schema: ",
			    errorParsingHtmlTable: "Грешка при извличането на данни от HTML таблицата и при прилагането на дефинираната schema: ",
			    errorExpectedTbodyParameter: "Очакваният параметър трябва да е от тип table или tbody.",
			    errorTableWithIdNotFound: "Не е намерена HTML таблица с ID: ",
			    errorParsingHtmlTableNoSchema: "Грешка при парсиране на табличния DOM: ",
			    errorParsingJsonNoSchema: "Грешка при парсиране на JSON string: ",
			    errorParsingXmlNoSchema: "Грешка при парсиране на XML string: ",
			    errorXmlSourceWithoutSchema: "Подаденият източник на данни е XML документ, но няма дефинирана schema за данните ($.IgDataSchema).",
			    errorUnrecognizedFilterCondition: "Неразпознато условие за филтриране: ",
			    errorRemoteRequest: "Неуспешно завършено външно поискване на данни: ",
			    errorSchemaMismatch: "Входните данни не отговарят на подадената schema; съответното поле не може да бъде попълнено успешно: ",
			    errorSchemaFieldCountMismatch: "Входните данни не отговарят на подадената схема като брой полета. ",
			    errorUnrecognizedResponseType: "Типът на доставените данни не е деклариран правилно или не е било възможно типът да бъде определен автоматично. Моля попълнете settings.responseDataType и/или settings.responseContentType.",
			    hierarchicalTablesNotSupported: "Таблици не се поддържат от HierarchicalSchema",
			    cannotBuildTemplate: "Шаблонът не може да бъде построен. Източника на данни няма записи и не са дефинирани колони.",
			    unrecognizedCondition: "Неразпознато условие за филтриране: ",
			    fieldMismatch: "Изразът съдържа невалидно поле или условие за филтриране: ",
			    noSortingFields: "Моля задайте поне едно поле при извикване на sort().",
			    filteringNoSchema: "Нямате зададени schema / fields. Нужно е да зададете schema с field дефиниция и типове, за да можете да филтрирате източника на данни."
		    }
	    });

    }
})(jQuery);
/*
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
			    seriesName: "трябва да попълните series name в зададените от вас опции.",
			    axisName: "трябва да попълните axis name в зададените от вас опции.",
			    invalidLabelBinding: "Не съществува такава стойност, с която да се обвържат етикетите.",
			    close: "Затвори",
			    overview: "Преглед",
			    zoomOut: "Отдалечи",
			    zoomIn: "Увеличи",
			    resetZoom: "Рестартирай увеличението"
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
			    undefinedArgument: 'Грешка при опит да се вземе стойността на следното свойство от източника на данни: '
		    }
	    });
    }
})(jQuery);

