﻿$(document).ready(function () {
    $('#ObracunPotrosnjeTable').DataTable({
        "ajax": {
            "url": "/RacunElektraObracuniPotrosnje/GetList",
            "type": "POST",
            "datatype": "json"
        },
        // name mi treba za filter u controlleru - taj se parametar pretražuje po nazivu
        // koristi se kao selector (nije posve jasna dokumentacija)
        "columns": [
            {
                "data": null, "name": "datumObracuna",
                "render": function (data, type, row, meta) {
                    return '<a href="RacuniHolding/Details/' + data.id + '">' + moment(data).format("DD.MM.YYYY") + '</a>';
                }
            },
            {
                "data": "brojilo", "name": "brojilo",
            },
            {
                "data": null, "name": "racunElektra.brojRacuna",
                "render": function (data, type, row, meta) {
                    return '<a href="RacuniElektra/Details/' + data.racunElektra.id + '">' + data.racunElektra.brojRacuna + '</a>';
                }
            },
            {"data": "rvt", "name": "rvt"},
            {"data": "rnt", "name": "rnt"},
        ],
        "paging": true,
        "serverSide": true,
        "order": [[0, 'asc']], // default sort po datumu
        "bLengthChange": false,
        //"processing": true,
        "language": {
            "processing": "tražim...",
            "search": "", // remove search text
        },
        "scrollX": true,
        "columnDefs": [
            {
                "targets": 0, // Datum obračuna
            },
            {
                "targets": 1, // brojilo
                "render": $.fn.dataTable.render.ellipsis(10),
            }, {
                "targets": 2, // broj računa
                "render": $.fn.dataTable.render.ellipsis(10),
            },
            {
                "targets": 3, // RVT
                "render": $.fn.dataTable.render.ellipsis(10),
            },
            {
                "targets": 4, // RNT
                "render": $.fn.dataTable.render.ellipsis(8),
            }
        ]
    });
});