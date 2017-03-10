(function ($) {
    Date.prototype.addDays = function (days) {
        var dat = new Date(this.valueOf());
        dat.setDate(dat.getDate() + days);
        return dat;
    }
    $(document).ready(function () {

        var dateToday = new Date();
        $('#datePicker').datepicker({
            minDate: dateToday.addDays(2)
        });
    });
})(jQuery);