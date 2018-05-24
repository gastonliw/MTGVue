<template>  
<div v-if="!isFetching" class="row">
  <div v-if="card!=null" class="border border-secondary rounded-top col-md-12 col-xs-12">
    <div class="row">
      <div class="card-body col-md-12 col-xs-12">
        <h4 class="card-title">{{card.name}}</h4>
        <p class="card-text">{{card.type}}</p>
      </div>
    </div>
    <div class="row mb-1">      
      <div class="col-md-4 md-1">
        <img :src="cardImage" style="max-width:190px" class="card-img-bottom" v-bind:title="card.name" v-bind:alt="card.name">        
      </div>      
      <div class="col-md-8 col-xs-12 mb-1">
        <div class="row">
          <div class="col-md-6 col-xs-12">
              <dl>
                <template v-if="card.manaCost">
                  <dt>Mana:</dt>          
                  <dl>
                    <i v-for="(cost, index) in splitManaCost" :key="index" v-bind:class="'ms-' + cost" class="ms"></i>
                  </dl>
                </template>
                <dt>Set:</dt>
                <dl>{{card.setName}}</dl>
                <dt>Rarity:</dt>
                <dl>{{card.rarity}}</dl>                    
              </dl>
          </div>
          <div class="col-md-6 col-xs-12">
            <dl>
              <template v-if="card.power">
                <dt>Power/Toughness</dt>
                <dl>{{card.power}}/{{card.toughness}}</dl>
              </template>
              <dt>Artist:</dt>
              <dl>{{card.artist}}</dl>
            </dl>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12 col-xs-12">              
              <dl>
                <template v-if="card.text">
                    <dt>Card Text:</dt>
                    <dl class="font-bold-light">{{card.text}}</dl>
                  </template>
                  <template v-if="card.flavor">
                    <dt>Flavor:</dt>
                    <dl class="font-bold-light">{{ card.flavor | truncate(100) }}</dl>
                  </template>
              </dl>
          </div>
        </div>    
      </div>      
    </div>        
  </div>
  <div v-else class="border border-secondary rounded-top col-md-12 col-xs-12">
    <div class="col-md-5 offset-md-1 mb-2 mt-2">
      <p>
        No card selected
      </p>
    </div>
  </div>
</div>
<div v-else class="ui clean segment empty-loader row border border-secondary rounded-top border-top-0">
    <div class="h-50 col-md-4 offset-md-5 row align-items-center">
      <i class="fa fa-circle-o-notch fa-spin" style="font-size:80px"></i>
    </div>
</div>
</template>

<script>
export default {
  computed: {
    splitManaCost: function() {
      //fix regex
      if (this.card.manaCost != null)
        return this.card.manaCost.split(/[{}]/).filter(String);
      else return new Array();
    },
    card() {
      return this.$store.getters.getCardVuex;
    },
    isFetching() {
      return this.$store.getters.getIsFetching;
    },
    cardImage() {
      return this.card.imageUrl != null
        ? this.card.imageUrl
        : "images/card.jpg";
    }
  },
  filters: {
    truncate(text, top) {
      return text ? text.slice(0, top) + (top < text.length ? "..." : "") : "";
    }
  }
};
</script>