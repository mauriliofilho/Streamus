$(function () {
	window.youtube = {
		embed: function ($elem, videoId, dimensions) {
			var $iframe = $("<iframe>");
			$iframe.attr("src", "//www.youtube.com/embed/" + videoId + "?autoplay=1");
			$iframe.attr("frameborder", "0");
			$iframe.attr("allowfullscreen", "allowfullscreen");

			if (dimensions) {
				$iframe.attr("width", dimensions.width);
				$iframe.attr("height", dimensions.height);
			}

			$elem.append($iframe);
		}
	};
});