// Sticky header class
$(window).scroll(function() {
    var winTop = $(window).scrollTop();
    if (winTop >= 30) {
        $("body").addClass("sticky-header");
    } else {
        $("body").removeClass("sticky-header");
    }
});

// Animation Onload
var tl = new TimelineMax();
var tl2 = new TimelineMax();
const controller = new ScrollMagic.Controller();
tl.from(".guide", .5, {
    x: 100,
    opacity: 0
});
tl.from("#btnRegister", .5, {
    x: 100,
    opacity: 0
});

tl.from("#btnEnter", .5, {
    x: 100,
    opacity: 0
});
tl.from(".dialogbox", .5, {
    x: -20,
    opacity: 0
});
tl.from(".imgContent", 1, {
    x: -100,
    opacity: 0
}, "=-1");

const scene2 = new ScrollMagic.Scene({
    triggerElement: ".guide"
})
    .setTween(tl2)
    .addTo(controller);

// Menu dropdown
"use strict";
$('.menu > ul > li:has( > ul)').addClass('menu-dropdown-icon');
//Checks if li has sub (ul) and adds class for toggle icon - just an UI

$('.menu > ul > li > ul:not(:has(ul))').addClass('normal-sub');
//Checks if drodown menu's li elements have anothere level (ul), if not the dropdown is shown as regular dropdown, not a mega menu (thanks Luka Kladaric)

$(".menu > ul > li").hover(function (e) {
    if ($(window).width() > 943) {
        $(this).children("ul").stop(true, false).fadeToggle(150);
        e.preventDefault();
    }
});
//If width is more than 943px dropdowns are displayed on hover

$(".menu > ul > li").click(function () {
    if ($(window).width() <= 943) {
        $(this).children("ul").fadeToggle(150);
    }
});
//If width is less or equal to 943px dropdowns are displayed on click

$(".menu-mobile").click(function () {
    $(".menu > ul").addClass('show-on-mobile');
    $(".overlay").show();
    $(".sc-container.sc-mobile").show();
    $(".closebtn").show();
    $('body').css('height', '100vh').css('overflow-y', 'hidden');
});

function closeNav() {
    $(".menu > ul").removeClass('show-on-mobile');
    $(".closebtn").hide();
    $(".sc-container.sc-mobile").hide();
    $(".overlay").hide();
    $('body').css('height', '').css('overflow-y', '');
}
//when clicked on mobile-menu, normal menu is shown as a list, classic rwd menu story

// Back to top button
(function () {
    $(document).ready(function () {
        return $(window).scroll(function () {
            return $(window).scrollTop() > 200 ? $("#back-to-top").addClass("show") : $("#back-to-top").removeClass("show")
        }), $("#back-to-top").click(function () {
            return $("html,body").animate({
                scrollTop: "0"
            })
        })
    })
}).call(this);

//   carosel
// Carousel Auto-Cycle
$(document).ready(function () {
    $('.carousel').carousel({
        interval: 6000
    })
});

// Animate on images
var _in = function () {
    var t = setTimeout(function () {
        $(this).removeData("timer");
        $(".box").addClass("img-hover");
        $("#tag-animate").addClass("text-hover");
        $(".paragraph-animate").addClass("text-hover");
        $(".archive").addClass("archive-hover");
    }, 200);
    $(this).data("timer", t);
}
$("#image-top").mouseenter(_in);


// settimeout for TooltipBox
$(function () {
    setTimeout(function () {
        $(".dialogbox").fadeOut('fast')
    }, 5000);
});

// Tooltip on bottun mouseMove
$("#btnRegister").mouseover(function () {
    $(".dialogbox").show();
});
$("#btnRegister").mouseout(function () {
    $(".dialogbox").hide();
});

// archive page select
var option = $('.selectbox select option');
option.css('font-family', 'yekan');
$(document).ready(function () {
    var selectTarget = $('.selectbox select');
    selectTarget.on('blur', function () {
        $(this).parent().removeClass('focus');
    });

    selectTarget.change(function () {
        var select_name = $(this).children('option:selected').text();

        $(this).siblings('label').text(select_name);
    });
});

// archive ja
$(function () {
    $('#OurWork').mixItUp();
});

//about us js
function customWayPoint(className, addClassName, customOffset) {
    var waypoints = $(className).waypoint({
      handler: function(direction) {
        if (direction == "down") {
          $(className).addClass(addClassName);
        } else {
          $(className).removeClass(addClassName);
        }
      },
      offset: customOffset
    });
  }
  
  var defaultOffset = '50%';
  
  for (i=0; i<17; i++) {
    customWayPoint('.timeline__item--'+i, 'timeline__item-bg', defaultOffset);
  }