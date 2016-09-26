$(document).ready(function () {
    $('#custom-search-input button')
        .click(function () {
            getVideosForPage(1);
        });

    $(document).on('click', '.videoIframe', function () {
        var videoId = $(this).find('#videoStart').data('youtubeurl');
        if (videoId !== null) {
            var youtubeSrc = 'http://www.youtube.com/embed/' + videoId + '?autoplay=1';
            $('#iframeModal')
                .on('shown.bs.modal',
                    function () {
                        $(this).find('iframe').attr('src', youtubeSrc);
                    });
            $('#iframeModal')
                .on('hide.bs.modal',
                    function () {
                        $(this).find('iframe').attr('src', '');
                    });
            $('#iframeModal').modal('show');
        }
    });


    $('#search')
        .keypress(function(event) {
            if (event.keyCode === 13) {
                $('#custom-search-input button').click();
            }
        });
});

function getVideosForPage(page) {
    var query = $('#custom-search-input #search').val();
    var searchUrl = window.SearchBaseUrl + "?query=" + query + "&page=" + page;
    $('#videoResults').css('opacity', 0.5);
    $.get(searchUrl)
        .success(function (response) {
            currenPageIndex = page;
            $('#videoResults').fadeOut(500,
                function () {
                    $(this).css('opacity', 1).html(response).fadeIn(500);
                });
        });
}

function getVideosForNextPage(maxPage) {
    if (currenPageIndex < maxPage)
        getVideosForPage(currenPageIndex + 1);
}

function getVideosForPrevPage() {
    if (currenPageIndex > 1)
        getVideosForPage(currenPageIndex - 1);
}
