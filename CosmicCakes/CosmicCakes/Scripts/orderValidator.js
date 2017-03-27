(function ($) {
    $(document).ready(function () {
        $("#orderForm").validate({
            rules: {
                CakeWeight: {
                    required:true,
                    min: 1.5,
                    max:20,
                    number:true
                },
                CustomerName: "required",
                CustomerPhoneNumber: {
                    required: true
                },
                ExpireDateString: "required"
            },
            messages: {
                CustomerName: "<p style='color:red;'>Как же Вас зовут?</p>",
                CakeWeight: {
                    required: "<p style='color:red;'>Не указан вес тортика</p>",
                    min: "<p style='color:red;'>Минимальный вес - 1.5 кг</p>",
                    max: "<p style='color:red;'>Больше 20 кг не сможем поместить в холодильник :(</p>"
                },
                CustomerPhoneNumber: {
                    required: "<p style='color:red;'>Даже телефончик не оставите?</p>",
                },

                ExpireDateString: "<p style='color:red;'>Кажется,Вы не указали дату для тортика</p>"
            }
        });
    });
})(jQuery);