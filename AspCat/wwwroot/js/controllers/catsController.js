var CatsController = function () {
    var link;

    var init = function (container) {
        $(container).on('click', '.js-delete-cat', deleteCat);
    };

    var callCatDeleteApi = function () {
        $.ajax({
            url: '/api/cats/' + link.attr('data-cat-id'),
            method: 'DELETE'
        })
        .done(function () {
            link.parents("li").fadeOut(function () {
                $(this).remove();
            });
        })
        .fail(function () {
            alert('Something failed!');
        });
    };

    var deleteCat = function (e) {
        link = $(e.target);
        bootbox.dialog({
            message: "Are you sure you want to delete this cat?",
            buttons: {
                cancel: {
                    label: "No",
                    className: "btn-default"
                },
                confirm: {
                    label: "Yes",
                    className: "btn-danger",
                    callback: callCatDeleteApi
                }
            }
        });
    };

    return {
        init: init
    };
}();