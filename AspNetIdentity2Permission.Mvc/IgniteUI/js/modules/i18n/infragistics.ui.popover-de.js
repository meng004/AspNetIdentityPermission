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
			popoverOptionChangeNotSupported: "Die Änderung der folgenden Option nach der Initialisierung von igPopover wird nicht unterstützt:",
			popoverShowMethodWithoutTarget: "Der Target-Parameter der Show-Funktion ist obligatorisch, wenn die Selectors-Option verwendet wird"
		}
	});

}
})(jQuery);