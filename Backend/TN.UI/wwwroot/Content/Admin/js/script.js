
//var firsLatLng = new google.maps.LatLng(10.823418, 106.628370);
// v 1.0
var defaultLatLng = { lat: 21.0277644, lng: 105.83415979999995 };
var thisController = GetControllerByUrl(window.location.pathname);
(function ($) {
    $.queryString = (function (paramsArray) {
        let params = {};
        for (let i = 0; i < paramsArray.length; ++i) {
            let param = paramsArray[i]
                .split('=', 2);
            if (param.length !== 2)
                continue;
            params[param[0]] = decodeURIComponent(param[1].replace(/\+/g, " "));
        }
        return params;
    })(window.location.search.substr(1).split('&'));
    alertify.set('notifier', 'position', 'top-right');
    initMenuAdmin();
    initScrollBody();
})(jQuery);
function initMenuAdmin() {
    $("#menuleftadmin li").each(function (i, item) {
        if (thisController != "") {
            var thisa = $(item).find(">a");
            if (thisController == GetControllerByUrl(thisa.attr("href"))) {
                if ($(item).hasClass("cap2")) {
                    $(item).addClass("active");
                    thisa.closest("li>ul").closest("li").addClass("active");
                }
                else {
                    $(item).addClass("active");
                }
                return;
            }
        }
        else {
            $(".isDasb").addClass("active");
            return;
        }
    });
}
function GetControllerByUrl(url) {
    if (url == null) {
        return "";
    }
    var arrpa = url.split('/');
    if (arrpa.length >= 4) {
        return arrpa[3];
    }
    return "";
}
function fixButton() {
    //alert($("#canbtn").outerWidth());
    $("#divbutton").width($("#canbtn").outerWidth());
}
function bindLoading(tag) {
    var $loading = $(tag).waitMe({
        effect: "ios",
        text: '',
        bg: 'rgba(51, 51, 51, 0.03)',
        color: '#555'
    });
    return $loading;
}
function bindNumRow(tag, page, totalrows, limit) {
    var totalPage = (totalrows % limit) > 0 ? (Math.floor((totalrows / limit)) + 1) : Math.floor(totalrows / limit);
    $(tag).html("Bản ghi từ " + (page == 1 ? 1 : ((page - 1) * limit)).toLocaleString('vi-VN') + " - " + (totalPage == page ? totalrows : (page * limit)).toLocaleString('vi-VN') + " trong tổng " + totalrows.toLocaleString('vi-VN') + " bản ghi (trang " + page.toLocaleString('vi-VN') + "/" + totalPage.toLocaleString('vi-VN') + ")");
}
function bindPagination(tag, funtion, page, totalrows, limit) {
    var phandem = 2;
    var isBack = false, isNext = false;
    var totalPage = (totalrows % limit) > 0 ? (Math.floor((totalrows / limit)) + 1) : Math.floor(totalrows / limit);

    if (page > 1 && page <= totalPage) {
        isBack = true;
    }
    if (page > 1) {
        isBack = true;
    }
    if (page < totalPage) {
        isNext = true;
    }
    var str1 =
        `
                                     <ul class="pagination">
                                        <li class="`+ ((totalPage >= 1 && page != 1) ? "" : "disabled") + `">
                                              <a title='Trang đầu tiên' `+ ((totalPage >= 1 && page != 1) ? "onclick='" + funtion + "(1)'" : "") + ` href="javascript:void(0);">
                                                 <i class="material-icons">first_page</i>
                                              </a>
                                         </li>
                                         <li class="`+ (isBack == true ? "" : "disabled") + `">
                                              <a title='Quay lại trang' class='fixpage'`+ (isBack == false ? "" : "onclick='" + funtion + "(" + (page - 1) + ")'") + ` href="javascript:void(0);">
                                                 <i class="material-icons">chevron_left</i>
                                              </a>
                                         </li>
                                `;
    var str2 = `
                                         <li class="`+ (isNext == true ? "" : "disabled") + `">
                                              <a  title='Trang tiếp theo' class='fixpage' `+ (isNext == false ? "" : "onclick='" + funtion + "(" + (parseFloat(page) + 1) + ")'") + ` href="javascript:void(0);" class="waves-effect">
                                                 <i class="material-icons">chevron_right</i>
                                              </a>
                                         </li>
                                        <li class="`+ ((totalPage > page) ? "" : "disabled") + `">
                                              <a title='Trang cuối' `+ ((totalPage > page) ? "onclick='" + funtion + "(" + totalPage + ")'" : "") + ` href="javascript:void(0);" class="waves-effect">
                                                 <i class="material-icons">last_page</i>
                                              </a>
                                         </li>
                                     </ul>
                                `;
    var str3 = ``;
    if (totalPage >= 15) {
        for (i = 1; i <= totalPage; i++) {
            //if () {
            //    str3 += `<li class="` + (page == i ? "active" : "") + `"><a  onclick='` + funtion + `(` + i + `)' href="javascript:void(0);">` + i + `</a></li>`;
            //}
            if ((i <= phandem) || (((i - phandem)) <= page && ((i + phandem + 1)) > page) || (i >= (totalPage - phandem))) {
                str3 += `<li class="` + (page == i ? "active" : "") + `"><a  onclick='` + funtion + `(` + i + `)' href="javascript:void(0);">` + i + `</a></li>`;
            }
        }
    }
    else {
        for (i = 1; i <= totalPage; i++) {
            str3 += `<li class="` + (page == i ? "active" : "") + `"><a  onclick='` + funtion + `(` + i + `)' href="javascript:void(0);">` + i + `</a></li>`;
        }
    }
    $(tag).html(str1 + str3 + str2);
}
function jsonToQueryString(json) {
    return '?' +
        Object.keys(json).map(function (key) {
            return encodeURIComponent(key) + '=' +
                encodeURIComponent(json[key]);
        }).join('&');
}
function changeUrl(data) {
    window.history.pushState('page2', 'Title', jsonToQueryString(data));
}

