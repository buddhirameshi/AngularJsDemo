
app.directive('itemInfo', function () {
    return {
        restrict: 'E',
        scope: {
            info: '='
        },
        templateUrl: 'scripts/directives/itemInfo.html'
    };
});


