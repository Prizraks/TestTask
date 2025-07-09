
<script lang="ts" src="./MeteoritesView.ts"></script>
<style lang="css" src="./MeteoritesView.css" scoped></style>

<template>
    <div class="meteorites-table-container">
        <div class="filters-container">
            <PrimeButton 
                icon="pi pi-filter" 
                label="Фильтры" 
                @click="toggleShowFilters()" 
                class="filters-btn" 
            />
            <MeteoritesFiltersBlock
                v-if="showFilters"
                :classes="classes"
                :years=years
                :lazyParams="lazyParams"
                :invalid-fields="filtersErrors"
                @apply="(filters: any) => applyFilters(filters)"
            />
        </div>

        <PrimeDataTable
            :value="meteorites"
            lazy
            paginator
            :virtualScrollerOptions="{ itemSize: 44 }"
            :rows="$options.currentPageSize" 
            :rowsPerPageOptions="$options.rowsPerPageOptions"
            :totalRecords="totalRecords"
            sortField="Year"
            :sortOrder="-1"
            removableSort
            scrollable
            scrollHeight="50vh"
            tableStyle="min-width: 50rem"
            @page="onPageChange"
            @sort="onSort"
        >
            <PrimeColumn sortable sortField="Year" field="year" header="Год" style="width: 25%"></PrimeColumn>
            <PrimeColumn sortable sortField="Count" field="count" header="Кол-во метеоритов" style="width: 25%"></PrimeColumn>
            <PrimeColumn sortable sortField="MassSum" field="massSum" header="Суммарная масса" style="width: 25%"></PrimeColumn>
        </PrimeDataTable>
    </div>
</template>
