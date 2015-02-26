/*!@license
* Infragistics.Web.ClientUI Zoombar localization resources 14.2.20142.1018
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Zoombar) {
	    $.ig.Zoombar = {};

	    $.extend($.ig.Zoombar, {

	        locale: {
	            zoombarTargetNotSpecified: "igZoombar изисква валидна цел, към която да се прикрепи!",
	            zoombarTypeNotSupported: "Видът на компонента, към който igZoombar се опитва да се прикрепи не се поддържа!",
	            optionChangeNotSupported: "Промяната на следната опция след инициализация на igZoombar не се поддържа:"
		    }
	    });

    }
})(jQuery);