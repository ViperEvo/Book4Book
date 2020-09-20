<template>
    <div>
        <div class="header">
            <section class="start">
                <nav>
                    <div class="logo">
                        Book4Book
                    </div>
                    <ul class="menu" v-bind:class="{ sticky: isMenuSticky }">
                            <li>
                                <a href="#app">Start</a>
                            </li>
                            <li>
                                <a href="#ogloszenia">Ogloszenia</a>
                            </li>
                            <li>
                                <a href="#informacje">Jak to dziala?</a>
                            </li>
                            <li class="menu-right">
                                <a @click="showLogin">Logowanie/Rejestracja</a>
                            </li>
                    </ul>
                </nav>
            </section>
        </div>
        <LoginPanel v-if="loginPanelVisible"/>
    </div>
</template>

<script>
    import LoginPanel from './LoginPanel.vue'
    export default {
        name: 'AppHeader',
        components: {
           LoginPanel,
        },
        data() {
            return {
                isMenuSticky: false,
                loginPanelVisible: false,
            };
        },
        created() {
            window.addEventListener('scroll', this.handleStickyMenu);
        },
        beforeDestroy() {
            window.removeEventListener('scroll', this.handleStickyMenu);
        },
        mounted() {
            this.$on("visibleLoginPanel", response => {
                this.loginPanelVisible = response;
            });
        },
        methods: {
            handleStickyMenu() {
                if (window.scrollY > 150) {
                    this.isMenuSticky = true;
                } else {
                    this.isMenuSticky = false;
                }
            },
            showLogin() {
                this.loginPanelVisible = true;
            },
        },
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .header {
        background: url(https://i.imgur.com/H7DNjbf.jpg);
        height: 600px;
        width: 100%;
        box-sizing: border-box;
        background-position-y: -300px;
    }

    nav {
        background: rgba(44, 54, 64, 0.45);
        height: 600px;
        overflow: hidden;
        position: relative;
        text-decoration: none;
    }

    nav ul {
        position: absolute;
        display: flex;
        list-style-type: none;
        background: rgba(44, 54, 64, 0.75);
        width: 100%;
        top: 150px;
        margin-top: 0px;
        z-index: 12;
        min-height: 66px;
    }

    nav ul li a {
        margin: 20px;
        text-decoration: none;
        font-weight: 500;
        font-size: 20px;
        background: transparent;
        border-style: none;
        color: rgb(234, 238, 245);
        font-family: 'Montserrat', sans-serif;
        display: inline-block;
        clear: left;
    }

    nav ul li a:hover {
        color: rgb(235, 181, 99);
    }

    .logo {
        position: relative;
        color: rgb(234, 238, 245);
        font-size: 35px;
        top: 70px;
        margin-left: 60px;
        font-weight: 500;
    }

    .menu-right {
        cursor: pointer;
        position: absolute;
        right: 0px;
        margin-right: 50px;
    }

    .menu-right a {
        color: rgb(260, 162, 60);
    }

    .sticky {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        margin-top: 0;
        background: rgba(44, 54, 64, 0.97);
    }
</style>
