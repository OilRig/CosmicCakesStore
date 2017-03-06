(function ($) {
    $(document).ready(function () {
        var timedImagesForwardEven = setInterval(function () {
            $('img#cakeImageFirst:even').fadeOut(1500,
                function () {
                    var currSrc = $(this).attr('src');
                    var frstImgNexSrc = $(this).next('img#cakeImageSecond').attr('src');
                    $(this).next('img#cakeImageSecond').attr('src', currSrc);
                    $(this).attr("src", frstImgNexSrc);
                    $(this).fadeIn(1000);
                });
        }, 7000);
        var timedImagesForwardOdd = setInterval(function () {
            $('img#cakeImageFirst:odd').fadeOut(1500,
                function () {
                    var currSrc = $(this).attr('src');
                    var frstImgNexSrc = $(this).next('img#cakeImageSecond').attr('src');
                    $(this).next('img#cakeImageSecond').attr('src', currSrc);
                    $(this).attr("src", frstImgNexSrc);
                    $(this).fadeIn(1000);
                });
        }, 13000);
        var timedImagesForwardThirdForwardEven = setInterval(function () {
            $('img#cakeImageThird:even').fadeOut(1500,
                function () {
                    var currSrc = $(this).attr('src');
                    var frstImgNexSrc = $(this).next('img#cakeImageFourth').attr('src');
                    $(this).next('img#cakeImageFourth').attr('src', currSrc);
                    $(this).attr("src", frstImgNexSrc);
                    $(this).fadeIn(1000);
                });
        }, 18000);
        var timedImagesThirdForwardOdd = setInterval(function () {
            $('img#cakeImageThird:odd').fadeOut(1500,
                function () {
                    var currSrc = $(this).attr('src');
                    var frstImgNexSrc = $(this).next('img#cakeImageFourth').attr('src');
                    $(this).next('img#cakeImageFourth').attr('src', currSrc);
                    $(this).attr("src", frstImgNexSrc);
                    $(this).fadeIn(1000);
                });
        }, 27000);
    });
})(jQuery);