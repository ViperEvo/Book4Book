<template>
    <div class="overlay">
        <div class="inputs-container">
            <div class="inputs-wrapper">
                <div class="inputs">
                    Eloo
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'AddAdvert',
        methods: {
            addAdvert() {
                console.log("Dodaj");
            },
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .inputs {
        padding: 50px;
    }

    .inputs-container {
        display: block;
        height: 600px;
        padding: 100px;
        margin: auto;
        width: 600px;
    }

    .inputs-wrapper {
        background-color: rgb(240, 240, 240);
        display: block;
        height: 100%;
        width: 100%;
    }

    .overlay {
        background-color: rgba(44, 54, 64, 0.85);
        display: block;
        height: 100%;
        position: absolute;
        top: 0px;
        width: 100%;
        z-index: 12;
    }
</style>
