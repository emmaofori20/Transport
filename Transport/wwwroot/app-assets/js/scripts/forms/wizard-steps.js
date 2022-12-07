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
        finish: 'Submit'
    },
    onFinished: function (event, currentIndex) {
        alert("Form submitted.");
    }
});

////from maintenance spareparts
//$(".steps").steps({
//    headerTag: "h6",
//    bodyTag: "fieldset",
//    transitionEffect: "fade",
//    titleTemplate: '<span class="step">#index#</span> #title#',
//    labels: {
//        finish: 'Submit'
//    },
//    onFinished: function (event, currentIndex) {
//        $("#my_Form").submit();
//    }

//    ///////////////Passing final data to the controller using ajax////////


//    /*alert("Form submitted.");*/

//});


//from maintenance spareparts
$(".mysteps").steps(
    {
    headerTag: "h6",
    bodyTag: "fieldset",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: 'Submit'
    },
        onFinished: function (event, currentIndex) {

            /////////////getting values//////////////////////
            var RequestId = document.getElementById('RequestId').value;
            var RegistrationNumber = $('form #select2').val();
            //var MaintainedBy = $('form #MaintainedBy').val();
            var MaintenanceDescription = $('form #projectinput8').val();
            /////////////getting values//////////////////////

            var SparePartList = [];// for holding spare parts
            var FinalList = {}

            var allSpareParts = $('#List .form-control');

            for (var i = 0; i < allSpareParts.length; i++) {
                let obj = {};
                let sparename;
                let quantity;
                let amount;
                let requestTypeId;
                console.log(allSpareParts[i])

                if (allSpareParts[i].getAttribute("id") == `spareParts_${i / 4}__SparePartName` || allSpareParts[i].getAttribute("id") == "spareParts_0__SparePartName") {
                    sparename = allSpareParts[i].value;
                    quantity = allSpareParts[i + 1].value;
                    amount = allSpareParts[i + 2].value;
                    requestTypeId = allSpareParts[i + 3].value;
                    i = i + 3;
                } else {

                }

                obj = { "SparePartName": sparename, "Quantity": quantity, "Amount": amount,"RequestTypeId": requestTypeId };
                SparePartList.push(obj);
                console.log(obj)
            }

            ////////////PREPARING FINAL LIST////////////////////
            FinalList = {
                "VehicleId": RegistrationNumber,
                "MaintenanceDescription": MaintenanceDescription,
                "RequestId": RequestId,
                "spareParts": SparePartList
            }
            ////////////PREPARING FINAL LIST////////////////////

            console.log("the final list", FinalList);
            ///////////////Passing final data to the controller using ajax////////
            var url = 'Request/EditRequestMaintenance';
            var completeUrl = baseUrl + url;
            $.ajax({
                url: completeUrl,
                dataType: 'html',
                method: 'post',
                data: { 'model': FinalList, 'RequestId': RequestId },
                success: function (res) {
                    console.log('Success');
                    window.location.href = `/Request/RequestSparePartDetails?ListId=${RequestId}`;

                },
                error: function (err) {
                    toastr.error('Your Request list was not sent. Please try again later ', 'Error Occured', { "hideDuration": 3000 });
                }
            })
        }
});


 //Vertical tabs form wizard setup
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

        $('#my_Form').submit();
        
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
        format: 'YYYY/MM/DD h:mm A'
    }
});