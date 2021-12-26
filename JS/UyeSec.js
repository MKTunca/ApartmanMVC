function AdSec() {

    var katID = $('#uyeler').val();

    $.ajax({
        url: "/Calculation/IslemEkle",
        type: "GET",
        dataType: "JSON",
        data: { id: katID },
        success: function (cevap) {


        }


    });
}

