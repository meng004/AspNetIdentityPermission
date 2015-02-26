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
			    invalidDataSource: "指定したデータ ソースは無効です。スカラーです。",
			    unknownDataSource: "データ ソース型を決定できません。JSON または XML データであるかどうかを指定してください。",
			    errorParsingArrays: "配列データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingJson: "JSON データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingXml: "XML データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingHtmlTable: "HTML テーブルからデータを展開してスキーマを適用したときにエラーが発生しました。 ",
			    errorExpectedTbodyParameter: "パラメーターは tbody または table である必要があります。",
			    errorTableWithIdNotFound: "この ID を持つ HTML テーブルが見つかりませんでした:  ",
			    errorParsingHtmlTableNoSchema: "テーブルの DOM の分析でエラーが発生しました:  ",
			    errorParsingJsonNoSchema: "JSON 文字列の分析または評価でエラーが発生しました: ",
			    errorParsingXmlNoSchema: "XML 文字列の分析でエラーが発生しました: ",
			    errorXmlSourceWithoutSchema: "指定したデータ ソースは XML ドキュメントですが、データ スキーマ ($.IgDataSchema) が定義されていません。 ",
			    errorUnrecognizedFilterCondition: "渡されたフィルター条件は無効です。 ",
			    errorRemoteRequest: "データを取得するリモート要求に失敗しました。 ",
			    errorSchemaMismatch: "入力データがスキーマと一致しません。このフィールドをマップできませんでした:  ",
			    errorSchemaFieldCountMismatch: "入力のデータがスキーマと一致しません。フィールド数が無効です。 ",
			    errorUnrecognizedResponseType: "応答型が正しく設定されなかったか、自動的に検出できませんでした。settings.responseDataType または settings.responseContentType を設定してください。",
			    hierarchicalTablesNotSupported: "HierarchicalSchema でテーブルをサポートしません。",
			    cannotBuildTemplate: "jQuery テンプレートをビルドできませんでした。データ ソースでレコードがないし、列が定義されていません。",
			    unrecognizedCondition: "この式で無効なフィルター条件があります:  ",
			    fieldMismatch: "この式で無効なフィールドまたはフィルター条件があります:  ",
			    noSortingFields: "フィールドが指定されていません。sort() を呼び出すときに、並べ替えるフィールドを 1 つ以上を指定する必要があります。",
			    filteringNoSchema: "スキーマまたはフィールドが指定されていません。データ ソースをフィルターするには、フィールド定義および型を含むスキーマを指定する必要があります。"
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
			    seriesName: "オプションを設定するときに、シリーズ名のオプションを指定する必要があります。",
			    axisName: "オプションを設定するときに、軸名のオプションを指定する必要があります。",
			    invalidLabelBinding: "ラベルにバインドする値はありません。",
			    close: "閉じる",
			    overview: "概要",
			    zoomOut: "ズームアウト",
			    zoomIn: "ズームイン",
			    resetZoom: "ズームのリセット"
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
		    undefinedArgument: 'データ ソース プロパティを取得する際にエラーが発生しました: '
		}
	});
}
})(jQuery);

