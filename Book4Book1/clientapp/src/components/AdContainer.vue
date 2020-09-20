<template>
    <div>
        <div class="table-wrapper">
            <div class="table-controls">
                <el-button @click="refreshAdverts" type="warning">Odswiez Ogloszenia</el-button>
                <el-button @click="addAdvert" type="warning">Dodaj Ogloszenie</el-button>
            </div>
            <el-table ref="filterTable"
                      :data="tableData"
                      :default-sort="{prop: 'date', order: 'descending'}"
                      stripe
                      height="100%"
                      style="width: 100%">
                <el-table-column prop="date"
                                 label="Data dodania"
                                 sortable>
                </el-table-column>
                <el-table-column prop="city"
                                 label="Miasto"
                                 sortable
                                 width="180"
                                 column-key="city"
                                 :filters="[{text: 'Krakow', value: 'Krakow'}, {text: 'Warszawa', value: 'Warszawa'}]"
                                 :filter-method="filterHandler">
                </el-table-column>
                <el-table-column prop="category"
                                 label="Kategoria"
                                 sortable
                                 width="180"
                                 column-key="category"
                                 :filters="[{text: 'Beletrystyka', value: 'Beletrystyka'}, {text: 'Fantastyka', value: 'Fantastyka'}, {text: 'Horror', value: 'Horror'},
                                 {text: 'Inne', value: 'Inne'}, {text: 'Komiks/Manga', value: 'Komiks/Manga'}, {text: 'Kryminal', value: 'Kryminal'},
                                 {text: 'Romans', value: 'Romans'}, {text: 'Romans Historyczny', value: 'Romans Historyczny'}, {text: 'Literatura Dziecieca', value: 'Literatura Dziecieca'},
                                 {text: 'Literatura Faktu', value: 'Literatura Faktu'}, {text: 'Literatura Mlodziezowa', value: 'Literatura Mlodziezowa'},
                                 {text: 'Literatura Naukowa', value: 'Literatura Naukowa'}, {text: 'Literatura Obcojezyczna', value: 'Literatura Obcojezyczna'}]"
                                 :filter-method="filterHandler">
                </el-table-column>
                <el-table-column prop="title"
                                 label="Tytul"
                                 sortable>
                </el-table-column>
                <el-table-column prop="author"
                                 sortable
                                 width="300"
                                 label="Autor">
                </el-table-column>
                <el-table-column prop="deleter"
                                 label=""
                                 width="200">
                    <template slot-scope="scope">
                        <el-button type="warning" @click="showAdvert(scope)">Zobacz ogloszenie</el-button>
                    </template>
                </el-table-column>
            </el-table>
        </div>
        <AddAdvert v-if="addAdvertVisible" />
        <ShowAdvert v-if="showAdvertVisible" :advertData="advertData"/>
    </div>
</template>

<script>
    import AddAdvert from './AddAdvert.vue'
    import ShowAdvert from './ShowAdvert.vue'
    import jQuery from 'jquery';
    let $ = jQuery;

    export default {
        name: 'AdContainer',
        components: {
            AddAdvert,
            ShowAdvert,
        },
        data() {
            return {
                advertData: null,
                addAdvertVisible: false,
                showAdvertVisible: false,
                tableData: [{
                    date: "2020-09-14 23:38",
                    city: 'Krakow',
                    category: 'Fantastyka',
                    title: 'Test1',
                    author: 'Ziomek1',
                    description: "TAGASDBALSOLGDSAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
                }, {
                    date: "2020-09-17 23:38",
                    city: 'Warszawa',
                    category: 'Fantastyka',
                    title: 'Test2',
                    author: 'Ziomek2',
                    description: "TAGASDBALSOLGDSA22222"
                }, {
                    date: "2020-09-16 23:38",
                    city: 'Krakow',
                    category: 'Kryminal',
                    title: 'Test3',
                    author: 'Ziomek3'
                }, {
                    date: "2020-09-16 23:28",
                    city: 'Krakow',
                    category: 'Romans',
                    title: 'Test4',
                    author: 'Ziomek4'
                }, {
                    date: "2020-09-16 12:38",
                    city: 'Krakow',
                    category: 'Kryminal',
                    title: 'Test5',
                    author: 'Ziomek5'
                }, {
                    date: "2020-03-18 23:38",
                    city: 'Krakow',
                    category: 'Romans',
                    title: 'Test6',
                    author: 'Ziomek6'
                }]
            }
        },
        mounted() {
            this.$on("visibleAddAdvert", response => {
                this.addAdvertVisible = response;
            });
            this.$on("visibleAdvert", response => {
                this.showAdvertVisible = response;
            });
        },
        methods: {
            addAdvert() {
                this.addAdvertVisible = true;
            },
            refreshAdverts() {
                this.loadAdverts();
            },
            showAdvert(scope) {
                this.showAdvertVisible = true;
                this.advertData = scope.row;
            },
            filterHandler(value, row, column) {
                const property = column['property'];
                return row[property] === value;
            },
            loadAdverts() {
                $.ajax({
                    type: "POST",
                    url: "/GetAllAnnouncements",
                    success: function (response) {
                        console.log(response)
                    },
                    error: function (response) {
                        console.log("Cos poszlo nie tak" + response)
                    }
                })
            },
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    .table-controls {
        margin: 20px 0;
        text-align: center;
    }

    .table-wrapper {
        background-color: rgb(240, 240, 240);
        margin: 0 50px;
        padding-bottom: 50px;
    }

    .el-table {
        background-color: rgb(240, 240, 240);
        max-height: 600px;
    }

    .el-table th, .el-table tr {
        background-color: rgb(44, 54, 64);
        color: rgb(234, 238, 245);
    }

    .el-table--striped .el-table__body tr.el-table__row--striped td {
        background-color: rgb(235, 235, 235);
        color: rgb(44, 54, 64);
    }

    .el-table tr:nth-child(odd) {
        background-color: rgb(240, 240, 240);
        color: rgb(44, 54, 64);
    }

</style>
