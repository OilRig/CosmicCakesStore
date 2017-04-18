 (function ($) {

            $.validator.addMethod("emailRegx", function (value, element, regexpr) {
                return regexpr.test(value);
            }, "<p style='color:red;'>Ваш email не похож на example@domain.ru</p>");

            $("#subscribeForm").validate({
                rules: {
                    Email: {
                        emailRegx: /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$|^$/,
                        required: true
                    }
                },
                messages: {
                    Email: {
                        required: "<p style='color:red;'>А куда же нам отправлять письма?</p>"
                    }
                }
            });
        })
        (jQuery);
