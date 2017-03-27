(function ($) {
    $(document).ready(function () {

        $.validator.addMethod("emailRegx", function (value, element, regexpr) {
            return regexpr.test(value);
        }, "<p style='color:red;'>Ваш email не похож на example@domain.ru</p>");

        $("#feedbackForm").validate({
            rules: {
                Author: "required",
                Content: "required",
                Email: {
                    emailRegx: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$ |^$/,
                    required:false
                }
            },
            messages: {
                Author: "<p style='color:red;'>А как Вас зовут?</p>",
                Content: "<p style='color:red;'>Мы грустим,когда Вы ничего не пишете :(</p>"
            }
        });
    });
})(jQuery);