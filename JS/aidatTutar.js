function Degistir(tab_id) {

    var aidatTutari = document.getElementById('aidatTutari_' + tab_id);

    if (aidatTutari.value != '') {
        var dataBilgi = {};
        dataBilgi.aidat = { ID: tab_id, aidatTutari: aidatTutari.value};
        $.ajax({
            url: '/Setting/Degisim',
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
