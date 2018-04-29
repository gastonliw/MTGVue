import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    //variables
    state: {
        cardVuex:null
    },

    //getting states
    getters: {
        getCardVuex: state => {
            return state.cardVuex;
        }
    },

    //seters
    mutations: {
        selectCardVuex: (state, selectedCard) => {
            state.cardVuex = selectedCard;
        }
    },

    actions: {

    },

    

});