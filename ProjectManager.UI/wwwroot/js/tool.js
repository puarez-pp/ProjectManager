
function renumberToolsTable() {
    $("#toolsTable tbody tr").each(function (index) {
        $(this).find(".row-number").text(index + 1);
    });
}

// Usuwanie
        $(document).on("click", ".open-delete-tool-confirm", function () {
            let id = $(this).data("id");
            $("#DeleteToolId").val(id);
            $("#deleteToolModal").modal("show");
        });

        $(document).on("click", "#btnConfirmDeleteTool", function () {
            console.log("klik");

            let id = $("#DeleteToolId").val();
            $.ajax({
                type: "POST",
                url: "/Tool/DeleteTool",
                data: { id: id },
                success: function (data) {
                    if (data.success) {
                        $('[data-id="' + id + '"]').remove();
                        $("#deleteToolModal").modal("hide");
                        toastr.success('Urządzenie zostało usunięte.');
                        
                    } else {
                        toastr.error('Błąd przy usuwaniu urządzenia');
                    }
                },
                dataType: "json"
            });
        });

        // wypożycz
        $(document).on("click", ".open-rent-tool-confirm", function () {
            let id = $(this).data("id");
            $("#RentToolId").val(id);
            $("#rentToolModal").modal("show");
        });

        $(document).on("click", "#confirmRentTool", function () {
            let id = $("#RentToolId").val();
            $.ajax({
                type: "POST",
                url: "/Tool/RentTool",
                data: { id: id },
                success: function (data) {
                    if (data.success) {
                        $("#toolsContainer")
                        .load("/Tool/Tools #toolsTable", function () { 
                            renumberToolsTable();
                            $("#rentToolModal").modal("hide"); 
                            toastr.success("Urządzenie wypożyczone."); 
                        });
                    } else {
                        toastr.error('Błąd, nie udało się potwierdzić wypożyczenia');
                    }
                },
                dataType: "json"
            });
        });

                        // zwróć
           $(document).on("click", ".open-return-tool-confirm", function () {
               let id = $(this).data("id");
               $("#RentToolId").val(id);
               $("#returnToolModal").modal("show");
           });

           $(document).on("click", "#confirmReturnTool", function () {
               let id = $("#RentToolId").val();
               $.ajax({
                   type: "POST",
                   url: "/Tool/ReturnTool",
                   data: { id: id },
                   success: function (data) {
                       if (data.success) {
                           $("#userContainer")
                           .load("/Tool/UserRents #userTable", function () {
                               $("#returnToolModal").modal("hide");
                               toastr.success("Urządzenie zwrócone.");
                           });
                       } else {
                           toastr.error('Błąd, nie udało się zaktualizować danych');
                       }
                   },
                   dataType: "json"
               });
           });