(function ($) {
    $(document).ready(function () {
        $("#orderForm").validate({
            rules:
                {
                ExpireDateString:
                   {
                       required:true
                   },
                CakeStringWeight: {
                    required:true,
                    min: 1.5,
                    max:20,
                    number:true
                },
                CustomerName: "required",
                CustomerPhoneNumber: {
                    required: true
                }
            },
            messages: {
                ExpireDateString: "<p style='color:red;'>Кажется,Вы не указали дату для тортика</p>",
                CustomerName: "<p style='color:red;'>Как же Вас зовут?</p>",
                CakeStringWeight: {
                    required: "<p style='color:red;'>Не указан вес тортика</p>",
                    min: "<p style='color:red;'>Минимальный вес - 1.5 кг</p>",
                    max: "<p style='color:red;'>Больше 20 кг не сможем поместить в холодильник :(</p>"
                },
                CustomerPhoneNumber: {
                    required: "<p style='color:red;'>Даже телефончик не оставите?</p>",
                }
            }
        });

        $('input#CakeStringWeight').on('input', function () {
            var name = $('div#cakeName').text();
            if (name != 'Двухъярусный   торт')
            {
                var theMessage = '';
                var weightValue = $(this).val();
                var levelValue = $('select#SelectedLevels :selected').text();
                if (weightValue > 3 && levelValue < 2) {
                    theMessage = "Рекомендуем увеличить количество ярусов";
                }
                $('p#recomend').text(theMessage);
            }
           
        });

        $('select#SelectedLevels').on('change', function () {
            var name = $('div#cakeName').text();
            if (name != 'Двухъярусный   торт') {
                var theMessage = '';
                var weightValue = $('input#CakeStringWeight').val();
                var levelValue = $('select#SelectedLevels :selected').text();
                if (weightValue > 3 && levelValue < 2) {
                    theMessage = "Рекомендуем увеличить количество ярусов";
                }
                $('p#recomend').text(theMessage);
            }

            //for level selectors count
            if ($(this).val() == 1)
            {
                $('div#multiLevelCake').css('display', 'none');
                $('div#singleLevelCake').css('display', 'block');
                $('input#CustomLevelBisquits').attr('checked', false);
                $('input#CustomLevelBisquits').trigger('change');
            }
            else if($(this).val()==2)
            {
                $('div#multiLevelCake').css('display', 'block');
                $('div#singleLevelCake').css('display', 'none');
                $('#FirstLevelBisquit,#fstLvlLabel').css('display', 'block');
                $('#SecondLevelBisquit,#scdLvlLabel').css('display', 'block');
                $('#ThirdLevelBisquit,#thrdLvlLabel').css('display', 'none');  
            }
            else if($(this).val()==3)
            {
                $('div#multiLevelCake').css('display', 'block');
                $('div#singleLevelCake').css('display', 'none');
                $('#FirstLevelBisquit, #fstLvlLabel').css('display', 'block');
                $('#SecondLevelBisquit, #scdLvlLabel').css('display', 'block');
                $('#ThirdLevelBisquit, #thrdLvlLabel').css('display', 'block');
            }
        });

        $('input#CustomLevelBisquits').on('change', function () {
            
                if ($(this).is(':checked')) {
                    $('div#singleLevelBisquit').css('display', 'none');
                    $('div#levelSelector').css('display', 'block');
                    $('div#oneBisquitMiltiLevel').css('display', 'none');
                }
                else if ($(this).is(':unchecked')) {
                    $('div#levelSelector').css('display', 'none');
                    $('div#oneBisquitMiltiLevel').css('display', 'block');
                    $('div#singleLevelBisquit').css('display', 'none');
            } 
        });

        $('input#deliveryNeeded').on('change', function () {
            if($(this).is(':checked'))
            {
                $('div#deliveryAdress').css('display', 'block');
                $('p#recomendDelivery').text('+350-400р. к сумме заказа в зависимости от места доставки');
            }
            else
            {
                $('div#deliveryAdress').css('display', 'none');
                $('p#recomendDelivery').text('');
            }
        });
    });
})(jQuery);