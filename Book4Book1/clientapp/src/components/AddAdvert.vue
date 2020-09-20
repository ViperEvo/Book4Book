<template>
    <div class="overlay">
        <div class="inputs-container">
            <div class="inputs-wrapper">
                <div class="button-container">
                    <div @click="closeAddAdvert" class="button-close">
                        <i class="fas fa-times"></i>
                    </div>
                </div>
                <div class="inputs">
                    <el-select v-model="city" clearable placeholder="Wybierz Miasto w ktorym mozliwa jest wymiana">
                        <el-option v-for="option in cities"
                                   :key="option"
                                   :label="option"
                                   :value="option">
                        </el-option>
                    </el-select>
                    <el-select v-model="category" clearable placeholder="Wybierz Kategorie twojej ksiazki">
                        <el-option v-for="option in categories"
                                   :key="option"
                                   :label="option"
                                   :value="option">
                        </el-option>
                    </el-select>
                    <el-input placeholder="Tytul twojej ksiazki"
                              v-model="title"
                              clearable>
                    </el-input>
                    <el-input placeholder="Autor twojej ksiazki"
                              v-model="author"
                              clearable>
                    </el-input>
                    <el-input placeholder="Opis"
                              v-model="description"
                              clearable>
                    </el-input>
                    <div class="information">
                        Pamietaj aby w opisie umiescic informacje o tym jakie ksiazki Cie interesuja i jaka forma kontaktu preferujesz.
                    </div>
                    <el-button @click="addAdvert" type="warning">Dodaj Ogloszenie</el-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'AddAdvert',
        data() {
            return {
                author: '',
                category: '',
                city: '',
                description: '',
                title: '',
                cities: ['Krakow', 'Warszawa'],
                categories: ['Beletrystyka', 'Fantastyka', 'Horror', 'Inne', 'Komiks/Manga', 'Kryminal', 'Romans', 'Romans Historyczny', 'Literatura Dziecieca', 'Literatura Faktu', 'Literatura Mlodziezowa', 'Literatura Naukowa', 'Literatura Obcojezyczna'],
            }
        },
        methods: {
            addAdvert() {
                const advert = new Object();
                advert.author = this.author;
                advert.category = this.category;
                advert.city = this.city;
                advert.description = this.description;
                advert.title = this.title;
                advert.date = this.getDate();
            },
            closeAddAdvert() {
                this.$parent.$emit("visibleAddAdvert", false);
            },
            getDate() {
                const date = new Date();
                const currentDate = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();
                const currentTime = date.getHours() + ":" + date.getMinutes();
                return currentDate + " " + currentTime;
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

    .el-input {
        margin-bottom: 20px;
    }

    .el-select {
        display: block;
        margin-bottom: 20px;
    }

    .inputs {
        padding: 50px;
    }

    .inputs-container {
        display: block;
        padding: 100px;
        margin: auto;
        width: 600px;
    }

    .inputs-wrapper {
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
