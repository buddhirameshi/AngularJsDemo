
app.controller('MainController', ['$scope', 'itemFactory', function ($scope, itemFactory) {
    $scope.title = 'Angular Grid View Demo';
    itemFactory.getItems().success(function (data) {
        $scope.model = {
            items: data,
            selected: {}
        };
    });



    //$scope.editItem = function (index) {
    //    var rowNum = index;
    //    var row = $(this).closest('tr');
    //    alert(row);
    //  //  alert(tds.length);
    //    //for (var i = 0; i < tds.length; i++) {
    //    //    if (i > 0 && i < 3) {
    //    //        var currentValue = $(tds[i]).html();
    //    //        $(tds[i]).html("<input id='edit" + rowNum + i + "' type='text' value='" + currentValue + "'/>");
    //    //    }
    //    //    else if (i == 3) {
    //    //        $(tds[i]).html("<div class='btn-group form-inline'><div id='updateBtn'><img src='Styles/update.ico' class='imgBtn btn'/></div><div id='cancelBtn'><img src='Styles/cancel.ico' class='imgBtn btn'/></div></div>");
    //    //    }
    //    //    else {
    //    //        continue;
    //    //    }
    //    //}
    //    var newItem ={ItemID:$scope[index].ItemID,Description:$scope[index].Description,Price:$scope[index].Price};
    //    itemFactory.editItem(newItem).success(function(data){alert('edited');});
    //};
    $scope.deleteItem = function (index) {
        alert($scope.items[index].ItemID);
        itemFactory.deleteItem(index).success(function (data) { alert('deleted'); });
    };
    $scope.addItem = function (index) {
        alert($scope.items[index].ItemID);
        var newItem = { ItemID: $scope[index].ItemID, Description: $scope[index].Description, Price: $scope[index].Price };

        itemFactory.addItem(newItem).success(function (data) { alert('added'); });
    };

    $scope.editItem = function (item) {
        $scope.model.selected = angular.copy(item);
    };

    // gets the template to ng-include for a table row / item
    $scope.getTemplate = function (item) {
        if (item.ItemID === $scope.model.selected.ItemID) {
            return 'edit';
        }
        else {
            return 'display';
        }
    };
    $scope.saveItem = function (index) {
        $scope.model.items[index] = angular.copy($scope.model.selected);
        var editedItem = { ItemID: $scope.model.items[index].ItemID, Description: $scope.model.items[index].Description, Price: $scope.model.items[index].Price };
        itemFactory.editItem(editedItem).success(function (data) { console.log('edited'); }).error(function (error) { console.log(error);});
        $scope.reset();
    };

    $scope.reset = function () {
        $scope.model.selected = {};
    };


}]);


