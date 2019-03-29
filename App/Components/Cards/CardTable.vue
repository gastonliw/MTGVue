<template>    
    <div v-if="CardList!=null && !isFetching">
        <table class="table table-striped">
            <thead class="thead-active">
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Type</th>
                    <th scope="col">Rarity</th>
                    <th scope="col">Edition</th>
                    <th scope="col">Mana Cost</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(card, index) in currentPageCards" :key="index">
                    <td>
                        {{card.name}}
                    </td>
                    <td>
                        {{card.type}}
                    </td>
                    <td>
                        {{card.rarity}}
                    </td>
                    <td>
                        {{card.setName}}
                    </td>
                    <td class="manaColumn">
                        <template v-if="card.manaCost">
                            <i v-for="(cost, index) in card.manaCost" :key="index" v-bind:class="'ms-' + cost" class="ms"></i>
                        </template>
                    </td>
                </tr>
            </tbody>
        </table>
        <ul class="pagination justify-content-center">            
            <li v-bind:class="[page == 1 ? 'page-item disabled': '', page-item]">
                <a class="page-link" href="#" tabindex="-1" @click.prevent="page--">Previous</a>
            </li>
            <li v-for="(pageNumber, index) in pages" :key="index" v-bind:class="[page == index+1 ? 'page-item disabled': '', page-item]" >
                <a class="page-link" href="#"  @click.prevent="page=pageNumber">{{pageNumber}}</a>
            </li>

            <li v-bind:class="[page == pages.length ? 'page-item disabled': '', page-item]">
                <a class="page-link" href="#" @click.prevent="page++">Next</a>
            </li>            
        </ul>
    </div>
    <div v-else-if="isFetching" class="ui clean segment empty-loader row border border-secondary rounded-top border-top-0">
        <div class="h-50 col-md-4 offset-md-5 row align-items-center">
            <i id="imageLoading" class="fa fa-circle-o-notch fa-spin"></i>
        </div>
    </div>
    <div v-else-if="CardList==null">
        <p>
            no cards
        </p>
    </div>

</template>
<style>
    .manaColumn{
        text-align: center;
    }
</style>

<script>
export default {
    data:function(){
        return{
            page: 1,
            perPage: 10,
            pages: []
        }
    },
    watch: {
        CardList() {
            this.setPages();
        }
    },
    methods: {
        setPages:function() {
            this.pages = [];
            let numberOfPages = Math.ceil(this.CardList.length / this.perPage);
            for (let index = 1; index <= numberOfPages; index++) {
                this.pages.push(index);
            }
        }
    },
    computed: {
        CardList(){
            return this.$store.getters.getCardsVuex;
        },
        splitManaCost: function () {
            //fix regex
            if (this.card.manaCost != null)
                return this.card.manaCost.split(/[{}]/).filter(String);
            else return new Array();
        },
        currentPageCards:function(){
            let page = this.page;
            let perPage = this.perPage;
            let from = (page * perPage) - perPage;
            let to = (page * perPage);
            return this.$store.getters.getCardsVuex.slice(from, to)
        },
         isFetching() {
            return this.$store.getters.getIsFetching;
        },
    }
}
</script>

