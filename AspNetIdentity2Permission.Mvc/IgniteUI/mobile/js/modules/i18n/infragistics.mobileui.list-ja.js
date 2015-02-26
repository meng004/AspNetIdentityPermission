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
		noSuchWidget: "ウィジェットは読み込まれていません: ",
		optionChangeNotSupported: "igListView が作成された後のこのオプションを変更はサポートされません:",
		emptyListText: "リスト項目はありません。",
		goBackLabel: "戻る",
		detailsLabel: "詳細",
		searchTrayExpandLabel: "並べ替え/フィルター",
		searchTrayCollapseLabel: "縮小"
	};
	$.ig.mobileListViewFiltering.locale = {
		keywordSearchLabel: "",
		keywordAllStateText: "すべてのフィールド",
		filterPresetsLabel: "フィルターのプリセット:",
		searchBarPlaceHolder: "項目のフィルター",
		filterAllStateText: "すべて",
		showLabel: "表示: ",
		cancelButtonLabel: "キャンセル",
		clearSearchButtonText: "テキストをクリア"
	};
	$.ig.mobileListViewLoadOnDemand.locale = {
		loadMoreItemsLabel: "追加の項目を読み込む",
		noMoreItemsLabel: "読み込む項目はありません"
	};
	$.ig.mobileListViewSorting.locale = {
		sortPresetsLabel: "並べ替えのプリセット:",
		sortDefaultStateText: "デフォルト",
		sortByLabel: "並べ替え条件: ",
		expandedCueText: "クリックして {0} を縮小",
		collapsedCueText: "クリックして {0} を展開"
	};

}