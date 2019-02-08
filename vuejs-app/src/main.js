import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './registerServiceWorker'
import Buefy from 'buefy';
import 'buefy/dist/buefy.css'
import axios from 'axios'
import ApiUrl from '../src/apiUrl'

const apiUrl = new ApiUrl()

Vue.use(Buefy)

Vue.config.productionTip = false

axios.defaults.baseURL = `https://localhost:44392/api/`

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
