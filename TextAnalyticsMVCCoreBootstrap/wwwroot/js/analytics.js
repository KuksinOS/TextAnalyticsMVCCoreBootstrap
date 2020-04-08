var analytics = (function () {

    var mostFrequentChar = function (fileName) {
        return new Promise(function (resolve, reject) {
       // alert(fileName);
        $.ajax({
            type: "POST",
            url: "/Home/MostFrequentChar",
            data: '"' + fileName + '"',
            //data: JSON.stringify(phonemobile),
            //data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: (data) => {
                resolve(data);                            
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
              
                //debugger;
                if (XMLHttpRequest.status == 404) {
                    alert('404');
                    reject(err);
                }

                else {
                    alert(errorThrown + "Not Found? " + XMLHttpRequest);
                    reject(err);
                }
            }
        });

        });
        
    };

    var detectLanguage = function (fileName) {
        return new Promise(function (resolve, reject) {
            // alert(fileName);
            $.ajax({
                type: "POST",
                url: "/Home/DetectLanguage",
                data: '"' + fileName + '"',
                //data: JSON.stringify(phonemobile),
                //data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: (data) => {
                    resolve(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {

                    //debugger;
                    if (XMLHttpRequest.status == 404) {
                        alert('404');
                        reject(err);
                    }

                    else {
                        alert(errorThrown + "Not Found? " + XMLHttpRequest);
                        reject(err);
                    }
                }
            });

        });

    };


    return {
        GetAnalytics: function (keyanalytic, fileName) {
            let result;
            switch (keyanalytic) {
                case "1":
                    result = mostFrequentChar(fileName);
                    break;
                case "2":
                    result = detectLanguage(fileName);
                    break;
                case "3":
                    result = "";
                    break; 
                default:              
            }

            return result;
        }

    };


})();

