(function ($) {
    $('input#CakeStringWeight').on('input', function () {
        var value = $(this).val();
        if (value.includes(","))
            value = value.replace(",", ".");
        var kgPrice = $('div#cakeName').data('kgprice');
        var price = Math.round((value * kgPrice)*100)/100;
        if(!isNaN(price))
            $('#priceHolder').text(price+"р.");
        else
            $('#priceHolder').text('Какой-то вес странный...');
    });
})(jQuery)