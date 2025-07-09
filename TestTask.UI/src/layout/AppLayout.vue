<script lang="ts" src="./AppLayout.ts"></script>
<style lang="css" src="./AppLayout.css" />

<template>
  <div class="layout-wrapper">
    <header class="layout-header">
        <PrimeMenubar 
            :model="menuItems" 
            class="desktop-menu" 
        >
            <template #start>
                <img src="../assets//vue.svg" alt="Icon" class="icon" />
            </template>
        </PrimeMenubar>
    </header>

    <main class="layout-content">
        <RouterView />
    </main>
    <footer class="layout-footer">
      <div class="footer-content">
        <div class="footer-section">
          <p>© {{ $options.currentYear }} MyApp. Все права защищены.</p>
        </div>
      </div>
    </footer>
  </div>
</template>