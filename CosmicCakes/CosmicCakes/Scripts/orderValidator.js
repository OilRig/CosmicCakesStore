(function ($) {
    $(document).ready(function () {
        $("#orderForm").validate({
            rules: {
                CakeWeight: "required",
                CustomerName: "required",
                CustomerPhoneNumber: {
                    required: true
                },
                ExpireDateString: "required"
            },
            messages: {
                CustomerName: "Как же Вас зовут?",
                CakeWeight: "Не указан вес тортика",
                CustomerPhoneNumber: {
                    required: "Даже телефончик не оставите?",
                },

                ExpireDateString: "Кажется,Вы не указали дату для тортика"
            }
        });
    });
})(jQuery);