import DashboardLayout from '../layout/DashboardLayout.vue'
// GeneralViews
import NotFound from '../pages/NotFoundPage.vue'

// Admin pages
import Overview from 'src/pages/Overview.vue'
import Login from 'src/pages/Login/Login.vue'

const routes = [
  {
    path: '/',
    component: Login,
  },
  {
    path: '/SGCD',
    name: 'SGCD',
    component: DashboardLayout,
    redirect: '/SGCD/overview',
    children: [
      {
        path: 'overview',
        name: 'Overview',
        component: Overview
      },
      {
        path: 'altapaciente',
        name: 'AltaPaciente',
        component: () => import('../pages/Pacientes/AltaPacientes.vue')
      },
      {
        path: 'informacionpacientes',
        name: 'InformacionPacientes',
        component: () => import('../pages/Pacientes/InformacionPacientes.vue')
      },
      {
        path: 'GeneracionServicios',
        name: 'GeneracionServicios',
        component: () => import('../pages/servicios/GeneracionServicios.vue')
      },
      {
        path: 'agendarcita',
        name: 'AgendarCita',
        component: () => import('../pages/Citas/AgendarCita.vue')
      },
      {
        path: 'historialclinico',
        name: 'HistorialClinico',
        component: () => import('../pages/Pacientes/HistorialClinico.vue')
      },
      {
        path: 'listadeespera',
        name: 'ListaDeEspera',
        component: () => import('../pages/Citas/ListaDeEspera.vue')
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
