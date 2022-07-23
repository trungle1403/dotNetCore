var tempThem = true;
$(function () {
    NTS.unloadding();
    NTS.loadDataCombo({
        name: '#PhanMem_Loc',
        ajaxUrl: '/Services/ServiceSystem.asmx/GetPhanMem',
        indexValue: 0,
        indexText: 1,
        indexText1: 2,
        textShowTatCa: '-Chọn phần mềm-',
        columns: 2,
        showTatCa: !0
    });
});
