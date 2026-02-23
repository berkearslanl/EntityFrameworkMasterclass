(function ($) {
    'use strict';
    $(function () {
        $('#order-listing').DataTable({
            "aLengthMenu": [
                [5, 10, 15, -1],
                [5, 10, 15, "Tümü"]
            ],
            "iDisplayLength": 10,
            "language": {
                "lengthMenu": "Sayfada _MENU_ kayıt göster",
                "zeroRecords": "Kayıt bulunamadı",
                "info": "_TOTAL_ kayıttan _START_ - _END_ arası gösteriliyor",
                "infoEmpty": "Gösterilecek kayıt yok",
                "infoFiltered": "(_MAX_ kayıt içerisinden filtrelendi)",
                "search": "Ara:",
                "paginate": {
                    "first": "İlk",
                    "last": "Son",
                    "next": "Sonraki",
                    "previous": "Önceki"
                }
            }
        });

        $('#order-listing').each(function () {
            var datatable = $(this);

            var search_input = datatable.closest('.dataTables_wrapper').find('div[id$=_filter] input');
            search_input.attr('placeholder', 'Ara');
            search_input.removeClass('form-control-sm');

            var length_sel = datatable.closest('.dataTables_wrapper').find('div[id$=_length] select');
            length_sel.removeClass('form-control-sm');
        });
    });
})(jQuery);
