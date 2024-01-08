<script setup>
import { auth } from '@/firebaseconfig';
</script>

<template>
  <main>
    <h1>Home View</h1>
    Welcome {{ auth.currentUser.displayName}}!
  </main>
</template>

