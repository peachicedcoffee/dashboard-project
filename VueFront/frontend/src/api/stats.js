import axios from 'axios'

const api = axios.create({
  baseURL: 'http://localhost:5127/api',
})

//요청마다 토큰 자동 첨부
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')
  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

export const getSummary = () => api.get('/stats/summary')
export const getMonthly = () => api.get('/stats/monthly')
