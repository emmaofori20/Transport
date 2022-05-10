/*=========================================================================================
    File Name: wizard-steps.js
    Description: wizard steps page specific js
    ----------------------------------------------------------------------------------------
    Item Name: Modern Admin - Clean Bootstrap 4 Dashboard HTML Template
    Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

// Wizard tabs with numbers setup
$(".number-tab-steps").steps({
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
    onFinished: function (event, currentIndex) {
        alert("Form submitted.");
    }
});

// Wizard tabs with icons setup
$(".icons-tab-steps").steps({
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
    onFinished: function (event, currentIndex) {
        alert("Form submitted.");
    }
});

//from maintenance spareparts
$(".steps").steps({
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
    onFinished: function (event, currentIndex) {
        GetList();
        function GetList() {
            var EditForm = {}
            var RequestId = document.getElementById('RequestId').value;
            var RegistrationNumber = document.getElementById('RegistrationNumber').value;
            var MaintenanceDescription = document.getElementById('projectinput8').value;
            //var List = document.getElementById('List').childElementCount;
            var numberOfInputs = $("#List .form.row .form-group input");

            var List = [];
            debugger;

            //for loop..... please take care and overview
            for (var i = 0; i < numberOfInputs.length; i++) {
                let obj = {};
                let sparename;
                let quantity;
                let amount;
                if (numberOfInputs[i].getAttribute('id') == `spareParts_${i/3}__SparePartName`) {
                    sparename = numberOfInputs[i].value;
                    quantity = numberOfInputs[i + 1].value;
                    amount = numberOfInputs[i + 2].value;
                    i = i + 2;
                } else {

                }
                obj = { "SparePartName": sparename, "Quantity": quantity, "Amount": amount };
                List.push(obj);

            }

            EditForm = {
                "RegistrationNumber": RegistrationNumber,
                "MaintenanceDescription": MaintenanceDescription,
                "RequestId": RequestId,
                "spareParts": List
            }

            console.log('the final list', EditForm);

            $.ajax({
                url: '/Request/EditRequestMaintenance',
                dataType: 'html',
                method: 'post',
                data: { 'model': EditForm, 'RequestId': RequestId },
                success: function (res) {
                    console.log('Sucess');
                    window.location.href = `/Request/RequestSparePartDetails?ListId=${RequestId}`;
                },
                error: function (err) {
                    console.log(err, "err");
                }
            })





        }

        //$("form").submit();
    }
});

// Vertical tabs form wizard setup
$(".vertical-tab-steps").steps({
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    stepsOrientation: "vertical",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
    onFinished: function (event, currentIndex) {
        alert("Form submitted.");
    }
});

// Validate steps wizard

// Show form
var form = $(".steps-validation").show();

$(".steps-validation").steps({
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
    onStepChanging: function (event, currentIndex, newIndex)
    {
        // Allways allow previous action even if the current form is not valid!
        if (currentIndex > newIndex)
        {
            return true;
        }
        // Forbid next action on "Warning" step if the user is to young
        if (newIndex === 3 && Number($("#age-2").val()) < 18)
        {
            return false;
        }
        // Needed in some cases if the user went back (clean up)
        if (currentIndex < newIndex)
        {
            // To remove error styles
            form.find(".body:eq(" + newIndex + ") label.error").remove();
            form.find(".body:eq(" + newIndex + ") .error").removeClass("error");
        }
        form.validate().settings.ignore = ":disabled,:hidden";
        return form.valid();
    },
    onFinishing: function (event, currentIndex)
    {
        form.validate().settings.ignore = ":disabled";
        return form.valid();
    },
    onFinished: function (event, currentIndex)
    {
        alert("Submitted!");
    }
});

// Initialize validation
$(".steps-validation").validate({
    ignore: 'input[type=hidden]', // ignore hidden fields
    errorClass: 'danger',
    successClass: 'success',
    highlight: function(element, errorClass) {
        $(element).removeClass(errorClass);
    },
    unhighlight: function(element, errorClass) {
        $(element).removeClass(errorClass);
    },
    errorPlacement: function(error, element) {
        error.insertAfter(element);
    },
    rules: {
        email: {
            email: true
        }
    }
});


// Initialize plugins
// ------------------------------

// Date & Time Range
$('.datetime').daterangepicker({
    timePicker: true,
    timePickerIncrement: 30,
    locale: {
        format: 'MM/DD/YYYY h:mm A'
    }
});