$(document).ready(function () {
    $("ul.dropdown-menu input[type=checkbox]").each(function () {
        $(this).change(function () {
            var line = "";
            $("ul.dropdown-menu input[type=checkbox]").each(function () {
                if ($(this).is(":checked")) {
                    line += $("+ span", this).text() + ";";
                }
            });
            $("input.form-control").val(line);
        });
    });
});