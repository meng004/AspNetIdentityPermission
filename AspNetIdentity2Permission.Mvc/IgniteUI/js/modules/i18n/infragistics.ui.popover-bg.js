/*!@license
* Infragistics.Web.ClientUI Popover localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Popover) {
	$.ig.Popover = {};

	$.extend( $.ig.Popover, {
		locale: {
			popoverOptionChangeNotSupported: "Промяната на следната опция след инициализация на igPopover не се поддържа:",
			popoverShowMethodWithoutTarget: "Целевият параметър на функцията show е задължителен, когато се използва опцията за селектори."
		}
	});

}
})(jQuery);