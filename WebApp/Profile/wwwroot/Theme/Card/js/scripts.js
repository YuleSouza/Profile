/*  Preloader */

$(window).on("load", function () {
    var preload = $('.preloader');
    preload.find('.spinner').fadeOut(function () {
        preload.fadeOut();
    });
});

$(function () {
    'use strict';

    /* Vars */
    var width = $(window).width();
    var height = $(window).height();

    /*	Header Menu Desktop */
    var container = $('.container');
    var card_items = $('.card-inner');
    var animation_in = container.data('animation-in');
    var animation_out = container.data('animation-out');

    $('.top-menu').on('click', 'a', function () {

        /* vars */
        var id = $(this).attr('href');
        var h = parseFloat($(id).offset().top);
        var card_item = $(id);
        var menu_items = $('.top-menu li');
        var menu_item = $(this).closest('li');
        var d_lnk = $('.lnks .lnk.discover');

        /* if desktop */
        if (!menu_item.hasClass('active') & (width > 1023) & $('#home-card').length) {

            /* close card items */
            menu_items.removeClass('active');
            container.find(card_items).removeClass('animated ' + animation_in);

            if ($(container).hasClass('opened')) {
                container.find(card_items).addClass('animated ' + animation_out);
            }

            /* open card item */
            menu_item.addClass('active');
            container.addClass('opened');
            container.find(card_item).removeClass('animated ' + animation_out);
            container.find(card_item).addClass('animated ' + animation_in);

            $(card_items).addClass('hidden');

            $(card_item).removeClass('hidden');
            $(card_item).addClass('active');
        }

        /* if mobile */
        if ((width < 1024) & $('#home-card').length) {

            /* scroll to section */
            $('body,html').animate({
                scrollTop: h - 76
            }, 800);
        }

        return false;
    });

    /* Smoothscroll */

    if ((width < 1024) & $('#home-card').length) {
        $(window).on('scroll', function () {
            var scrollPos = $(window).scrollTop();
            $('.top-menu ul li a').each(function () {
                var currLink = $(this);
                var refElement = $(currLink.attr("href"));
                if (refElement.offset().top - 76 <= scrollPos) {
                    $('.top-menu ul li').removeClass("active");
                    currLink.closest('li').addClass("active");
                }
            });
        });
    }

    /* slimScroll */

    if (width > 1024) {
        $('.card-inner .card-wrap').slimScroll({
            height: '570px'
        });
    }

    /* Hire Button */

    $('.lnks').on('click', '.lnk.discover', function () {
        $('.top-menu a[href="#contacts-card"]').trigger('click');
    });

    /* Initialize masonry items */

    var $container = $('.grid-items');

    $container.imagesLoaded(function () {
        $container.multipleFilterMasonry({
            itemSelector: '.grid-item',
            filtersGroupSelector: '.filter-button-group',
            percentPosition: true,
            gutter: 0
        });
    });

    /* 12. Initialize masonry filter */

    $('.filter-button-group').on('change', 'input[type="radio"]', function () {
        if ($(this).is(':checked')) {
            $('.f_btn').removeClass('active');
            $(this).closest('.f_btn').addClass('active');
        }

        /* popup image */
        $('.has-popup-image').magnificPopup({
            type: 'image',
            closeOnContentClick: true,
            mainClass: 'popup-box',
            image: {
                verticalFit: true
            }
        });

        /* popup video */
        $('.has-popup-video').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false,
            disableOn: 0,
            mainClass: 'popup-box'
        });

        /* popup music */
        $('.has-popup-music').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false,
            mainClass: 'popup-box'
        });

        /* popup media */
        $('.has-popup-media').magnificPopup({
            type: 'inline',
            overflowY: 'auto',
            closeBtnInside: true,
            mainClass: 'popup-box-inline'
        });
    });

    /* popup image */
    $('.has-popup-image').magnificPopup({
        type: 'image',
        closeOnContentClick: true,
        mainClass: 'popup-box',
        image: {
            verticalFit: true
        }
    });

    /* popup video */
    $('.has-popup-video').magnificPopup({
        disableOn: 700,
        type: 'iframe',
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false,
        disableOn: 0,
        mainClass: 'popup-box'
    });

    /* popup music */
    $('.has-popup-music').magnificPopup({
        disableOn: 700,
        type: 'iframe',
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false,
        disableOn: 0,
        mainClass: 'popup-box'
    });

    /* popup media */
    $('.has-popup-media').magnificPopup({
        type: 'inline',
        overflowY: 'auto',
        closeBtnInside: true,
        mainClass: 'popup-box-inline',
        callbacks: {
            open: function () {
                $('.popup-box-inline .popup-box').slimScroll({
                    height: height + 'px'
                });
            }
        }
    });

    /* Validate Comment Form */

    $("#comment-form").validate({

        rules: {
            title: {
                required: true
            },
            comment: {
                required: true
            },
            hiddenRecaptcha: {
                required: function () {
                    if (grecaptcha.getResponse() == '') {
                        return true;
                    } else {
                        return false;
                    }
                }
            }
        },
        success: "valid",
        submitHandler: function () {

            $.ajax({
                url: '../Home/PutComment',
                type: 'post',
                dataType: 'json',
                data: {
                    'Title': $("#comment-form").find('input[name="title"]').val(),
                    'CommentDescription': $("#comment-form").find('textarea[name="commentDescription"]').val()
                },
                beforeSend: function () {
                    var preload = $('.preloader');
                },
                complete: function () {
                    $('#comment-form').fadeOut();
                    $('.alert-success').delay(1000).fadeIn();
                    $('.alert-success').delay(5000).fadeOut();
                    $('#comment-form').delay(5000).fadeIn();
                },
                success: function (data) {

                }
            });
        }
    });

    /* Validate Contact Form */

    $("#contact-form").validate({

        rules: {
            name: {
                required: true
            },
            message: {
                required: true
            },
            email: {
                required: true,
                email: true
            },
            hiddenRecaptcha: {
                required: function () {
                    if (grecaptcha.getResponse() == '') {
                        return true;
                    } else {
                        return false;
                    }
                }
            }
        },
        success: "valid",
        submitHandler: function () {
            $.ajax({
                url: '../Home/PutContact',
                type: 'post',
                dataType: 'json',
                data: {
                    'Name': $("#contact-form").find('input[name="name"]').val(),
                    'Email': $("#contact-form").find('input[name="email"]').val(),
                    'Message': $("#contact-form").find('textarea[name="message"]').val()
                },
                beforeSend: function () {

                },
                complete: function () {
                    $('#contact-form').fadeOut();
                    $('.alert-success').delay(1000).fadeIn();
                    $('.alert-success').delay(5000).fadeOut();
                    $('#contact-form').delay(5500).fadeIn();
                },
                success: function (data) {

                }
            });
        }
    });

    /* Google Maps */

    if ($('#map').length) {
        initMap();
    }
});


/*	Google Map Options */

function initMap() {
    var myLatlng = new google.maps.LatLng(-23.541773, -46.652054); // <- Your latitude and longitude
    var styles = [
        {
            "featureType": "water",
            "stylers":
                [{
                    "color": "#d8dee9"
                },
                {
                    "visibility": "on"
                }]
        },
        {
            "featureType": "landscape",
            "stylers": [{
                "color": "#eeeeee"
            }]
        }]
    var mapOptions = {
        zoom: 14,
        center: myLatlng,
        mapTypeControl: false,
        disableDefaultUI: true,
        zoomControl: true,
        scrollwheel: false,
        styles: styles
    }

    var map = new google.maps.Map(document.getElementById('map'), mapOptions);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'We are here!'
    });
}