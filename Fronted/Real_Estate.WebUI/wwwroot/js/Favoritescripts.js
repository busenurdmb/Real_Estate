$(document).ready(function () {
    var userId = $('#UserId').val(); // Kullanıcı ID'sini HTML'den al
    var favoritePropertyIds = [];

    // Favori ilanları almak için API çağrısı
    $.getJSON(`https://localhost:7028/api/Favorite/GetUserFavorites/${userId}`, function (data) {
        favoritePropertyIds = data.map(item => item.propertyId); // PropertyId'leri çıkart

        // Her ilan için favori kontrolü yap
        $('.property-card').each(function () {
            var propertyId = $(this).data('id');
            if (favoritePropertyIds.includes(propertyId)) {
                $(this).find('.favorite-icon').removeClass('la-star-o').addClass('la-star').css('color', 'gold');
                $(this).find('.btn-favorite').addClass('active').text('Favorilerden Çıkar');
            }
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Favori ilanları getirme başarısız:", textStatus, errorThrown);
    });

    // Favorilere Ekle / Favorilerden Çıkar butonuna tıklama olayını yönet
    $('.btn-favorite').on('click', function (e) {
        e.preventDefault(); // Sayfanın yenilenmesini engelle
        var propertyId = $(this).data('id');
        var $this = $(this);
        var $icon = $this.closest('.property-card').find('.favorite-icon');

        if ($this.hasClass('active')) {
            // Favorilerden çıkarma işlemi
            $.post(`/User/Favorite/RemoveFavorite/${propertyId}`, function () {
                $this.removeClass('active');
                $icon.removeClass('la-star').addClass('la-star-o').css('color', 'grey');
                $this.text('Favorilere Ekle');
            }).fail(function (jqXHR, textStatus, errorThrown) {
                console.error("Favorilerden çıkarma başarısız:", textStatus, errorThrown);
            });
        } else {
            // Favorilere ekleme işlemi
            $.post(`/User/Favorite/CreateFavorite/${propertyId}`, function () {
                $this.addClass('active');
                $icon.removeClass('la-star-o').addClass('la-star').css('color', 'gold');
                $this.text('Favorilerden Çıkar');
            }).fail(function (jqXHR, textStatus, errorThrown) {
                console.error("Favorilere ekleme başarısız:", textStatus, errorThrown);
            });
        }
    });
});
