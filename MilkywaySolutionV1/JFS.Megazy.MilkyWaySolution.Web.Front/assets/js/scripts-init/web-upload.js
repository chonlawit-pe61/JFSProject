var WebUpload = WebUpload || {};
//Being File Upload ตรวจสอบขนาดไฟล์
WebUpload.fileSelected = function fileSelected(fileToUpload) {
    var file = fileToUpload.files[0];
    if (file) {

        ($(fileToUpload)).next('span').remove();
        var fileSize = 0;
        if (file.size > 1024 * 1024)
            fileSize = (Math.round(file.size * 100 / (1024 * 1024)) / 100).toString() + 'MB';
        else
            fileSize = (Math.round(file.size * 100 / 1024) / 100).toString() + 'KB';

        $('<span class="filesize">Size: ' + fileSize + "</span>").insertAfter($(fileToUpload));
    }
}

/*Start file upload*/
WebUpload.uploadFile = function uploadFile(fileToUpload, url, divProgressBar,callBack) {
    //var fd = new FormData();
    //fd.append("fileToUpload", fileToUpload.files[0]);
    var xhr = new XMLHttpRequest();
    xhr.upload.addEventListener("progress", function (evt) { WebUpload.uploadProgress(evt, divProgressBar); }, false);
    xhr.addEventListener("load", function (evt) { WebUpload.uploadComplete(evt, fileToUpload, divProgressBar, callBack); }, false);
    xhr.addEventListener("error", WebUpload.uploadFailed, false);
    xhr.addEventListener("abort", WebUpload.uploadCanceled, false);
    xhr.open("POST", url);
    xhr.send(fileToUpload);
}

WebUpload.uploadProgress = function uploadProgress(evt, progressBar) {
    //console.log('uploadprogresss');
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        var tt = percentComplete.toString() + '%';
        if ($(progressBar).length) {
            //$(divProgressBar).html(tt);
            //var percent = Math.round((e.loaded / e.total) * 100);
            $(progressBar).attr('aria-valuenow', percentComplete).css('width', percentComplete + '%').text(percentComplete + '%');
        }
    }
    else {
        if ($(progressBar).length) {
            $(progressBar).html('unable to compute');
        }
    }
}

WebUpload.uploadComplete = function uploadComplete(evt, fileToUpload, progressBar,callBack) {
    /* This event is raised when the server send back a response */
    if (evt.target.responseText) {
        if ($(progressBar).length) {
            setTimeout(function () {
                $(progressBar).attr('aria-valuenow', 0).css('width', '0%').text('Finish');
            }, 1000); 
        }
        if (typeof callBack === "function")
        {
            //return JSON.parse(evt.target.response);
            callBack(evt.target.response);
        }
    }

}

WebUpload.uploadFailed =function uploadFailed(evt) {
    console.log("There was an error attempting to upload the file.");
}

WebUpload.uploadCanceled =function uploadCanceled(evt) {
    console.log("The upload has been canceled by the user or the browser dropped the connection.");
}


        //End File Upload