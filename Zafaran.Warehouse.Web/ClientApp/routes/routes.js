import DashboardLayout from '../pages/Layout/DashboardLayout.vue'
import Dashboard from '../pages/Dashboard.vue'
import Commodities from '../pages/Commodities/index'
import TableList from '../pages/TableList.vue'
import Typography from '../pages/Typography.vue'
import Icons from '../pages/Icons.vue'
import Notifications from '../pages/Notifications.vue'
import UpgradeToPRO from '../pages/Layout/MobileMenu.vue'

const routes = [
  {
    path: '/',
    component: DashboardLayout,
    redirect: '/dashboard',
    children: [
      {
        path: 'dashboard',
        name: 'Dashboard',
        component: Dashboard
      },
      {
        path: 'commodities',
        name: 'commodities',
        component: Commodities
      },
      {
        path: 'table',
        name: 'Table List',
        component: TableList
      },
      {
        path: 'typography',
        name: 'Typography',
        component: Typography
      },
      {
        path: 'icons',
        name: 'Icons',
        component: Icons
      },
      {
        path: 'notifications',
        name: 'Notifications',
        component: Notifications
      },
      {
        path: 'upgrade',
        name: 'Upgrade to PRO',
        component: UpgradeToPRO
      }
    ]
  }
]

export default routes
