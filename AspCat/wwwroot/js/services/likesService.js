var LikesService = function () {
    var createLike = function (catId, done, fail) {
        $.post("/api/likes", { catId: catId })
            .done(done)
            .fail(fail);
            //.always(console.log("finished"));
    };

    var deleteLike = function (catId, done, fail) {
        $.ajax({
            url: "/api/likes/" + catId,
            type: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createLike: createLike,
        deleteLike: deleteLike
    };
}();