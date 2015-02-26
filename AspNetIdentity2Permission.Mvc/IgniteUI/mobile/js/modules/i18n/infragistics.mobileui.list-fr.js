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
		noSuchWidget: "Aucun widget similaire chargé : ",
		optionChangeNotSupported: "La modification de l'option suivante après la création de VueListeig n'est pas prise en charge :",
		emptyListText: "Aucun élément de liste !",
		goBackLabel: "Retour",
		detailsLabel: "Détails",
		searchTrayExpandLabel: "Trier/Filtrer",
		searchTrayCollapseLabel: "Réduire"
	};
	$.ig.mobileListViewFiltering.locale = {
		keywordSearchLabel: "",
		keywordAllStateText: "Tous les champs",
		filterPresetsLabel: "Filtrer préréglages :",
		searchBarPlaceHolder: "Filtrer éléments...",
		filterAllStateText: "Tous",
		showLabel: "Afficher ",
		cancelButtonLabel: "Annuler",
		clearSearchButtonText: "Effacer texte"
	};
	$.ig.mobileListViewLoadOnDemand.locale = {
		loadMoreItemsLabel: "Charger d'autres éléments",
		noMoreItemsLabel: "Aucun élément à charger"
	};
	$.ig.mobileListViewSorting.locale = {
		sortPresetsLabel: "Trier préréglages :",
		sortDefaultStateText: "Par défaut",
		sortByLabel: "Trier par ",
		expandedCueText: "Cliquer pour réduire {0}",
		collapsedCueText: "Cliquer pour développer {0}"
	};

}
