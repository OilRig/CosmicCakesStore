(function ($) {
    $(document).ready(function () {
        $("#feedbackForm").validate({
            rules: {
                Author: "required",
                Content: "required"
            },
            messages: {
                Author: "<p style='color:red;'>А как Вас зовут?</p>",
                Content: "<p style='color:red;'>Мы грустим,когда Вы ничего не пишете :(</p>"
            }
        });
    });
})(jQuery);