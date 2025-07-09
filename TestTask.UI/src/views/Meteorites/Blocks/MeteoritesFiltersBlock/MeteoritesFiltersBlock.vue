<script lang="ts" src="./MeteoritesFiltersBlock.ts"></script>

<template>
  <div class="filter-accordion">
    <div class="filters-items">
      <ValidSelect
        id="yearFrom"
        v-model="filters.yearFrom"
        label-name="Год с"
        field-name="YearFrom"
        :options="years"
        :invalid-fields="invalidFields"
      />           
      <ValidSelect
        id="yearTo"
        v-model="filters.yearTo"
        label-name="Год по"
        field-name="YearTo"
        :options="years"
        :invalid-fields="invalidFields"
      />
      <ValidInputText
        id="name"
        v-model="filters.name"
        label-name="Наименование"
        field-name="Name"
        :invalid-fields="invalidFields"
      />
      <ValidSelect
        id="recClass"
        v-model="filters.recClass"
        label-name="Класс"
        field-name="RecClass"
        :options="classes"
        :invalid-fields="invalidFields"
      />
    </div>

    <div class="filters-btn">
      <PrimeButton 
        label="Применить"
        class="filters-btn" 
        icon="pi pi-check" 
        severity="success"
        variant="outlined"
        @click="applyFilter()" 
      />
      <PrimeButton 
        label="Очистить" 
        class="filters-btn" 
        icon="pi pi-filter-slash"
        severity="secondary" 
        variant="outlined"
        @click="clearFilter()" 
      />
    </div>
  </div>
</template>

<style lang="css" src="./MeteoritesFiltersBlock.css" scoped></style>
