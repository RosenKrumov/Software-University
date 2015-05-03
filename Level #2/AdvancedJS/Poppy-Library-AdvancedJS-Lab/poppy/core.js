var poppy = (function(){
	function pop(type, title, message) {
	    var popup;
	    switch (type) {
	        case 'success':
	        	popup = new popups.success(type, title, message);
	        	break;
	    	case 'info':
	        	popup = new popups.info(type, title, message);
	        	break;
	    	case 'error':
	    		popup = new popups.error(type, title, message);
	    		break;
			case 'warning':
				popup = new popups.warning(type, title, message);
				break;
	    }
		
		// generate view from view factory
	    var view = createPopupView(popup);
	    processPopup(view, popup);
	}

	return {
		pop: pop
	}
})();

function processPopup(domView, popup) {
	fadeIn(domView);

	if (popup._popupData.closeButton) {
		document.getElementsByClassName('poppy-close-button')[0]
			.addEventListener("click", function(){
			fadeOut(domView);
		});
	} 

	if (popup._popupData.autoHide) {
		var timeout = popup._popupData.timeout
		setTimeout(function(){ fadeOut(domView); }, timeout);
	}

	if (popup._popupData.callback) {
		domView.addEventListener("click", function redirect() {
			window.location = 'https://softuni.bg';
		});
	}
}

function fadeIn(el, display){
  el.style.opacity = 0;
  el.style.display = display || "block";

  (function fade() {
    var val = parseFloat(el.style.opacity);
    if (!((val += .1) > 1)) {
      el.style.opacity = val;
      requestAnimationFrame(fade);
	  document.body.appendChild(el);
    }
  })();
}

function fadeOut(el){
  el.style.opacity = 1;

  (function fade() {
    if ((el.style.opacity -= .1) < 0) {
      el.style.display = "none";
      document.body.removeChild(el);
    } else {
      requestAnimationFrame(fade);
    }
  })();
}