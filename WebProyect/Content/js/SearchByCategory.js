$(document).ready(function () {
    $("#searchBtn").click(function () {
        var cat = $("#category").val();
        
        var sel = $("#categorySelect option");

        for (var i = 0; i < sel.length; i++) {
            var opt = sel[i];

            if (opt.text === cat) {
                $("#idCategory").val(opt.value);
                
                $("#songsResult").empty();
                $.ajax({
                    type: 'POST',
                    url: $("#category").data('url'),
                    dataType: 'json',
                    data: { idCategory: String($("#idCategory").val()) },
                    success: function (songs) {
                        if (songs.length > 0)
                            $.each(songs, function (i, song) {
                                var trId = "trResult".concat(i);
                                $("#songsResult").append('<tr id="'.concat(trId).concat('">'));
                                $("#".concat(trId)).append('<th scope="col">'.concat(song.Track.Name).concat('</th>'));
                                $("#".concat(trId)).append('<th scope="col">'.concat(song.Track.Album.Name).concat('</th>'));
                                var artists = new Array();
                                $.each(song.Track.Album.Artists, function (i, art) {
                                    artists.push(art.Name);
                                });
                                $("#".concat(trId)).append('<th scope="col">'.concat(artists.join(', ')).concat('</th>'));
                                $("#songsResult").append('</tr>');
                            });
                    }
                    //error: function (request, errorType, errorMessage) {
                    //    alert(errorMessage);
                    //}
                });
                return;
            }
        }

        $("#songsResult").empty();
        $("#validateCategory").empty();
        $("#validateCategory").append("<span id='validateError'>Please enter a valid category</span>");
    });

    $("#category").keyup(function () {
        $("#validateCategory").empty();
    });
});