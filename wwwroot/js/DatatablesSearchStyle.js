﻿function setStyle(input, filter) {
// ************************************ search styling ************************************ //

    input.attr('placeholder', 'Pretraga');
    input.attr('class', 'form-control form-control-sm');
    input.css({'width': '300px', 'display': 'inline-block'});

    filter.removeClass('dataTables_filter');
    filter.addClass('search-top-20 justify-content-start');
}


