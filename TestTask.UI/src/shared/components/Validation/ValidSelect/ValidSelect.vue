<script lang="ts" src="./ValidSelect.ts"></script>

<template>
  <div class="flex flex-column gap-2">
    <PrimeIftaLabel>
      <label
        :for="id"
        class="z-1"
      >{{ labelName }}</label>
      <PrimeSelect
        :id="id"
        v-model="model"
        editable 
        :options="options" 
        :virtual-scroller-options="{ itemSize: 38 }"
        @change="clearError()"
      />
    </PrimeIftaLabel>

    <PrimeMessage 
      v-if="isExistsError()"
      size="small" 
      severity="secondary" 
      variant="simple"
      class="text-red-500"
    >
      {{ getErrorText() }}
    </PrimeMessage>
  </div>
</template>