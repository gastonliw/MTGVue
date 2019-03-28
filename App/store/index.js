import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    //variables
    state: {
        cardVuex:null,
        cardsVuex:null,
        isFetching:false
    },

    //getting states
    getters: {
        getCardsVuex: state => {
            return state.cardsVuex;
        },
        getCardVuex: state => {
            return state.cardVuex;
        },
        getIsFetching: state => {
            return state.isFetching;
        }
    },

    //seters
    mutations: {
        selectCardVuex: (state, selectedCard) => {
            state.cardVuex = selectedCard;
        },
        searchCardVuex: (state, searchResult) => {
            state.cardsVuex = searchResult
        },
        setFetching: (state, isFetching) => {
            state.isFetching = isFetching;
        }
    },

    actions: {

    },

    

});