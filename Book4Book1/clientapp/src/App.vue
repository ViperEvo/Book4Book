<template>
    <div id="app">
        <header>
            <AppHeader />
        </header>
        <section class="ogloszenia">
            <div class="section-wrapper">
                <div id="ogloszenia"></div>
                <h2>Ogloszenia</h2>
                <hr width="85%">
            </div>
        </section>
        <AdContainer />
        <section class="informacje">
            <div class="section-wrapper">
                <div id="informacje"></div>
                <h2>Informacje</h2>
                <hr width="85%">
            </div>
        </section>
    </div>
</template>

<script>
    import AppHeader from './components/AppHeader.vue'
    import AdContainer from './components/AdContainer.vue'

    export default {
        name: 'app',
        components: {
            AppHeader,
            AdContainer,
        }
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css?family=Montserrat');
    body {
        margin: 0;
    }

    #app {
        background-color: rgb(240, 240, 240);
        font-family: 'Montserrat', sans-serif;
        margin: 0;
        position: relative;
    }

    .section-wrapper {
        text-align: center;
        font-size: 25px;
        color: rgb(44, 54, 64);
    }
</style>
