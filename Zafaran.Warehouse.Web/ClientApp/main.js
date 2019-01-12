import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App'
import VueResource from 'vue-resource';
import GlobalComponents from './globalComponents'
import GlobalDirectives from './globalDirectives'
import Notifications from './components/NotificationPlugin'
import routes from './routes/routes'
import MaterialDashboard from './material-dashboard'
import Chartist from 'chartist'
import * as fileters from './filters/Arrayfilter';
import VueSweetalert2 from 'vue-sweetalert2';
import Toaster from 'v-toaster'
import 'v-toaster/dist/v-toaster.css'

Vue.use(Toaster, {
  timeout: 2000,
  position:'bottomLeft'
});
fileters.register();
Vue.use(VueSweetalert2);
Vue.use(VueRouter);
Vue.use(VueResource);
Vue.use(MaterialDashboard);
Vue.use(GlobalComponents);
Vue.use(GlobalDirectives);
Vue.use(Notifications);
const router = new VueRouter({
  routes,
  mode: 'history',
  linkExactActiveClass: 'nav-item active'
});
// global library setup
Object.defineProperty(Vue.prototype, '$Chartist', {
  get() {
    return this.$root.Chartist
  }
});

export default new Vue({
  render: h => h(App),
  router,
  data: {
    Chartist: Chartist
  },
  scrollBehavior(to, from, savedPosition) {
    return {x: 0, y: 0}
  }
});
