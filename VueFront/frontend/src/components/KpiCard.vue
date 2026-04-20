<template>
  <div class="card">
    <span class="label">{{ label }}</span>
    <span class="value">{{ value }}</span>
  </div>
</template>

<script setup>
defineProps({
  label: String,
  value: String,
})
</script>

<style scoped>
.card {
  background: #1e293b;
  border-radius: 12px;
  padding: 1.5rem;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  color: #fff;
}
.label {
  font-size: 0.85rem;
  color: #94a3b8;
}
.value {
  font-size: 1.8rem;
  font-weight: 700;
}
</style>
