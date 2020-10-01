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
                <div class="text-wrapper">
                    Book4Book dziala na zasadzie popularnego w ostatnich latach OLX.
                    To portal przede wszystkim dla fanow ksiazek, miejsce w ktorym bezplatnie moga wystawic swoje ulubione powiesci i wymieniac sie razem z innymi ksiazkoholikami.
                    Clou projektu jest bardzo proste - uzytkownik rejestruje sie na strone podajac podstawowe dane takie jak login i haslo. Klikajac w zakladke "dodaj ogloszenie" 
                    moze dodac krotka informacje na temat ksiazki tj: nazwe, autora oraz gatunek literacki. Uzytkownicy wymieniaja sie ksiazkami lokalnie. Portal zastrzega sobie wystawianie ogloszen platnych.
                </div>
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

    .text-wrapper {
        display: inline-block;
        margin-bottom: 100px;
        max-width: 1000px;
        word-break: break-word;
    }
</style>
