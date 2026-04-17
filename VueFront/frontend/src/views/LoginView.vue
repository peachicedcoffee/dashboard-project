<template>
  <div class="login-wrap">
    <div class="login-box">
      <h2 class="title">Dashboard Login</h2>

      <div class="field">
        <label>아이디</label>
        <input v-model="form.username" type="text" placeholder="아이디 입력" />
      </div>

      <div class="field">
        <label>비밀번호</label>
        <input v-model="form.password" type="password" placeholder="비밀번호 입력" />
      </div>

      <p v-if="errorMsg" class="error">{{ errorMsg }}</p>

      <button @click="handleLogin" :disabled="loading">
        {{ loading ? '로그인 중...' : '로그인' }}
      </button>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { login } from '@/api/auth'

const router = useRouter()

const form = ref({
  username: '',
  password: '',
})

const errorMsg = ref('')

const loading = ref(false)

const handleLogin = async () => {
  errorMsg.value = ''

  if (!form.value.username || !form.value.password) {
    errorMsg.value = '아이디와 비밀번호를 입력해주세요.'
    return
  }

  loading.value = true

  try {
    const { data } = await login(form.value.username, form.value.password)
    localStorage.setItem('token', data.token)
    localStorage.setItem('isLoggedIn', 'true')
    router.push('/')
  } catch (e) {
    errorMsg.value = e.response?.data?.message ?? '로그인실패'
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.login-wrap {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: #0f172a;
}
.login-box {
  background: #1e293b;
  border-radius: 16px;
  padding: 2.5rem;
  width: 100%;
  max-width: 400px;
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}
.title {
  color: #fff;
  font-size: 1.5rem;
  text-align: center;
  margin-bottom: 0.5rem;
}
.field {
  display: flex;
  flex-direction: column;
  gap: 0.4rem;
}
label {
  color: #94a3b8;
  font-size: 0.85rem;
}
input {
  background: #0f172a;
  border: 1px solid #334155;
  border-radius: 8px;
  padding: 0.75rem 1rem;
  color: #fff;
  font-size: 1rem;
  outline: none;
}
input:focus {
  border-color: #4f86f7;
}
button {
  background: #4f86f7;
  color: #fff;
  border: none;
  border-radius: 8px;
  padding: 0.85rem;
  font-size: 1rem;
  cursor: pointer;
  margin-top: 0.5rem;
}
button:hover {
  background: #3b6fd4;
}
button:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}
.error {
  color: #f87171;
  font-size: 0.85rem;
  text-align: center;
}
</style>
