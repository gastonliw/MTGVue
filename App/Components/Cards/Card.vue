<template>  
  <div v-if="card!=null">
    <div class="card-body">
      <h4 class="card-title">{{card.name}}</h4>
      <p class="card-text">{{card.type}}</p>
    </div>
    <div class="row mb-2">
      <div class="col-lg-6">
        <img v-if="card.imageUrl!=null" class="card-img-bottom" v-bind:src="card.imageUrl" v-bind:alt="card.name">      
        <p v-else class="border border-dark">
          No image to display
        </p>
      </div>
      <div class="col-lg-6">
        <dl>
          <dt>Mana</dt>          
          <dl>
            <i v-for="(cost, index) in splitManaCost" :key="index" v-bind:class="'ms-' + cost" class="ms"></i>
          </dl>          
          <dt>Set:</dt>
          <dl>{{card.setName}}</dl>
          <dt>Rarity:</dt>
          <dl>{{card.rarity}}</dl>
          <template v-if="card.power">
            <dt>Power/Toughness</dt>
            <dl>{{card.power}}/{{card.toughness}}</dl>
          </template>          
        </dl>
      </div>      
    </div>  
  </div>
  <p v-else>
    No card selected
  </p>
</template>

<script>
    export default {        
        computed:{
          splitManaCost: function(){
            //fix regex
            if(this.card.manaCost!=null)
              return this.card.manaCost.split(/[{}]/).filter(String);
            else
              return new Array();
          },
          card(){
            return this.$store.getters.getCardVuex;
          }
        }
    };
</script>