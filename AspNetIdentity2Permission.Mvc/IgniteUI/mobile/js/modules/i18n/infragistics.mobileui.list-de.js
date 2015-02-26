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
		noSuchWidget: "Kein solches Widget geladen: ",
		optionChangeNotSupported: "Die Änderung der folgenden Option nach der Erstellung von igListView wird nicht unterstützt:",
		emptyListText: "Es gibt keine Listenelemente!",
		goBackLabel: "Zurück",
		detailsLabel: "Details",
		searchTrayExpandLabel: "Sortieren/Filtern",
		searchTrayCollapseLabel: "Reduzieren"
	};
	$.ig.mobileListViewFiltering.locale = {
		keywordSearchLabel: "",
		keywordAllStateText: "Alle Felder",
		filterPresetsLabel: "Filtervoreinstellungen:",
		searchBarPlaceHolder: "Filterelemente...",
		filterAllStateText: "Alle",
		showLabel: "Anzeigen ",
		cancelButtonLabel: "Abbrechen",
		clearSearchButtonText: "Text löschen"
	};
	$.ig.mobileListViewLoadOnDemand.locale = {
		loadMoreItemsLabel: "Mehr Elemente laden",
		noMoreItemsLabel: "Es gibt keine zu ladenden Elemente mehr"
	};
	$.ig.mobileListViewSorting.locale = {
		sortPresetsLabel: "Voreinstellungen sortieren:",
		sortDefaultStateText: "Standard",
		sortByLabel: "Sortieren nach ",
		expandedCueText: "Klicken, um {0} zu reduzieren",
		collapsedCueText: "Klicken, um {0} zu erweitern"
	};

}
