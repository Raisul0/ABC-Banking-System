$(function () {

    $('#TransfersveClk').click(function () {
        
            var amount= $('#amount').val();
            alert(amount);
            if (amount > 0 && amount < user[0].User_balance) {

                var User1 = {
                    User_Name: localStorage.getItem("username"),
                    User_acc_no: localStorage.getItem("accountNo"),
                    User_balance: user[0].User_balance-amount
                }

                //var User2 = {
                //    User_Name: $('#Tname').val(),
                //    User_acc_no: $('#Tid').val(),
                //}
                

                //$.ajax({
                //    url: 'http://localhost:48951/api/Users' + localStorage.getItem("accountNo"),
                //    method: 'Put',
                //    headers: {
                //        Authorization: 'Basic ' + credential
                //    },
                //    data:User1,
                //    complete: function (xmlhttp) {

                //        alert(xmlhttp.status);

                //        if (xmlhttp.status == 201) {
                //            $('#msg').html("Successfully Updated");
                //        }
                //        else {
                //            $('#msg').html(xmlhttp.status + ": " + xmlhttp.statusText);
                //        }
                //    }
        
                //});

            } else {

            }
     });
});