// https://github.com/infinum/cookies_eu

$(document).ready(function () {
	$('.cookies-eu-ok').click(function (e) {
		e.preventDefault();
		$.cookie('cookie_consented', 'true', { path: '/', expires: 365 });
		$('.cookies-eu').remove();
	});
});