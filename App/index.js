import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import Card from './Components/Cards/Card.vue'



Vue.config.productionTip = false
Vue.use(VueRouter)

const routes = [
  { 
    path: '/', 
    component: App,
    children: [        
        {
          path: 'card',
          component: Card
        }
      ]
  }
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

new Vue({
  el: '#app',
  template: "<div><router-view></router-view></div>",  
  router
})
