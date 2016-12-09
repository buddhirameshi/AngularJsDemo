app.factory('itemFactory', ['$http', function ($http) {
    //return $http.get('http://ramz:4545/api/Item/GetItems')
    //       .success(function (data) {
    //           return data;
    //       })
    //       .error(function (data) {
    //           return data;
    //       });

    var urlBase = 'http://ramz:4545/api/Item';
    var dataFactory = {};

    dataFactory.getItems = function () {
        var getUrlBase = urlBase + "/GetItems";
        return $http.get(getUrlBase).success(function (data) { return data; }).error(function (error) { return error; });
    };

    dataFactory.getItemById = function (id) {
        var getUrlBase = urlBase + "/GetItem/"+id;
        return $http.get(getUrlBase).success(function (data) { return data; }).error(function (error) { return error; });
    };

    dataFactory.addItem = function (oneItem) {
        var url = urlBase + "/InsertItem"
        return $http.post(url, oneItem).success(function (data) { return data; }).error(function (error) { return error; });
    };

    dataFactory.editItem = function (oneItem) {
        var request = {
            method: 'PUT',
            url: urlBase + '/UpdateItem',
            data: oneItem,
            headers: {
                'Content-Type': 'text/HTML'
            }
        };
        return $http(request)
                    .success(
                    function (data) {
                        return data;
                    })
           .error( function (errorData) {
               return errorData;
            });
         };

    dataFactory.deleteItem = function (id) {
        var url = urlBase + "/DeleteItem/" + id;
        return $http.delete(url).success(function (data) { return data; }).error(function (error) { return error; });
    };

    //dataFactory.getOrders = function (id) {
    //    return $http.get(urlBase + '/' + id + '/orders');
    //};

    return dataFactory;
}]);


