var LikesController = function (likesService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-like", toggleLike);
    };

    var toggleLike = function (e) {
        button = $(e.target);
        var catId = button.attr("data-cat-id");
        if (button.hasClass("text-secondary"))
            likesService.createLike(
                catId, toggleButton, fail);
        else
            likesService.deleteLike(
                catId, toggleButton, fail);
    };

    var toggleButton = function () {
        button
            .toggleClass("text-secondary")
            .toggleClass("text-danger");
    };

    var fail = function () {
        alert("Something failed!");
    };

    return {
        init: init
    };

}(LikesService);