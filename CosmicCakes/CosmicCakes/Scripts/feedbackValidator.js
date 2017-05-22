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
                    emailRegx: /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$|^$/,
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