
function BodyClickCloseNav() {
    $("html, body").on("click", function (e) {
        var target = $(e.target);
        if (!target.is("#navMainLink") && !target.is("#navMainIcon") && !target.is("#chkNavClose")) {
            var isChecked = $("#chkNavClose").is(":checked");
            if (isChecked) {
                $("#chkNavClose").click(function (event) {
                    event.stopPropagation();
                });
                $("#chkNavClose").trigger("click");
            }
        }
    });
}

function SetElementFocus(element) {
    if (element instanceof HTMLElement) {
        element.focus();
    }
}

function SetElementFocusWithId(inputId) {
    var id = "#" + inputId;
    $(id).focus();
}

function RemoveMessageInfoBox() {
    $("#messageInfoBox").hide();
}

function ShowMessageInfoBox() {
    $("#messageInfoBox").hide(function () {
        $("#messageInfoBox").show();
        setTimeout(function () {
            $("#messageInfoBox").hide();
        }, 20000);
    });
}

function SetInputEmpty(className) {
    var selector = "." + className;
    $(selector).val("");
}

function DropdownSelectNullValue(element) {
    $(element).val("");
}