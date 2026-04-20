<template>
  <div class="dashboard">
    <!--KPI 카드-->
    <div class="kpi-grid">
      <KpiCard v-for="kpi in kpiCards" :key="kpi.label" :label="kpi.label" :value="kpi.value" />
    </div>

    <!--월별 차트-->
    <div class="chart-box">
      <Bar v-if="chartData !== null" :data="chartData" :options="chartOptions" />
    </div>

    <!--라인 차트-->
    <div class="chart-box" style="margin-top: 1rem">
      <Line v-if="lineData !== null" :data="lineData" :options="chartOptions" />
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { Bar, Line } from 'vue-chartjs'
import {
  Chart as ChartJs,
  BarElement,
  LineElement,
  PointElement,
  CategoryScale,
  LinearScale,
  Tooltip,
  Legend,
} from 'chart.js'
import KpiCard from '@/components/KpiCard.vue'
import { getSummary, getMonthly } from '@/api/stats'

ChartJs.register(BarElement, LineElement, PointElement, CategoryScale, LinearScale, Tooltip, Legend)

const kpiCards = ref([])
const chartData = ref(null)
const lineData = ref(null)

const chartOptions = {
  responsive: true,
  plugins: { legend: { position: 'top' } },
}

onMounted(async () => {
  const { data: s } = await getSummary()
  kpiCards.value = [
    { label: '총 사용자', value: s.totalUsers.toLocaleString() },
    { label: '총 매출', value: `${s.totalSales.toLocaleString()}` },
    { label: '활성 세션', value: String(s.activeSession) },
    { label: '에러율', value: `${s.errorRate}%` },
  ]

  const { data: m } = await getMonthly()
  ;((chartData.value = {
    labels: m.map((d) => d.month),
    datasets: [
      { label: '매출', data: m.map((d) => d.sales), backgroundColor: '#4f86f7' },
      { label: '방문자', data: m.map((d) => d.visits), backgroundColor: '#f7a44f' },
    ],
  }),
    (lineData.value = {
      labels: m.map((d) => d.month),
      datasets: [
        {
          label: '매출 추세',
          data: m.map((d) => d.sales),
          borderColor: '#4f86f7',
          backgroundColor: 'rgba(79,134,247,0.1)',
          tension: 0.4,
          fill: true,
        },
        {
          label: '방문자 추세',
          data: m.map((d) => d.visits),
          borderColor: '#f7a44f',
          backgroundColor: 'rgba(247,164,79,0.1)',
          tension: 0.4,
          fill: true,
        },
      ],
    }))
})
</script>

<style scoped>
.dashboard {
  padding: 2rem;
  background: #0f172a;
  min-height: 100vh;
}
.kpi-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 1rem;
  margin-bottom: 2rem;
}
.chart-box {
  background: #1e293b;
  border-radius: 12px;
  padding: 1.5rem;
}
</style>
