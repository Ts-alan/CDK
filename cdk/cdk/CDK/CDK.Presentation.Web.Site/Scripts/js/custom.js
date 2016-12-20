$(document).ready(function () {
    //stick in the fixed 100% height behind the navbar but don't wrap it
    $('#slide-nav.navbar .container').append($('<div id="navbar-height-col"></div>'));

    // Enter your ids or classes
    var toggler = '.navbar-toggle';
    var pagewrapper = '#page-content';
    var navigationwrapper = '.navbar-header';
    var menuwidth = '100%'; // the menu inside the slide menu itself
    var slidewidth = '100%';
    var menuneg = '-100%';
    var slideneg = '-100%';


    $("#slide-nav").on("click", toggler, function (e) {

        var selected = $(this).hasClass('slide-active');

        $('#slidemenu').stop().animate({
            right: selected ? menuneg : '0px'
        });

        $('#navbar-height-col').stop().animate({
            right: selected ? slideneg : '0px'
        });

        // $(pagewrapper).stop().animate({
        //     right: selected ? '0px' : slidewidth
        // });
        //
        // $(navigationwrapper).stop().animate({
        //     right: selected ? '0px' : slidewidth
        // });


        $(this).toggleClass('slide-active', !selected);
        $('#slidemenu').toggleClass('slide-active');


        $('#page-content, .navbar, body, .navbar-header').toggleClass('slide-active');


    });


    var selected = '#slidemenu, #page-content, body, .navbar';


    if ($(window).width() < 1025) {
        var fullheight = $(window).height();
        $("#slidemenu").height(fullheight);
    }

    $(window).on("resize", function () {

        if ($(window).width() > 1024 && $('.navbar-toggle').is(':hidden')) {
            $(selected).removeClass('slide-active');
        }



    });




    // push the button - change password in account profile

    $('#account-change-password-open-js').click(function(){
      $('.want-change-password').fadeIn('medium');
    });

    $('#account-change-password-close-js').click(function(){
      $('.want-change-password').fadeOut('medium');
    });


    // Vertical centered modals
    // you can give custom class like this // var modalVerticalCenterClass = ".modal.modal-vcenter";

    var modalVerticalCenterClass = ".modal";
    function centerModals($element) {
        var $modals;
        if ($element.length) {
            $modals = $element;
        } else {
            $modals = $(modalVerticalCenterClass + ':visible');
        }
        $modals.each( function(i) {
            var $clone = $(this).clone().css('display', 'block').appendTo('body');
            var top = Math.round(($clone.height() - $clone.find('.modal-content').height()) / 2);
            top = top > 0 ? top : 0;
            $clone.remove();
            $(this).find('.modal-content').css("margin-top", top);
        });
    }
    $(modalVerticalCenterClass).on('show.bs.modal', function(e) {
        centerModals($(this));
    });
    $(window).on('resize', centerModals);

    // favourite buttons toggling
    $('.favorite').click(function(event){
      event.preventDefault();
      $(this).toggleClass('active');
    });


    $('#details-modal').modal('show');
    $('#first-modal').modal('show');
    $('#forgot-password-modal').modal('show');


      // footer collapse columns
      if ($(window).width() > 767) {
          active = false;
          $('.footer-col h4').attr('data-toggle', '');
      } else {
          active = true;
          $('.footer-col h4').attr('data-toggle', 'collapse');

      }

      // details collapse
      if ($(window).width() > 480) {
          $('.tab-toggle-header').attr('data-toggle', '');
      } else {
          $('.tab-toggle-header').attr('data-toggle', 'collapse');

      }



      $('#accordion').on('show.bs.collapse', function () {
        if (active) $('#accordion .in').collapse('hide');
      });


      $(".map-item").click(function() {
          $('body').removeClass('gallery-class-js');
          $('body').removeClass('list-class-js');
          $('body').addClass('map-class-js');
      });
      $(".list-on-item").click(function() {
          $('body').removeClass('gallery-class-js');
          $('body').removeClass('map-class-js');
          $('body').addClass('list-class-js');
      });
      $(".gallery-on-item").click(function() {
          $('body').removeClass('map-class-js');
          $('body').removeClass('list-class-js');
          $('body').addClass('gallery-class-js');
      });

      // saved searches page is empty
        $('.saved-searches-box .alert').on('closed.bs.alert', function () {
            if ($(".saved-searches-box > .search-alert").length == 0){
              $(".no-any-saved-searches").fadeIn("medium");
            }

        });


        if ($('.checkboxInput').attr("checked") ) {
          $(this).closest('label').addClass('labelChecked');
        }

        $('.checkbox label').click(function() {
          $(this).toggleClass('labelChecked');
        });
});
