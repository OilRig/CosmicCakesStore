(function ($) {
    $('input#CakeStringWeight').on('input', function () {
        var value = $(this).val();
        var kgPrice = $('div#cakeName').data('kgprice');
        var price = value * kgPrice;
        if(!isNaN(price))
            $('#priceHolder').text(price+"р.");
        else
            $('#priceHolder').text('Напишите цену через запятую');
    });
})(jQuery)