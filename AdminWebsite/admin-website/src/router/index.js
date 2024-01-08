import { createRouter, createWebHistory } from 'vue-router'
import { checkAuthUser } from '@/firebaseconfig'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('../views/HomeView.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/logout',
      name: 'logout',
      component: () => import('../views/LogoutView.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/message',
      name: 'message',
      component: () => import('../views/AdminMessageView.vue'),
      meta: { requiresAuth: true }
    }
  ]
})

router.beforeEach(async (to) => {
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth)
  const currentUser = await checkAuthUser()
  if (requiresAuth && !currentUser) {
    return '/login'
  }
})

export default router
