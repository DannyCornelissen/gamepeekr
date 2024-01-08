<template>
  <div>
    <n-space vertical>
      <n-card v-for="(message, index) in messages" :key="index" style="background-color: #64CCC5;">
        <n-text>{{ message }}</n-text>
      </n-card>
    </n-space>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { useSignalR } from '@dreamonkey/vue-signalr';
import { create } from 'naive-ui';

const naive = create();

export default {
  setup() {
    const signalr = useSignalR();
    const messages = ref([]);

    onMounted(() => {
      const storedMessages = sessionStorage.getItem('reviewMessages');
      if (storedMessages) {
        messages.value = JSON.parse(storedMessages);
      }

      signalr.on('ReceiveMessage', (message) => {
        console.log(message);
        messages.value.push(message);
        sessionStorage.setItem('reviewMessages', JSON.stringify(messages.value));
      });
    });

    return {
      messages,
    };
  },
};
</script>



