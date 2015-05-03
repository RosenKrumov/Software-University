var popups = (function(){
	var abstractPopup = (function(){
		function AbstractPopup(type, title, message, callback, position, timeout, autoHide, closeButton){
			this._popupData = {
				type: type,
				title: title,
				message: message,
				position: position,
				timeout: timeout,
				autoHide: autoHide,
				closeButton: closeButton
			}
		}

		return AbstractPopup;
	})();

	var successPopup = (function(){
		function SuccessPopup(type, title, message, callback, position, timeout, autoHide, closeButton){
			abstractPopup.call(this, type, title, message, 'false', 'bottomLeft', 0, false, false);
		}

		SuccessPopup.extends(abstractPopup);

		return SuccessPopup;
	})();

	var infoPopup = (function(){
		function InfoPopup(type, title, message, callback, position, timeout, autoHide, closeButton){
			abstractPopup.call(this, type, title, message, 'false', 'topLeft', 0, false, true);
		}

		InfoPopup.extends(abstractPopup);

		return InfoPopup;
	})();

	var errorPopup = (function(){
		function ErrorPopup(type, title, message, callback, position, timeout, autoHide, closeButton){
			abstractPopup.call(this, type, title, message, 'false', 'topRight', 5000, true, false);
		}

		ErrorPopup.extends(abstractPopup);

		return ErrorPopup;
	})();

	var warningPopup = (function(){
		function WarningPopup(type, title, message, callback, position, timeout, autoHide, closeButton, callback){
			abstractPopup.call(this, type, title, message, 'true', 'bottomRight', 0, false, false);
		}

		WarningPopup.extends(abstractPopup);

		return WarningPopup;
	})();

	return {
		success: successPopup,
		info: infoPopup,
		error: errorPopup,
		warning: warningPopup
	}
})();
