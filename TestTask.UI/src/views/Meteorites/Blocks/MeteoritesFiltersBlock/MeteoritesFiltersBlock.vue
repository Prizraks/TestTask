<script lang="ts" src="./MeteoritesFiltersBlock.ts"></script>
<style lang="css" src="./MeteoritesFiltersBlock.css" scoped></style>

<template>
    <div class="filter-accordion">
        <div class="filters-items">
            <ValidSelect
                v-model="filters.yearFrom"
                id="yearFrom"
                label-name="Год с"
                field-name="YearFrom"
                :options="years"
                :invalid-fields="invalidFields"
            />           
            <ValidSelect
                v-model="filters.yearTo"
                id="yearTo"
                label-name="Год по"
                field-name="YearTo"
                :options="years"
                :invalid-fields="invalidFields"
            />
            <ValidInputText
                v-model="filters.name"
                id="name"
                label-name="Наименование"
                field-name="Name"
                :invalid-fields="invalidFields"
            />
            <ValidSelect
                v-model="filters.recClass"
                id="recClass"
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
