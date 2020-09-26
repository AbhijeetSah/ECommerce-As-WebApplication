


    function MakeAutocomplete(field,flag) {
        $(function () {
            //debugger;
            $(field).autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/StaticData/LoadAutocomplete",
                        //url: url,
                        type: "POST",
                        dataType: "json",
                        data: { type: flag, param: $(field).val() },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.text, value: item.text };
                            }))
                        }
                    })
                }
            });
        })
    }



function loadCartCount() {
    debugger;
    setInterval(function () {
        //var xhttp = new XMLHttpRequest();
        //xhttp.onreadystatechange = function () {
        //    if (this.readyState == 4 && this.status == 200) {
        //        document.getElementById("cartCount").innerHTML = this.responseText;
        //    }
        //}
        //xhttp.open("GET", "UserCart", true);
        //xhttp.send();
        $.get("/UserCart/CartItemCount",
            function (data, status) {
                
                data = parseInt(data);
                //quantity.max = data;
                document.getElementById("cartCount").innerHTML = data;
            });
    }, 3000);
}
function loadNotificationCount() {
    setInterval(function () {
        //var xhttp = new XMLHttpRequest();
        //xhttp.onreadystatechange = function () {
        //    if (this.readyState == 4 && this.status == 200) {
        //        document.getElementById("cartCount").innerHTML = this.responseText;
        //    }
        //}
        //xhttp.open("GET", "UserCart", true);
        //xhttp.send();
        $.get("/User/NotificationCount",
            function (data, status) {
                
                data = parseInt(data);
                //quantity.max = data;
                document.getElementById("notificationCount").innerHTML = data;
            });
    }, 1000);
}