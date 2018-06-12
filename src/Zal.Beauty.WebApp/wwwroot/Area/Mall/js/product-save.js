var $selectedSkuImg;
$(function () {
    //新增品牌按钮点击事件
    $("#add-brand-btn").click(function () {
        var brand = $("#BrandName").val();
        if (!brand) {
            toastr.warning("请输入品牌", "操作提示!");
            return false;
        }
        show_loading_bar(70);
        $.post("/Mall/Brand/Save", { Name: brand }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        $("#BrandName").val("");
                        var $block = $("#brand-group .form-block").first();
                        var maxCount = $block.find("input[type='radio']").length;
                        $("#brand-group .form-block").each(function () {
                            if ($(this).find("input[type='radio']").length < maxCount) {
                                $block = $(this);
                                return false;  //跳出循环
                            }
                        })
                        //新增品牌页面元素
                        $block.append('<lable><div class="cbr-replaced cbr-radio">' +
                            '<div class="cbr-input"><input type="radio" value="' + resp.id + '" class="cbr cbr-done"></div>' +
                            '<div class="cbr-state"><span></span></div>' +
                            '</div>' + brand + '</lable><br>');
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        });
    });
    //删除品牌按钮点击事件
    $("#del-brand-btn").click(function () {
        var delIds = [];
        var $checked = $("#brand-group .cbr-checked");
        if ($checked.length === 0) {
            toastr.warning("请选择需要删除的品牌", "操作提示!");
            return false;
        }
        show_loading_bar(70);
        $.post("/Mall/Brand/Delete", { id: $checked.find("input[type='radio']").attr("value") }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        $checked.removeClass("cbr-checked");
                        $checked.addClass("cbr-disabled");
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        })
    });

    //新增规格按钮点击事件
    $("#add-specification-btn").click(function () {
        var specification = $("#SpecificationName").val();
        if (!specification) {
            toastr.warning("请输入规格", "操作提示!");
            return false;
        }
        show_loading_bar(70);
        $.post("/Mall/Specification/Save", { Name: specification }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        $("#SpecificationName").val("");
                        var $group = $(".specification-group").last();

                        //新增品牌页面元素
                        $group.after('<div class="form-group specification-group" specification-id="' + resp.id + '" specification-name="' + specification + '">' +
                            '<strong style="position: relative;min-height: 1px;padding-right: 15px;padding-left: 15px;display:block;margin-left: 16.7%;">' +
                            specification +
                            '<a href="javascript:void(0);" title="新增规格值"><span class="glyphicon glyphicon-plus-sign"></span></a></strong>' +
                            '<div class="col-sm-2"></div><div class="col-sm-2"><div class="form-block"></div></div>' +
                            '<div class="col-sm-2"></div><div class="col-sm-2"><div class="form-block"></div></div>' +
                            '<div class="col-sm-2"></div><div class="col-sm-2"><div class="form-block"></div></div>' +
                            '<div class="col-sm-2"></div><div class="col-sm-2"><div class="form-block"></div></div>' +
                            '<div class="col-sm-2"></div><div class="col-sm-2"><div class="form-block"></div></div>' + '</div>');
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        });
    });
    //删除品牌按钮点击事件
    $("#del-brand-btn").click(function () {
        var delIds = [];
        var $checked = $("#brand-group .cbr-checked");
        if ($checked.length === 0) {
            toastr.warning("请选择需要删除的品牌", "操作提示!");
            return false;
        }
        show_loading_bar(70);
        $.post("/Mall/Brand/Delete", { id: $checked.find("input[type='radio']").attr("value") }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        $checked.removeClass("cbr-checked");
                        $checked.addClass("cbr-disabled");
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        })
    });

    //新增规格值点击按钮事件
    var specificationId = 0, $specification;
    $(document).on("click", ".specification-group .glyphicon-plus-sign", function () {
        $specification = $(this).parent().parent().parent("div.specification-group");
        specificationId = $specification.attr("specification-id");
        $("#add-value-modal #SpecificationValue").val("");
        $('#add-value-modal').modal('show', { backdrop: 'static' });
    });

    //新增规格值保存
    $("#add-value-modal .save-btn").click(function () {
        var data = {};
        data.SpecificationId = specificationId;
        data.Name = $("#add-value-modal #SpecificationValue").val();
        if (!data.Name) {
            toastr.warning("请输入规格值", "操作提示!");
            return false;
        }
        show_loading_bar(70);
        $.post("/Mall/Specification/SaveValue", { parameter: data }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        $('#add-value-modal').modal("hide");
                        var $block = $specification.find(".form-block").first();
                        var maxCount = $block.find("input[type='checkbox']").length;
                        $specification.find(".form-block").each(function () {
                            if ($(this).find("input[type='checkbox']").length < maxCount) {
                                $block = $(this);
                                return false;  //跳出循环
                            }
                        })
                        $block.append('<lable><div class="cbr-replaced">' +
                            '<div class="cbr-input"><input type="checkbox" name="' + data.Name + '" value="' + resp.id + '" class="cbr cbr-done"></div>' +
                            '<div class="cbr-state"><span></span></div>' +
                            '</div> ' + data.Name + '</lable><br>');
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        });
    });

    //规格值点击事件
    $(document).on("click", ".cbr-replaced", function () {
        var specs = [];
        var totalRow = 1;
        //选中规格和值
        $(".specification-group").each(function () {
            var $this = $(this);
            var $values = $this.find(".cbr-checked");
            if ($values.length > 0) {
                var values = [];
                $values.each(function () {
                    values.push({
                        name: $(this).find("input[type='checkbox']").attr("name"),
                        id: $(this).find("input[type='checkbox']").attr("value")
                    });
                });
                specs.push({
                    id: $this.attr("specification-id"),
                    name: $this.attr("specification-name"),
                    values: values
                });
                totalRow *= values.length;
            }
        });
        if (specs.length === 0) {
            $("#specification-table").html("");
            return false;
        }
        //组装表格Html
        var html = "<thead><tr>";
        for (var i = 0; i < specs.length; i++) {
            html += "<th>" + specs[i].name + "</th>";
        }
        html += "<th>条码</th><th>采购价</th><th>市场价</th><th>销售价</th><th>库存</th><th>图片</th></tr></thead><tbody>"
        for (var i = 1; i <= totalRow; i++) {
            var specificationIdsStr = "";
            var skuName = "";
            var tdHtml = "";
            var tmpTotalRow = totalRow;
            for (var j = 0; j < specs.length; j++) {
                if (specs[j].values.length === 1) {
                    if (i === 1) {
                        tdHtml += "<td rowspan='" + totalRow + "'>" + specs[j].values[0].name + "</td>";
                        specs[j].usedValueId = specs[j].values[0].id;
                        specs[j].usedValueName = specs[j].values[0].name;
                    }
                } else {
                    var rowCount = tmpTotalRow / specs[j].values.length;
                    if ((i - 1) % rowCount === 0) {
                        var index = (i - 1) / rowCount % specs[j].values.length;
                        tdHtml += "<td rowspan='" + rowCount + "'>" + specs[j].values[index].name + "</td>";
                        specs[j].usedValueId = specs[j].values[index].id;
                        specs[j].usedValueName = specs[j].values[index].name;
                    }

                }
                tmpTotalRow = tmpTotalRow / specs[j].values.length;
                //记录规格和规格值ID字符串（“规格1ID，规格1值ID|规格2ID，规格2值ID”）
                specificationIdsStr += (specificationIdsStr ? "|" : "") + specs[j].id + "," + specs[j].usedValueId;
                //记录SkuName（“规格值1，规格值2”）
                skuName += skuName ? " " + specs[j].usedValueName : specs[j].usedValueName;
            }
            tdHtml += "<td><input type='text' class='form-control barcode'></td>";
            tdHtml += "<td><input type='number' class='form-control purchase-price'></td>";
            tdHtml += "<td><input type='number' class='form-control market-price'></td>";
            tdHtml += "<td><input type='number' class='form-control sale-price'></td>";
            tdHtml += "<td><input type='number' class='form-control quantity'></td>";
            tdHtml += "<td title='点击设置sku图片' style='text-align: center;vertical-align: middle;padding:0px;'><a href='javascript:void(0);' data-imgId='' class='select-sku-img'><img src='../../images/add.png' height='20' width='20'  class='sku-picture'/></a></td>";
            html += "<tr class='sku-tr' sku-name='" + skuName + "' value-ids='" + specificationIdsStr + "'>" + tdHtml + "</tr>";
        }
        html += "</tbody>";
        $("#specification-table").html(html);
    });

    var imageType = 0; // 1: 选择主图; 2: 选择sku图片；3：选择辅图
    //处理商品主图
    $(document).on("click", "#select-main-image", function () {
        imageType = 1;
        $("#flies-modal").modal("show");
        $.ajax({
            url: "/Common/File/FileModal",
            success: function (response) {
                $('#flies-modal .modal-body-files').html(response);
            }
        });
    });

    //处理商品辅图
    $(document).on("click", "#select-other-image", function () {
        imageType = 2;
        $("#flies-modal").modal("show");
        $.ajax({
            url: "/Common/File/FileModal",
            success: function (response) {
                $('#flies-modal .modal-body-files').html(response);
            }
        });
    });

    //删除辅图
    $(document).on("click", ".del-other-image", function () {
        $(this).parent("a").remove();
    })

    //处理sku图片
    $(document).on("click", ".select-sku-img", function () {
        imageType = 3;
        $selectedSkuImg = $(this);
        $("#flies-modal").modal("show");
        $.ajax({
            url: "/Common/File/FileModal",
            success: function (response) {
                $('#flies-modal .modal-body-files').html(response);
            }
        });
    });

    //选择模态框图片图片
    $("#files-save").click(function () {
        var imgId = $("#file-modal-List").find(".cbr-checked").find("input[type='checkbox']").val();
        var imgUrl = $("#file-modal-List").find(".cbr-checked").find("input[type='checkbox']").attr("data-url");
        if (!imgId) {
            toastr.warning("请选择图片", "操作提示！");
            return false;
        }
        if (imageType === 1) {
            $("#main-image-group").attr("data-imgId", imgId);
            $("#select-main-image img").attr("src", imgUrl);
            $("#select-main-image span").hide();
            $("#select-main-image img").show();
        } else if (imageType === 2) {
            var imgHtml = '<a data-imgId="' + imgId + '" class="other-image-item" href="javascript:void(0);" style="display: inline-block; width:100px;height:100px;border: 2px dotted #d9dadc;text-align: center;vertical-align: middle;line-height:100px;margin-right: 15px"><img style="width: 96px;height: 96px;margin-bottom: 6px;" ' +
                ' src="' + imgUrl + '" /><span class="glyphicon glyphicon-remove del-other-image" style="float: right;margin-right: -7px;margin-top: -111px;color: #cc3f44"></span></a>';
            $("#select-other-image").before(imgHtml);
        } else if (imageType === 3) {
            $selectedSkuImg.attr("data-imgId", imgId);
            $selectedSkuImg.find("img").attr("src", imgUrl);
            $selectedSkuImg.find("img").attr("height", "50");
            $selectedSkuImg.find("img").attr("width", "50");
        }
        $("#flies-modal").modal("hide");
    });

    //保存商品
    $("#save-btn").click(function () {
        //获取商品名称
        var name = $("input[name='Name']").val();
        if (!name) {
            toastr.warning("请输入商品名称", "操作提示！");
            return false;
        }
        //获取商品副标题
        var subTitle = $("textarea[name='SubTitle']").val();
        if (!subTitle) {
            toastr.warning("请输入商品副标题", "操作提示！");
            return false;
        }
        //获取商品主图
        var imgs = [];
        var mainImgId = $("#main-image-group").attr("data-imgid");
        if (!mainImgId) {
            toastr.warning("请选择商品主图", "操作提示！");
            return false;
        }
        imgs.push({ ImgId: mainImgId, Type: 1 });
        //获取商品品牌
        var brandId = $("#brand-group .cbr-checked input").attr("value");
        if (!brandId) {
            toastr.warning("请选择商品品牌", "操作提示！");
            return false;
        }
        //获取商品标签
        var tags = [];
        var $tagIds = $("#tag-group .cbr-checked");
        $tagIds.each(function () {
            tags.push({ TagId: $(this).find("input").attr("value") });
        });
        //获取sku规格信息
        var $skuTrs = $("tr.sku-tr");
        if (!$skuTrs || $skuTrs.length === 0) {
            toastr.warning("请选择商品规格", "操作提示！");
            return false;
        }
        var skus = [];
        var isAllPass = true;
        $skuTrs.each(function () {
            var sku = {
                ImgId: $(this).find(".select-sku-img").attr("data-imgid"),
                Name: $(this).attr("sku-name"),
                Barcode: $(this).find(".barcode").val(),
                PurchsePrice: $(this).find(".purchase-price").val(),
                MarketPrice: $(this).find(".market-price").val(),
                SalePrice: $(this).find(".sale-price").val(),
                Quantity: $(this).find(".quantity").val()
            };
            //验证sku信息
            if (!sku.PurchsePrice || Number(sku.PurchsePrice) <= 0) {
                toastr.warning("请填写正确sku采购价", "操作提示！");
                isAllPass = false;
                return false;
            }
            if (!sku.MarketPrice || Number(sku.MarketPrice) <= 0) {
                toastr.warning("请填写正确sku市场价", "操作提示！");
                isAllPass = false;
                return false;
            }
            if (!sku.SalePrice || Number(sku.SalePrice) <= 0) {
                toastr.warning("请填写正确sku销售价", "操作提示！");
                isAllPass = false;
                return false;
            }
            if (!sku.Quantity || Number(sku.Quantity) < 0) {
                toastr.warning("请填写正确sku库存", "操作提示！");
                isAllPass = false;
                return false;
            }
            if (!sku.ImgId || Number(sku.ImgId) <= 0) {
                toastr.warning("请选择sku图片", "操作提示！");
                isAllPass = false;
                return false;
            }
            //获取sku规格信息
            var specifications = [];
            var valueIdsStr = $(this).attr("value-ids");
            var specIdsStr = valueIdsStr.split("|");
            for (var i = 0; i < specIdsStr.length; i++) {
                var tmpIds = specIdsStr[i].split(",");
                specifications.push({ SpecificationId: tmpIds[0], SpecificationValueId: tmpIds[1] });
            }
            sku.SkuSpecifications = specifications;
            skus.push(sku);
        });
        if (!isAllPass) return false;
        //获取商品辅图
        var $otherImgIds = $("#other-image-group .other-image-item");
        $otherImgIds.each(function () {
            imgs.push({ ImgId: $(this).attr("data-imgid"), Type: 2 });
        });
        //组装商品数据
        var product = {
            BrandId: brandId,
            Name: name,
            SubTitle: subTitle,
            Imgs: imgs,
            Tags: tags,
            Skus: skus
        };
        //提交商品数据
        show_loading_bar(70);
        $.post("/Mall/Product/Save", { product: product }, function (resp) {
            show_loading_bar({
                pct: 100,
                finish: function () {
                    if (resp.isSuccess) {
                        window.location.href = "/Mall/Product/List";
                    }
                    else {
                        toastr.error(resp.message, "操作错误!");
                    }
                }
            });
        })
    });
})