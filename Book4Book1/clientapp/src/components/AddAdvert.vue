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
                    <el-input placeholder="Tytul Ksiazki"
                              v-model="title"
                              clearable>
                    </el-input>
                    <el-input placeholder="Autor Ksiazki"
                              v-model="author"
                              clearable>
                    </el-input>
                </div>
                <el-button @click="addAdvert" type="warning">Dodaj Ogloszenie</el-button>
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
                title: ''
            }
        },
        methods: {
            addAdvert() {
                console.log("Dodaj");
            },
            closeAddAdvert() {
                this.$parent.$emit("visibleAddAdvert", false);
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
        color: rgb(44, 54, 64);
        display: block;
        height: 100%;
        text-align: center;
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
