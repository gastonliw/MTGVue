<template>
    <div v-if="!isFetching">
        <div v-for="(card, index) in cards" :key="index"  class="row">
            <Card v-bind:card="card"></Card>
        </div>
    </div>
    <div v-else class="ui clean segment empty-loader row border border-secondary rounded-top border-top-0">
    <div class="h-50 col-md-4 offset-md-5 row align-items-center">
      <i id="imageLoading" class="fa fa-circle-o-notch fa-spin"></i>
    </div>
</div>
</template>

<script>
import Card from './Card.vue';

export default {
    components:{
        Card
    },
    computed: {
        cards() {
            return this.$store.getters.getCardsVuex;
        },
        isFetching() {
            return this.$store.getters.getIsFetching;
        },
    }
}
</script>
