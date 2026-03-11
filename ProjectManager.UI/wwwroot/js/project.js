let deleteId;
//usuwanie pozycji z zakresu
$(document).on("click", ".open-delete-position-confirm", function () {
    deleteId = $(this).data("position");
    $('#modal-confirm-delete-position').modal('show');
    $('.loading-overlay').show();

});
$(document).on("click", "#modal-confirm-delete-position-btn", function () {
    const errorMessage = 'Błąd. Nie udało się usunąć wybranej pozycji.';
    $.ajax({
        type: "POST",
        url: "/Project/DeletePosition",
        data: { id: deleteId },
        success: function (data) {
            console.log(data);
            if (data.success) {
                $('[data-pos-id="' + deleteId + '"]').remove();
                $('#modal-confirm-delete-position').modal('hide');
                toastr.success('Dane zostały zaktualizowane.')
            }
            else
                toastr.error(errorMessage);
            $('.loading-overlay').hide();
        },
        dataType: "json"
    });
});

//usuwanie komentarza do pozycji
$(document).on("click", ".open-delete-post-confirm", function () {
    deleteId = $(this).data("post");
    $('#modal-confirm-delete-post').modal('show');
    $('.loading-overlay').show();

});
$(document).on("click", "#modal-confirm-delete-post-btn", function () {
    const errorMessage = 'Błąd. Nie udało się usunąć wybranego komentarza.';
    $.ajax({
        type: "POST",
        url: "/Project/DeletePost",
        data: { id: deleteId },
        success: function (data) {
            console.log(data);
            if (data.success) {
                $('[data-post-id="' + deleteId + '"]').remove();
                $('#modal-confirm-delete-post').modal('hide');
                toastr.success('Dane zostały zaktualizowane.')
            }
            else
                toastr.error(errorMessage);
            $('.loading-overlay').hide();
        },
        dataType: "json"
    });
});

//lazy loading, pobieranie tylko w pierwszym wywołaniu
$(document).on("show.bs.collapse", ".accordion-collapse", function () {
    const collapse = $(this);
    const wrapper = collapse.closest(".position-wrapper");
    const posId = wrapper.data("pos-id");

    const postsContainer = collapse.find(".posts-container");

    // Jeśli już załadowane — nie pobieramy ponownie
    if (postsContainer.data("loaded")) return;

    $.ajax({
        url: `/Project/PositionPosts?id=${posId}`,
        type: "GET",
        success: function (html) {
            postsContainer.html(html);
            postsContainer.data("loaded", true);
        },
        error: function () {
            postsContainer.html("<div class='text-danger'>Błąd ładowania komentarzy.</div>");
        }
    });
});

$(document).on("click", ".open-add-position-modal", function () {
    var scopeId = $(this).data("scope");
    $.ajax({
        url: "/Project/AddPosition",
        type: "GET",
        data: { id: scopeId },
        success: function (result) {
            $("#modal-container").html(result);
            $("#modal-add-position").modal('show');
        }
    });
});

$(document).on("submit", "#add-position-form", function (e) {
    e.preventDefault(); // zatrzymanie submitu
    const errorMessage = "Błąd. Nie udało się dodać nowej pozycji.";
    $.ajax({
        type: "POST",
        url: "/Project/AddPosition",
        data: $(this).serialize(),
        success: function (data) {
            if (data.success) {
                toastr.success('Dane zostały zaktualizowane.');
                $('#modal-add-position').modal('hide');
                reloadScope(data.scopeId);
            } else {
                toastr.error(errorMessage);
            }
        },
        dataType: "json"
    });
});

$(document).on("click", ".open-edit-position-modal", function () {
    var positionId = $(this).data("position");
    $.ajax({
        url: "/Project/EditPosition",
        type: "GET",
        data: { id: positionId },
        success: function (result) {
            $("#modal-container").html(result);
            $("#modal-edit-position").modal('show');
        }
    });
});

