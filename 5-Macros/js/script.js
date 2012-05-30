/* Author:

*/

$(function() {
	var currentTimer = null;
	$('.fancybox').fancybox({
		type: 'ajax',
		scrolling: 'no',
		fitToView: false,
		wrapCSS: 'custom-fancy',
		beforeShow: function() {
			$('.cycle').cycle({
				fx:     'scrollHorz',
			    prev:   '#left',
			    next:   '#right',
			    timeout: 0,
				speed: 600
			});
			$('.portfolio-detail').hover(function() {
				if(currentTimer != null) {
					clearTimeout(currentTimer);
					currentTimer = null;
				} else 
					$('.portfolio-description').fadeIn(400);
				
			}, function() {
				if($('.portfolio-description').is(':visible')) {
					currentTimer = setTimeout(function() {
						$('.portfolio-description').fadeOut(400);
						currentTimer = null;
					},700)
				}
				
			})
			external.loadNew();
		}
	});
	
	external = {
		init: function() {
			$('a[rel=external]').attr('target','_blank');
		},
		loadNew: function() {
			$('a[rel=external]:not([target])').attr('target','_blank')
		}
	}
	
	pageHistory = {
		init: function() {
			if(window.location.hash != "" && window.location.hash != "#" && $(window.location.hash).length > 0) 
				$(window.location.hash).click();
		}
	}
	
	external.init();
	pageHistory.init();
});




