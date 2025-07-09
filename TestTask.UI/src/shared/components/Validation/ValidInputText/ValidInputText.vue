<script lang="ts" src="./ValidInputText.ts"></script>

<template>
    <div class="flex flex-column gap-2">
        <PrimeIftaLabel>
            <label :for="id">{{ labelName }}</label>
            <PrimeInputText v-model="model" :id="id" class="w-full mb-3" @key-up="clearError()" />
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