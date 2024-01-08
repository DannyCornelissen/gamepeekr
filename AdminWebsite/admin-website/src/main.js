import './assets/main.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import naive from 'naive-ui'
import { createPinia } from 'pinia'
import { VueSignalR } from '@dreamonkey/vue-signalr'
import { HubConnectionBuilder } from '@microsoft/signalr';

const pinia = createPinia()
const app = createApp(App)

 const connection = new HubConnectionBuilder()
  .withUrl('https://localhost:32001/message')
  .build();


app.use(VueSignalR, { connection })
app.use(pinia)
app.use(router)
app.use(naive)

app.mount('#app')
