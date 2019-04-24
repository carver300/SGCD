import Vue from 'vue'
import Router from 'vue-router'
import Login from './views/Login/Login.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    },
    {
      path: '/Home',
      name: 'Home',
      children:[
        {
          path: 'DashBoard',
          name: 'DashBoard',
          component: () => import(/* webpackChunkName: "about" */ './views/ContenidoPrincipal/DashBoard.vue')
        },
        {
          path: 'AltaPaciente',
          name: 'AltaPaciente',
          component: () => import('./views/Pacientes/AltaPaciente.vue')
        },
        {
          path:'ConsultaInformacion',
          name:'ConsultaInformacion',
          component: () => import('./views/Pacientes/ConsultarInformacionPaciente.vue')
        }
      ],
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/ContenidoPrincipal/Home.vue')
    },
    
  ]
})
