<template>
    <div class="overlay">
        <div class="panel-container">
            <div class="panel-wrapper">
                <div class="button-container">
                    <div @click="closePanel" class="button-close">
                        <i class="fas fa-times"></i>
                    </div>
                </div>
                <div class="panel">
                    <el-input placeholder="Login"
                              v-model="userLogin"
                              clearable>
                    </el-input>
                    <el-input placeholder="Haslo"
                              v-model="userPassword"
                              clearable>
                    </el-input>
                    <el-input placeholder="E-mail"
                              v-model="userEmail"
                              clearable
                              v-if="showRegisterControlls">
                    </el-input>
                    <el-input placeholder="Nazwa uzytkownika"
                              v-model="userNickname"
                              clearable
                              v-if="showRegisterControlls">
                    </el-input>
                    <div class="buttons">
                        <el-button @click="login" v-if="!showRegisterControlls" type="success">Zaloguj</el-button>
                        <el-button @click="register" v-if="!showRegisterControlls" type="warning">Zarejestruj</el-button>
                        <el-button @click="backToLogin" v-if="showRegisterControlls" type="primary">Powrot</el-button>
                        <el-button @click="createAcount" v-if="showRegisterControlls" type="warning">Utworz konto</el-button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'LoginPanel',
        data() {
            return {
                userEmail: '',
                userLogin: '',
                userNickname: '',
                userPassword: '',
                showRegisterControlls: false,
            }
        },
        methods: {
            backToLogin() {
                this.showRegisterControlls = false;
            },
            closePanel() {
                this.$parent.$emit("visibleLoginPanel", false);
            },
            createAcount() {
                console.log("Utworz");
            },
            login() {
                console.log("Login");
            },
            register() {
                this.showRegisterControlls = true;
            },
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .buttons .el-button {
        margin: 0 10px;
        min-width: 140px;
    }

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
        max-width: 300px;
    }

    .panel {
        padding: 50px;
    }

    .panel-container {
        display: block;
        padding: 100px;
        margin: auto;
        width: 600px;
    }

    .panel-wrapper {
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
        position: fixed;
        top: 0px;
        width: 100%;
        z-index: 12;
    }
</style>
