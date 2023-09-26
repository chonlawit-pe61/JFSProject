$(document).ready(function () {
    //   window.onscroll = function () { Common.ScrollFix(); };
    $('body')
        .off('click', '#btsearchcase')
        .on('click', '#btsearchcase', function (event) {
            if ($('#txtkwsearch').val() != "") { window.location.href = "/applicant?kw=" + $('#txtkwsearch').val(); }
        }).off('click', '.js--open')
        .on('click', '.js--open', function (event) {
            $(this).closest('.list-group-item').remove();
            var link = $(this).data('link');
            $.ajax({
                url: '/inbox/setread',
                method: 'POST',
                data: { id: $(this).data('id'), uid: $(this).data('uid') },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        window.location.href = link;
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });
            event.stopPropagation(); //กำหนดเพื่อไม่ให้ปิด modal เมือคลิกภายใน propover
        }).off('click', '.js--cancelnoti')
        .on('click', '.js--cancelnoti', function (event) {
            $(this).closest('.list-group-item').remove();
            $.ajax({
                url: '/inbox/setread',
                method: 'POST',
                data: { id: $(this).data('id'), uid: $(this).data('uid') },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) { }
                }
                , error: function (err) {
                    console.log(err);
                }
            });
            event.stopPropagation(); //กำหนดเพื่อไม่ให้ปิด modal เมือคลิกภายใน propover
        });
   //Notifications
    if ($('#mg-noti').length) {

        $.ajax({
            url: '/inbox/getinboxunread',
            method: 'POST',
            data: { id: $('#mg-noti').data('id') },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {
                    if (data.Data.length != 0) {
                        $('#mg-noti').find('.icon').addClass('icon-anim-pulse');
                        $('#mg-noti').find('.icon').after('<span class="badge badge-dot badge-dot-sm badge-danger">แจ้งเตือน</span>');
                        var template = Handlebars.compile($('#tmpl-notification').html());
                        $('#list-noti').html(template(data.Data));
                    } else {
                        $('#list-noti').html('<div class="p-3 text-center">ไม่มีข้อความ</div>');
                        $('#mg-noti').find('.icon').removeClass('icon-anim-pulse');
                        $('#mg-noti').find('.icon').next('span').remove();
                    }
                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
     // Sidebar Menu
    setTimeout(function () {
        $(".vertical-nav-menu").metisMenu();
    }, 100);

    // Search wrapper trigger

    $('.search-icon').click(function () {
        $(this).parent().parent().addClass('active');
    });

    $('.search-wrapper .close').click(function () {
        $(this).parent().removeClass('active');
    });

    // BS4 Popover

    $('[data-toggle="popover-custom-content"]').each(function (i, obj) {

        $(this).popover({
            html: true,
            placement: 'auto',
            template: '<div class="popover popover-custom" role="tooltip"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>',
            content: function () {
                var id = $(this).attr('popover-id');
                return $('#popover-content-' + id).html();
            }
        });

    });

    // Stop Bootstrap 4 Dropdown for closing on click inside
    //เปิด กรณีต้องการไม่ให้ คลิกภายใน modal แล้วปิดตัว modal
    //$('.dropdown-menu').on('click', function (event) {
    //    var events = $._data(document, 'events') || {};
    //    events = events.click || [];
    //    for (var i = 0; i < events.length; i++) {
    //        if (events[i].selector) {
    //            ///console.log(events[i].selector)
    //            if ($(event.target).is(events[i].selector)) {
                   
    //                events[i].handler.call(event.target, event);
    //            }

    //            $(event.target).parents(events[i].selector).each(function () {
    //                events[i].handler.call(this, event);
    //                console.log(this, event)
    //            });
    //        }
    //    }
    //    event.stopPropagation(); //Always stop propagation
    //});


    $('[data-toggle="popover-custom-bg"]').each(function (i, obj) {

        var popClass = $(this).attr('data-bg-class');

        $(this).popover({
            trigger: 'focus',
            placement: 'top',
            template: '<div class="popover popover-bg ' + popClass + '" role="tooltip"><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
        });

    });

    $(function () {
        $('[data-toggle="popover"]').popover();
    });

    $('[data-toggle="popover-custom"]').each(function (i, obj) {

        $(this).popover({
            html: true,
            container: $(this).parent().find('.rm-max-width'),
            content: function () {
                return $(this).next('.rm-max-width').find('.popover-custom-content').html();
            }
        });
    });

    $('body').on('click', function (e) {
        $('[rel="popover-focus"]').each(function () {
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
            }
        });
    });

    $('.header-megamenu.nav > li > .nav-link').on('click', function (e) {
        $('[data-toggle="popover-custom"]').each(function () {
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
            }
        });
    });

    // BS4 Tooltips

    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });

    $(function () {
        $('[data-toggle="tooltip-light"]').tooltip({
            template: '<div class="tooltip tooltip-light"><div class="tooltip-inner"></div></div>'
        });
    });

    // Drawer

    $('.open-right-drawer').click(function () {
        $(this).addClass('is-active');
        $('.app-drawer-wrapper').addClass('drawer-open');
        $('.app-drawer-overlay').removeClass('d-none');
    });

    $('.drawer-nav-btn').click(function () {
        $('.app-drawer-wrapper').removeClass('drawer-open');
        $('.app-drawer-overlay').addClass('d-none');
        $('.open-right-drawer').removeClass('is-active');
    });

    $('.app-drawer-overlay').click(function () {
        $(this).addClass('d-none');
        $('.app-drawer-wrapper').removeClass('drawer-open');
        $('.open-right-drawer').removeClass('is-active');
    });

    $('.mobile-toggle-nav').click(function () {
        $(this).toggleClass('is-active');
        $('.app-container').toggleClass('sidebar-mobile-open');
    });

    $('.mobile-toggle-header-nav').click(function () {
        $(this).toggleClass('active');
        $('.app-header__content').toggleClass('header-mobile-open');
    });

    $('.mobile-app-menu-btn').click(function () {
        $('.hamburger', this).toggleClass('is-active');
        $('.app-inner-layout').toggleClass('open-mobile-menu');
    });

    // Responsive

    $(window).on('resize', function(){
        var win = $(this);
        if (win.width() < 1250) {
            $('.app-container').addClass('closed-sidebar-mobile closed-sidebar');
        }
        else
        {
            $('.app-container').removeClass('closed-sidebar-mobile closed-sidebar');
        }
    });

    //Card ใช่รวมกับ CollapsedCard
    //Common.CollapsedCard(this);
    //$('.card').on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });
    $('.js--cancel').on('click', function () {
        let el = $(this).closest('.card')
        el.addClass('collapsed-card');
        el.find('.card-body').slideUp();//.css("display", "none");
        Common.CollapsedCard(this);
    });

 
});

