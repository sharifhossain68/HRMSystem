function adjustCollapseView() {
    var desktopView = $(document).width();
    if (desktopView >= "768") {
        $("#collapseOne a[data-toggle]").attr("data-toggle", "");
        $("#collapseOne.collapse").addClass("in").css("height", "auto")

        $("#collapseTwo a[data-toggle]").attr("data-toggle", "");
        $("#collapseTwo.collapse").addClass("in").css("height", "auto")

        $("#collapseThree a[data-toggle]").attr("data-toggle", "");
        $("#collapseThree.collapse").addClass("in").css("height", "auto")

        $("#collapseFour a[data-toggle]").attr("data-toggle", "");
        $("#collapseFour.collapse").addClass("in").css("height", "auto")

    } else {
        $("#collapseOne a[data-toggle]").attr("data-toggle", "collapse");
        $("#collapseOne.collapse").removeClass("in").css("height", "0")
        $("#collapseOne .collapse:first").addClass("in").css("height", "auto")


        $("#collapseTwo a[data-toggle]").attr("data-toggle", "collapse");
        $("#collapseTwo.collapse").removeClass("in").css("height", "0")
        $("#collapseTwo .collapse:first").addClass("in").css("height", "auto")

        $("#collapseThree a[data-toggle]").attr("data-toggle", "collapse");
        $("#collapseThree.collapse").removeClass("in").css("height", "0")
        $("#collapseThree .collapse:first").addClass("in").css("height", "auto")

        $("#collapseFour a[data-toggle]").attr("data-toggle", "collapse");
        $("#collapseFour.collapse").removeClass("in").css("height", "0")
        $("#collapseFour .collapse:first").addClass("in").css("height", "auto")
    }
}

$(function () {
    adjustCollapseView();
    $(window).on("resize", function () {
        adjustCollapseView();
    });
});