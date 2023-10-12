﻿(function ($) {
    "use strict";

    // Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();


    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1500, 'easeInOutExpo');
        return false;
    });


    // Sidebar Toggler
    $('.sidebar-toggler').click(function () {
        $('.sidebar, .content').toggleClass("open");
        return false;
    });


    // Progress Bar
    $('.pg-bar').waypoint(function () {
        $('.progress .progress-bar').each(function () {
            $(this).css("width", $(this).attr("aria-valuenow") + '%');
        });
    }, { offset: '80%' });



    // Calendar
    $('#calender').datetimepicker({
        inline: true,
        format: 'L',
        locale: 'pt-br'
    });


    // Testimonials carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        items: 1,
        dots: true,
        loop: true,
        nav: false
    });


    // Worldwide Sales Chart
    var ctx1 = $("#worldwide-sales").get(0).getContext("2d");
    var myChart1 = new Chart(ctx1, {
        type: "bar",
        data: {
            labels: ["2016", "2017", "2018", "2019", "2020", "2021", "2022"],
            datasets: [{
                label: "SP",
                data: [15, 30, 55, 65, 60, 80, 95],
                backgroundColor: ["#2b7e1f"]
            },
            {
                label: "RJ",
                data: [8, 35, 40, 60, 70, 55, 75],
                backgroundColor: ["#78be66"]
            },
            {
                label: "BH",
                data: [12, 25, 45, 55, 65, 70, 60],
                backgroundColor: ["#c4ffad"]
            }
            ]
        },
        options: {
            responsive: true
        }
    });



    // Salse & Revenue Chart
    var ctx2 = $("#salse-revenue").get(0).getContext("2d");
    var myChart2 = new Chart(ctx2, {
        type: "line",
        data: {
            labels: ["2016", "2017", "2018", "2019", "2020", "2021", "2022"],
            datasets: [{
                label: "Faltas",
                data: [15, 30, 55, 45, 70, 65, 85],
                backgroundColor: ["#78be66"],
                fill: true
            },
            {
                label: "Presenças",
                data: [99, 135, 170, 130, 190, 180, 270],
                backgroundColor: ["#c4ffad"],
                fill: true
            }
            ]
        },
        options: {
            responsive: true
        }
    });


})(jQuery);

