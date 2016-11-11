/// <reference path="../App.js" />

(function () {
    "use strict";
    var xhr;

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            $('#get-data-from-selection').click(getDataFromSelection);
        });
    };

    // Reads data from current document selection and displays a notification
    function getDataFromSelection() {
        Office.context.document.getSelectedDataAsync(Office.CoercionType.Text,
            function (result) {
                if (result.status === Office.AsyncResultStatus.Succeeded) {
                    app.showNotification('The selected text is:', '"' + result.value + '"');
                } else {
                    app.showNotification('Error:', result.error.message);
                }
            }
        );
    }

    function makeServiceRequest() {
        $.support.cors = true;
        $.ajax({
            type: "GET",
            url: "https://us-staging.gomercatus.com/rest/projectDetail/assumptions/12084",
            dataType: "json",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8",
                "Authorization": "Bearer 7b78fb60-2af3-4201-8522-43974f601f7d"
            },
            success: function (response) {
                app.showNotification("success");
                if (response.data != null) {
                    var val = response.data.liteAssumptionVOs[0]
                    //foreach(var item in val) {
                    app.showNotification(val.aid);
                    //});
                } else {
                    app.showNotification("no response");
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                app.showNotification("failure");
                //https://jsonplaceholder.typicode.com/posts/1
            }
        }).then(function (data) {
            app.showNotification("data");
            console.log(data);
        });
        // xhr = new XMLHttpRequest();

        //// Update the URL to point to your service location.
        // xhr.open("GET", "https://us-staging.gomercatus.com/rest/projectDetail/assumptions/12084", true);

        //xhr.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        //xhr.setRequestHeader("Authorization", "Bearer 7b78fb60-2af3-4201-8522-43974f601f7d");

        //xhr.onreadystatechange = requestReadyStateChange;

        //// Translate the attachment details into a form easily understood by WCF.
        ////for (i = 0; i < Office.context.mailbox.item.attachments.length; i++) {
        ////    serviceRequest.attachments[i] = JSON.parse(JSON.stringify(Office.context.mailbox.item.attachments[i].$0_0));
        ////}

        //// Send the request. The response is handled in the 
        //// requestReadyStateChange function.
        //xhr.send();


    }


    // Handles the response from the JSON web service.
    function requestReadyStateChange() {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                var response = JSON.parse(xhr.responseText);
                if (!response.isError) {
                    // show successfull message
                } else {
                    //show error message
                }
            } else {
                if (xhr.status == 404) {
                    alert("Service not found");
                } else {
                    alert("Unknown error");
                }
            }
        }
    }

    // Shows the service response.
    function showResponse(response) {
        showToast("Service Response", "Attachments processed: " + response.attachmentsProcessed);
    }

    // Displays a message for 10 seconds.
    function showToast(title, message) {

        $('#errorMsg').text(title + " => " + message);

    }
}
)();

