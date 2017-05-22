(function ($) {
    $(document).ready(function () {

        $('a.showCake').hover(function () {
            $(this).parent().parent().find('div.childBackground').fadeTo('slow', 0.9);
            $(this).parent().parent().addClass("cakeInfoSet");

        }).mouseout(function () {
            $(this).parent().parent().find('div.childBackground').fadeTo('fast', 0);
            $(this).parent().parent().removeClass("cakeInfoSet");
        });
    });
})(jQuery);