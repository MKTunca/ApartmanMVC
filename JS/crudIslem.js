function UyeDegistir(tablo_id) {

    var ad = document.getElementById('adsoyad_' + tablo_id);
    var daire = document.getElementById('daire_' + tablo_id);
    var oturan = document.getElementById('oturan_' + tablo_id);
    var gsm = document.getElementById('gsm_' + tablo_id);
    var tarih = document.getElementById('tarih_' + tablo_id);
    if ((ad.value != '') && (daire.value != '') && (gsm.value != '')) {
        var dataBilgi = {};
        dataBilgi.uyedeg = { ID: tablo_id, ad: ad.value, daire: daire.value, oturan: oturan.value, gsm: gsm.value, tarih: tarih.value };
        $.ajax({
            url: '/Uyeler/Degisim',
            data: dataBilgi,
            type: 'POST',
            success: function (sonuc) {
                bootbox.alert('Bilgileriniz güncellendi');
            },
            error: function () {
            }
        });
    }
    else {
        bootbox.alert('Alanları boş bırakmayınız!');
    }
}
function UyeSil(id) {

    bootbox.confirm('Müşteriyi silmek istiyor musunuz?', function (cevap) {

        if (cevap) {

            $.ajax({
                url: '/Uyeler/Sil/' + id,
                type: 'POST',
                success: function (sonuc) {

                    bootbox.alert(sonuc);
                    $('#tablo_' + id).remove();
                },
                error: function () {

                }
            });

        }
        else {
            bootbox.alert('Silme işlemi iptal edildi.');
        }

    })
}