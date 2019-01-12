import Vue from 'vue';

export  function register() {
  Vue.filter('filter', function (array, searchTerm) {
    return array.filter(item => {
      for (let prop in item) {
        if (typeof (item[prop]) === typeof("") && item[prop].includes(searchTerm)) {
          return true;
        }
      }
    });
  })
}