function onCheckAll(e, tag) {
    $(tag).find("input[type='checkbox']").prop("checked", $(e).prop("checked"))
}
function initModal(callBack) {
    $(".btnPopup").on("click", function (e) {
        e.preventDefault();
        var xxModal = "#myModal";
        if ($(this).attr('data-namemodal') != undefined || $(this).attr('data-namemodal') != null) {
            xxModal = $(this).attr('data-namemodal');
        }
        $(xxModal).modal('show');
        callBack($(this));
    });
}
function initPopup(tagForm = ".ajaxValidateForm", tagBtn = ".btnPopup") {
    $(tagBtn).on("click", function (e) {
        e.preventDefault();
        var xxModal = "#myModal";
        if ($(this).attr('data-namemodal') != undefined || $(this).attr('data-namemodal') != null) {
            xxModal = $(this).attr('data-namemodal');
        }
        $(xxModal).modal({ backdrop: 'static', keyboard: false });
        $(xxModal + ">div>div.modal-content").html("<div class='modalLoadding'><i class='material-icons icon-spin'>data_usage</i><span>Đang xử lý...</span></div>");
        $.get($(this).attr("href"), function (data) {
            $(xxModal + ">div>div.modal-content").html(data);
            $(xxModal).modal('show');
            var $form = $(xxModal + " .modal-content " + tagForm);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
            }
            //$.AdminBSB.browser.activate();
            //$.AdminBSB.dropdownMenu.activate();
            //$.AdminBSB.input.activate();
            $.AdminBSB.select.activate();
            //$.AdminBSB.search.activate();
            //open dialog
        });
    });
}
$('.modal').on('hidden.bs.modal', function (e) {
    $(this).removeData();
});
function imgAvatarError(image) {
    image.onerror = "";
    image.src = "/Content/Admin/images/no-avatar.jpg";
    return true;
}
function getBool(val) {
    return !!JSON.parse(String(val).toLowerCase());
}
function initSearchExtension() {
    //$(".searchExtensionForm").width($(".keywidth").outerWidth()-42);
    $(".searchExtension").on("click", function () {
        if ($(".searchExtensionForm").hasClass("open")) {
            $(".searchExtensionForm").removeClass("open");
            $(".searchExtensionForm").fadeOut(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_down</i>");
        }
        else {
            $(".searchExtensionForm").addClass("open");
            $(".searchExtensionForm").fadeIn(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_up</i>");
        }
    });
}
function getQueryString(isFirst, qr, input) {
    return (isFirst && qr != null) ? qr : input
}
function closeSearchExtension() {
    if ($(".searchExtensionForm").hasClass("open")) {
        $(".searchExtensionForm").fadeOut(300);
        $(".searchExtensionForm").removeClass("open");
        $(".searchExtension").html("<i class='material-icons'>keyboard_arrow_down</i>");
    }
}
function logout() {
    $("#formLogout").submit();
}
function initScrollBody() {
    var viewportHeight = $(window).height();
    $('#body').slimScroll({
        height: viewportHeight + 'px',
        color: '#455A64',
        distance: '0',
        allowPageScroll: true,
        alwaysVisible: true
    });
}
function initAjaxSubmit(callBack, ajaxSubmit = ".ajaxSubmit", ajaxValidateForm = ".ajaxValidateForm") {
    closeSearchExtension();
    $(ajaxSubmit).on("click", function () {
        var $this = $(this);
        $this.find(".waves-ripple").remove();
        if ($(ajaxValidateForm).valid()) {
            $this.button('loading');
            $.ajax({
                type: "POST",
                url: $(ajaxValidateForm).attr("action"),
                data: $(ajaxValidateForm).serialize(),
                headers:
                    {
                        "RequestVerificationToken": $(ajaxValidateForm).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {

                        alertify.notify(rs.message, rs.type, 5);
                        setTimeout(function () {
                            $this.button('reset');
                        }, 300);
                        if (rs.output == 1) {
                            $(ajaxValidateForm + " .modal-footer .close").click();
                            reGetDataGrid();
                        }
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        }
    });
}
function initAjaxDelete(callBack, btndelete = ".btndelete", ajaxValidateForm = ".ajaxValidateForm") {
    closeSearchExtension();
    $(btndelete).on("click", function () {
        var $this = $(this);
        swal({
            title: "Bạn có muốn thực hiện chức năng này?",
            text: "Nếu bạn thực hiện, dữ liệu này sẽ bị xóa vĩnh viên, bạn có muốn tiếp tục?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Đồng ý, xóa bản ghi này!",
            closeOnConfirm: false
        }, function () {
            $this.button('loading');
            $.ajax({
                type: "POST",
                url: $this.attr("data-action"),
                data: $(ajaxValidateForm).serialize(),
                headers:
                    {
                        "RequestVerificationToken": $(ajaxValidateForm).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {
                        var returnurl = $this.attr("data-returnurl");
                        if (rs.isUse) {
                            swal({
                                title: "Xóa dữ liệu thất bại!",
                                text: rs.message,
                                type: "warning",
                                confirmButtonText: "Đóng!"
                            });
                        }
                        else {
                            if (rs.output == 1) {
                                swal({
                                    title: "Thành công!",
                                    text: "Xóa dữ liệu thành công, click quay lại ngay hoặc tự động quay lại trang danh sách trong 5s!",
                                    type: "success",
                                    confirmButtonText: "Quay lại ngay!"
                                },
                                    function () {
                                        window.location.href = returnurl;
                                    });

                                setTimeout(function () {
                                    window.location.href = returnurl;
                                }, 5000);
                            }
                            else {
                                alertify.notify(rs.message, rs.type, 5);
                            }
                        }
                        setTimeout(function () {
                            $this.button('reset');
                        }, 300);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        });
    });
}
function intitFileUpload(callBack, ajaxValidateForm = ".ajaxValidateForm") {
    $(ajaxValidateForm + " .chosefileupload").change(function () {
        var $this = $(ajaxValidateForm + " #btnChosefile");
        $this.button('loading');
        var fileUpload = document.getElementById("file");
        var data = new FormData();
        for (var i = 0; i < fileUpload.files.length; i++) {
            var file = fileUpload.files[i];
            data.append(file.name, file);
        }
        $.ajax({
            type: "POST",
            url: $(".ajaxValidateForm .chosefileupload").attr("data-url"),
            contentType: false,
            processData: false,
            data: data,
            dataType: "html",
            headers: {
                "RequestVerificationToken": $(".ajaxValidateForm").find("input[name='__RequestVerificationToken']").val()
            },
            success: function (rs) {
                callBack(rs, $this);
            },
            error: function () {
                alert("Vui lòng F5 trình duyệt rồi thử lại!");
            },
            complete: function (jqxhr, txt_status) {
                if (jqxhr.status == 502) {
                    alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                }
            }
        });
    });
}
function dataGridView(isFirst, page = 1, data, urlAjax, isChangeUrl = true, callBackSetValue = null, tagBindTag = "#dataBindGrid", tagLoading = ".card-loading", tagCheckAll = "#checkAll", callBack = null) {
    var $loading = bindLoading(tagLoading);
    if (!isFirst && isChangeUrl == true) {
        changeUrl(data);
    }
    else {
        if (callBackSetValue != null) {
            callBackSetValue(data);
        }
    }
    $(tagCheckAll).prop("checked", false);
    if (callBack == null) {
        $.ajax({
            method: 'POST',
            url: urlAjax,
            data: data
        }).done(function (data, statusText, xhdr) {
            $(tagBindTag).html(data);
            $loading.waitMe('hide');
        }).fail(function (xhdr, statusText, errorText) {

        });
    }
    else {
        callBack(isFirst, page, data, urlAjax);
    }
}
function initViewEditAdvance(tagBtnClick = ".btnEditAdvance", tagForm = ".ajaxValidateForm") {
    $(tagBtnClick).on("click", function (e) {
        e.preventDefault();
        $.get($(this).attr("href"), function (data) {
            $("#vehicleSchool_0_0").html(data);
            var $form = $(tagForm);
            try {
                $form.unbind();
                $form.data("validator", null);
                $.validator.unobtrusive.parse(document);
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
            }
            $.AdminBSB.browser.activate();
            $.AdminBSB.dropdownMenu.activate();
            $.AdminBSB.input.activate();
            $.AdminBSB.select.activate();
            $("#vehicleSchool_0_0").fadeIn(1000);
        });
    });
}
function checkProperty(obj, name, valDefault) {
    if (Object.prototype.hasOwnProperty.call(obj, name)) {
        obj[name] = valDefault;
    }
    else {
        obj[name] = valDefault;
    }
}
function dataGridViewAdvance(
    isFirst,
    page = 1,
    setting = {},
    callBackEndDefail = null,
    callBackGetvalue = null,
    callBackSetValue = null,
    callBack = null, )
{

    //Setting default
    setting.parentTag = setting.parentTag == undefined ? "[gr-form-index]" : setting.parentTag;
    setting.url = setting.url == undefined ? "/" : setting.url;
    setting.isChangeUrl = setting.isChangeUrl == undefined ? true : setting.isChangeUrl;
    setting.method = setting.method == undefined ? "POST" : setting.method;
    setting.tagBindData = setting.tagBindData == undefined ? "[gr-bind-data]" : setting.tagBindData;
    setting.inputCheckAll = setting.inputCheckAll == undefined ? "[gr-input-check-all]" : setting.inputCheckAll;
    setting.inputSearch = setting.inputSearch == undefined ? "[gr-input-search]" : setting.inputSearch;
    setting.tagLoading = setting.tagLoading == undefined ? "[gr-loading]" : setting.tagLoading;
    setting.customFuntionName = setting.customFuntionName == undefined ? "getDataGrid" : setting.customFuntionName;
    setting.paginationTag = setting.paginationTag == undefined ? "[gr-bind-pagination]" : setting.paginationTag;
    setting.numrowTag = setting.numrowTag == undefined ? "[gr-show-num-row]" : setting.numrowTag;

    var $parent = $(setting.parentTag);
    var $loading = bindLoading($parent.find(setting.tagLoading));
    closeSearchExtensionAdvance($parent);
    ////Get inputSearch name .inputSearch
    var $data = {};
    $data.page = getQueryString(isFirst, $.queryString.page, page);

    var $inputText = $parent.find("input" + setting.inputSearch + "[type=text], input[type=number], input[type=date], input[type=datetime], input[type=hidden]");

    $inputText.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    // CheckBoxInput
    var $inputCheckBox = $parent.find("input" + setting.inputSearch + "[type='checkbox']");
    $inputCheckBox.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.is(":checked"));
        }
    });

    // CheckBoxInput
    var $inputRadio = $parent.find("input" + setting.inputSearch + "[type='radio']:checked");
    $inputRadio.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    // Select
    var $selectInput = $parent.find("select" + setting.inputSearch);
    $selectInput.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    if (callBackGetvalue != null) {
        $data = callBackGetvalue($data);
    }


    if (!isFirst && setting.isChangeUrl == true) {
        changeUrl($data);
    }
    else {
        // Text
        var $inputText = $parent.find("input" + setting.inputSearch + "[type=text], input[type=number], input[type=date], input[type=datetime]");
        $inputText.each(function (i, item) {
            $(item).val($data[$(item).attr("name")]);
        });
        // CheckBoxInput
        var $inputCheckBox = $parent.find("input" + setting.inputSearch + "[type='checkbox']");
        $inputCheckBox.each(function (i, item) {
            $(item).prop('checked', getBool($data[$(item).attr("name")]));
        });
        // Select
        var $selectInput = $parent.find("select" + setting.inputSearch);
        $selectInput.each(function (i, item) {
            $(item).val($data[$(item).attr("name")]).selectpicker('refresh');
        });
        if (callBackSetValue != null) {
            callBackSetValue($data);
        }
    }
    $($parent.find(setting.tagCheckAll)).prop("checked", false);
    $.ajax({
        method: setting.method,
        url: setting.url,
        data: $data
    }).done(function (rp, statusText, xhdr) {
        if (callBack == null) {
            $parent.find(setting.tagBindData).html(rp);
            var _page = $($(setting.parentTag).find(setting.tagBindData)).find("input[gr-data-page]").val();
            var _totalrows = $($(setting.parentTag).find(setting.tagBindData)).find("input[gr-data-totalrows]").val();
            var _limit = $($(setting.parentTag).find(setting.tagBindData)).find("input[gr-data-limit]").val();
            bindPagination($(setting.parentTag).find(setting.paginationTag), setting.customFuntionName, _page, _totalrows, _limit);
            bindNumRow($(setting.parentTag).find(setting.numrowTag), _page, _totalrows, _limit);
            if (callBackEndDefail == null) {
                initPopupAdvance();
            }
            else {
                callBackEndDefail($data);
            }
        }
        else {
            callBack(isFirst, page, $data, setting);
        }
        $loading.waitMe('hide');
    }).fail(function (xhdr, statusText, errorText) {
    });
}

function initSearchExtensionAdvance(tagParent = "[gr-form-index]") {
    var $thisParent = $(tagParent);
    $thisParent.find("[gr-search-ex]").on("click", function () {
        if ($thisParent.find("[gr-search-form-ex]").hasClass("open")) {
            $thisParent.find("[gr-search-form-ex]").removeClass("open");
            $thisParent.find("[gr-search-form-ex]").fadeOut(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_down</i>");
        }
        else {
            $thisParent.find("[gr-search-form-ex]").addClass("open");
            $thisParent.find("[gr-search-form-ex]").fadeIn(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_up</i>");
        }
    });
    $thisParent.find("[gr-search-close-ex]").on("click", function () {
        closeSearchExtensionAdvance(tagParent);
    });
}

function closeSearchExtensionAdvance(tagParent = "[gr-form-index]") {
    var $thisParent = $(tagParent);
    if ($thisParent.find("[gr-search-form-ex]").hasClass("open")) {
        $thisParent.find("[gr-search-form-ex]").fadeOut(300);
        $thisParent.find("[gr-search-form-ex]").removeClass("open");
        $thisParent.find("[gr-search-ex]").html("<i class='material-icons'>keyboard_arrow_down</i>");
    }
}
// v 2.0
function initPopupAdvance(setting = {}) {
    setting.formTag = setting.formTag == undefined ? "[form-edit]" : setting.formTag;
    setting.tagButton = setting.tagButton == undefined ? "[form-show-form]" : setting.tagButton;
    var $parent = $(setting.parentTag);
    $(setting.tagButton).on("click", function (e) {
        e.preventDefault();
        var xxModal = "#myModal";
        if ($(this).attr('data-modal-name') != undefined || $(this).attr('data-modal-name') != null) {
            xxModal = $(this).attr('data-modal-name');
        }
        $(xxModal).modal({ backdrop: 'static', keyboard: false });
        $(xxModal + ">div>div.modal-content").html("<div class='modalLoadding'><i class='material-icons icon-spin'>data_usage</i><span>Đang xử lý...</span></div>");
        $.get($(this).attr("href"), function (data) {
            $(xxModal + ">div>div.modal-content").html(data);
            $(xxModal).modal('show');
            var $form = $(xxModal + " .modal-content " + setting.formTag);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
            }
            $.AdminBSB.select.activate();
        });
    });
}
function initAjaxSubmitAdvance(callBack = null, callBackEnd = null, setting = {}) {
    setting.formTag = setting.formTag == undefined ? "[form-edit]" : setting.formTag;
    setting.tagButton = setting.tagButton == undefined ? "[form-button-submit]" : setting.tagButton;
    setting.method = setting.method == undefined ? "POST" : setting.method;

    $(setting.formTag).find(setting.tagButton).on("click", function () {

        var $this = $(this);
        $this.find(".waves-ripple").remove();
        if ($(setting.formTag).valid()) {
            $this.button('loading');
            $.ajax({
                type: setting.method,
                url: $(setting.formTag).attr("action"),
                data: $(setting.formTag).serialize(),
                headers:
                    {
                        "RequestVerificationToken": $(setting.formTag).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {
                        setTimeout(function () {
                            $this.button('reset');
                            if (rs.isClosePopup) {
                                $(setting.formTag + " .close").click();
                            }
                            alertify.notify(rs.message, rs.type, 5);
                            if (callBackEnd != null) {
                                callBackEnd(rs, $this);
                            }
                            else {
                                reGetDataGrid();
                            }
                        }, 200);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        }
    });
}
function intitFileUploadAdvance(callBack = null, setting = {}) {
    setting.formTag = setting.formTag == undefined ? "[form-edit]" : setting.formTag;
    setting.inputFileTag = setting.fileTag == undefined ? "[form-input-file]" : setting.fileTag;
    setting.btnButton = setting.btnButton == undefined ? "[form-button-upload]" : setting.btnButton;
    setting.method = setting.method == undefined ? "POST" : setting.method;
    $(setting.formTag + " " + setting.inputFileTag).change(function () {
        var $this = $(setting.formTag + " " + setting.btnButton);
        $this.button('loading');
        var fileUpload = document.getElementById("file");
        var data = new FormData();
        for (var i = 0; i < fileUpload.files.length; i++) {
            var file = fileUpload.files[i];
            data.append(file.name, file);
        }
        $.ajax({
            type: setting.method,
            url: $this.attr("data-url"),
            contentType: false,
            processData: false,
            data: data,
            dataType: "json",
            headers: {
                "RequestVerificationToken": $(setting.formTag).find("input[name='__RequestVerificationToken']").val()
            },
            success: function (rs) {
                callBack(rs, $this);
            },
            error: function () {
                alert("Vui lòng F5 trình duyệt rồi thử lại!");
            },
            complete: function (jqxhr, txt_status) {
                if (jqxhr.status == 502) {
                    alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                }
            }
        });
    });
    $(setting.btnButton).click(function () {
        $(setting.inputFileTag).click();
    });
}
function initAjaxDeleteAdvance(callBack = null, callBackEnd = null, setting = {}) {

    setting.formTag = setting.formTag == undefined ? "[form-edit]" : setting.formTag;
    setting.tagButton = setting.tagButton == undefined ? "[form-button-delete]" : setting.tagButton;
    setting.type = setting.type == undefined ? "popup" : setting.type;
    $(setting.tagButton).on("click", function () {

        var $this = $(this);
        swal({
            title: "Bạn có muốn thực hiện chức năng này?",
            text: "Nếu bạn thực hiện, dữ liệu này sẽ bị xóa vĩnh viên, bạn có muốn tiếp tục?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Đồng ý, xóa bản ghi này!",
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            $this.button('loading');
            $.ajax({
                type: "POST",
                url: $this.attr("data-action"),
                data: [],
                headers:
                    {
                        "RequestVerificationToken": $(setting.formTag).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {
                        var returnurl = $this.attr("data-return-url");
                        setTimeout(function () {
                            if (rs.isUse) {
                                swal({
                                    title: "Xóa dữ liệu thất bại!",
                                    text: rs.message,
                                    type: "warning",
                                    confirmButtonText: "Đóng!"
                                });
                            }
                            else {
                                if (rs.output == 1) {

                                    if (setting.type == "popup") {
                                        swal({
                                            title: "Thành công!",
                                            text: rs.message,
                                            type: rs.type,
                                            confirmButtonText: "Đóng!"
                                        },
                                            function () {
                                                if (rs.isClosePopup) {
                                                    $(setting.formTag + " .close").click();
                                                }
                                                if (callBackEnd == null) {
                                                    reGetDataGrid();
                                                }
                                                else {
                                                    callBackEnd(rs, $this, returnurl);
                                                }
                                            });
                                    }
                                    else {
                                        if (callBackEnd == null) {
                                            swal({
                                                title: "Thành công!",
                                                text: "Xóa dữ liệu thành công, click quay lại ngay hoặc tự động quay lại trang danh sách trong 5s!",
                                                type: "success",
                                                confirmButtonText: "Quay lại ngay!"
                                            },
                                                function () {
                                                    window.location.href = returnurl;
                                                });
                                            setTimeout(function () {
                                                window.location.href = returnurl;
                                            }, 5000);
                                        }
                                        else {
                                            callBackEnd(rs, $this, returnurl);
                                        }
                                    }
                                }
                                else {
                                    swal({
                                        title: "Thông báo!",
                                        text: rs.message,
                                        type: rs.type,
                                        confirmButtonText: "Đóng!"
                                    });
                                }
                            }
                            $this.button('reset');
                        }, 300);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        });
    });
}
function initFormAdvance(setting = {}) {

    setting.formTag = setting.formTag == undefined ? "[form-bind-edit]" : setting.formTag;
    setting.tagButton = setting.tagButton == undefined ? "[form-button-bind]" : setting.tagButton;
    setting.tagBindForm = setting.tagBindForm == undefined ? "[form-bind]" : setting.tagBindForm;
    setting.isBindDefaulForm = setting.isBindDefaulForm == undefined ? true : setting.isBindDefaulForm;
    setting.isBindForm = setting.isBindForm == undefined ? true : setting.isBindForm;
    
    var $parent = $(setting.parentTag);
    if (setting.isBindDefaulForm && setting.defaultUrl != undefined) {
        var $loading = bindLoading(setting.tagBindForm);
        $.get(setting.defaultUrl, function (data) {
            $(setting.tagBindForm).html(data);
            var $form = $(setting.formTag);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
                console.log(e);
            }
            $.AdminBSB.select.activate();
            $loading.waitMe('hide');
        });
        $loading.waitMe('hide');
    }
    if (setting.isBindForm) {
        $(setting.tagButton).on("click", function (e) {
            e.preventDefault();
            var $loading = bindLoading(setting.tagBindForm);
            $.get($(this).attr("href"), function (data) {
                $(setting.tagBindForm).html(data);
                var $form = $(setting.formTag);
                try {
                    // Unbind existing validation
                    $form.unbind();
                    $form.data("validator", null);
                    // Check document for changes
                    $.validator.unobtrusive.parse(document);
                    // Re add validation with changes
                    $form.validate($form.data("unobtrusiveValidation").options);
                } catch (e) {
                }
                $.AdminBSB.select.activate();
                $loading.waitMe('hide');
            });
        });
    }
}
// v 3.0
$.fn.toPopup = function (setting = {})
{
    setting.form = setting.form == undefined ? "[form-edit]" : setting.form;
    var $this = $(this);
    var $parent = $(setting.form);
    $(document).on("click", $this.selector, function (e) {
        e.preventDefault();
        var myModal = "#myModal";
        if ($(this).attr('data-target') != undefined || $(this).attr('data-target') != null) {
            myModal = $(this).attr('data-target');
        }
        $(myModal).modal({ backdrop: 'static', keyboard: false });
        $(myModal + ">div>div.modal-content").html("<div class='modalLoadding'><i class='material-icons icon-spin'>data_usage</i><span>Đang xử lý...</span></div>");
        $.get($(this).attr("href"), function (data) {
           
            $(myModal + ">div>div.modal-content").html(data);
            $(myModal).modal('show');
            var $form = $(myModal + " " + setting.form);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
                console.log(e);
            }
            $.AdminBSB.select.activate();
        });
    });
    
}
$.fn.toSubmit = function (setting = {}, callBackSubmitEnd, callBackSubmit)
{
    setting.form = setting.form == undefined ? "[form-edit]" : setting.form;
    var $this = $(this);
    $($this).on("click", function () {
        var $thisButtonSubmit = $(this);
        $thisButtonSubmit.find(".waves-ripple").remove();
        if ($(setting.form).valid()) {
            $thisButtonSubmit.button('loading');
            $.ajax({
                type: "POST",
                url: $(setting.form).attr("action"),
                data: $(setting.form).serialize(),
                headers:
                    {
                        "RequestVerificationToken": $(setting.form).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBackSubmit != null) {
                        callBackSubmit(rs, $thisButtonSubmit);
                    }
                    else {
                        setTimeout(function () {
                            $thisButtonSubmit.button('reset');
                            console.log(rs);
                            if (rs.isClosePopup) {
                                $(setting.form + " .close").click();
                            }
                            alertify.notify(rs.message, rs.type, 5);
                            if (callBackSubmitEnd != null) {
                                callBackSubmitEnd(rs, $thisButtonSubmit);
                            }
                            else {
                                reGetDataGrid();
                            }
                        }, 200);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        }
        else {
            alertify.notify($(setting.form).find(".validation-summary-errors").html(), "warning", 5);
        }
    });
}
$.fn.toGridView = function (isFirst, page, setting = {}, callBackEndDefail = null, callBackGetValue = null, callBackSetValue = null, callBack = null) {
    var $this = $(this);
    var $parent = $($this.selector);
    setting.url = setting.url == undefined ? "/" : setting.url;
    setting.isChangeUrl = setting.isChangeUrl == undefined ? true : setting.isChangeUrl;
    setting.method = setting.method == undefined ? "POST" : setting.method;
    setting.tagData = setting.tagData == undefined ? "[grid-data]" : setting.tagData;
    setting.tagCheckAll = setting.tagCheckAll == undefined ? "[grid-check-all]" : setting.tagCheckAll;
    setting.tagInput = setting.tagInput == undefined ? "[grid-input]" : setting.tagInput;
    setting.tagLoading = setting.tagLoading == undefined ? "[grid-loading]" : setting.tagLoading;
    setting.customFuntionName = setting.customFuntionName == undefined ? "getDataGrid" : setting.customFuntionName;
    setting.tagPagination = setting.tagPagination == undefined ? "[grid-pagination]" : setting.tagPagination;
    setting.tagNumRow = setting.tagNumRow == undefined ? "[grid-num-row]" : setting.tagNumRow;
   
    var $loading = bindLoading($parent.find(setting.tagLoading));

    $parent.find("[search-close]").click();

    ////Get inputSearch name .inputSearch
    var $data = {};
    $data.page = getQueryString(isFirst, $.queryString.page, page);
    var $inputText = $parent.find("input" + setting.tagInput + "[type=text], input[type=number], input[type=date], input[type=datetime], input[type=hidden]");
    $inputText.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    // CheckBoxInput
    var $inputCheckBox = $parent.find("input" + setting.tagInput + "[type='checkbox']");
    $inputCheckBox.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.is(":checked"));
        }
    });

    // CheckBoxInput
    var $inputRadio = $parent.find("input" + setting.tagInput + "[type='radio']:checked");
    $inputRadio.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    // Select
    var $selectInput = $parent.find("select" + setting.tagInput);
    $selectInput.each(function (i, item) {
        var thisitem = $(item);
        var nameItem = thisitem.attr("name");
        if (nameItem != undefined && nameItem != null && nameItem != '') {
            $data[nameItem] = getQueryString(isFirst, $.queryString[nameItem], thisitem.val());
        }
    });

    if (callBackGetValue != null) {
        $data = callBackGetValue($data);
    }

    if (!isFirst && setting.isChangeUrl == true) {
        changeUrl($data);
    }
    else {
        // Text
        var $inputText = $parent.find("input" + setting.tagInput + "[type=text], input[type=number], input[type=date], input[type=datetime]");
        $inputText.each(function (i, item) {
            $(item).val($data[$(item).attr("name")]);
        });
        // CheckBoxInput
        var $inputCheckBox = $parent.find("input" + setting.tagInput + "[type='checkbox']");
        $inputCheckBox.each(function (i, item) {
            $(item).prop('checked', getBool($data[$(item).attr("name")]));
        });
        // Select
        var $selectInput = $parent.find("select" + setting.tagInput);
        $selectInput.each(function (i, item) {
            $(item).val($data[$(item).attr("name")]).selectpicker('refresh');
        });
        if (callBackSetValue != null) {
            callBackSetValue($data);
        }
    }
    $($parent.find(setting.tagCheckAll)).prop("checked", false);
    $.ajax({
        method: setting.method,
        url: setting.url,
        data: $data
    }).done(function (rp, statusText, xhdr) {
        if (callBack == null) {
            $parent.find(setting.tagData).html(rp);
            var _page = $parent.find("input[grid-data-page]").val();
            var _totalrows = $parent.find("input[grid-data-totalrows]").val();
            var _limit = $parent.find("input[grid-data-limit]").val();
            bindPagination($parent.find(setting.tagPagination), setting.customFuntionName, _page, _totalrows, _limit);
            bindNumRow($parent.find(setting.tagNumRow), _page, _totalrows, _limit);
            if (callBackEndDefail != null) {
                callBackEndDefail($data);
            }
        }
        else {
            callBack(isFirst, page, $data, setting);
        }
        $loading.waitMe('hide');
    }).fail(function (xhdr, statusText, errorText) {
    });
}
$.fn.toDelete = function (setting = {}, callBackEnd = null, callBack = null) {
    setting.form = setting.form == undefined ? "[form-edit]" : setting.form;
    setting.type = setting.type == undefined ? "popup" : setting.type;
    var $thisSelector = $(this);
    $($thisSelector).on("click", function () {
        var $this = $(this);
        console.log($(setting.form).find("input[name='__RequestVerificationToken']").val());
        swal({
            title: "Bạn có muốn thực hiện chức năng này?",
            text: "Nếu bạn thực hiện, dữ liệu này sẽ bị xóa vĩnh viên, bạn có muốn tiếp tục?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Đồng ý, xóa bản ghi này!",
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            $this.button('loading');
            $.ajax({
                type: "POST",
                url: $this.attr("data-action"),
                data: [],
                headers:
                    {
                        "RequestVerificationToken": $(setting.form).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs)
                {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {
                        var returnurl = $this.attr("data-return-url");
                        setTimeout(function () {
                            if (rs.isUse) {
                                swal({
                                    title: "Xóa dữ liệu thất bại!",
                                    text: rs.message,
                                    type: "warning",
                                    confirmButtonText: "Đóng!"
                                });
                            }
                            else {
                                if (rs.output == 1) {

                                    if (setting.type == "popup") {
                                        swal({
                                            title: "Thành công!",
                                            text: rs.message,
                                            type: rs.type,
                                            confirmButtonText: "Đóng!"
                                        },
                                            function () {
                                                if (rs.isClosePopup) {
                                                    $(setting.form + " .close").click();
                                                }
                                                if (callBackEnd == null) {
                                                    reGetDataGrid();
                                                }
                                                else {
                                                    callBackEnd(rs, $this, returnurl);
                                                }
                                            });
                                    }
                                    else {
                                        if (callBackEnd == null) {
                                            swal({
                                                title: "Thành công!",
                                                text: "Xóa dữ liệu thành công, click quay lại ngay hoặc tự động quay lại trang danh sách trong 5s!",
                                                type: "success",
                                                confirmButtonText: "Quay lại ngay!"
                                            },
                                                function () {
                                                    window.location.href = returnurl;
                                                });
                                            setTimeout(function () {
                                                window.location.href = returnurl;
                                            }, 5000);
                                        }
                                        else {
                                            callBackEnd(rs, $this, returnurl);
                                        }
                                    }
                                }
                                else {
                                    swal({
                                        title: "Thông báo!",
                                        text: rs.message,
                                        type: rs.type,
                                        confirmButtonText: "Đóng!"
                                    });
                                }
                            }
                            $this.button('reset');
                        }, 300);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        });
    });
}
$.fn.toSearch = function (setting = {})
{
    var $this = $(this);
    var $thisParent = $($this.selector);
    $thisParent.find("[search-menu]").on("click", function () {
        if ($thisParent.find("[search-form]").hasClass("open")) {
            $thisParent.find("[search-form]").removeClass("open");
            $thisParent.find("[search-form]").fadeOut(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_down</i>");
        }
        else {
            $thisParent.find("[search-form]").addClass("open");
            $thisParent.find("[search-form]").fadeIn(300);
            $(this).html("<i class='material-icons'>keyboard_arrow_up</i>");
        }
    });
    $thisParent.find("[search-close]").on("click", function () {
        if ($thisParent.find("[search-form]").hasClass("open")) {
            $thisParent.find("[search-form]").fadeOut(300);
            $thisParent.find("[search-form]").removeClass("open");
            $thisParent.find("[search-menu]").html("<i class='material-icons'>keyboard_arrow_down</i>");
        }
    });
}
$.fn.toUploadFile = function (setting = {}, callBack = null) {
    var $this = $(this);
    var $thisParent = $($this.selector);

    setting.form = setting.form == undefined ? "[form-edit]" : setting.form;
    setting.tagInputFile = setting.tagInputFile == undefined ? "[input-file]" : setting.tagInputFile;
    setting.method = setting.method == undefined ? "POST" : setting.method;
    setting.isImg = setting.isImg == undefined ? true : setting.isImg;
    setting.tagImg = setting.tagImg == undefined ? "[img-file]" : setting.tagImg;

    $(setting.tagInputFile).change(function () {
        $thisParent.button('loading');
        var fileUpload = document.getElementById("file");
        var data = new FormData();
        for (var i = 0; i < fileUpload.files.length; i++) {
            var file = fileUpload.files[i];
            data.append(file.name, file);
        }
        $.ajax({
            type: setting.method,
            url: $this.attr("data-url"),
            contentType: false,
            processData: false,
            data: data,
            dataType: "json",
            headers: {
                "RequestVerificationToken": $(setting.form).find("input[name='__RequestVerificationToken']").val()
            },
            success: function (rs) {
                if (callBack == null) {
                    setTimeout(function () {
                        $thisParent.button('reset');
                        alertify.notify(rs.message, rs.type, 5);
                        if (setting.isImg) {
                            if (rs.output == 1) {
                                var newSrc = rs.data + "?v=" + Math.random();
                                $(setting.tagImg).attr("src", newSrc);
                            }
                        }
                    }, 500);
                }
                else {
                    callBack(rs, $this);
                }
            },
            error: function () {
                alert("Vui lòng F5 trình duyệt rồi thử lại!");
            },
            complete: function (jqxhr, txt_status) {
                if (jqxhr.status == 502) {
                    alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                }
            }
        });
    });
    $($thisParent).click(function () {
        $(setting.tagInputFile).click();
    });
}
$.fn.toStaticForm = function(setting = {}) {
    setting.form = setting.form == undefined ? "[form-static-edit]" : setting.form;
    setting.tagShow = setting.tagShow == undefined ? "[form-static-show]" : setting.tagShow;
    setting.isDefaulOpen = setting.isDefaulOpen == undefined ? true : setting.isDefaulOpen;

    var $this = $(this);
    var $thisParent = $($this.selector);

    if (setting.isDefaulOpen) {
        var $loading = bindLoading(setting.form);
        $.get(setting.defaultUrl, function (data) {
            $(setting.tagShow).html(data);
            var $form = $(setting.form);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
                console.log(e);
            }
            $.AdminBSB.select.activate();
            $loading.waitMe('hide');
        });
        $loading.waitMe('hide');
    }
    $(document).on("click", $this.selector, function (e) {
        e.preventDefault();
        var $loading = bindLoading(setting.from);
        $.get($(this).attr("href"), function (data) {
            $(setting.tagShow).html(data);
            var $form = $(setting.from);
            try {
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
            } catch (e) {
            }
            $.AdminBSB.select.activate();
            $loading.waitMe('hide');
        });
    });
}
$.fn.toPost = function (setting = {}, callBack = null, callBackAddData = null) {
    setting.form = setting.form == undefined ? "[form-edit]" : setting.form;
    setting.msgTitle = setting.msgTitle == undefined ? "Thông báo" : setting.msgTitle;
    setting.msgType = setting.msgType == undefined ? "warning" : setting.msgType;
    setting.msgText = setting.msgText == undefined ? "Bạn có muốn thực hiện chức năng này?" : setting.msgText;
    var data = {};

    var $thisSelector = $(this);
    $($thisSelector).on("click", function () {
        var $this = $(this);
        swal({
            title: setting.msgTitle,
            text: setting.msgText,
            type: setting.msgType,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Đồng ý!",
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            if (callBackAddData != null) {
                data = callBackAddData(data);
            }
            $this.button('loading');
            $.ajax({
                type: "POST",
                url: $this.attr("data-action"),
                data: data,
                headers:
                    {
                        "RequestVerificationToken": $(setting.form).find("input[name='__RequestVerificationToken']").val()
                    },
                success: function (rs) {
                    if (callBack != null) {
                        callBack(rs, $this);
                    }
                    else {
                        swal({
                            title: "Thông báo!",
                            text: rs.message,
                            type: rs.type,
                            confirmButtonText: "Đóng!"
                        });
                        setTimeout(function () {
                            $this.button('reset');
                        }, 300);
                    }
                },
                error: function () {
                    alert("Vui lòng F5 trình duyệt rồi thử lại!");
                },
                complete: function (jqxhr, txt_status) {
                    if (jqxhr.status == 502) {
                        alertify.notify("Phiên làm việc đã kết thúc F5 trình duyệt rồi thử lại.", "warning", 5);
                    }
                }
            });
        });
    });
}
// v4.0.0
//$.fn.toButtonDowload = function(data = {}) {
//    var $this = $(this);
//    $($this).on("click", function () {
//        var url = $this.attr("data-url");
//        document.location.href = url;
//    });
//};