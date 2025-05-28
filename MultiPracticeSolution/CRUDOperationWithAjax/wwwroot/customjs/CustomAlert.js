function WarningMessage(message) {
    Notiflix.Report.warning(
        message,
        "",
        'Okay',
    );
}

function SuccessMessage(message) {
    Notiflix.Report.success(
        message,
        "",
        'Okay',
    );
}

function ErrorMessage(message) {
    Notiflix.Report.failure(
        'Error',
        'message',
        'Okay',
    );
}

function SuccessMessageboxWithCallBankLink(title, message, actionName, controllerName) {
    Notiflix.Report.success(
        title,
        message,
        'OK',
        () => {
            window.location.href = "/" + controllerName + "/" + actionName + "/";
        },
    );
}

function ConfirmationDelteMessage(Id) {
    Notiflix.Confirm.show(
        'Confirmation',
        'Are you sure want to delete?',
        'Yes',
        'No',
        function SayYes() {
            $.ajax({
                type: "POST",
                url: "https://localhost:44386/api/deleteEmployee?EmployeeID=" + Id,
                //contentType: "application/json",
                dataType: "JSON",
                data: {},
                success: function (result) {
                    console.log(result.response.respCode);
                    if (result.response.respCode = "I0000") {
                        SuccessMessageboxWithCallBankLink(result.response.respMessage, "Delete Success", "Index", "Employee");
                    }
                },
                error: function () {
                    console.log("Failed");
                }
            })
        },
        function SayNo() {
            alert('If you say so...');
        }
    )
}
