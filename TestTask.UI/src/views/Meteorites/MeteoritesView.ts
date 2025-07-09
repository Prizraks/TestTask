import { defineAsyncComponent, defineComponent } from 'vue';
import type { MeteoriteFiltersModel, MeteoritesLoadRequestModel, MeteoritesLoadResponseModel, MeteoriteViewModel } from './MeteoritesView.types';
import MeteoriteApiService from '../../services/api/Meteorite.api';
import type { DataTablePageEvent, DataTableSortEvent } from 'primevue';

const MeteoritesFiltersBlock = defineAsyncComponent(() => import('./Blocks/MeteoritesFiltersBlock/MeteoritesFiltersBlock.vue'));

const defaultPageSize: number = 20;

export default defineComponent({
  name: 'MeteoritesView',
  components: { MeteoritesFiltersBlock },
  data(): {
    isLoading: boolean,
    showFilters: boolean,
    meteorites: Array<MeteoriteViewModel>
    classes: Array<string>,
    years: Array<number>,
    lazyParams: MeteoritesLoadRequestModel,
    totalRecords: number;
    filtersErrors: Record<string, string>;
  } {
    return {
      isLoading: false,
      showFilters: false,
      meteorites: [],
      classes: [],
      years: [],
      lazyParams: {
        yearFrom: null,
        yearTo: null,
        name: null,
        recClass: null,
        sortField: null,
        sortOrder: null,
        pageNumber: 0,
        pageSize: defaultPageSize,
      } as MeteoritesLoadRequestModel,
      totalRecords: 0,
      filtersErrors: {},
    }
  },

  created() {
    this.$options.currentPageSize = defaultPageSize;
    this.$options.rowsPerPageOptions = [defaultPageSize, 50, 100, 500];

    this.loadMeteorites(this.lazyParams);
  },

  methods: {
    loadMeteorites(lazyParams: MeteoritesLoadRequestModel): void {
      this.isLoading = true;

      MeteoriteApiService.getMeteorites(lazyParams)
        .then((data: MeteoritesLoadResponseModel) => {
          if (!this.$record.isEmpty(data.invalidFields)) {
            this.setFilterErrors(data.invalidFields);
            return;
          }

          this.meteorites = data.data;
          this.totalRecords = data.totalRecords;
          this.setFilterErrors({});
        })
        .finally(() => this.isLoading = false);
    },

    setFilterErrors(filtersErrors: Record<string, string>): void {
      this.filtersErrors = filtersErrors;
    },
    async loadClasses(): Promise<void> {
      this.classes = await MeteoriteApiService.getAllClasses();
    },

    async setYearsArrays(): Promise<void> {
      this.years = (await MeteoriteApiService.getYears())
        .sort((a: number, b: number) => b - a)
    },

    toggleShowFilters(): void {
      if (this.classes.length == 0) {
        this.loadClasses();
      }

      if (this.years.length == 0) {
        this.setYearsArrays();
      }

      this.showFilters = !this.showFilters;
    },

    applyFilters(filters: MeteoriteFiltersModel): void {
      this.lazyParams.yearFrom = filters.yearFrom;
      this.lazyParams.yearTo = filters.yearTo;
      this.lazyParams.name = filters.name;
      this.lazyParams.recClass = filters.recClass;
      this.loadMeteorites(this.lazyParams);
    },
    onPageChange (event: DataTablePageEvent) {
      this.lazyParams.pageNumber = event.first;
      this.lazyParams.pageSize = event.rows;
      this.loadMeteorites(this.lazyParams);
    },

    onSort (event: DataTableSortEvent) {
      this.lazyParams.sortField = event.sortField as string;
      this.lazyParams.sortOrder = event.sortOrder;
      this.loadMeteorites(this.lazyParams);
    },
  }
});