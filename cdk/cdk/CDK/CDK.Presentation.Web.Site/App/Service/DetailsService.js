'use strict';
cdkApp.service('detailsService', ['cdkDataService',"$q", function (cdkDataService,$q) {

  
        var self = this;
 
        self.dataRequest = "";
 
        self.data = null;
    
        self.getdata = function (requestValue) {
            
            if (requestValue === self.dataRequest && self.data) {
                
                var deferred = $q.defer();

                deferred.resolve(self.data);

                return deferred.promise;
            }
            
            return cdkDataService.getDetails(requestValue).then(function (g) {
                    if (g.data) {
                        self.data = g.data;
                        self.dataRequest = requestValue;
                        

                    } else {
                        self.data = null;
                        self.dataRequest = "";
                     
                    }
                
                    return $q.resolve(self.data);
                }, function(error) {
                    return $q.reject(error);
                });
            }
    
        


    return self;


}]);