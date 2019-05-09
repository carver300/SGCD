import DashboardLayout from '../layout/DashboardLayout.vue'
// GeneralViews
import NotFound from '../pages/NotFoundPage.vue'

// Admin pages
import Overview from 'src/pages/Overview.vue'


const routes = [
  {
    path: '/',
    component: DashboardLayout,
    redirect: '/admin/overview'
  },
  {
    path: '/admin',
    component: DashboardLayout,
    redirect: '/admin/overview',
    children: [
      {
        path: 'overview',
        name: 'Overview',
        component: Overview
      },
      {
        path: 'AltaPaciente',
        name: 'AltaPaciente',
        component: () => import('../pages/Pacientes/AltaPacientes.vue')
      },
      {
        path: 'InformacionPacientes',
        name: 'InformacionPacientes',
        component: () => import('../pages/Pacientes/InformacionPacientes.vue')
      },
      {
        path: 'GeneracionServicios',
        name: 'GeneracionServicios',
        component: () => import('../pages/servicios/GeneracionServicios.vue')
      },
      {
        path: 'AgendarCita',
        name: 'AgendarCita',
        component: () => import('../pages/Citas/AgendarCita.vue')
      },
      {
        path: 'HistorialClinico',
        name: 'HistorialClinico',
        component: () => import('../pages/Pacientes/HistorialClinico.vue')
      }
    ]
  },
  { path: '*', component: NotFound }
]

/**
 * Asynchronously load view (Webpack Lazy loading compatible)
 * The specified component must be inside the Views folder
 * @param  {string} name  the filename (basename) of the view to load.
function view(name) {
   var res= require('../components/Dashboard/Views/' + name + '.vue');
   return res;
};**/

export default routes
