$(document).ready(function () {
    $('a#top').click(function () {
        $('html, body').animate({
            scrollTop: 0
        }, 700);
    });
});