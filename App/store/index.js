import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    //variables
    state: {
        cardVuex:null,
        isFetching:false
    },

    //getting states
    getters: {
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
        setFetching: (state, isFetching) => {
            state.isFetching = isFetching;
        }
    },

    actions: {

    },

    

});