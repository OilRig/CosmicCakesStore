(function ($) {
    $(document).ready(function () {
        $("#orderForm").validate({
            rules:
                {
                ExpireDateString:
                   {
                       required:true
                   },
                CakeWeight: {
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
                CakeWeight: {
                    required: "<p style='color:red;'>Не указан вес тортика</p>",
                    min: "<p style='color:red;'>Минимальный вес - 1.5 кг</p>",
                    max: "<p style='color:red;'>Больше 20 кг не сможем поместить в холодильник :(</p>"
                },
                CustomerPhoneNumber: {
                    required: "<p style='color:red;'>Даже телефончик не оставите?</p>",
                }
            }
        });

        $('input#CakeWeight').on('input', function () {
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
                var weightValue = $('input#CakeWeight').val();
                var levelValue = $('select#SelectedLevels :selected').text();
                if (weightValue > 3 && levelValue < 2) {
                    theMessage = "Рекомендуем увеличить количество ярусов";
                }
                $('p#recomend').text(theMessage);
            }
        });
    });
})(jQuery);