$(document).ready(
    function Preloading() {
        loadGenre();
        loadArtist();
        loadAlbumType();
    });
//流派下拉菜单实现
//select的使用技巧：http://www.w3cschool.cn/htmltags/tag-select.html
function loadGenre() {
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetGenreList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>"
                });
            contentString = "<select id='GenreId' name='GenreId' class='form-control'>" + contentString + "</select>";
            $('#GenreSelectList').html(contentString);
            $('#GenreSelectList').val($('CurrentGenreSelectedId').val());//被选项
        }
    })
}

//歌手下拉菜单实现
function loadArtist() {
    
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetArtistList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>"
                });
            contentString = "<select id='ArtistId' name='ArtistId' class='form-control'>" + contentString + "</select>";
            $('#ArtistSelectList').html(contentString);
            $('#ArtistSelectList').val($('CurrentArtistSelectedId').val());//被选项
        }
    })
}
//音乐类型下拉菜单实现
function loadAlbumType() {
   
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetAlbumTypeList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>"
                });
            contentString = "<select id='AlbumTypeId' name='AlbumTypeId' class='form-control'>" + contentString + "</select>";
            $('#AlbumTypeSelectList').html(contentString);
            $('#AlbumTypeSelectList').val($('CurrentAlbumTypeSelectedId').val());//被选项
        }
    })
    //
}
//图片上传实现
function upFileImg() {
    var file = $('#UploadedFile').prop('files');
    var data = new FormData();
    data.append('imgFile', files[0]);

    $.ajax({
        type: 'POST',
        url: "/AdminAlbum/UploadImFile",
        data: data,
        dataType: 'json',
        cache: false,
        processData: false,
        contentType: false,
        success: function (result) {
            alert(result.imgUrlString);
            $("#UrlString").val(result.imgUrlString);
        }
    });
}
//图片预览实现
function singleFileSelected() {
    var selectedFile=($("#UploadedFile"))[0].false[0];
    if(selectedFile){
        var FileSize=0;
        var imageType=/image.*/;
        if(selectedFile.size>1048576){
            FileSize=Math.round(selectedFile.size*100/1048576)/100+"MB";

        }
        else if(selectedFile.size>1024){
            FileSize=Math.round(selectedFile.size*100/1024)/100+"MB";
        }
        else{
            FileSize=selectedFile.size+"Bytes";
        }

        $("#FileName").text("文件名:"+selectedFile.naem);
        $("#FileSize").text("大小:"+FileSize);
        $("#FileType").text("类型:"+selectedFile.type);
    }
    if(selectedFile.type.match(imageType)){
        var reader= new FileReader();
        reader.onload=function(e){
            $("Imagecontainer").empty();
            var dataURL=reader.result;
            var img=new Image();
            img.src=dataURL;
            img.className="thumb"
            $("Imagecontainer").append(img);

        };
        reader.readAsDataURL(selectedFile);
    }
}