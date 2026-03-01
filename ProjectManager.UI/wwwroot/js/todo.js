let todoToFinishId = null;

$(document).on("click", ".btnFinishTodo", function () {
    todoToFinishId = $(this).data("id");
    $("#finishTodoModal").modal("show");
});

$("#confirmFinishTodo").on("click", function () {
    if (!todoToFinishId) return;

    $.ajax({
        url: '/Todo/FinishTodo',
        type: 'POST',
        data: { id: todoToFinishId },
        success: function (res) {
            if (res.success) {
                const card = $(`.todo-item[data-id='${todoToFinishId}']`);

                // aktualizacja statusu
                card.find(".card-title").addClass("text-decoration-line-through");
                card.find(".badge.bg-warning, .badge.text-dark").removeClass("bg-warning text-dark").addClass("bg-success").text("Zakończone");

                // ukrycie przycisku zakończenia
                card.find(".btnFinishTodo").remove();

                $("#finishTodoModal").modal("hide");
            }
        }
    });
});


// Usuwanie zadania
$(document).on("click", ".btnDeleteTodo", function () {
    let id = $(this).data("id");
    $("#DeleteTodoId").val(id);
    $("#deleteTodoModal").modal("show");
});

$(document).on("click", "#btnConfirmDeleteTodo", function () {
    let id = $("#DeleteTodoId").val();
    $.ajax({
        type: "POST",
        url: "/Todo/DeleteTodo",
        data: { id: id },
        success: function (data) {
            if (data.success) {
                $('[data-id="' + id + '"]').remove();
                $("#deleteTodoModal").modal("hide");
                toastr.success('Zadanie zostało usunięte.');
            } else {
                toastr.error('Błąd przy usuwaniu zadania');
            }
        },
        dataType: "json"
    });
});

// Dodawanie posta

$(document).on("click", ".btnAddPost", function () {
    let id = $(this).data("id");
    $("#PostTodoId").val(id);
    $("#PostBody").val("");
    $("#addPostModal").modal("show");
});

$(document).on("click", "#btnSavePost", function () {

    let todo = {
        TodoId: $("#PostTodoId").val(),
        Body: $("#PostBody").val()
    };
    $.ajax({
        type: "POST",
        url: "/Todo/AddPost",
        data: { command: todo },
        success: function (data) {
            if (data.success) {
                $("#addPostModal").modal("hide");
                
                // przeładuj tylko posty dla jednego todo
                let postsNumber = $("#postsNumber_" + todo.TodoId);
                postsNumber.text("Komentarze: " + data.postsNumber);
                let container = $("#postsContainer_" + todo.TodoId);
                container.data("loaded", false); // reset
                container.hide();

                $.get("/Todo/Posts", { id: todo.TodoId }, function (html) {
                    container.html(html);
                    container.data("loaded", true);
                    container.show();
                });

                toastr.success('Komentarz został dodany.');
            }
        },
        dataType: "json"
    });
});

// Lazy loading postów
$(document).on("click", ".btnTogglePosts", function () {
    let todoId = $(this).data("id");
    let container = $("#postsContainer_" + todoId);

    // Jeśli już załadowane tylko toggle
    if (container.data("loaded")) {
        container.toggle();
        return;
    }

    $.get("/Todo/Posts", { id: todoId }, function (html) {
        container.html(html);
        container.data("loaded", true);
        container.show();
    });
});