$(document).on("submit", "#edit-position-form", function (e) {
    e.preventDefault(); // zatrzymanie submitu
    const errorMessage = "Błąd. Nie udało się zaktualizować danych.";
    $.ajax({
        type: "POST",
        url: "/Project/EditPosition",
        data: $(this).serialize(),
        success: function (data) {
            if (data.success) {
                toastr.success('Dane zostały zaktualizowane.');
                $('#modal-edit-position').modal('hide');
                reloadScope(data.scopeId);
            } else {
                toastr.error(errorMessage);
            }
        },
        dataType: "json"
    });
});

$(document).on('change', '.form-check-input', function () {
    const isCompleted = $(this).is(':checked');
    const posId = $(this).data('pos-id');
    $.ajax({
        url: '/Project/FinishPosition',
        type: 'POST',
        data: {
            id: posId,
            isCompleted: isCompleted
        },
        success: function (response) {
            toastr.success('Zaktualizowano status');
        },
        error: function () {
            toastr.error('Błąd podczas aktualizacji statusu');
        }
    });
});

// kolorowanie i przekreślanie
$(document).on("change", ".isCompletedCb", function () {
    const posId = $(this).data("pos-id");
    const isChecked = $(this).is(":checked");

    const title = $(`.position-title[data-pos-id='${posId}']`);
    const wrapper = $(`.position-wrapper[data-pos-id='${posId}']`);

    if (isChecked) {
        title.addClass("completed");
        wrapper.addClass("completed");
    } else {
        title.removeClass("completed");
        wrapper.removeClass("completed");
    }
});

// ładowanie postów przy otwarciu accordionu
$(document).on("shown.bs.collapse", ".accordion-collapse", function () {
    const posId = $(this).attr("id").replace("pos-collapse-", "");
    const target = `#posts-${posId}`;
    loadPosts(posId, target);
});

$(document).on("click", ".open-add-post-modal", function () {
    const positionId = $(this).data("position");
    $.ajax({
        url: "/Project/AddPositionPost",
        type: "GET",
        data: { id: positionId },
        success: function (result) {
            $("#modal-container").html(result);
            $("#modal-add-position-post").modal('show');
        }
    });
});

$(document).on("submit", "#add-position-post-form", function (e) {
    e.preventDefault();
    const errorMessage = "Błąd. Nie udało się dodać komentarza.";
    const posId = $("#position-id").val();
    const target = `#posts-${posId}`;
    $.ajax({
        type: "POST",
        url: "/Project/AddPositionPost",
        data: $(this).serialize(),
        success: function (data) {
            if (data.success) {
                toastr.success('Dane zostały zaktualizowane.');
                $('#modal-add-position-post').modal('hide');
                loadPosts(posId, target);
            } else {
                toastr.error(errorMessage);
            }
        },
        error: function (data) {
            toastr.error(errorMessage);
        },
        dataType: "json"
    });
});


$('#modal-add-position').on('hidden.bs.modal', function () {
    $(this).remove(); // usuwa modal z DOM po zamknięciu
});

$('#modal-edit-position').on('hidden.bs.modal', function () {
    $(this).remove(); // usuwa modal z DOM po zamknięciu
});

$('#modal-add-position-post').on('hidden.bs.modal', function () {
    $(this).remove(); // usuwa modal z DOM po zamknięciu
});


function loadPosts(posId, target) {
    $.ajax({
        url: "/Project/PositionPosts",
        type: "GET",
        data: { id: posId },
        success: function (result) {
            $(target).html(result);
        }
    });
}

function reloadScope(scopeId) {
    const collapse = $(`#collapse-scope-${scopeId}`);
    const scope = collapse.closest(".accordion-item");
    const wasOpen = collapse.hasClass("show");
    $.ajax({
        url: "/Project/GetScope",
        type: "GET",
        data: { id: scopeId },
        success: function (html) {
            const newScope = $(html);
            scope.replaceWith(newScope);
            $(collapse).html(html);
            if (wasOpen) {
                const newCollapse = $(`#collapse-scope-${scopeId}`);
                newCollapse.addClass("show");
                newCollapse
                    .prev(".accordion-header")
                    .find("button")
                    .removeClass("collapsed")
                    .attr("aria-expanded", "true");
            }
        }
    });
}