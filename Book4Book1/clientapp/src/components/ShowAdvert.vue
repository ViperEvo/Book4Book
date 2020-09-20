<template>
    <div class="overlay">
        <div class="advert-container">
            <div class="advert-wrapper">
                <div class="button-container">
                    <div @click="closeAdvert" class="button-close">
                        <i class="fas fa-times"></i>
                    </div>
                </div>
                <div class="advert">
                    Miasto: {{ advertData.city }}
                    <hr>
                    Kategoria: {{ advertData.category }}
                    <hr>
                    Tytul: {{ advertData.title }}
                    <hr>
                    Autor: {{ advertData.author }}
                    <hr>
                    Opis: {{ advertData.description }}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'ShowAdvert',
        props: {
            advertData: {
                type: Object,
                default: null,
            },
        },
        methods: {
            closeAdvert() {
                this.$parent.$emit("visibleAdvert", false);
            },
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .button-container {
        position: relative;
    }

    .button-close {
        cursor: pointer;
        font-size: 20px;
        padding: 6px 10px;
        position: absolute;
        right: 0px;
    }

    .advert {
        overflow-wrap: break-word;
        padding: 50px;
        text-align: left;
    }

    .advert-container {
        display: block;
        padding: 100px;
        margin: auto;
        width: 600px;
    }

    .advert-wrapper {
        background-color: rgb(240, 240, 240);
        color: rgb(44, 54, 64);
        display: block;
        height: 100%;
        text-align: center;
        width: 100%;
    }

    .information {
        margin-bottom: 20px;
    }

    .overlay {
        background-color: rgba(44, 54, 64, 0.85);
        display: block;
        height: 100%;
        position: fixed;
        top: 0px;
        width: 100%;
        z-index: 12;
    }
</style>
