// navbar.js

function sliderMenu() {
    $(document).ready(function () {
        $('.sub-menu ul').hide();
        $(".sub-menu a").click(function (e) {
            e.preventDefault(); // Prevent the default behavior of the anchor link
            var submenu = $(this).parent(".sub-menu").children("ul");

            if (submenu.is(":visible")) {
                submenu.slideUp("fast");
                $(this).find(".right").removeClass("fa-caret-up").addClass("fa-caret-down");
            } else {
                submenu.slideDown("fast");
                $(this).find(".right").removeClass("fa-caret-down").addClass("fa-caret-up");
            }
        });
    });
}
