<template>
  <div class="wrapper" :class="{'nav-open': $sidebar.showSidebar}">
    <notifications></notifications>

    <side-bar>
      <mobile-menu slot="content"></mobile-menu>
      <sidebar-link to="/dashboard">
        <md-icon>dashboard</md-icon>
        <p>داشبورد</p>
      </sidebar-link>
      <sidebar-link to="/commodities">
        <md-icon>settings_input_svideo</md-icon>
        <p>محصولات</p>
      </sidebar-link>
      <sidebar-link to="/workers">
        <md-icon>person_pin</md-icon>
        <p>کارمندان</p>
      </sidebar-link>
      <sidebar-link to="/typography">
        <md-icon>store</md-icon>
        <p>انبار ها</p>
      </sidebar-link>
      <sidebar-link to="/icons">
        <md-icon>restaurant</md-icon>
        <p>رستوران ها</p>
      </sidebar-link>
    </side-bar>

    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content>

      </dashboard-content>

    </div>
  </div>
</template>
<style lang="scss">

</style>
<script>
import TopNavbar from './TopNavbar.vue'
import DashboardContent from './Content.vue'
import MobileMenu from '../../pages/Layout/MobileMenu.vue'

export default {
  components: {
    TopNavbar,
    DashboardContent,
    MobileMenu
  }
}
</script>
