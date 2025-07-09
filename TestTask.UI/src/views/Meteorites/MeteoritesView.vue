
<script lang="ts" src="./MeteoritesView.ts"></script>

<template>
  <div class="meteorites-table-container">
    <div class="filters-container">
      <PrimeButton 
        icon="pi pi-filter" 
        label="Фильтры" 
        class="filters-btn" 
        @click="toggleShowFilters()" 
      />
      <MeteoritesFiltersBlock
        v-if="showFilters"
        :classes="classes"
        :years="years"
        :lazy-params="lazyParams"
        :invalid-fields="filtersErrors"
        @apply="applyFilters"
      />
    </div>

    <PrimeDataTable
      :value="meteorites"
      lazy
      paginator
      :virtual-scroller-options="{ itemSize: 44 }"
      :rows="$options.currentPageSize" 
      :rows-per-page-options="$options.rowsPerPageOptions"
      :total-records="totalRecords"
      sort-field="Year"
      :sort-order="-1"
      removable-sort
      scrollable
      scroll-height="50vh"
      table-style="min-width: 50rem"
      @page="onPageChange"
      @sort="onSort"
    >
      <PrimeColumn
        sortable
        sort-field="Year"
        field="year"
        header="Год"
        style="width: 25%"
      />
      <PrimeColumn
        sortable
        sort-field="Count"
        field="count"
        header="Кол-во метеоритов"
        style="width: 25%"
      />
      <PrimeColumn
        sortable
        sort-field="MassSum"
        field="massSum"
        header="Суммарная масса"
        style="width: 25%"
      />
    </PrimeDataTable>
  </div>
</template>

<style lang="css" src="./MeteoritesView.css" scoped></style>
