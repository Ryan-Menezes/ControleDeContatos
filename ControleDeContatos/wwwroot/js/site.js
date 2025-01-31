$(document).ready(function () {
    loadDatatables();

    $('.btn-total-contatos').click(function () {
        const usuarioId = $(this).attr('usuario-id');

        $.ajax({
            method: 'GET',
            url: '/Usuario/ListarContatosPorUsuarioId/' + usuarioId,
            success: function (result) {
                $('#lista-contatos-usuario').html(result);
                $('#modal-contatos-usuario').modal('show');
                loadDatatables('#table-contatos-usuario');
            },
        });
    });
});

function loadDatatables(seletor = '.table') {
    $(seletor).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}