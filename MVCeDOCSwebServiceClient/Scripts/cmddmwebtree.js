$("#contactus").on("click", function () {



    var selectedSearch = $('#SelectedSearch').val();
    var currentSearchMode = $('#currentSearchMode').val();
    var contacturl = $("#contacturl").data('request-url') + "?SelectedSearch=" + selectedSearch + "&currentSearchMode=" + currentSearchMode;
    //alert(contacturl);
    window.open(contacturl);
});